using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using static MOGI.TaskDefinition;

namespace MOGI
{
	public class TaskProgressEventArgs : EventArgs
	{
		public TimeSpan TotalEstimatedTime { get; }
		public TimeSpan ElapsedTime { get; }
		public TimeSpan RemainingTime { get; }
		public int CurrentRepetition { get; }
		public int TotalRepetitions { get; }
		public double SingleRepetitionActualSeconds { get; }

		public TaskProgressEventArgs(TimeSpan total, TimeSpan elapsed, TimeSpan remaining, int currentRep, int totalReps, double singleRepSeconds)
		{
			TotalEstimatedTime = total;
			ElapsedTime = elapsed;
			RemainingTime = remaining;
			CurrentRepetition = currentRep;
			TotalRepetitions = totalReps;
			SingleRepetitionActualSeconds = singleRepSeconds;
		}
	}

	public class Task_Manager
	{
		private static readonly Lazy<Task_Manager> _instance = new Lazy<Task_Manager>(() => new Task_Manager());
		public static Task_Manager Instance => _instance.Value;

		private CancellationTokenSource _mainCts;
		private Task _mainRunningTask;
		private BaseAutomationTask _mainTaskInstance;
		private BaseAutomationTask _sellTaskInstance;

		private CancellationTokenSource _sellCts;
		private Task _sellRunningTask;

		private Stopwatch _stopwatch;
		private System.Threading.Timer _progressTimer;
		private TimeSpan _initialTotalEstimatedTime;

		private MouseTrackerService _mouseTrackerService;

		public event EventHandler<Point> MousePositionChanged;
		public event EventHandler<string> CurrentTaskNameChanged;
		public event EventHandler<TaskProgressEventArgs> TaskProgressUpdated;

		private Task_Manager()
		{
			_mouseTrackerService = new MouseTrackerService();
			_mouseTrackerService.MousePositionChanged += (s, pos) => MousePositionChanged?.Invoke(this, pos);

			_stopwatch = new Stopwatch();
			_progressTimer = new System.Threading.Timer(ProgressTimerCallback, null, Timeout.Infinite, 1000);
		}

		public void InitializeAndStartServices()
		{
			_mouseTrackerService.StartTracking();
		}

		public void StartMainTask(BaseAutomationTask task, TaskConfig config)
		{
			StopMainTask();

			_mainCts = new CancellationTokenSource();
			task._token = _mainCts.Token;
			task._taskConfig = config;
			_mainTaskInstance = task;

			task.OnTaskNameChanged = (name) => CurrentTaskNameChanged?.Invoke(this, name);
			task.OnRepetitionChanged = (rep) => UpdateProgress();

			double totalSeconds = (task.EstimatedDurationSeconds * config.Repetitions) + (task.DelayTimeAfterRepetition.TotalSeconds * (config.Repetitions - 1));
			_initialTotalEstimatedTime = TimeSpan.FromSeconds(Math.Max(0, totalSeconds));

			_stopwatch.Restart();
			_progressTimer.Change(0, 1000);
			UpdateProgress();

			_mainRunningTask = Task.Run(() => task.ExecuteAsync(), _mainCts.Token)
				.ContinueWith(t => StopMainTask(isCompleted: true));
		}

		public Task StartSellTask(BaseAutomationTask task, TaskConfig config)
		{
			if (_sellRunningTask != null && !_sellRunningTask.IsCompleted)
			{
				return Task.CompletedTask;
			}

			_sellCts = new CancellationTokenSource();
			task._token = _sellCts.Token;
			task._taskConfig = config;
			_sellTaskInstance = task;

			_sellRunningTask = Task.Run(() => task.ExecuteAsync(), _sellCts.Token)
				.ContinueWith(t => _sellTaskInstance = null); 

			return _sellRunningTask;
		}

		public bool IsMainTaskRunning()
		{
			return _mainTaskInstance != null && !(_mainTaskInstance is EmptyTask);
		}

		public bool IsSellTaskRunning()
		{
			return _sellTaskInstance != null && (_sellRunningTask != null && !_sellRunningTask.IsCompleted);
		}

		public void StopSellTask()
		{
			_sellCts?.Cancel();
		}

		public void StopMainTask(bool isCompleted = false)
		{
			if (!isCompleted)
			{
				_mainCts?.Cancel();
			}

			_stopwatch.Stop();
			_progressTimer.Change(Timeout.Infinite, Timeout.Infinite);
			CurrentTaskNameChanged?.Invoke(this, TaskNames[TaskType.None]);
			UpdateProgress(reset: true);
			_mainTaskInstance = null;
		}

		public void StopAllTasks()
		{
			StopMainTask();
			StopSellTask();
		}

		public void ShutdownServices()
		{
			StopAllTasks();
			_mouseTrackerService.StopTracking();
		}

		private void ProgressTimerCallback(object state)
		{
			UpdateProgress();
		}

		private void UpdateProgress(bool reset = false)
		{
			if (reset || _mainTaskInstance == null || !_stopwatch.IsRunning)
			{
				TaskProgressUpdated?.Invoke(this, new TaskProgressEventArgs(TimeSpan.Zero, TimeSpan.Zero, TimeSpan.Zero, 0, 0, 0));
				return;
			}

			int totalRepetitions = _mainTaskInstance._taskConfig.Repetitions;
			int currentRepetition = _mainTaskInstance.TaskRepetitionCounter;
			TimeSpan elapsedTime = _stopwatch.Elapsed;

			double singleRepActualSeconds = _mainTaskInstance.EstimatedDurationSeconds;
			double remainingReps = totalRepetitions - currentRepetition;

			double remainingActionTime = remainingReps * singleRepActualSeconds;
			double remainingDelayTime = Math.Max(0, remainingReps - 1) * _mainTaskInstance.DelayTimeAfterRepetition.TotalSeconds;

			TimeSpan remainingTime = TimeSpan.FromSeconds(remainingActionTime + remainingDelayTime);

			TaskProgressUpdated?.Invoke(this, new TaskProgressEventArgs(_initialTotalEstimatedTime, elapsedTime, remainingTime, currentRepetition, totalRepetitions, singleRepActualSeconds));
		}
	}
}
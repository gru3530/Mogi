
using System.Diagnostics;
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
		public double SingleRepetitionActualSeconds { get; } // 새로 추가: 단일 반복의 실제 소요 시간 (초)

		public TaskProgressEventArgs(TimeSpan totalEstimatedTime, TimeSpan elapsedTime, TimeSpan remainingTime, int currentRepetition, int totalRepetitions, double singleRepetitionActualSeconds)
		{
			TotalEstimatedTime = totalEstimatedTime;
			ElapsedTime = elapsedTime;
			RemainingTime = remainingTime;
			CurrentRepetition = currentRepetition;
			TotalRepetitions = totalRepetitions;
			SingleRepetitionActualSeconds = singleRepetitionActualSeconds; // 단일 반복 실제 시간 저장
		}
	}

	public class Task_Manager
	{
		private static readonly Lazy<Task_Manager> _instance = new Lazy<Task_Manager>(() => new Task_Manager());

		public static Task_Manager Instance => _instance.Value;
		public CancellationToken CurrentToken => _cancellationTokenSource?.Token ?? CancellationToken.None;

		private CancellationTokenSource _cancellationTokenSource;
		private Task _currentRunningTask;
		private Stopwatch _stopwatch;
		private System.Threading.Timer _progressTimer;

		private MouseTrackerService _mouseTrackerService;

		public event EventHandler<Point> MousePositionChanged;
		public event EventHandler<string> CurrentTaskNameChanged;
		public event EventHandler<TaskProgressEventArgs> TaskProgressUpdated;

		private BaseAutomationTask _currentTaskInstance;
		private TaskConfig _currentTaskConfig;

		private Input_Manager _Input_Manager;

		private Task_Manager()
		{
			_cancellationTokenSource = new CancellationTokenSource();
			_stopwatch = new Stopwatch();
			_progressTimer = new System.Threading.Timer(ProgressTimerCallback, null, Timeout.Infinite, 1000);
			_Input_Manager = Input_Manager.Instance;

			_mouseTrackerService = new MouseTrackerService();
			_mouseTrackerService.MousePositionChanged += (s, pos) => MousePositionChanged?.Invoke(this, pos);
		}

		public void InitializeAndStartServices()
		{
			_mouseTrackerService.StartTracking();
			StartTask(new EmptyTask(new CancellationToken()), new TaskConfig());
		}

		public void StartTask(BaseAutomationTask taskToRun, TaskConfig config)
		{
			StopAllTasks();

			_cancellationTokenSource = new CancellationTokenSource();
			taskToRun._token = _cancellationTokenSource.Token;
			taskToRun._taskConfig = config;

			_currentTaskInstance = taskToRun;
			_currentTaskConfig = config;

			if (config.InitialMonitorClickEnabled)
			{
				Task.Run(async () =>
				{
					try
					{
						Rectangle secondaryMonitorCenter = _Input_Manager.GetSecondaryMonitorCenterArea(20);
						Point initialClickPoint = _Input_Manager.GetRandomPointInBox(secondaryMonitorCenter);

						await _Input_Manager.MoveMouseHumanLike(initialClickPoint, _cancellationTokenSource.Token, durationSeconds: 0.8, noiseMagnitude: 5.0, overshootChance: 0.1);
						_Input_Manager.SimulateLeftClick(_cancellationTokenSource.Token); // 클릭 시 token 전달
						await _Input_Manager.RandomDelay(500, 1000, _cancellationTokenSource.Token);
					}
					catch (OperationCanceledException)
					{
					}
					catch (Exception ex)
					{
						Console.WriteLine($"초기 모니터 클릭 중 오류 발생: {ex.Message}");
					}
				}, _cancellationTokenSource.Token);
			}

			taskToRun.OnTaskNameChanged = (name) => CurrentTaskNameChanged?.Invoke(this, name);
			taskToRun.OnRepetitionChanged = (currentRepetition) => UpdateProgress(currentRepetition);

			_stopwatch.Restart();
			_progressTimer.Change(0, 1000);

			UpdateProgress(1);

			_currentRunningTask = Task.Run(() => taskToRun.ExecuteAsync(), _cancellationTokenSource.Token)
				.ContinueWith(t =>
				{
					_stopwatch.Stop();
					_progressTimer.Change(Timeout.Infinite, Timeout.Infinite);

					if (t.IsCanceled)
					{
					}
					else if (t.IsFaulted)
					{
						Console.WriteLine($"Task 실행 중 예외 발생: {t.Exception}");
					}
					CurrentTaskNameChanged?.Invoke(this, TaskNames[TaskType.None]);
					UpdateProgress(0, true);
					_currentTaskInstance = null;
					_currentTaskConfig = null;
				}, TaskScheduler.Default);
		}

		public void StopAllTasks()
		{
			if (_cancellationTokenSource != null && !_cancellationTokenSource.IsCancellationRequested)
			{
				_cancellationTokenSource.Cancel();
			}
			_stopwatch.Stop();
			_progressTimer.Change(Timeout.Infinite, Timeout.Infinite);
			CurrentTaskNameChanged?.Invoke(this, TaskNames[TaskType.None]);
			UpdateProgress(0, true);
			_currentTaskInstance = null;
			_currentTaskConfig = null;
		}

		public void ShutdownServices()
		{
			StopAllTasks();
			_mouseTrackerService.StopTracking();
		}

		private void ProgressTimerCallback(object? state)
		{
			UpdateProgress(_currentTaskInstance?.TaskRepetitionCounter ?? 0);
		}

		private void UpdateProgress(int currentRepetition, bool reset = false)
		{
			TimeSpan totalEstimatedTime = TimeSpan.Zero;
			TimeSpan elapsedTime = TimeSpan.Zero;
			TimeSpan remainingTime = TimeSpan.Zero;
			int totalRepetitions = 0;
			double singleRepetitionActualSeconds = 0.0; // 단일 반복 실제 시간

			if (!reset && _currentTaskInstance != null && _currentTaskConfig != null && _stopwatch.IsRunning)
			{
				totalRepetitions = _currentTaskConfig.Repetitions;
				singleRepetitionActualSeconds = _currentTaskInstance.EstimatedDurationSeconds; // BaseAutomationTask에서 측정한 값 가져옴

				// --- 전체 예상 시간 계산 로직 변경 ---
				// (단일 반복의 실제 측정 시간 + 반복 간 지연 시간) * 남은 반복 횟수 + 경과 시간
				// 또는 (단일 반복의 실제 측정 시간 + 반복 간 지연 시간) * 총 반복 횟수
				if (totalRepetitions > 0 && singleRepetitionActualSeconds > 0)
				{
					double estimatedTotalSecondsPerRep = singleRepetitionActualSeconds + _currentTaskInstance.DelayTimeAfterRepetition.TotalSeconds;
					// 마지막 반복 후 대기는 제외하므로 총 반복 -1 만큼만 DelayTimeAfterRepetition을 곱합니다.
					double totalCalculatedSeconds = (singleRepetitionActualSeconds * totalRepetitions) + (_currentTaskInstance.DelayTimeAfterRepetition.TotalSeconds * (totalRepetitions - 1));
					totalEstimatedTime = TimeSpan.FromSeconds(Math.Max(0, totalCalculatedSeconds));
				}

				elapsedTime = _stopwatch.Elapsed;
				remainingTime = totalEstimatedTime - elapsedTime;

				if (remainingTime < TimeSpan.Zero)
				{
					remainingTime = TimeSpan.Zero;
				}
			}
			else if (reset)
			{
				totalEstimatedTime = TimeSpan.Zero;
				elapsedTime = TimeSpan.Zero;
				remainingTime = TimeSpan.Zero;
				currentRepetition = 0;
				totalRepetitions = 0;
				singleRepetitionActualSeconds = 0.0;
			}

			TaskProgressUpdated?.Invoke(this, new TaskProgressEventArgs(totalEstimatedTime, elapsedTime, remainingTime, currentRepetition, totalRepetitions, singleRepetitionActualSeconds));
		}
	}
}
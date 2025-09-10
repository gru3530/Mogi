using System.Diagnostics;
using static MOGI.TaskDefinition;

namespace MOGI
{
	public abstract class BaseAutomationTask
	{
		public CancellationToken _token { get; set; }
		public TaskConfig _taskConfig;
		protected UiController _uiController;

		public TaskType TaskType { get; protected set; }
		public string TaskName { get; protected set; }
		public double EstimatedDurationSeconds { get; protected set; }
		public int TaskRepetitionCounter { get; protected set; }
		public TimeSpan DelayTimeAfterRepetition { get; protected set; }

		public Action<string> OnTaskNameChanged;
		public Action<int> OnRepetitionChanged;

		protected BaseAutomationTask()
		{
			TaskType = TaskType.None;
			TaskName = TaskDefinition.TaskNames[TaskType.None];
			EstimatedDurationSeconds = 0.0;
			TaskRepetitionCounter = 0;
			DelayTimeAfterRepetition = TimeSpan.Zero;
		}

		protected abstract Task ExecuteSingleRepetitionAsync();

		public async Task ExecuteAsync()
		{
			_uiController = new UiController(Input_Manager.Instance, _token);
			Stopwatch singleRepetitionStopwatch = new Stopwatch();

			try
			{
				for (int i = 1; i <= _taskConfig.Repetitions; i++)
				{
					_token.ThrowIfCancellationRequested();
					TaskRepetitionCounter = i;
					OnRepetitionChanged?.Invoke(TaskRepetitionCounter);

					singleRepetitionStopwatch.Restart();
					await ExecuteSingleRepetitionAsync();
					singleRepetitionStopwatch.Stop();

					EstimatedDurationSeconds = singleRepetitionStopwatch.Elapsed.TotalSeconds;

					if (i < _taskConfig.Repetitions)
					{
						int baseDelayMs = (int)DelayTimeAfterRepetition.TotalMilliseconds;
						int minExtraDelay = 1;
						int maxExtraDelay = 500;
						int actualMinDelayMs = Math.Max(0, baseDelayMs);
						int actualMaxDelayMs = actualMinDelayMs + Input_Manager.Instance.RandomInstance.Next(minExtraDelay, maxExtraDelay + 1);

						if (actualMinDelayMs > actualMaxDelayMs)
						{
							actualMaxDelayMs = actualMinDelayMs + 1;
						}
						await Input_Manager.Instance.RandomDelay(actualMinDelayMs, actualMaxDelayMs, _token);
					}
				}
			}
			catch (OperationCanceledException)
			{
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				Console.WriteLine(ex.StackTrace);
			}
			finally
			{
				UpdateCurrentTaskName(TaskType.None);
				OnRepetitionChanged?.Invoke(0);
				EstimatedDurationSeconds = 0.0;
			}
		}

		protected async Task Click(Rectangle area)
			=> await _uiController.ClickArea(area);

		protected async Task Click<TEnum>(TEnum areaType) where TEnum : Enum
			=> await _uiController.ClickArea(areaType);

		protected async Task SelectItem<TEnum>(TEnum item) where TEnum : Enum
			=> await _uiController.SelectItemFromList(item);

		protected void UpdateCurrentTaskName(TaskType type)
		{
			TaskName = TaskDefinition.TaskNames[type];
			OnTaskNameChanged?.Invoke(TaskName);
		}
	}
}
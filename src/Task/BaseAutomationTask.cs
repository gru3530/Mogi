using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using static MOGI.TaskDefinition;

namespace MOGI
{
	public abstract class BaseAutomationTask
	{
		public CancellationToken _token { get; set; }
		public TaskConfig _taskConfig;
		public UiController _uiController;

		public TaskType TaskType { get; protected set; }
		public string TaskName { get; protected set; }
		public double EstimatedDurationSeconds { get; set; }
		public int TaskRepetitionCounter { get; set; }
		public TimeSpan DelayTimeAfterRepetition { get; protected set; }

		public Action<string> OnTaskNameChanged;
		public Action<int> OnRepetitionChanged;

		protected BaseAutomationTask()
		{
			TaskType = TaskType.None;
			TaskName = TaskNames[TaskType];
			EstimatedDurationSeconds = 5.0;
			TaskRepetitionCounter = 0;
			DelayTimeAfterRepetition = TimeSpan.Zero;
		}

		public abstract Task ExecuteSingleRepetitionAsync();

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
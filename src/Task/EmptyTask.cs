using static MOGI.TaskDefinition;

namespace MOGI
{
	public class EmptyTask : BaseAutomationTask
	{
		public EmptyTask(CancellationToken token) : base()
		{
			TaskType = TaskType.None;
			TaskName = TaskNames[TaskType.None];
			_token = token;
			EstimatedDurationSeconds = 0.0; 
			_taskConfig = new TaskConfig();
			DelayTimeAfterRepetition = TimeSpan.Zero;
		}

		protected override Task ExecuteSingleRepetitionAsync()
		{
			UpdateCurrentTaskName(TaskType.None);
			return Task.CompletedTask;
		}
	}
}
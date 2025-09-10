using static MOGI.CommonArea;
using static MOGI.TaskDefinition;

namespace MOGI
{
	public class TaskInsect : BaseAutomationTask
	{
		private readonly InsectType _selectedInsectType;

		public TaskInsect(InsectType selectedInsectType) : base()
		{
			TaskType = TaskType.InsectGathering;
			TaskName = TaskNames[TaskType.InsectGathering];
			EstimatedDurationSeconds = 5;
			DelayTimeAfterRepetition = System.TimeSpan.FromSeconds(10 * 7);

			_selectedInsectType = selectedInsectType;
		}

		protected override async Task ExecuteSingleRepetitionAsync()
		{
			UpdateCurrentTaskName(TaskType.InsectGathering);

			await Click(AreaType.ProfileClick);
			await Click(AreaType.LifeSkill);
			await Click(AreaType.InsectGathering);
			await SelectItem(_selectedInsectType);
			await Click(GetLocationMove(_selectedInsectType));
		}
	}
}
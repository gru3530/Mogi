using static MOGI.CommonArea;
using static MOGI.TaskDefinition;

namespace MOGI
{
	public class TaskHoeing : BaseAutomationTask
	{
		private readonly HoeingType _selectedHoeingType;

		public TaskHoeing(HoeingType selectedHoeingType) : base()
		{
			TaskType = TaskType.Hoeing;
			TaskName = TaskNames[TaskType.Hoeing];
			EstimatedDurationSeconds = 5;
			DelayTimeAfterRepetition = System.TimeSpan.FromSeconds(10 * 8);

			_selectedHoeingType = selectedHoeingType;
		}

		public override async Task ExecuteSingleRepetitionAsync()
		{
			UpdateCurrentTaskName(TaskType.Hoeing);

			await Click(AreaType.ProfileClick);
			await Click(AreaType.LifeSkill);
			await Click(AreaType.Hoeing);
			await SelectItem(_selectedHoeingType);
			await Click(GetLocationMove(_selectedHoeingType));
		}
	}
}
using static MOGI.CommonArea;
using static MOGI.TaskDefinition;

namespace MOGI
{
	public class TaskHerb : BaseAutomationTask
	{
		private readonly HerbType _selectedHerbType;

		public TaskHerb(HerbType selectedHerbType) : base()
		{
			TaskType = TaskType.HerbGathering;
			TaskName = TaskNames[TaskType.HerbGathering];
			EstimatedDurationSeconds = 5;
			DelayTimeAfterRepetition = System.TimeSpan.FromSeconds(10 * 7);

			_selectedHerbType = selectedHerbType;
		}

		protected override async Task ExecuteSingleRepetitionAsync()
		{
			UpdateCurrentTaskName(TaskType.HerbGathering);

			await Click(AreaType.ProfileClick);
			await Click(AreaType.LifeSkill);
			await Click(AreaType.HerbGathering);
			await SelectItem(_selectedHerbType);
			await Click(GetLocationMove(_selectedHerbType));
		}
	}
}
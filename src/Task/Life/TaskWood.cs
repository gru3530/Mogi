using static MOGI.CommonArea;
using static MOGI.TaskDefinition;

namespace MOGI
{
	public class TaskWood : BaseAutomationTask
	{
		private readonly WoodType _selectedWoodType;

		public TaskWood(WoodType selectedWoodType) : base()
		{
			TaskType = TaskType.Woodcutting;
			TaskName = TaskNames[TaskType.Woodcutting];
			EstimatedDurationSeconds = 5;
			DelayTimeAfterRepetition = System.TimeSpan.FromSeconds(10 * 7);

			_selectedWoodType = selectedWoodType;
		}

		protected override async Task ExecuteSingleRepetitionAsync()
		{
			UpdateCurrentTaskName(TaskType.Woodcutting);

			await Click(AreaType.ProfileClick);
			await Click(AreaType.LifeSkill);
			await Click(AreaType.Wood);
			await SelectItem(_selectedWoodType);
			await Click(GetLocationMove(_selectedWoodType));
		}
	}
}
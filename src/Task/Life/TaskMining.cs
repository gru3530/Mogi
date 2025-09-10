using static MOGI.CommonArea;
using static MOGI.TaskDefinition;

namespace MOGI
{
	public class TaskMining : BaseAutomationTask
	{
		private readonly MineralType _selectedMineralType;

		public TaskMining(MineralType selectedMineralType) : base()
		{
			TaskType = TaskType.Mining;
			TaskName = TaskNames[TaskType.Mining];
			EstimatedDurationSeconds = 5;
			DelayTimeAfterRepetition = System.TimeSpan.FromSeconds(8 * 10);

			_selectedMineralType = selectedMineralType;
		}

		protected override async Task ExecuteSingleRepetitionAsync()
		{
			UpdateCurrentTaskName(TaskType.Mining);

			await Click(AreaType.ProfileClick);
			await Click(AreaType.LifeSkill);
			await Click(AreaType.Mining);
			await SelectItem(_selectedMineralType);
			await Click(GetLocationMove(_selectedMineralType));
		}
	}
}
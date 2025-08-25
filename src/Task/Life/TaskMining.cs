
using static MOGI.CommonArea;
using static MOGI.TaskDefinition;

namespace MOGI
{
	public class TaskMining : BaseAutomationTask
	{
		private MineralType _selectedCropType;

		public TaskMining(MineralType selectedCropType = MineralType.Ore) : base()
		{
			TaskType = TaskType.Mining;
			TaskName = TaskNames[TaskType.Mining];
			EstimatedDurationSeconds = 5;
			DelayTimeAfterRepetition = TimeSpan.FromSeconds(8 * 10);

			_selectedCropType = selectedCropType;
		}

		protected override async Task ExecuteSingleRepetitionAsync()
		{
			UpdateCurrentTaskName(TaskType.Mining);

			await PerformClickSequence(GetArea(AreaType.ProfileClick));
			await PerformClickSequence(GetArea(AreaType.LifeSkill));
			await PerformClickSequence(GetArea(AreaType.Mining));
			//await SelectScrollableItem(_selectedCropType, (MineralType[])Enum.GetValues(typeof(MineralType)));
			await PerformClickSequence(GetArea(_selectedCropType));
			await PerformClickSequence(GetArea(AreaType.LocationMove));
		}
	}
}
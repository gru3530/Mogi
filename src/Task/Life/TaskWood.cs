
using static MOGI.CommonArea;
using static MOGI.TaskDefinition;

namespace MOGI
{
	public class TaskWood : BaseAutomationTask
	{
		private WoodType _selectedCropType;

		public TaskWood(WoodType selectedCropType = WoodType.Normal) : base()
		{
			TaskType = TaskType.Harvest;
			TaskName = TaskNames[TaskType.Harvest];
			EstimatedDurationSeconds = 5;
			DelayTimeAfterRepetition = TimeSpan.FromSeconds(10 * 7);

			_selectedCropType = selectedCropType;
		}

		protected override async Task ExecuteSingleRepetitionAsync()
		{
			UpdateCurrentTaskName(TaskType.Woodcutting);

			await PerformClickSequence(GetArea(AreaType.ProfileClick));
			await PerformClickSequence(GetArea(AreaType.LifeSkill));

			await PerformClickSequence(GetArea(AreaType.Wood));
			await PerformClickSequence(GetArea(_selectedCropType));
			await PerformClickSequence(GetLocationMove(_selectedCropType));
		}
	}
}

using static MOGI.CommonArea;
using static MOGI.TaskDefinition;

namespace MOGI
{
	public class TaskHarvest : BaseAutomationTask
	{
		private CropType _selectedCropType;

		public TaskHarvest(CropType selectedCropType = CropType.Wheat) : base()
		{
			TaskType = TaskType.Harvest;
			TaskName = TaskNames[TaskType.Harvest];
			EstimatedDurationSeconds = 5;
			DelayTimeAfterRepetition = TimeSpan.FromSeconds(10 * 7);

			_selectedCropType = selectedCropType;
		}

		protected override async Task ExecuteSingleRepetitionAsync()
		{
			UpdateCurrentTaskName(TaskType.Harvest);

			await PerformClickSequence(GetArea(AreaType.ProfileClick));
			await PerformClickSequence(GetArea(AreaType.LifeSkill));
			await PerformClickSequence(GetArea(AreaType.Harvest));
			await PerformClickSequence(GetArea(_selectedCropType));
			await PerformClickSequence(GetArea(AreaType.LocationMove));
		}
	}
}
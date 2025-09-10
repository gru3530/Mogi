using static MOGI.CommonArea;
using static MOGI.TaskDefinition;

namespace MOGI
{
	public class TaskHarvest : BaseAutomationTask
	{
		private readonly CropType _selectedCropType;

		public TaskHarvest(CropType selectedCropType) : base()
		{
			TaskType = TaskType.Harvest;
			TaskName = TaskNames[TaskType.Harvest];
			EstimatedDurationSeconds = 5;
			DelayTimeAfterRepetition = System.TimeSpan.FromSeconds(10 * 7);

			_selectedCropType = selectedCropType;
		}

		protected override async Task ExecuteSingleRepetitionAsync()
		{
			UpdateCurrentTaskName(TaskType.Harvest);

			await Click(AreaType.ProfileClick);
			await Click(AreaType.LifeSkill);
			await Click(AreaType.Harvest);
			await SelectItem(_selectedCropType);
			await Click(GetLocationMove(_selectedCropType));
		}
	}
}
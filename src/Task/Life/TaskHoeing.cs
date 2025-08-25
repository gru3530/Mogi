
using static MOGI.CommonArea;
using static MOGI.TaskDefinition;

namespace MOGI
{
	public class TaskHoeing : BaseAutomationTask
	{
		private HoeingType _selectedCropType;

		public TaskHoeing(HoeingType selectedCropType = HoeingType.Potato) : base()
		{
			TaskType = TaskType.Harvest;
			TaskName = TaskNames[TaskType.Harvest];
			EstimatedDurationSeconds = 5;
			DelayTimeAfterRepetition = TimeSpan.FromSeconds(10 * 8);

			_selectedCropType = selectedCropType;
		}

		protected override async Task ExecuteSingleRepetitionAsync()
		{
			UpdateCurrentTaskName(TaskType.Hoeing);

			await PerformClickSequence(GetArea(AreaType.ProfileClick));
			await PerformClickSequence(GetArea(AreaType.LifeSkill));
			await PerformClickSequence(GetArea(AreaType.Hoeing));
			await PerformClickSequence(GetArea(_selectedCropType));
			await PerformClickSequence(GetArea(AreaType.LocationMove));
		}
	}
}
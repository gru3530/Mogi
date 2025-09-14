using Emgu.CV;
using static MOGI.TaskDefinition;

namespace MOGI
{
	public class TaskSellJunkItems : BaseAutomationTask
	{
		private readonly VisionService _visionService;
		private readonly List<string> _junkItemNames;

		public TaskSellJunkItems(List<string> junkItemNames) : base()
		{
			TaskType = TaskType.None;
			TaskName = "잡템 판매 중";
			_junkItemNames = junkItemNames;
			_visionService = new VisionService();
		}

		public override async Task ExecuteSingleRepetitionAsync()
		{
			OnTaskNameChanged?.Invoke(this.TaskName);

			await Input_Manager.Instance.SimulateKeyPress(Keys.I, _token);

			var inventoryArea = new Rectangle(1040, 170, 790, 900);

			foreach (var templatePair in AssetManager.Instance.ItemTemplates)
			{
				string itemName = templatePair.Key;
				Mat itemTemplateMat = templatePair.Value;

				var matches = _visionService.FindAllMatches(inventoryArea, itemTemplateMat, 0.90f);

				if (matches.Any())
				{
					var foundItem = matches.First();
					await _uiController.ClickArea(foundItem.Bounds);
					await Input_Manager.Instance.RandomDelay(500, 700, _token);

					if (await _uiController.FindAndClickTemplate(ButtonType.Sell))
					{
						if (await _uiController.FindAndClickTemplate(ButtonType.Max))
						{
							await _uiController.FindAndClickTemplate(ButtonType.SellConfirm);
						}
					}
				}
			}

			await Input_Manager.Instance.SimulateKeyPress(Keys.I, _token);
		}
	}
}
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
			var menuArea = CommonArea.GetArea(SearchAreaType.TopMenu);

			try
			{
				if (!await _uiController.FindAndClickTemplate(ButtonType.Menu, menuArea) ||
	!await _uiController.FindAndClickTemplate(ButtonType.Bag, menuArea))
				{
					return;
				}
			}
			catch(Exception ex)
			{

			}


			await Input_Manager.Instance.RandomDelay(200, 300, _token);
			var inventoryArea = CommonArea.GetArea(SearchAreaType.InventoryGrid);
			Mat inventoryScreen = null;

			try
			{
				inventoryScreen = _visionService.CaptureScreenMat(inventoryArea);

				foreach (var itemName in _junkItemNames)
				{
					MatchResult match = _visionService.FindItemMatch(inventoryScreen, itemName, 0.8f);
					if (match != null)
					{
						Rectangle itemRect = match.Bounds;
						itemRect.Offset(inventoryArea.Location);
						await _uiController.ClickArea(itemRect);

						if (await _uiController.FindAndClickTemplate(ButtonType.Sell) &&
							await _uiController.FindAndClickTemplate(ButtonType.Max) &&
							await _uiController.FindAndClickTemplate(ButtonType.SellConfirm))
						{
							inventoryScreen.Dispose();
							await _uiController.WaitForUiStability();
							inventoryScreen = _visionService.CaptureScreenMat(inventoryArea);
						}
					}
				}
			}
			finally
			{
				inventoryScreen?.Dispose();
			}

			await Input_Manager.Instance.SimulateKeyPress(Keys.Escape, _token);
		}
	}
}
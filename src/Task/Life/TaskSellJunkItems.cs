using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MOGI.TaskDefinition;

namespace MOGI
{
	public class TaskSellJunkItems : BaseAutomationTask
	{
		private readonly OcrService _ocrService;
		private readonly List<string> _junkItemNames;

		public TaskSellJunkItems(List<string> junkItemNames) : base()
		{
			TaskType = TaskType.None;
			TaskName = "잡템 판매 중";
			_ocrService = new OcrService();
			_junkItemNames = junkItemNames;
		}

		public override async Task ExecuteSingleRepetitionAsync()
		{
			OnTaskNameChanged?.Invoke(this.TaskName);

			var uiController = new UiController(Input_Manager.Instance, _token);

			//await Input_Manager.Instance.SimulateKeyPress(Keys.I, _token);

			var inventoryArea = new Rectangle(1040, 170, 790, 900);
			var recognizedItems = _ocrService.RecognizeText(inventoryArea);

			foreach (var itemToSell in _junkItemNames)
			{
				var foundItem = recognizedItems.FirstOrDefault(item => item.Text == itemToSell);

				if (foundItem != null)
				{
					await uiController.ClickArea(foundItem.Bounds);
					await Input_Manager.Instance.RandomDelay(300, 500, _token);

					await uiController.ClickArea(AreaType.SellButton);
					await Input_Manager.Instance.RandomDelay(300, 500, _token);

					await uiController.ClickArea(AreaType.MaxButton);
					await Input_Manager.Instance.RandomDelay(300, 500, _token);

					await uiController.ClickArea(AreaType.ConfirmSellButton);
					await Input_Manager.Instance.RandomDelay(300, 500, _token);
				}
			}

			await Input_Manager.Instance.SimulateKeyPress(Keys.I, _token);
		}
	}
}
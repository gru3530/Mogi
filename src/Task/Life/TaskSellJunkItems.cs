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

		protected override async Task ExecuteSingleRepetitionAsync()
		{
			// [수정] OnTaskNameChanged 이벤트를 직접 호출하여 UI에 작업 이름을 알립니다.
			OnTaskNameChanged?.Invoke(this.TaskName);

			// UiController는 BaseAutomationTask에 내장되어 있으므로 _uiController를 사용합니다.
			var uiController = new UiController(Input_Manager.Instance, _token);

			// [수정] _inputManager 대신 Input_Manager.Instance를 통해 직접 접근합니다.
			await Input_Manager.Instance.SimulateKeyPress(Keys.I, _token);

			var inventoryArea = new Rectangle(500, 200, 1000, 800);
			var recognizedItems = _ocrService.RecognizeText(inventoryArea);

			foreach (var itemToSell in _junkItemNames)
			{
				var foundItem = recognizedItems.FirstOrDefault(item => item.Text == itemToSell);

				if (foundItem != null)
				{
					await uiController.ClickArea(foundItem.Bounds);
					await Input_Manager.Instance.RandomDelay(300, 500, _token);

					// TODO: 아래 AreaType들을 CommonArea.cs에 실제 좌표와 함께 등록해야 합니다.
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
using static MOGI.CommonArea;

namespace MOGI
{
	public class UiController
	{
		private readonly Input_Manager _inputManager;
		private readonly CancellationToken _token;
		private const int BottomPaddingY = 30;
		private const int BottomScrollDistance = 500;

		public UiController(Input_Manager inputManager, CancellationToken token)
		{
			_inputManager = inputManager;
			_token = token;
		}

		public async Task ClickArea(Rectangle targetArea)
		{
			await _inputManager.PerformClickSequence(targetArea, _token);
		}

		public async Task ClickArea<TEnum>(TEnum areaType) where TEnum : Enum
		{
			Rectangle targetArea = GetArea(areaType);
			await ClickArea(targetArea);
		}

		public async Task SelectItemFromList<TEnum>(TEnum itemToSelect) where TEnum : Enum
		{
			var allPossibleItems = (TEnum[])Enum.GetValues(typeof(TEnum));
			int itemIndex = Array.IndexOf(allPossibleItems, itemToSelect);
			int totalItems = allPossibleItems.Length;

			if (itemIndex == -1)
			{
				throw new ArgumentException($"아이템 '{itemToSelect}'를 찾을 수 없습니다.");
			}

			int visibleSlotsCount = DefaultSlotAreas.Count;

			if (itemIndex < visibleSlotsCount)
			{
				await ClickArea(DefaultSlotAreas[itemIndex]);
				return;
			}

			if (itemIndex >= totalItems - visibleSlotsCount)
			{
				await ScrollToBottom();

				int slotIndexAfterScroll = itemIndex - (totalItems - visibleSlotsCount);
				Rectangle originalRect = DefaultSlotAreas[slotIndexAfterScroll];
				Rectangle adjustedRect = new Rectangle(
					originalRect.X,
					originalRect.Y - BottomPaddingY,
					originalRect.Width,
					originalRect.Height
				);

				await ClickArea(adjustedRect);
			}
			else
			{
				int itemsToScroll = itemIndex - (visibleSlotsCount - 1);
				for (int i = 0; i < itemsToScroll; i++)
				{
					await PerformUnitScroll();
					await _inputManager.RandomDelay(150, 250, _token);
				}
				await ClickArea(DefaultSlotAreas[visibleSlotsCount - 1]);
			}
		}

		private async Task PerformUnitScroll()
		{
			var (start, end) = _inputManager.GetPreciseDragPoints(DefaultSlotAreas[2], DefaultSlotAreas[1]);
			await _inputManager.SimulateDrag(start, end, _token, durationSeconds: 0.25);
		}
		
		private async Task ScrollToBottom()
		{
			Point start = _inputManager.GetRandomPointInBox(DefaultSlotAreas[3]);
			Point end = new Point(start.X, start.Y - BottomScrollDistance);

			await _inputManager.SimulateFlick(start, end, _token, durationSeconds: 0.2);

			await _inputManager.RandomDelay(500, 700, _token);
		}

		public async Task<bool> FindAndClickTemplate(string templateName, float threshold = 0.9f)
		{
			var visionService = new VisionService();

			var matchResult = visionService.FindTemplateOnScreen(templateName, threshold);

			if (matchResult != null)
			{
				await this.ClickArea(matchResult.Bounds);
				await Input_Manager.Instance.RandomDelay(300, 500, _token);
				return true;
			}

			Console.WriteLine($"{templateName} 버튼을 화면에서 찾지 못했습니다.");
			return false;
		}

		public async Task<bool> FindAndClickTemplate(ButtonType buttonType, float threshold = 0.9f)
		{
			string templateName = TaskDefinition.GetEnumDescription(buttonType);

			return await FindAndClickTemplate(templateName, threshold);
		}
	}
}
using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using static MOGI.CommonArea;

namespace MOGI
{
	public class UiController
	{
		private readonly Input_Manager _inputManager;
		private readonly CancellationToken _token;

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

			int itemsToScroll = itemIndex - (visibleSlotsCount - 1);
			int scrolls_3_needed = itemsToScroll / 3;
			int remainder = itemsToScroll % 3;
			int scrolls_2_needed = remainder / 2;
			int scrolls_1_needed = remainder % 2;

			await PerformScroll(scrolls_3_needed, 0, 0.3);
			await PerformScroll(scrolls_2_needed, 1, 0.35);
			await PerformScroll(scrolls_1_needed, 2, 0.4);

			await ClickArea(DefaultSlotAreas[visibleSlotsCount - 1]);
		}

		private async Task PerformScroll(int scrollsNeeded, int endSlotIndex, double duration)
		{
			if (scrollsNeeded <= 0) return;

			Point start = _inputManager.GetRandomPointInBox(DefaultSlotAreas[3]);
			Point end = _inputManager.GetRandomPointInBox(DefaultSlotAreas[endSlotIndex]);

			for (int i = 0; i < scrollsNeeded; i++)
			{
				await _inputManager.SimulateDrag(start, end, _token, durationSeconds: duration);
				await _inputManager.RandomDelay(300, 500, _token);
			}
		}
	}
}
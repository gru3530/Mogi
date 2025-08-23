using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using MOGI; // CommonEnum의 enum들을 사용하기 위해 네임스페이스 명시
using static MOGI.CommonArea;
using static MOGI.TaskDefinition;

namespace MOGI
{
	public abstract class BaseAutomationTask
	{
		public CancellationToken _token { get; set; }
		public Input_Manager _inputManager = Input_Manager.Instance;
		public TaskConfig _taskConfig;

		public TaskType TaskType { get; protected set; }
		public string TaskName { get; protected set; }
		public double EstimatedDurationSeconds { get; protected set; }
		public int TaskRepetitionCounter { get; protected set; }

		public TimeSpan DelayTimeAfterRepetition { get; protected set; }

		public Action<string> OnTaskNameChanged;
		public Action<int> OnRepetitionChanged;

		protected BaseAutomationTask()
		{
			TaskType = TaskType.None;
			TaskName = TaskDefinition.TaskNames[TaskType.None];
			EstimatedDurationSeconds = 0.0;
			TaskRepetitionCounter = 0;
			DelayTimeAfterRepetition = TimeSpan.Zero;
		}

		protected abstract Task ExecuteSingleRepetitionAsync();

		public async Task ExecuteAsync()
		{
			Stopwatch singleRepetitionStopwatch = new Stopwatch();

			try
			{
				for (int i = 1; i <= _taskConfig.Repetitions; i++)
				{
					_token.ThrowIfCancellationRequested();
					TaskRepetitionCounter = i;
					OnRepetitionChanged?.Invoke(TaskRepetitionCounter);

					singleRepetitionStopwatch.Restart();
					await ExecuteSingleRepetitionAsync();
					singleRepetitionStopwatch.Stop();

					EstimatedDurationSeconds = singleRepetitionStopwatch.Elapsed.TotalSeconds;

					if (i < _taskConfig.Repetitions)
					{
						int baseDelayMs = (int)DelayTimeAfterRepetition.TotalMilliseconds;

						int minExtraDelay = 1; 
						int maxExtraDelay = 500;

						int actualMinDelayMs = Math.Max(0, baseDelayMs);
						int actualMaxDelayMs = actualMinDelayMs + _inputManager.RandomInstance.Next(minExtraDelay, maxExtraDelay + 1); // minExtraDelay ~ maxExtraDelay까지 랜덤 추가

						// minDelay가 maxDelay보다 커지는 상황을 방지
						if (actualMinDelayMs > actualMaxDelayMs)
						{
							actualMaxDelayMs = actualMinDelayMs + 1; // 최소 1ms라도 더 크게
						}

						await RandomDelay(actualMinDelayMs, actualMaxDelayMs);
					}
				}
			}
			catch (OperationCanceledException)
			{
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				Console.WriteLine(ex.StackTrace);
			}
			finally
			{
				UpdateCurrentTaskName(TaskType.None);
				OnRepetitionChanged?.Invoke(0);
				EstimatedDurationSeconds = 0.0;
			}
		}

		protected async Task RandomDelay(int minMs, int maxMs)
		{
			await _inputManager.RandomDelay(minMs, maxMs, _token);
		}

		protected Point GetRandomPointInBox(Rectangle box)
		{
			return _inputManager.GetRandomPointInBox(box);
		}

		protected async Task SimulateTapAsync(Rectangle targetArea)
		{
			await _inputManager.SimulateTapAsync(targetArea, _token);
		}

		protected async Task SimulateTapAsync<TEnum>(TEnum areaType) where TEnum : Enum
		{
			Rectangle targetArea = GetArea(areaType);
			await SimulateTapAsync(targetArea);
		}

		protected async Task SelectScrollableItem<TItemEnum>(TItemEnum itemToSelect, TItemEnum[] allPossibleItems, int itemsPerScroll = 4) where TItemEnum : Enum
		{
			int itemIndex = Array.IndexOf(allPossibleItems, itemToSelect);
			if (itemIndex == -1)
			{
				throw new ArgumentException($"Item '{itemToSelect}' not found.");
			}

			int visibleSlots = DefaultSlotAreas.Count;

			if (itemIndex < visibleSlots)
			{
				Rectangle slotArea = GetScrollableItemArea(itemToSelect, allPossibleItems);
				await _inputManager.PerformClickSequence(slotArea, _token);
			}
			else
			{
				int scrollsNeeded = 0;
				int tempIndex = itemIndex;
				while (tempIndex >= visibleSlots)
				{
					tempIndex -= itemsPerScroll;
					scrollsNeeded++;
				}
				int finalSlotIndex = tempIndex;

				Point dragStartPoint = GetRandomPointInBox(DefaultSlotAreas[visibleSlots - 1]);
				Point dragEndPoint = GetRandomPointInBox(DefaultSlotAreas[0]);

				for (int i = 0; i < scrollsNeeded; i++)
				{
					await _inputManager.SimulateDrag(dragStartPoint, dragEndPoint, _token, durationSeconds: 0.4);
					await RandomDelay(200, 300);
				}

				Rectangle finalSlotArea = DefaultSlotAreas[finalSlotIndex];
				await _inputManager.PerformClickSequence(finalSlotArea, _token);
			}
		}

		protected async Task PerformClickSequence(
			Rectangle targetArea,
			int preClickDelayMinMs = 300, int preClickDelayMaxMs = 700,
			int clickDownTimeMinMs = 60, int clickDownTimeMaxMs = 180,
			int postClickDelayMinMs = 700, int postClickDelayMaxMs = 1500,
			double mouseMoveDurationSec = 0.25, double mouseMoveNoise = 3.0, double mouseOvershootChance = 0.15, double mouseOvershootAmount = 0.05,
			double oclickChance = 0.05, double oclickOffset = 20.0)
		{
			await _inputManager.PerformClickSequence(
				targetArea, _token, preClickDelayMinMs, preClickDelayMaxMs,
				clickDownTimeMinMs, clickDownTimeMaxMs, postClickDelayMinMs, postClickDelayMaxMs,
				mouseMoveDurationSec, mouseMoveNoise, mouseOvershootChance, mouseOvershootAmount,
				oclickChance, oclickOffset);
		}

		protected void UpdateCurrentTaskName(TaskType type)
		{
			TaskName = TaskDefinition.TaskNames[type];
			OnTaskNameChanged?.Invoke(TaskName);
		}
	}
}
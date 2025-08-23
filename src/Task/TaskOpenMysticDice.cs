
namespace MOGI
{
	//public class TaskOpenMysticDice : BaseAutomationTask
	//{
	//	private MonitorInfo _targetMonitor;
	//	private bool _isDiagnosisMode = false; // 진단 모드 플래그

	//	// 디버깅 시각화를 Form으로 전달하기 위한 이벤트
	//	public event Action<Rectangle, Color, string> OnAreaDetected;

	//	public TaskOpenMysticDice(MonitorInfo targetMonitor) : base()
	//	{
	//		TaskType = TaskType.미스틱다이스;
	//		TaskName = TaskNames[TaskType.미스틱다이스];
	//		DelayTimeAfterRepetition = TimeSpan.FromSeconds(5);

	//		_targetMonitor = targetMonitor;
	//	}

	//	// 진단 모드 설정 메서드
	//	public void SetDiagnosisMode(bool isDiagnosis)
	//	{
	//		_isDiagnosisMode = isDiagnosis;
	//		if (_isDiagnosisMode)
	//		{
	//			TaskName = "미스틱 다이스 진단";
	//		}
	//	}

	//	public override async Task ExecuteSingleRepetitionAsync()
	//	{
	//		UpdateCurrentTaskName(TaskType.미스틱다이스);
	//		Debug.WriteLine($"Executing Mystic Dice Task on monitor: {_targetMonitor.DeviceName} (Diagnosis Mode: {_isDiagnosisMode})");

	//		// 1. "장면 넘기기" 화면 확인 및 처리
	//		// 해당 영역을 모니터에 맞춰 가져옵니다.
	//		Rectangle skipSceneRect = CommonArea.GetArea(Area.SkipSceneButtonArea, _targetMonitor);
	//		using (Bitmap skipSceneImg = ScreenCapture.CaptureRegion(skipSceneRect, _targetMonitor))
	//		{
	//			string skipText = OcrHelper.RecognizeText(skipSceneImg);
	//			// UI에 인식 결과 시각화
	//			OnAreaDetected?.Invoke(skipSceneRect, Color.Green, $"장면 넘기기 인식: '{skipText}'");

	//			if (skipText.Contains("장면") && skipText.Contains("넘기기"))
	//			{
	//				Debug.WriteLine("장면 넘기기 화면 감지. 클릭합니다.");
	//				if (!_isDiagnosisMode) // 진단 모드가 아닐 때만 클릭
	//				{
	//					await PerformClickSequence(skipSceneRect, MouseSpeedProfile.Normal);
	//					await RandomDelay(1000, 2000); // 클릭 후 화면 전환 대기
	//				}
	//				else
	//				{
	//					Debug.WriteLine("진단 모드이므로 '장면 넘기기' 클릭 스킵.");
	//				}
	//			}
	//		}

	//		// 2. "미스틱 다이스 열기" 화면 나타날 때까지 대기 및 확인
	//		Rectangle mysticDiceTitleRect = CommonArea.GetArea(Area.MysticDiceTitleArea, _targetMonitor);
	//		bool isMysticDiceScreen = false;
	//		int maxAttempts = 10;
	//		for (int i = 0; i < maxAttempts; i++)
	//		{
	//			_token.ThrowIfCancellationRequested(); // 작업 취소 요청 확인
	//			using (Bitmap titleImg = ScreenCapture.CaptureRegion(mysticDiceTitleRect, _targetMonitor))
	//			{
	//				string titleText = OcrHelper.RecognizeText(titleImg);
	//				OnAreaDetected?.Invoke(mysticDiceTitleRect, Color.Red, $"타이틀 인식: '{titleText}' (시도 {i + 1}/{maxAttempts})");

	//				if (titleText.Contains("미스틱") && titleText.Contains("다이스") && titleText.Contains("열기"))
	//				{
	//					isMysticDiceScreen = true;
	//					Debug.WriteLine("미스틱 다이스 열기 화면 감지.");
	//					break;
	//				}
	//			}
	//			await RandomDelay(500, 1000);
	//		}

	//		if (!isMysticDiceScreen)
	//		{
	//			throw new InvalidOperationException("미스틱 다이스 열기 화면을 감지하지 못했습니다. 작업 중단.");
	//		}

	//		// 3. 남은 미스틱 다이스 수 카운트 및 버튼 클릭
	//		Rectangle remainingDiceCountRect = CommonArea.GetArea(Area.RemainingDiceCountArea, _targetMonitor);
	//		using (Bitmap countImg = ScreenCapture.CaptureRegion(remainingDiceCountRect, _targetMonitor))
	//		{
	//			string countText = OcrHelper.RecognizeText(countImg);
	//			int remainingDice = OcrHelper.ExtractNumber(countText);
	//			OnAreaDetected?.Invoke(remainingDiceCountRect, Color.Blue, $"남은 다이스: {remainingDice} ('{countText}')");

	//			if (remainingDice > 0)
	//			{
	//				Debug.WriteLine($"남은 미스틱 다이스: {remainingDice}개. '계속 열기' 클릭.");
	//				if (!_isDiagnosisMode) // 진단 모드가 아닐 때만 클릭
	//				{
	//					await PerformClickSequence(GetArea(Area.KeepOpeningButtonArea, _targetMonitor), MouseSpeedProfile.Normal);
	//				}
	//				else
	//				{
	//					Debug.WriteLine("진단 모드이므로 '계속 열기' 클릭 스킵.");
	//				}
	//			}
	//			else
	//			{
	//				Debug.WriteLine("남은 미스틱 다이스가 없습니다. '그만 열기' 클릭 후 작업 종료.");
	//				if (!_isDiagnosisMode) // 진단 모드가 아닐 때만 클릭
	//				{
	//					await PerformClickSequence(GetArea(Area.StopOpeningButtonArea, _targetMonitor), MouseSpeedProfile.Normal);
	//				}
	//				else
	//				{
	//					Debug.WriteLine("진단 모드이므로 '그만 열기' 클릭 스킵.");
	//				}
	//				throw new OperationCanceledException("남은 미스틱 다이스가 없어 작업을 종료합니다.");
	//			}
	//		}
	//	}
	//}
}

namespace MOGI
{
	public partial class Form_Dice : Form
	{
		private Task_Manager _taskManager;
		//private MonitorInfo _selectedMonitor; // 선택된 모니터 정보

		// Form_Home으로 디버깅 시각화 이벤트를 전달하기 위함
		public event Action<Rectangle, Color, string> OnAreaDetected;

		public Form_Dice()
		{
			InitializeComponent();
			_taskManager = Task_Manager.Instance;

			this.TopLevel = false;
			this.FormBorderStyle = FormBorderStyle.None;
			this.Dock = DockStyle.Fill;
		}

		// Form_Home에서 MonitorInfo를 전달받는 메서드
		//public void SetMonitorInfo(MonitorInfo monitor)
		//{
		//	_selectedMonitor = monitor;
		//	if (label_SelectedMonitor != null)
		//	{
		//		label_SelectedMonitor.Text = $"대상 모니터: {monitor.DeviceName}";
		//	}
		//}

		//// --- 미스틱 다이스 열기 버튼 클릭 이벤트 핸들러 (UI 역할만) ---
		//private void button_StartDiceTask_Click(object sender, EventArgs e)
		//{
		//	if (_selectedMonitor == null)
		//	{
		//		MessageBox.Show("대상 모니터 정보가 설정되지 않았습니다. 메인 화면에서 모니터를 선택해주세요.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
		//		return;
		//	}

		//	int repetitions = 9999; // 미스틱 다이스가 없어질 때까지 반복

		//	// 실제 작업 클래스(TaskOpenMysticDice)를 인스턴스화하고 TaskManager에 전달
		//	// 모든 인식/클릭 로직은 TaskOpenMysticDice 내부에서 수행됨
		//	TaskOpenMysticDice task = new TaskOpenMysticDice(_selectedMonitor);
		//	task.OnAreaDetected += this.OnAreaDetected; // Task의 디버깅 이벤트를 폼으로 전달

		//	TaskConfiguration config = new TaskConfiguration(repetitions);
		//	_taskManager.StartTask(task, config);

		//	// 사용자에게 작업 시작 알림 (선택 사항)
		//	MessageBox.Show("미스틱 다이스 열기 작업을 시작합니다.", "작업 시작", MessageBoxButtons.OK, MessageBoxIcon.Information);
		//}

		//// --- 화면 인식 확인 버튼 클릭 이벤트 핸들러 (UI 역할만) ---
		//private void button_VerifyDiceScreen_Click(object sender, EventArgs e)
		//{
		//	if (_selectedMonitor == null)
		//	{
		//		MessageBox.Show("먼저 모니터를 선택해주세요.", "모니터 선택", MessageBoxButtons.OK, MessageBoxIcon.Warning);
		//		return;
		//	}

		//	// TaskOpenMysticDice에 진단 모드를 추가하여 실행 (옵션)
		//	// 또는 별도의 진단용 Task를 만들 수 있습니다.
		//	// 여기서는 TaskOpenMysticDice에 'isDiagnosisMode'를 추가하는 방식으로 가정합니다.
		//	// 이렇게 하면 TaskOpenMysticDice 내부의 로직을 재활용하면서 특정 클릭 동작을 건너뛸 수 있습니다.

		//	TaskOpenMysticDice task = new TaskOpenMysticDice(_selectedMonitor);
		//	task.OnAreaDetected += this.OnAreaDetected;

		//	// 진단 모드 활성화 (ExecuteSingleRepetitionAsync 내에서 이를 체크하여 클릭 동작 스킵 등)
		//	task.SetDiagnosisMode(true);

		//	// 단일 반복으로 진단 작업 실행
		//	TaskConfiguration config = new TaskConfiguration(1);
		//	_taskManager.StartTask(task, config);

		//	MessageBox.Show("화면 인식 진단 작업을 시작합니다. UI 오버레이를 확인해주세요.", "진단 시작", MessageBoxButtons.OK, MessageBoxIcon.Information);
		//}
	}
}
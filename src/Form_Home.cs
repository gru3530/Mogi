using System;
using System.Drawing;
using System.Windows.Forms;
using MOGI; // MOGI 네임스페이스
using static MOGI.CommonArea;
using static MOGI.TaskDefinition; // TaskDefinition.GetEnumDescription 사용을 위해 필요

namespace MOGI
{
	public partial class Form_Home : Form
	{
		// 미리 생성해 둘 콘텐츠 폼들
		private Form_Harvest _formHarvest;
		private Form_Hoeing _formHoeing;
		private Form_Mining _formMining;
		private Form_Wood _formWood;
		// private Form_HerbGathering _formHerbGathering;
		// private Form_InsectGathering _formInsectGathering;


		private Task_Manager _taskManager;
		private Input_Manager _inputManager;
		private HotkeyManager _hotkeyManager;
		private int _monitorXOffset = 0;

		// --- 새로 추가: 현재 선택된 생활 활동 타입과 세부 항목 ---
		private TaskType _selectedLifeActivityType = TaskType.None; // 추수, 호미질 등 (TaskType 캐스팅)
		private Enum? _selectedDetailItem = null; // 선택된 세부 항목 (CropType, HoeingType 등)

		public Form_Home()
		{
			InitializeComponent();

			Initialize();
			DetectMonitorsAndSetRadioButtons();

			_formHarvest = new Form_Harvest();
			_formHoeing = new Form_Hoeing();
			_formMining = new Form_Mining();
			_formWood = new Form_Wood();

			_formHarvest.ItemSelected += FormHarvest_ItemSelectedHandler;
			_formHoeing.ItemSelected += FormHoeing_ItemSelectedHandler;
			_formMining.ItemSelected += FormMining_ItemSelectedHandler;
			_formWood.ItemSelected += FormWood_ItemSelectedHandler;


			AddFormToPanel(_formHarvest);
			AddFormToPanel(_formHoeing);
			AddFormToPanel(_formMining);
			AddFormToPanel(_formWood);


			ShowContentForm(_formHarvest);
			_selectedLifeActivityType = TaskType.Harvest;
		}

		private void Initialize()
		{
			_taskManager = Task_Manager.Instance;
			_inputManager = Input_Manager.Instance;
			//_hotkeyManager = new HotkeyManager();

			Initialize_UI();
			//Initialize_HotKey();



			_taskManager.MousePositionChanged += TaskManager_MousePositionChanged;
			_taskManager.CurrentTaskNameChanged += TaskManager_CurrentTaskNameChanged;
			_taskManager.TaskProgressUpdated += TaskManager_TaskProgressUpdated;


			UpdateTaskTimes(TimeSpan.Zero, TimeSpan.Zero, TimeSpan.Zero, 0, 0);
		}

		private void Initialize_HotKey()
		{
			_hotkeyManager.HotkeyFired += HotkeyManager_HotkeyFired;
			var keyMaps = CommonArea.GetKeyMaps();
			foreach (var key in keyMaps.Keys)
			{
				_hotkeyManager.RegisterHotkey(key);
			}
		}

		private void Initialize_UI()
		{

			if (label_CurrentTask != null)
			{
				label_CurrentTask.Text = TaskDefinition.TaskNames[TaskType.None];
			}
			if (trackBar1 != null)
			{
				trackBar1.Value = 1;
			}

			if (label_Scroll != null)
			{
				label_Scroll.Text = "1";
			}

			if (label_CurrentRepetition != null)
			{
				label_CurrentRepetition.Text = "0/0";
			}

			radioButton_SecondScreen.Checked = true;
		}


		private void DetectMonitorsAndSetRadioButtons()
		{
			Screen[] screens = Screen.AllScreens;

			if (radioButton_FirstScreen != null)
			{
				radioButton_FirstScreen.Enabled = (screens.Length > 0);
			}
			if (radioButton_SecondScreen != null)
			{
				radioButton_SecondScreen.Enabled = (screens.Length > 1);
			}

			if (screens.Length > 1 && radioButton_SecondScreen != null)
			{
				radioButton_SecondScreen.Checked = true;
				_monitorXOffset = screens[1].Bounds.X;
			}
			else if (screens.Length > 0 && radioButton_FirstScreen != null)
			{
				radioButton_FirstScreen.Checked = true;
				_monitorXOffset = screens[0].Bounds.X;
			}
			else
			{
				_monitorXOffset = 0;
			}
			UpdateCommonAreaOffset();
		}


		private void TaskManager_MousePositionChanged(object sender, Point mousePosition)
		{
			if (this.InvokeRequired)
			{
				this.Invoke(new Action(() => UpdateMouseCoordinates(mousePosition)));
			}
			else
			{
				UpdateMouseCoordinates(mousePosition);
			}
		}

		private void TaskManager_CurrentTaskNameChanged(object sender, string taskName)
		{
			if (this.InvokeRequired)
			{
				this.Invoke(new Action(() => UpdateTaskLabel(taskName)));
			}
			else
			{
				UpdateTaskLabel(taskName);
			}
		}

		private void TaskManager_TaskProgressUpdated(object sender, TaskProgressEventArgs e)
		{
			if (this.InvokeRequired)
			{
				this.Invoke(new Action(() => UpdateTaskTimes(e.TotalEstimatedTime, e.ElapsedTime, e.RemainingTime, e.CurrentRepetition, e.TotalRepetitions)));
			}
			else
			{
				UpdateTaskTimes(e.TotalEstimatedTime, e.ElapsedTime, e.RemainingTime, e.CurrentRepetition, e.TotalRepetitions);
			}
		}

		private void UpdateMouseCoordinates(Point position)
		{
			if (textBox_Mouse_X != null)
			{
				textBox_Mouse_X.Text = position.X.ToString();
			}
			if (textBox_Mouse_Y != null)
			{
				textBox_Mouse_Y.Text = position.Y.ToString();
			}
		}

		private void UpdateTaskLabel(string taskName)
		{
			if (label_CurrentTask != null)
			{
				label_CurrentTask.Text = taskName;
			}
		}

		private void UpdateTaskTimes(TimeSpan totalEstimated, TimeSpan elapsed, TimeSpan remaining, int currentRepetition, int totalRepetitions)
		{
			if (label_TotalTime != null)
			{
				label_TotalTime.Text = $"{totalEstimated:hh\\:mm\\:ss}";
			}
			if (label_ElapsedTime != null)
			{
				label_ElapsedTime.Text = $"{elapsed:hh\\:mm\\:ss}";
			}
			if (label_RemainingTime != null)
			{
				label_RemainingTime.Text = $"{remaining:hh\\:mm\\:ss}";
			}
			if (label_CurrentRepetition != null)
			{
				label_CurrentRepetition.Text = $"{currentRepetition}/{totalRepetitions}";
			}
		}

		private void RadioButton_Screen_CheckedChanged(object sender, EventArgs e)
		{
			RadioButton? checkedRadio = sender as RadioButton;
			if (checkedRadio != null && checkedRadio.Checked)
			{
				Screen[] screens = Screen.AllScreens;
				if (checkedRadio == radioButton_FirstScreen && screens.Length > 0)
				{
					_monitorXOffset = 0;
				}
				else if (checkedRadio == radioButton_SecondScreen && screens.Length > 1)
				{
					_monitorXOffset = screens[0].Bounds.X;
				}
				else
				{
					_monitorXOffset = 0;
				}
				UpdateCommonAreaOffset();
			}
		}

		private void UpdateCommonAreaOffset()
		{
			if (_inputManager != null)
			{
				_inputManager.SetMonitorXOffset(_monitorXOffset);
			}
		}

		private void RadioButton_LifeContent_CheckedChanged(object sender, EventArgs e)
		{
			RadioButton? checkedRadio = sender as RadioButton;
			if (checkedRadio != null && checkedRadio.Checked)
			{
				Form formToShow = null;
				TaskType selectedLifeActivity = TaskType.None;

				if (checkedRadio == radioButton_Harvest)
				{
					formToShow = _formHarvest;
					selectedLifeActivity = TaskType.Harvest;
				}
				else if (checkedRadio == radioButton_Hoeing)
				{
					formToShow = _formHoeing;
					selectedLifeActivity = TaskType.Hoeing;
				}
				else if (checkedRadio == radioButton_Mining)
				{
					formToShow = _formMining;
					selectedLifeActivity = TaskType.Mining;
				}
				else if (checkedRadio == radioButton_Wood)
				{
					formToShow = _formWood;
					selectedLifeActivity = TaskType.Woodcutting;
				}

				_selectedLifeActivityType = selectedLifeActivity;

				if (formToShow != null)
				{
					ShowContentForm(formToShow);
				}
			}
		}

		private void FormHarvest_ItemSelectedHandler(object? sender, CropType selectedCropType)
		{
			FormHome_ItemSelected(sender, selectedCropType);
		}
		private void FormHoeing_ItemSelectedHandler(object? sender, HoeingType selectedHoeingType)
		{
			FormHome_ItemSelected(sender, selectedHoeingType);
		}
		private void FormMining_ItemSelectedHandler(object? sender, MineralType selectedMineralType)
		{
			FormHome_ItemSelected(sender, selectedMineralType);
		}
		private void FormWood_ItemSelectedHandler(object? sender, WoodType selectedWoodType)
		{
			FormHome_ItemSelected(sender, selectedWoodType);
		}

		private void FormHome_ItemSelected(object? sender, Enum selectedItem)
		{
			_selectedDetailItem = selectedItem;
			// 메시지 박스는 이제 선택 사항
			// MessageBox.Show($"{TaskDefinition.GetEnumDescription(_selectedLifeActivityType)} - {TaskDefinition.GetEnumDescription(_selectedDetailItem)} 선택됨!", "항목 선택", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}


		private void button_Harvest_Click(object sender, EventArgs e)
		{
			if (_selectedLifeActivityType == TaskType.None)
			{
				MessageBox.Show("생활 활동 타입을 먼저 선택해주세요.", "시작 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			if (_selectedDetailItem == null)
			{
				MessageBox.Show("세부 항목을 먼저 선택해주세요.", "세부 항목 선택 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning); // 메시지 수정
				return;
			}

			int repetitions = trackBar1.Value;
			TaskConfig config = new TaskConfig(repetitions, false);

			BaseAutomationTask taskToStart = null;

			switch (_selectedLifeActivityType)
			{
				case TaskType.Harvest:
					if (_selectedDetailItem is CropType selectedCrop)
					{
						taskToStart = new TaskHarvest(selectedCrop);
					}
					break;
				case TaskType.Hoeing:
					if (_selectedDetailItem is HoeingType selectedHoeing)
					{
						taskToStart = new TaskHoeing(selectedHoeing);
					}
					break;
				case TaskType.Mining:
					if (_selectedDetailItem is MineralType selectedMineral)
					{
						taskToStart = new TaskMining(selectedMineral);
					}
					break;
				case TaskType.Woodcutting:
					if (_selectedDetailItem is WoodType selectedWood)
					{
						taskToStart = new TaskWood(selectedWood);
					}
					break;
					// 약초채집, 곤충채집 등 다른 TaskType에 대한 case 추가
			}

			if (taskToStart != null)
			{
				_taskManager.StartTask(taskToStart, config);
			}
			else
			{
				MessageBox.Show("선택된 활동에 해당하는 Task를 찾을 수 없습니다.", "시작 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}


		private void trackBar1_Scroll(object sender, EventArgs e)
		{
			label_Scroll.Text = trackBar1.Value.ToString();
		}

		private void button_Stop_Click(object sender, EventArgs e)
		{
			_taskManager.StopAllTasks();
		}

		private void AddFormToPanel(Form childForm)
		{
			childForm.TopLevel = false;
			childForm.FormBorderStyle = (FormBorderStyle)BorderStyle.None;
			childForm.Dock = DockStyle.Fill;
			panel_Life.Controls.Add(childForm);
			childForm.Hide();
		}

		private void ShowContentForm(Form formToShow)
		{
			foreach (Control control in panel_Life.Controls)
			{
				if (control is Form childForm)
				{
					childForm.Hide();
				}
			}
			formToShow.Show();
			formToShow.BringToFront();
		}

		private async void HotkeyManager_HotkeyFired(Keys key)
		{
			if (checkBox_KeyMapping.Checked)
			{
				var keyMaps = CommonArea.GetKeyMaps();
				if (keyMaps.TryGetValue(key, out Rectangle targetArea))
				{
					await _inputManager.SimulateTapAsync(targetArea, _taskManager.CurrentToken);
				}
			}
		}

		private void Form_Home_FormClosing(object sender, FormClosingEventArgs e)
		{
			_hotkeyManager?.Dispose();
		}
	}
}
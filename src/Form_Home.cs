using System.Threading.Tasks;
using static MOGI.TaskDefinition;

namespace MOGI
{
	public partial class Form_Home : Form
	{
		private Form_Harvest _formHarvest;
		private Form_Hoeing _formHoeing;
		private Form_Mining _formMining;
		private Form_Wood _formWood;
		private Form_Herb _formHerb;
		private Form_Insect _formInsect;

		private Dictionary<TaskType, Form> _lifeSkillForms;
		private Dictionary<TaskType, Func<Enum, BaseAutomationTask>> _taskFactory;

		private Task_Manager _taskManager;
		private Input_Manager _inputManager;
		private HotkeyManager _hotkeyManager;
		private int _monitorXOffset = 0;

		private TaskType _selectedLifeActivityType = TaskType.None; 
		private Enum? _selectedDetailItem = null;



		public Form_Home()
		{
			InitializeComponent();

			Initialize();
			DetectMonitorsAndSetRadioButtons();

			ShowContentForm(_formWood);
			_selectedLifeActivityType = TaskType.Woodcutting;
		}

		

		private void Initialize()
		{
			_taskManager = Task_Manager.Instance;
			_inputManager = Input_Manager.Instance;
			//_hotkeyManager = new HotkeyManager();

			InitializeFormsAndEvents();
			Initialize_UI();
			InitializeTaskFactory();
			InitializeLifeSkillButtons();
			//Initialize_HotKey();

			_taskManager.MousePositionChanged += TaskManager_MousePositionChanged;
			_taskManager.CurrentTaskNameChanged += TaskManager_CurrentTaskNameChanged;
			_taskManager.TaskProgressUpdated += TaskManager_TaskProgressUpdated;

			UpdateTaskTimes(TimeSpan.Zero, TimeSpan.Zero, TimeSpan.Zero, 0, 0);
		}

		private void InitializeFormsAndEvents()
		{
			_formHarvest = new Form_Harvest();
			_formHoeing = new Form_Hoeing();
			_formMining = new Form_Mining();
			_formWood = new Form_Wood();
			_formHerb = new Form_Herb();
			_formInsect = new Form_Insect();

			_lifeSkillForms = new Dictionary<TaskType, Form>
			{
				{ TaskType.Harvest, _formHarvest },
				{ TaskType.Hoeing, _formHoeing },
				{ TaskType.Mining, _formMining },
				{ TaskType.Woodcutting, _formWood },
				{ TaskType.HerbGathering, _formHerb },
				{ TaskType.InsectGathering, _formInsect }
			};

			_formHarvest.ItemSelected += (s, e) => FormHome_ItemSelected(s, e);
			_formHoeing.ItemSelected += (s, e) => FormHome_ItemSelected(s, e);
			_formMining.ItemSelected += (s, e) => FormHome_ItemSelected(s, e);
			_formWood.ItemSelected += (s, e) => FormHome_ItemSelected(s, e);
			_formHerb.ItemSelected += (s, e) => FormHome_ItemSelected(s, e);
			_formInsect.ItemSelected += (s, e) => FormHome_ItemSelected(s, e);

			foreach (var form in _lifeSkillForms.Values)
			{
				AddFormToPanel(form);
			}
		}

		private void InitializeTaskFactory()
		{
			_taskFactory = new Dictionary<TaskType, Func<Enum, BaseAutomationTask>>
											{
												{ TaskType.Harvest,       e => new TaskHarvest((CropType)e) },
												{ TaskType.Hoeing,        e => new TaskHoeing((HoeingType)e) },
												{ TaskType.Mining,        e => new TaskMining((MineralType)e) },
												{ TaskType.Woodcutting,   e => new TaskWood((WoodType)e) },
												{ TaskType.HerbGathering, e => new TaskHerb((HerbType)e) },
												{ TaskType.InsectGathering, e => new TaskInsect((InsectType)e) }
											};
		}


		private void InitializeLifeSkillButtons()
		{
			tableLayoutPanel1.AutoScroll = true;

			tableLayoutPanel1.Controls.Clear();
			tableLayoutPanel1.RowStyles.Clear();
			tableLayoutPanel1.RowCount = 0;

			var lifeSkillTypes = Enum.GetValues(typeof(LifeActivityType));

			foreach (LifeActivityType skillType in lifeSkillTypes)
			{
				TaskType taskType = (TaskType)skillType;

				tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));

				var button = new RadioButton
				{
					Text = GetEnumDescription(skillType),
					Tag = taskType,
					Appearance = Appearance.Button,
					Dock = DockStyle.Fill,
					TextAlign = ContentAlignment.MiddleCenter
				};

				button.CheckedChanged += LifeSkillButton_CheckedChanged;

				tableLayoutPanel1.Controls.Add(button);
				tableLayoutPanel1.RowCount++;
			}
		}

		private void LifeSkillButton_CheckedChanged(object sender, EventArgs e)
		{
			var checkedRadio = sender as RadioButton;
			if (checkedRadio != null && checkedRadio.Checked)
			{
				var selectedTaskType = (TaskType)checkedRadio.Tag;
				_selectedLifeActivityType = selectedTaskType;

				if (_lifeSkillForms.TryGetValue(selectedTaskType, out Form formToShow))
				{
					ShowContentForm(formToShow);
				}
			}
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

		private void FormHome_ItemSelected(object? sender, Enum selectedItem)
		{
			_selectedDetailItem = selectedItem;
		}


		private void Button_Start_Click(object sender, EventArgs e)
		{
			if (_selectedLifeActivityType == TaskType.None || _selectedDetailItem == null)
			{
				MessageBox.Show("생활 활동과 세부 항목을 모두 선택해주세요.", "시작 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			BaseAutomationTask taskToStart = null;

			if (_taskFactory.TryGetValue(_selectedLifeActivityType, out var factoryFunc))
			{
				taskToStart = factoryFunc(_selectedDetailItem);
			}

			if (taskToStart != null)
			{
				int repetitions = trackBar1.Value;
				TaskConfig config = new TaskConfig(repetitions, false);
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
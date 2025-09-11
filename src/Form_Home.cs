using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;
using MOGI;
using static MOGI.TaskDefinition;

namespace MOGI
{
	public partial class Form_Home : Form
	{
		#region 멤버 변수
		private Form_Harvest _formHarvest;
		private Form_Hoeing _formHoeing;
		private Form_Mining _formMining;
		private Form_Wood _formWood;
		private Form_Herb _formHerb;
		private Form_Insect _formInsect;

		private Dictionary<TaskType, Form> _lifeSkillForms;
		private Dictionary<TaskType, Func<Enum, BaseAutomationTask>> _taskFactory;

		private Task_Manager _taskManager;
		private ConfigManager _configManager => ConfigManager.Instance;

		private TaskType _selectedLifeActivityType = TaskType.None;
		private Enum _selectedDetailItem = null;

		// 자동 판매 기능 관련
		private System.Windows.Forms.Timer _sellTimer;
		private System.Windows.Forms.Timer _statusBlinkTimer;
		private bool _isBlinkOn = false;
		#endregion

		public Form_Home()
		{
			InitializeComponent();
			Initialize();
		}

		#region 초기화
		private void Initialize()
		{
			_taskManager = Task_Manager.Instance;

			InitializeFormsAndEvents();
			InitializeLifeSkillButtons();
			InitializeTaskFactory();
			InitializeAutoSellConfig();
			InitializeAutoSellUI();
			InitializeDefaultUI();
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

			_taskManager.MousePositionChanged += TaskManager_MousePositionChanged;
			_taskManager.CurrentTaskNameChanged += TaskManager_CurrentTaskNameChanged;
			_taskManager.TaskProgressUpdated += TaskManager_TaskProgressUpdated;
		}

		private void InitializeLifeSkillButtons()
		{
			tableLayoutPanel_LifeSkills.AutoScroll = true;
			tableLayoutPanel_LifeSkills.Controls.Clear();
			tableLayoutPanel_LifeSkills.RowStyles.Clear();
			tableLayoutPanel_LifeSkills.ColumnStyles.Clear();

			tableLayoutPanel_LifeSkills.ColumnCount = 2;
			tableLayoutPanel_LifeSkills.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
			tableLayoutPanel_LifeSkills.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));

			var lifeSkillTypes = Enum.GetValues(typeof(LifeActivityType)).Cast<LifeActivityType>().ToList();
			tableLayoutPanel_LifeSkills.RowCount = (int)Math.Ceiling(lifeSkillTypes.Count / 2.0);

			for (int i = 0; i < tableLayoutPanel_LifeSkills.RowCount; i++)
			{
				tableLayoutPanel_LifeSkills.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
			}

			for (int i = 0; i < lifeSkillTypes.Count; i++)
			{
				var skillType = lifeSkillTypes[i];
				var button = new RadioButton
				{
					Text = GetEnumDescription(skillType),
					Tag = (TaskType)skillType,
					Appearance = Appearance.Button,
					Dock = DockStyle.Fill,
					TextAlign = ContentAlignment.MiddleCenter,
					FlatStyle = FlatStyle.Flat,
					FlatAppearance = { BorderSize = 0, CheckedBackColor = Color.DodgerBlue }
				};
				button.CheckedChanged += LifeSkillButton_CheckedChanged;
				tableLayoutPanel_LifeSkills.Controls.Add(button, i % 2, i / 2);
			}

			// '나무 베기'를 기본으로 선택
			foreach (RadioButton button in tableLayoutPanel_LifeSkills.Controls)
			{
				if ((TaskType)button.Tag == TaskType.Woodcutting)
				{
					button.Checked = true;
					break;
				}
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

		private void InitializeAutoSellUI()
		{
			checkBox_ToggleAutoSell.CheckedChanged += CheckBox_ToggleAutoSell_CheckedChanged;
			trackBar_Interval.Scroll += TrackBar_Interval_Scroll;
			_sellTimer.Tick += SellTimer_Tick;
			_statusBlinkTimer.Tick += StatusBlinkTimer_Tick;

			trackBar_Interval.Value = 60;
			pictureBox_Status.BackColor = Color.Crimson;
			TrackBar_Interval_Scroll(null, null);
		}

		private void InitializeAutoSellConfig()
		{
			if (!_configManager.IsConfigLoadedFromFile)
			{
				var result = MessageBox.Show(
					$"설정 파일({ConfigManager.ConfigFileName})을 찾을 수 없습니다.\n\n기본 설정으로 새 파일을 생성하시겠습니까?",
					"설정 파일 생성",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Question);

				if (result == DialogResult.Yes)
				{
					var defaultConfig = new AppSettings
					{
						AutoSell = new AutoSellSettings
						{
							JunkItemNames = new List<string> { "통나무", "상급 통나무", "나뭇가지", "최상급 통나무", "나무 진액" }
						}
					};
					_configManager.SaveSettings(defaultConfig);
				}
			}

			SetSellListUi();
			_sellTimer = new System.Windows.Forms.Timer();
			_statusBlinkTimer = new System.Windows.Forms.Timer { Interval = 1500 };
		}

		private void InitializeDefaultUI()
		{
			UpdateTaskTimes(TimeSpan.Zero, TimeSpan.Zero, TimeSpan.Zero, 0, 0);
			trackBar_Repetitions.Value = 1;
			label_Repetitions.Text = $"{trackBar_Repetitions.Value} 회";
		}
		#endregion

		#region 자동 판매 기능
		private void SetSellListUi()
		{
			var autoSellSettings = _configManager.Settings.AutoSell;
			listBox_SellItems.Items.Clear();
			if (autoSellSettings?.JunkItemNames != null)
			{
				foreach (var item in autoSellSettings.JunkItemNames)
				{
					listBox_SellItems.Items.Add(item);
				}
			}
		}

		private void TrackBar_Interval_Scroll(object sender, EventArgs e)
		{
			trackBar_Interval.Value = (trackBar_Interval.Value / 5) * 5;
			int totalMinutes = trackBar_Interval.Value;

			if (totalMinutes >= 60)
			{
				int hours = totalMinutes / 60;
				int remainingMinutes = totalMinutes % 60;

				if (remainingMinutes == 0)
				{
					label_Interval.Text = $"{hours}시간마다";
				}
				else
				{
					label_Interval.Text = $"{hours}시간 {remainingMinutes}분마다";
				}
			}
			else
			{
				label_Interval.Text = $"{totalMinutes}분마다";
			}

			if (_sellTimer.Enabled)
			{
				_sellTimer.Interval = totalMinutes * 60 * 1000;
			}
		}

		private void CheckBox_ToggleAutoSell_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox_ToggleAutoSell.Checked)
			{
				_sellTimer.Interval = trackBar_Interval.Value * 60 * 1000;
				_sellTimer.Start();
				_statusBlinkTimer.Start();

				RunSellTask();
			}
			else
			{
				_sellTimer.Stop();
				_statusBlinkTimer.Stop();
				_taskManager.StopSellTask(); 
				pictureBox_Status.BackColor = Color.Crimson;
			}
		}

		private void StatusBlinkTimer_Tick(object sender, EventArgs e)
		{
			pictureBox_Status.BackColor = _isBlinkOn ? Color.MediumSeaGreen : Color.DarkGreen;
			_isBlinkOn = !_isBlinkOn;
		}

		private void SellTimer_Tick(object sender, EventArgs e)
		{
			RunSellTask();
		}

		private void RunSellTask()
		{
			if (_taskManager.IsSellTaskRunning()) return; // 이미 판매중이면 중복 실행 방지

			var sellTask = new TaskSellJunkItems(ConfigManager.Instance.Settings.AutoSell.JunkItemNames);
			_taskManager.StartSellTask(sellTask, new TaskConfig());
		}
		#endregion

		#region UI 이벤트 핸들러
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

		private void FormHome_ItemSelected(object sender, Enum selectedItem)
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
				int repetitions = trackBar_Repetitions.Value;
				TaskConfig config = new TaskConfig(repetitions, false);
				_taskManager.StartMainTask(taskToStart, config);
			}
			else
			{
				MessageBox.Show("선택된 활동에 해당하는 Task를 찾을 수 없습니다.", "시작 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void button_Stop_Click(object sender, EventArgs e)
		{
			_taskManager.StopAllTasks();
		}

		private void trackBar_Repetitions_Scroll(object sender, EventArgs e)
		{
			label_Repetitions.Text = $"{trackBar_Repetitions.Value} 회";
		}
		#endregion

		#region TaskManager 업데이트
		private void TaskManager_MousePositionChanged(object sender, Point e) => UpdateMouseCoordinates(e);
		private void TaskManager_CurrentTaskNameChanged(object sender, string e) => UpdateTaskLabel(e);
		private void TaskManager_TaskProgressUpdated(object sender, TaskProgressEventArgs e) => UpdateTaskTimes(e.TotalEstimatedTime, e.ElapsedTime, e.RemainingTime, e.CurrentRepetition, e.TotalRepetitions);

		private void UpdateMouseCoordinates(Point position)
		{
			if (InvokeRequired) { Invoke(new Action(() => UpdateMouseCoordinates(position))); return; }
			textBox_Mouse_X.Text = position.X.ToString();
			textBox_Mouse_Y.Text = position.Y.ToString();
		}

		private void UpdateTaskLabel(string taskName)
		{
			if (InvokeRequired) { Invoke(new Action(() => UpdateTaskLabel(taskName))); return; }
			label_CurrentTask.Text = taskName;
		}

		private void UpdateTaskTimes(TimeSpan total, TimeSpan elapsed, TimeSpan remaining, int currentRep, int totalReps)
		{
			if (InvokeRequired) { Invoke(new Action(() => UpdateTaskTimes(total, elapsed, remaining, currentRep, totalReps))); return; }
			label_TotalTime.Text = $"{total:hh\\:mm\\:ss}";
			label_ElapsedTime.Text = $"{elapsed:hh\\:mm\\:ss}";
			label_RemainingTime.Text = $"{remaining:hh\\:mm\\:ss}";
			label_CurrentRepetition.Text = $"{currentRep}/{totalReps}";
		}
		#endregion

		#region 헬퍼 메서드
		private void AddFormToPanel(Form childForm)
		{
			childForm.TopLevel = false;
			childForm.FormBorderStyle = FormBorderStyle.None;
			childForm.Dock = DockStyle.Fill;
			panel_Life.Controls.Add(childForm);
			childForm.Hide();
		}

		private void ShowContentForm(Form formToShow)
		{
			foreach (Control control in panel_Life.Controls)
			{
				if (control is Form childForm)
					childForm.Hide();
			}
			formToShow.Show();
		}
		#endregion
	}
}
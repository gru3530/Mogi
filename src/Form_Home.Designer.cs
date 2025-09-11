namespace MOGI
{
	partial class Form_Home
	{
		private System.ComponentModel.IContainer components = null;

		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		private void InitializeComponent()
		{
			tableLayoutPanel_Main = new TableLayoutPanel();
			panel_Left = new Panel();
			tableLayoutPanel_Actions = new TableLayoutPanel();
			button_Start = new Button();
			button_Stop = new Button();
			groupBox_Repetitions = new GroupBox();
			label_Repetitions = new Label();
			trackBar_Repetitions = new TrackBar();
			groupBox_Details = new GroupBox();
			panel_Life = new Panel();
			groupBox_LifeSkills = new GroupBox();
			tableLayoutPanel_LifeSkills = new TableLayoutPanel();
			label_Title_Settings = new Label();
			panel_Right = new Panel();
			groupBox_Mouse = new GroupBox();
			label1 = new Label();
			textBox_Mouse_X = new TextBox();
			label2 = new Label();
			textBox_Mouse_Y = new TextBox();
			groupBox_Screen = new GroupBox();
			tableLayoutPanel_Screen = new TableLayoutPanel();
			radioButton_FirstScreen = new RadioButton();
			radioButton_SecondScreen = new RadioButton();
			groupBox_AutoSell = new GroupBox();
			listBox_SellItems = new ListBox();
			label_SellListTitle = new Label();
			label_Interval = new Label();
			trackBar_Interval = new TrackBar();
			label_IntervalTitle = new Label();
			pictureBox_Status = new PictureBox();
			checkBox_ToggleAutoSell = new CheckBox();
			groupBox_Status = new GroupBox();
			label_CurrentRepetition = new Label();
			label7 = new Label();
			label_RemainingTime = new Label();
			label_ElapsedTime = new Label();
			label_TotalTime = new Label();
			label_CurrentTask = new Label();
			label6 = new Label();
			label5 = new Label();
			label4 = new Label();
			label3 = new Label();
			label_Title_Status = new Label();
			tableLayoutPanel_Main.SuspendLayout();
			panel_Left.SuspendLayout();
			tableLayoutPanel_Actions.SuspendLayout();
			groupBox_Repetitions.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)trackBar_Repetitions).BeginInit();
			groupBox_Details.SuspendLayout();
			groupBox_LifeSkills.SuspendLayout();
			panel_Right.SuspendLayout();
			groupBox_Mouse.SuspendLayout();
			groupBox_Screen.SuspendLayout();
			tableLayoutPanel_Screen.SuspendLayout();
			groupBox_AutoSell.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)trackBar_Interval).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox_Status).BeginInit();
			groupBox_Status.SuspendLayout();
			SuspendLayout();
			// 
			// tableLayoutPanel_Main
			// 
			tableLayoutPanel_Main.ColumnCount = 2;
			tableLayoutPanel_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
			tableLayoutPanel_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
			tableLayoutPanel_Main.Controls.Add(panel_Left, 0, 0);
			tableLayoutPanel_Main.Controls.Add(panel_Right, 1, 0);
			tableLayoutPanel_Main.Dock = DockStyle.Fill;
			tableLayoutPanel_Main.Location = new Point(0, 0);
			tableLayoutPanel_Main.Name = "tableLayoutPanel_Main";
			tableLayoutPanel_Main.RowCount = 1;
			tableLayoutPanel_Main.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
			tableLayoutPanel_Main.Size = new Size(800, 600);
			tableLayoutPanel_Main.TabIndex = 0;
			// 
			// panel_Left
			// 
			panel_Left.Controls.Add(tableLayoutPanel_Actions);
			panel_Left.Controls.Add(groupBox_Repetitions);
			panel_Left.Controls.Add(groupBox_Details);
			panel_Left.Controls.Add(groupBox_LifeSkills);
			panel_Left.Controls.Add(label_Title_Settings);
			panel_Left.Dock = DockStyle.Fill;
			panel_Left.Location = new Point(3, 3);
			panel_Left.Name = "panel_Left";
			panel_Left.Padding = new Padding(10);
			panel_Left.Size = new Size(394, 594);
			panel_Left.TabIndex = 0;
			// 
			// tableLayoutPanel_Actions
			// 
			tableLayoutPanel_Actions.ColumnCount = 2;
			tableLayoutPanel_Actions.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
			tableLayoutPanel_Actions.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
			tableLayoutPanel_Actions.Controls.Add(button_Start, 0, 0);
			tableLayoutPanel_Actions.Controls.Add(button_Stop, 1, 0);
			tableLayoutPanel_Actions.Dock = DockStyle.Bottom;
			tableLayoutPanel_Actions.Location = new Point(10, 524);
			tableLayoutPanel_Actions.Name = "tableLayoutPanel_Actions";
			tableLayoutPanel_Actions.RowCount = 1;
			tableLayoutPanel_Actions.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
			tableLayoutPanel_Actions.Size = new Size(374, 60);
			tableLayoutPanel_Actions.TabIndex = 4;
			// 
			// button_Start
			// 
			button_Start.BackColor = Color.FromArgb(0, 122, 204);
			button_Start.Dock = DockStyle.Fill;
			button_Start.FlatAppearance.BorderSize = 0;
			button_Start.FlatStyle = FlatStyle.Flat;
			button_Start.Font = new Font("맑은 고딕", 12F, FontStyle.Bold);
			button_Start.Location = new Point(3, 3);
			button_Start.Name = "button_Start";
			button_Start.Size = new Size(181, 54);
			button_Start.TabIndex = 0;
			button_Start.Text = "▶ 시작";
			button_Start.UseVisualStyleBackColor = false;
			button_Start.Click += Button_Start_Click;
			// 
			// button_Stop
			// 
			button_Stop.BackColor = Color.FromArgb(63, 63, 70);
			button_Stop.Dock = DockStyle.Fill;
			button_Stop.FlatAppearance.BorderSize = 0;
			button_Stop.FlatStyle = FlatStyle.Flat;
			button_Stop.Font = new Font("맑은 고딕", 12F, FontStyle.Bold);
			button_Stop.Location = new Point(190, 3);
			button_Stop.Name = "button_Stop";
			button_Stop.Size = new Size(181, 54);
			button_Stop.TabIndex = 1;
			button_Stop.Text = "■ 정지";
			button_Stop.UseVisualStyleBackColor = false;
			button_Stop.Click += button_Stop_Click;
			// 
			// groupBox_Repetitions
			// 
			groupBox_Repetitions.Controls.Add(label_Repetitions);
			groupBox_Repetitions.Controls.Add(trackBar_Repetitions);
			groupBox_Repetitions.Dock = DockStyle.Top;
			groupBox_Repetitions.ForeColor = Color.White;
			groupBox_Repetitions.Location = new Point(10, 440);
			groupBox_Repetitions.Name = "groupBox_Repetitions";
			groupBox_Repetitions.Size = new Size(374, 78);
			groupBox_Repetitions.TabIndex = 3;
			groupBox_Repetitions.TabStop = false;
			groupBox_Repetitions.Text = "반복 횟수 설정";
			// 
			// label_Repetitions
			// 
			label_Repetitions.Dock = DockStyle.Fill;
			label_Repetitions.Font = new Font("맑은 고딕", 11.25F, FontStyle.Bold);
			label_Repetitions.Location = new Point(284, 19);
			label_Repetitions.Name = "label_Repetitions";
			label_Repetitions.Size = new Size(87, 56);
			label_Repetitions.TabIndex = 1;
			label_Repetitions.Text = "1 회";
			label_Repetitions.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// trackBar_Repetitions
			// 
			trackBar_Repetitions.Dock = DockStyle.Left;
			trackBar_Repetitions.Location = new Point(3, 19);
			trackBar_Repetitions.Maximum = 300;
			trackBar_Repetitions.Minimum = 1;
			trackBar_Repetitions.Name = "trackBar_Repetitions";
			trackBar_Repetitions.Size = new Size(281, 56);
			trackBar_Repetitions.TabIndex = 0;
			trackBar_Repetitions.TickFrequency = 30;
			trackBar_Repetitions.Value = 1;
			trackBar_Repetitions.Scroll += trackBar_Repetitions_Scroll;
			// 
			// groupBox_Details
			// 
			groupBox_Details.Controls.Add(panel_Life);
			groupBox_Details.Dock = DockStyle.Top;
			groupBox_Details.ForeColor = Color.White;
			groupBox_Details.Location = new Point(10, 220);
			groupBox_Details.Name = "groupBox_Details";
			groupBox_Details.Padding = new Padding(10);
			groupBox_Details.Size = new Size(374, 220);
			groupBox_Details.TabIndex = 2;
			groupBox_Details.TabStop = false;
			groupBox_Details.Text = "세부 항목";
			// 
			// panel_Life
			// 
			panel_Life.Dock = DockStyle.Fill;
			panel_Life.Location = new Point(10, 26);
			panel_Life.Name = "panel_Life";
			panel_Life.Size = new Size(354, 184);
			panel_Life.TabIndex = 0;
			// 
			// groupBox_LifeSkills
			// 
			groupBox_LifeSkills.Controls.Add(tableLayoutPanel_LifeSkills);
			groupBox_LifeSkills.Dock = DockStyle.Top;
			groupBox_LifeSkills.ForeColor = Color.White;
			groupBox_LifeSkills.Location = new Point(10, 50);
			groupBox_LifeSkills.Name = "groupBox_LifeSkills";
			groupBox_LifeSkills.Padding = new Padding(10);
			groupBox_LifeSkills.Size = new Size(374, 170);
			groupBox_LifeSkills.TabIndex = 1;
			groupBox_LifeSkills.TabStop = false;
			groupBox_LifeSkills.Text = "생활 스킬";
			// 
			// tableLayoutPanel_LifeSkills
			// 
			tableLayoutPanel_LifeSkills.ColumnCount = 2;
			tableLayoutPanel_LifeSkills.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
			tableLayoutPanel_LifeSkills.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
			tableLayoutPanel_LifeSkills.Dock = DockStyle.Fill;
			tableLayoutPanel_LifeSkills.Location = new Point(10, 26);
			tableLayoutPanel_LifeSkills.Name = "tableLayoutPanel_LifeSkills";
			tableLayoutPanel_LifeSkills.RowCount = 2;
			tableLayoutPanel_LifeSkills.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
			tableLayoutPanel_LifeSkills.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
			tableLayoutPanel_LifeSkills.Size = new Size(354, 134);
			tableLayoutPanel_LifeSkills.TabIndex = 0;
			// 
			// label_Title_Settings
			// 
			label_Title_Settings.Dock = DockStyle.Top;
			label_Title_Settings.Font = new Font("맑은 고딕", 15.75F, FontStyle.Bold);
			label_Title_Settings.Location = new Point(10, 10);
			label_Title_Settings.Name = "label_Title_Settings";
			label_Title_Settings.Size = new Size(374, 40);
			label_Title_Settings.TabIndex = 0;
			label_Title_Settings.Text = "⚙️ 작업 설정";
			label_Title_Settings.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// panel_Right
			// 
			panel_Right.Controls.Add(groupBox_Mouse);
			panel_Right.Controls.Add(groupBox_Screen);
			panel_Right.Controls.Add(groupBox_AutoSell);
			panel_Right.Controls.Add(groupBox_Status);
			panel_Right.Controls.Add(label_Title_Status);
			panel_Right.Dock = DockStyle.Fill;
			panel_Right.Location = new Point(403, 3);
			panel_Right.Name = "panel_Right";
			panel_Right.Padding = new Padding(10);
			panel_Right.Size = new Size(394, 594);
			panel_Right.TabIndex = 1;
			// 
			// groupBox_Mouse
			// 
			groupBox_Mouse.Controls.Add(label1);
			groupBox_Mouse.Controls.Add(textBox_Mouse_X);
			groupBox_Mouse.Controls.Add(label2);
			groupBox_Mouse.Controls.Add(textBox_Mouse_Y);
			groupBox_Mouse.Dock = DockStyle.Bottom;
			groupBox_Mouse.ForeColor = Color.White;
			groupBox_Mouse.Location = new Point(10, 524);
			groupBox_Mouse.Name = "groupBox_Mouse";
			groupBox_Mouse.Size = new Size(374, 60);
			groupBox_Mouse.TabIndex = 3;
			groupBox_Mouse.TabStop = false;
			groupBox_Mouse.Text = "기타 정보";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(17, 28);
			label1.Name = "label1";
			label1.Size = new Size(57, 15);
			label1.TabIndex = 0;
			label1.Text = "마우스 X:";
			// 
			// textBox_Mouse_X
			// 
			textBox_Mouse_X.BackColor = Color.FromArgb(63, 63, 70);
			textBox_Mouse_X.BorderStyle = BorderStyle.FixedSingle;
			textBox_Mouse_X.ForeColor = Color.White;
			textBox_Mouse_X.Location = new Point(86, 25);
			textBox_Mouse_X.Name = "textBox_Mouse_X";
			textBox_Mouse_X.ReadOnly = true;
			textBox_Mouse_X.Size = new Size(80, 23);
			textBox_Mouse_X.TabIndex = 1;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(194, 28);
			label2.Name = "label2";
			label2.Size = new Size(57, 15);
			label2.TabIndex = 2;
			label2.Text = "마우스 Y:";
			// 
			// textBox_Mouse_Y
			// 
			textBox_Mouse_Y.BackColor = Color.FromArgb(63, 63, 70);
			textBox_Mouse_Y.BorderStyle = BorderStyle.FixedSingle;
			textBox_Mouse_Y.ForeColor = Color.White;
			textBox_Mouse_Y.Location = new Point(262, 25);
			textBox_Mouse_Y.Name = "textBox_Mouse_Y";
			textBox_Mouse_Y.ReadOnly = true;
			textBox_Mouse_Y.Size = new Size(80, 23);
			textBox_Mouse_Y.TabIndex = 3;
			// 
			// groupBox_Screen
			// 
			groupBox_Screen.Controls.Add(tableLayoutPanel_Screen);
			groupBox_Screen.Dock = DockStyle.Top;
			groupBox_Screen.ForeColor = Color.White;
			groupBox_Screen.Location = new Point(10, 430);
			groupBox_Screen.Name = "groupBox_Screen";
			groupBox_Screen.Padding = new Padding(10);
			groupBox_Screen.Size = new Size(374, 88);
			groupBox_Screen.TabIndex = 4;
			groupBox_Screen.TabStop = false;
			groupBox_Screen.Text = "모니터 선택";
			// 
			// tableLayoutPanel_Screen
			// 
			tableLayoutPanel_Screen.ColumnCount = 2;
			tableLayoutPanel_Screen.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
			tableLayoutPanel_Screen.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
			tableLayoutPanel_Screen.Controls.Add(radioButton_FirstScreen, 0, 0);
			tableLayoutPanel_Screen.Controls.Add(radioButton_SecondScreen, 1, 0);
			tableLayoutPanel_Screen.Dock = DockStyle.Fill;
			tableLayoutPanel_Screen.Location = new Point(10, 26);
			tableLayoutPanel_Screen.Name = "tableLayoutPanel_Screen";
			tableLayoutPanel_Screen.RowCount = 1;
			tableLayoutPanel_Screen.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
			tableLayoutPanel_Screen.Size = new Size(354, 52);
			tableLayoutPanel_Screen.TabIndex = 0;
			// 
			// radioButton_FirstScreen
			// 
			radioButton_FirstScreen.Appearance = Appearance.Button;
			radioButton_FirstScreen.Dock = DockStyle.Fill;
			radioButton_FirstScreen.FlatAppearance.CheckedBackColor = Color.DodgerBlue;
			radioButton_FirstScreen.FlatStyle = FlatStyle.Flat;
			radioButton_FirstScreen.Location = new Point(3, 3);
			radioButton_FirstScreen.Name = "radioButton_FirstScreen";
			radioButton_FirstScreen.Size = new Size(171, 46);
			radioButton_FirstScreen.TabIndex = 0;
			radioButton_FirstScreen.TabStop = true;
			radioButton_FirstScreen.Text = "1번 화면";
			radioButton_FirstScreen.TextAlign = ContentAlignment.MiddleCenter;
			radioButton_FirstScreen.UseVisualStyleBackColor = true;
			// 
			// radioButton_SecondScreen
			// 
			radioButton_SecondScreen.Appearance = Appearance.Button;
			radioButton_SecondScreen.Dock = DockStyle.Fill;
			radioButton_SecondScreen.FlatAppearance.CheckedBackColor = Color.DodgerBlue;
			radioButton_SecondScreen.FlatStyle = FlatStyle.Flat;
			radioButton_SecondScreen.Location = new Point(180, 3);
			radioButton_SecondScreen.Name = "radioButton_SecondScreen";
			radioButton_SecondScreen.Size = new Size(171, 46);
			radioButton_SecondScreen.TabIndex = 1;
			radioButton_SecondScreen.TabStop = true;
			radioButton_SecondScreen.Text = "2번 화면";
			radioButton_SecondScreen.TextAlign = ContentAlignment.MiddleCenter;
			radioButton_SecondScreen.UseVisualStyleBackColor = true;
			// 
			// groupBox_AutoSell
			// 
			groupBox_AutoSell.Controls.Add(listBox_SellItems);
			groupBox_AutoSell.Controls.Add(label_SellListTitle);
			groupBox_AutoSell.Controls.Add(label_Interval);
			groupBox_AutoSell.Controls.Add(trackBar_Interval);
			groupBox_AutoSell.Controls.Add(label_IntervalTitle);
			groupBox_AutoSell.Controls.Add(pictureBox_Status);
			groupBox_AutoSell.Controls.Add(checkBox_ToggleAutoSell);
			groupBox_AutoSell.Dock = DockStyle.Top;
			groupBox_AutoSell.ForeColor = Color.White;
			groupBox_AutoSell.Location = new Point(10, 200);
			groupBox_AutoSell.Name = "groupBox_AutoSell";
			groupBox_AutoSell.Size = new Size(374, 230);
			groupBox_AutoSell.TabIndex = 2;
			groupBox_AutoSell.TabStop = false;
			groupBox_AutoSell.Text = "잡템 자동 판매";
			// 
			// listBox_SellItems
			// 
			listBox_SellItems.BackColor = Color.FromArgb(63, 63, 70);
			listBox_SellItems.BorderStyle = BorderStyle.FixedSingle;
			listBox_SellItems.ForeColor = Color.White;
			listBox_SellItems.FormattingEnabled = true;
			listBox_SellItems.ItemHeight = 15;
			listBox_SellItems.Location = new Point(17, 137);
			listBox_SellItems.Name = "listBox_SellItems";
			listBox_SellItems.Size = new Size(341, 77);
			listBox_SellItems.TabIndex = 6;
			// 
			// label_SellListTitle
			// 
			label_SellListTitle.AutoSize = true;
			label_SellListTitle.Location = new Point(17, 119);
			label_SellListTitle.Name = "label_SellListTitle";
			label_SellListTitle.Size = new Size(130, 15);
			label_SellListTitle.TabIndex = 5;
			label_SellListTitle.Text = "판매 목록 (config.json)";
			// 
			// label_Interval
			// 
			label_Interval.Font = new Font("맑은 고딕", 9.75F, FontStyle.Bold);
			label_Interval.Location = new Point(284, 69);
			label_Interval.Name = "label_Interval";
			label_Interval.Size = new Size(84, 23);
			label_Interval.TabIndex = 4;
			label_Interval.Text = "60 분마다";
			label_Interval.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// trackBar_Interval
			// 
			trackBar_Interval.Location = new Point(13, 69);
			trackBar_Interval.Maximum = 300;
			trackBar_Interval.Minimum = 5;
			trackBar_Interval.Name = "trackBar_Interval";
			trackBar_Interval.Size = new Size(265, 45);
			trackBar_Interval.SmallChange = 5;
			trackBar_Interval.TabIndex = 3;
			trackBar_Interval.TickFrequency = 30;
			trackBar_Interval.Value = 60;
			trackBar_Interval.Scroll += TrackBar_Interval_Scroll;
			// 
			// label_IntervalTitle
			// 
			label_IntervalTitle.AutoSize = true;
			label_IntervalTitle.Location = new Point(17, 51);
			label_IntervalTitle.Name = "label_IntervalTitle";
			label_IntervalTitle.Size = new Size(59, 15);
			label_IntervalTitle.TabIndex = 2;
			label_IntervalTitle.Text = "판매 주기";
			// 
			// pictureBox_Status
			// 
			pictureBox_Status.BackColor = Color.Crimson;
			pictureBox_Status.BorderStyle = BorderStyle.FixedSingle;
			pictureBox_Status.Location = new Point(338, 26);
			pictureBox_Status.Name = "pictureBox_Status";
			pictureBox_Status.Size = new Size(20, 20);
			pictureBox_Status.TabIndex = 1;
			pictureBox_Status.TabStop = false;
			// 
			// checkBox_ToggleAutoSell
			// 
			checkBox_ToggleAutoSell.Appearance = Appearance.Button;
			checkBox_ToggleAutoSell.BackColor = Color.FromArgb(63, 63, 70);
			checkBox_ToggleAutoSell.FlatAppearance.CheckedBackColor = Color.FromArgb(0, 122, 204);
			checkBox_ToggleAutoSell.FlatStyle = FlatStyle.Flat;
			checkBox_ToggleAutoSell.Location = new Point(17, 22);
			checkBox_ToggleAutoSell.Name = "checkBox_ToggleAutoSell";
			checkBox_ToggleAutoSell.Size = new Size(126, 26);
			checkBox_ToggleAutoSell.TabIndex = 0;
			checkBox_ToggleAutoSell.Text = "자동판매 활성화";
			checkBox_ToggleAutoSell.TextAlign = ContentAlignment.MiddleCenter;
			checkBox_ToggleAutoSell.UseVisualStyleBackColor = false;
			checkBox_ToggleAutoSell.CheckedChanged += CheckBox_ToggleAutoSell_CheckedChanged;
			// 
			// groupBox_Status
			// 
			groupBox_Status.Controls.Add(label_CurrentRepetition);
			groupBox_Status.Controls.Add(label7);
			groupBox_Status.Controls.Add(label_RemainingTime);
			groupBox_Status.Controls.Add(label_ElapsedTime);
			groupBox_Status.Controls.Add(label_TotalTime);
			groupBox_Status.Controls.Add(label_CurrentTask);
			groupBox_Status.Controls.Add(label6);
			groupBox_Status.Controls.Add(label5);
			groupBox_Status.Controls.Add(label4);
			groupBox_Status.Controls.Add(label3);
			groupBox_Status.Dock = DockStyle.Top;
			groupBox_Status.ForeColor = Color.White;
			groupBox_Status.Location = new Point(10, 50);
			groupBox_Status.Name = "groupBox_Status";
			groupBox_Status.Size = new Size(374, 150);
			groupBox_Status.TabIndex = 1;
			groupBox_Status.TabStop = false;
			groupBox_Status.Text = "현재 상태";
			// 
			// label_CurrentRepetition
			// 
			label_CurrentRepetition.AutoSize = true;
			label_CurrentRepetition.Location = new Point(100, 116);
			label_CurrentRepetition.Name = "label_CurrentRepetition";
			label_CurrentRepetition.Size = new Size(26, 15);
			label_CurrentRepetition.TabIndex = 9;
			label_CurrentRepetition.Text = "0/0";
			// 
			// label7
			// 
			label7.AutoSize = true;
			label7.Font = new Font("맑은 고딕", 9F, FontStyle.Bold);
			label7.Location = new Point(17, 116);
			label7.Name = "label7";
			label7.Size = new Size(62, 15);
			label7.TabIndex = 8;
			label7.Text = "진행 횟수:";
			// 
			// label_RemainingTime
			// 
			label_RemainingTime.AutoSize = true;
			label_RemainingTime.Location = new Point(100, 92);
			label_RemainingTime.Name = "label_RemainingTime";
			label_RemainingTime.Size = new Size(55, 15);
			label_RemainingTime.TabIndex = 7;
			label_RemainingTime.Text = "00:00:00";
			// 
			// label_ElapsedTime
			// 
			label_ElapsedTime.AutoSize = true;
			label_ElapsedTime.Location = new Point(100, 68);
			label_ElapsedTime.Name = "label_ElapsedTime";
			label_ElapsedTime.Size = new Size(55, 15);
			label_ElapsedTime.TabIndex = 6;
			label_ElapsedTime.Text = "00:00:00";
			// 
			// label_TotalTime
			// 
			label_TotalTime.AutoSize = true;
			label_TotalTime.Location = new Point(100, 44);
			label_TotalTime.Name = "label_TotalTime";
			label_TotalTime.Size = new Size(55, 15);
			label_TotalTime.TabIndex = 5;
			label_TotalTime.Text = "00:00:00";
			// 
			// label_CurrentTask
			// 
			label_CurrentTask.AutoSize = true;
			label_CurrentTask.Font = new Font("맑은 고딕", 9.75F, FontStyle.Bold);
			label_CurrentTask.ForeColor = Color.FromArgb(0, 192, 192);
			label_CurrentTask.Location = new Point(99, 20);
			label_CurrentTask.Name = "label_CurrentTask";
			label_CurrentTask.Size = new Size(47, 17);
			label_CurrentTask.TabIndex = 4;
			label_CurrentTask.Text = "대기중";
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Font = new Font("맑은 고딕", 9F, FontStyle.Bold);
			label6.Location = new Point(17, 92);
			label6.Name = "label6";
			label6.Size = new Size(62, 15);
			label6.TabIndex = 3;
			label6.Text = "남은 시간:";
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Font = new Font("맑은 고딕", 9F, FontStyle.Bold);
			label5.Location = new Point(17, 68);
			label5.Name = "label5";
			label5.Size = new Size(62, 15);
			label5.TabIndex = 2;
			label5.Text = "진행 시간:";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Font = new Font("맑은 고딕", 9F, FontStyle.Bold);
			label4.Location = new Point(17, 44);
			label4.Name = "label4";
			label4.Size = new Size(62, 15);
			label4.TabIndex = 1;
			label4.Text = "예상 시간:";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Font = new Font("맑은 고딕", 9.75F, FontStyle.Bold);
			label3.Location = new Point(17, 20);
			label3.Name = "label3";
			label3.Size = new Size(37, 17);
			label3.TabIndex = 0;
			label3.Text = "상태:";
			// 
			// label_Title_Status
			// 
			label_Title_Status.Dock = DockStyle.Top;
			label_Title_Status.Font = new Font("맑은 고딕", 15.75F, FontStyle.Bold);
			label_Title_Status.Location = new Point(10, 10);
			label_Title_Status.Name = "label_Title_Status";
			label_Title_Status.Size = new Size(374, 40);
			label_Title_Status.TabIndex = 0;
			label_Title_Status.Text = "📊 상태 및 도구";
			label_Title_Status.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// Form_Home
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.FromArgb(45, 45, 48);
			ClientSize = new Size(800, 600);
			Controls.Add(tableLayoutPanel_Main);
			ForeColor = Color.White;
			Name = "Form_Home";
			Text = "MOGI Automation";
			tableLayoutPanel_Main.ResumeLayout(false);
			panel_Left.ResumeLayout(false);
			tableLayoutPanel_Actions.ResumeLayout(false);
			groupBox_Repetitions.ResumeLayout(false);
			groupBox_Repetitions.PerformLayout();
			((System.ComponentModel.ISupportInitialize)trackBar_Repetitions).EndInit();
			groupBox_Details.ResumeLayout(false);
			groupBox_LifeSkills.ResumeLayout(false);
			panel_Right.ResumeLayout(false);
			groupBox_Mouse.ResumeLayout(false);
			groupBox_Mouse.PerformLayout();
			groupBox_Screen.ResumeLayout(false);
			tableLayoutPanel_Screen.ResumeLayout(false);
			groupBox_AutoSell.ResumeLayout(false);
			groupBox_AutoSell.PerformLayout();
			((System.ComponentModel.ISupportInitialize)trackBar_Interval).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox_Status).EndInit();
			groupBox_Status.ResumeLayout(false);
			groupBox_Status.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_Main;
		private System.Windows.Forms.Panel panel_Left;
		private System.Windows.Forms.Panel panel_Right;
		private System.Windows.Forms.Label label_Title_Settings;
		private System.Windows.Forms.Label label_Title_Status;
		private System.Windows.Forms.GroupBox groupBox_LifeSkills;
		private System.Windows.Forms.GroupBox groupBox_Details;
		private System.Windows.Forms.GroupBox groupBox_Repetitions;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_Actions;
		private System.Windows.Forms.Button button_Start;
		private System.Windows.Forms.Button button_Stop;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_LifeSkills;
		private System.Windows.Forms.Panel panel_Life;
		private System.Windows.Forms.TrackBar trackBar_Repetitions;
		private System.Windows.Forms.Label label_Repetitions;
		private System.Windows.Forms.GroupBox groupBox_Status;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label_CurrentTask;
		private System.Windows.Forms.Label label_TotalTime;
		private System.Windows.Forms.Label label_ElapsedTime;
		private System.Windows.Forms.Label label_RemainingTime;
		private System.Windows.Forms.Label label_CurrentRepetition;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.GroupBox groupBox_AutoSell;
		private System.Windows.Forms.CheckBox checkBox_ToggleAutoSell;
		private System.Windows.Forms.PictureBox pictureBox_Status;
		private System.Windows.Forms.Label label_IntervalTitle;
		private System.Windows.Forms.TrackBar trackBar_Interval;
		private System.Windows.Forms.Label label_Interval;
		private System.Windows.Forms.Label label_SellListTitle;
		private System.Windows.Forms.ListBox listBox_SellItems;
		private System.Windows.Forms.GroupBox groupBox_Mouse;
		private System.Windows.Forms.TextBox textBox_Mouse_X;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox_Mouse_Y;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox_Screen;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_Screen;
		private System.Windows.Forms.RadioButton radioButton_FirstScreen;
		private System.Windows.Forms.RadioButton radioButton_SecondScreen;
	}
}
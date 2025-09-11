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
			this.tableLayoutPanel_Main = new System.Windows.Forms.TableLayoutPanel();
			this.panel_Left = new System.Windows.Forms.Panel();
			this.tableLayoutPanel_Actions = new System.Windows.Forms.TableLayoutPanel();
			this.button_Start = new System.Windows.Forms.Button();
			this.button_Stop = new System.Windows.Forms.Button();
			this.groupBox_Repetitions = new System.Windows.Forms.GroupBox();
			this.label_Repetitions = new System.Windows.Forms.Label();
			this.trackBar_Repetitions = new System.Windows.Forms.TrackBar();
			this.groupBox_Details = new System.Windows.Forms.GroupBox();
			this.panel_Life = new System.Windows.Forms.Panel();
			this.groupBox_LifeSkills = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel_LifeSkills = new System.Windows.Forms.TableLayoutPanel();
			this.label_Title_Settings = new System.Windows.Forms.Label();
			this.panel_Right = new System.Windows.Forms.Panel();
			this.groupBox_Mouse = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox_Mouse_X = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox_Mouse_Y = new System.Windows.Forms.TextBox();
			this.groupBox_Screen = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel_Screen = new System.Windows.Forms.TableLayoutPanel();
			this.radioButton_FirstScreen = new System.Windows.Forms.RadioButton();
			this.radioButton_SecondScreen = new System.Windows.Forms.RadioButton();
			this.groupBox_AutoSell = new System.Windows.Forms.GroupBox();
			this.listBox_SellItems = new System.Windows.Forms.ListBox();
			this.label_SellListTitle = new System.Windows.Forms.Label();
			this.label_Interval = new System.Windows.Forms.Label();
			this.trackBar_Interval = new System.Windows.Forms.TrackBar();
			this.label_IntervalTitle = new System.Windows.Forms.Label();
			this.pictureBox_Status = new System.Windows.Forms.PictureBox();
			this.checkBox_ToggleAutoSell = new System.Windows.Forms.CheckBox();
			this.groupBox_Status = new System.Windows.Forms.GroupBox();
			this.label_CurrentRepetition = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label_RemainingTime = new System.Windows.Forms.Label();
			this.label_ElapsedTime = new System.Windows.Forms.Label();
			this.label_TotalTime = new System.Windows.Forms.Label();
			this.label_CurrentTask = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label_Title_Status = new System.Windows.Forms.Label();
			this.tableLayoutPanel_Main.SuspendLayout();
			this.panel_Left.SuspendLayout();
			this.tableLayoutPanel_Actions.SuspendLayout();
			this.groupBox_Repetitions.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBar_Repetitions)).BeginInit();
			this.groupBox_Details.SuspendLayout();
			this.groupBox_LifeSkills.SuspendLayout();
			this.panel_Right.SuspendLayout();
			this.groupBox_Mouse.SuspendLayout();
			this.groupBox_Screen.SuspendLayout();
			this.tableLayoutPanel_Screen.SuspendLayout();
			this.groupBox_AutoSell.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBar_Interval)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_Status)).BeginInit();
			this.groupBox_Status.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel_Main
			// 
			this.tableLayoutPanel_Main.ColumnCount = 2;
			this.tableLayoutPanel_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel_Main.Controls.Add(this.panel_Left, 0, 0);
			this.tableLayoutPanel_Main.Controls.Add(this.panel_Right, 1, 0);
			this.tableLayoutPanel_Main.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel_Main.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel_Main.Name = "tableLayoutPanel_Main";
			this.tableLayoutPanel_Main.RowCount = 1;
			this.tableLayoutPanel_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel_Main.Size = new System.Drawing.Size(800, 600);
			this.tableLayoutPanel_Main.TabIndex = 0;
			// 
			// panel_Left
			// 
			this.panel_Left.Controls.Add(this.tableLayoutPanel_Actions);
			this.panel_Left.Controls.Add(this.groupBox_Repetitions);
			this.panel_Left.Controls.Add(this.groupBox_Details);
			this.panel_Left.Controls.Add(this.groupBox_LifeSkills);
			this.panel_Left.Controls.Add(this.label_Title_Settings);
			this.panel_Left.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel_Left.Location = new System.Drawing.Point(3, 3);
			this.panel_Left.Name = "panel_Left";
			this.panel_Left.Padding = new System.Windows.Forms.Padding(10);
			this.panel_Left.Size = new System.Drawing.Size(394, 594);
			this.panel_Left.TabIndex = 0;
			// 
			// tableLayoutPanel_Actions
			// 
			this.tableLayoutPanel_Actions.ColumnCount = 2;
			this.tableLayoutPanel_Actions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel_Actions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel_Actions.Controls.Add(this.button_Start, 0, 0);
			this.tableLayoutPanel_Actions.Controls.Add(this.button_Stop, 1, 0);
			this.tableLayoutPanel_Actions.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.tableLayoutPanel_Actions.Location = new System.Drawing.Point(10, 524);
			this.tableLayoutPanel_Actions.Name = "tableLayoutPanel_Actions";
			this.tableLayoutPanel_Actions.RowCount = 1;
			this.tableLayoutPanel_Actions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel_Actions.Size = new System.Drawing.Size(374, 60);
			this.tableLayoutPanel_Actions.TabIndex = 4;
			// 
			// button_Start
			// 
			this.button_Start.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
			this.button_Start.Dock = System.Windows.Forms.DockStyle.Fill;
			this.button_Start.FlatAppearance.BorderSize = 0;
			this.button_Start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button_Start.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
			this.button_Start.Location = new System.Drawing.Point(3, 3);
			this.button_Start.Name = "button_Start";
			this.button_Start.Size = new System.Drawing.Size(181, 54);
			this.button_Start.TabIndex = 0;
			this.button_Start.Text = "▶ 시작";
			this.button_Start.UseVisualStyleBackColor = false;
			// 
			// button_Stop
			// 
			this.button_Stop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
			this.button_Stop.Dock = System.Windows.Forms.DockStyle.Fill;
			this.button_Stop.FlatAppearance.BorderSize = 0;
			this.button_Stop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button_Stop.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
			this.button_Stop.Location = new System.Drawing.Point(190, 3);
			this.button_Stop.Name = "button_Stop";
			this.button_Stop.Size = new System.Drawing.Size(181, 54);
			this.button_Stop.TabIndex = 1;
			this.button_Stop.Text = "■ 정지";
			this.button_Stop.UseVisualStyleBackColor = false;
			// 
			// groupBox_Repetitions
			// 
			this.groupBox_Repetitions.Controls.Add(this.label_Repetitions);
			this.groupBox_Repetitions.Controls.Add(this.trackBar_Repetitions);
			this.groupBox_Repetitions.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox_Repetitions.ForeColor = System.Drawing.Color.White;
			this.groupBox_Repetitions.Location = new System.Drawing.Point(10, 440);
			this.groupBox_Repetitions.Name = "groupBox_Repetitions";
			this.groupBox_Repetitions.Size = new System.Drawing.Size(374, 78);
			this.groupBox_Repetitions.TabIndex = 3;
			this.groupBox_Repetitions.TabStop = false;
			this.groupBox_Repetitions.Text = "반복 횟수 설정";
			// 
			// label_Repetitions
			// 
			this.label_Repetitions.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label_Repetitions.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold);
			this.label_Repetitions.Location = new System.Drawing.Point(284, 19);
			this.label_Repetitions.Name = "label_Repetitions";
			this.label_Repetitions.Size = new System.Drawing.Size(87, 56);
			this.label_Repetitions.TabIndex = 1;
			this.label_Repetitions.Text = "1 회";
			this.label_Repetitions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// trackBar_Repetitions
			// 
			this.trackBar_Repetitions.Dock = System.Windows.Forms.DockStyle.Left;
			this.trackBar_Repetitions.Location = new System.Drawing.Point(3, 19);
			this.trackBar_Repetitions.Maximum = 300;
			this.trackBar_Repetitions.Minimum = 1;
			this.trackBar_Repetitions.Name = "trackBar_Repetitions";
			this.trackBar_Repetitions.Size = new System.Drawing.Size(281, 56);
			this.trackBar_Repetitions.TabIndex = 0;
			this.trackBar_Repetitions.TickFrequency = 30;
			this.trackBar_Repetitions.Value = 1;
			// 
			// groupBox_Details
			// 
			this.groupBox_Details.Controls.Add(this.panel_Life);
			this.groupBox_Details.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox_Details.ForeColor = System.Drawing.Color.White;
			this.groupBox_Details.Location = new System.Drawing.Point(10, 220);
			this.groupBox_Details.Name = "groupBox_Details";
			this.groupBox_Details.Padding = new System.Windows.Forms.Padding(10);
			this.groupBox_Details.Size = new System.Drawing.Size(374, 220);
			this.groupBox_Details.TabIndex = 2;
			this.groupBox_Details.TabStop = false;
			this.groupBox_Details.Text = "세부 항목";
			// 
			// panel_Life
			// 
			this.panel_Life.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel_Life.Location = new System.Drawing.Point(10, 26);
			this.panel_Life.Name = "panel_Life";
			this.panel_Life.Size = new System.Drawing.Size(354, 184);
			this.panel_Life.TabIndex = 0;
			// 
			// groupBox_LifeSkills
			// 
			this.groupBox_LifeSkills.Controls.Add(this.tableLayoutPanel_LifeSkills);
			this.groupBox_LifeSkills.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox_LifeSkills.ForeColor = System.Drawing.Color.White;
			this.groupBox_LifeSkills.Location = new System.Drawing.Point(10, 50);
			this.groupBox_LifeSkills.Name = "groupBox_LifeSkills";
			this.groupBox_LifeSkills.Padding = new System.Windows.Forms.Padding(10);
			this.groupBox_LifeSkills.Size = new System.Drawing.Size(374, 170);
			this.groupBox_LifeSkills.TabIndex = 1;
			this.groupBox_LifeSkills.TabStop = false;
			this.groupBox_LifeSkills.Text = "생활 스킬";
			// 
			// tableLayoutPanel_LifeSkills
			// 
			this.tableLayoutPanel_LifeSkills.ColumnCount = 2;
			this.tableLayoutPanel_LifeSkills.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel_LifeSkills.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel_LifeSkills.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel_LifeSkills.Location = new System.Drawing.Point(10, 26);
			this.tableLayoutPanel_LifeSkills.Name = "tableLayoutPanel_LifeSkills";
			this.tableLayoutPanel_LifeSkills.RowCount = 2;
			this.tableLayoutPanel_LifeSkills.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel_LifeSkills.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel_LifeSkills.Size = new System.Drawing.Size(354, 134);
			this.tableLayoutPanel_LifeSkills.TabIndex = 0;
			// 
			// label_Title_Settings
			// 
			this.label_Title_Settings.Dock = System.Windows.Forms.DockStyle.Top;
			this.label_Title_Settings.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold);
			this.label_Title_Settings.Location = new System.Drawing.Point(10, 10);
			this.label_Title_Settings.Name = "label_Title_Settings";
			this.label_Title_Settings.Size = new System.Drawing.Size(374, 40);
			this.label_Title_Settings.TabIndex = 0;
			this.label_Title_Settings.Text = "⚙️ 작업 설정";
			this.label_Title_Settings.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panel_Right
			// 
			this.panel_Right.Controls.Add(this.groupBox_Mouse);
			this.panel_Right.Controls.Add(this.groupBox_Screen);
			this.panel_Right.Controls.Add(this.groupBox_AutoSell);
			this.panel_Right.Controls.Add(this.groupBox_Status);
			this.panel_Right.Controls.Add(this.label_Title_Status);
			this.panel_Right.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel_Right.Location = new System.Drawing.Point(403, 3);
			this.panel_Right.Name = "panel_Right";
			this.panel_Right.Padding = new System.Windows.Forms.Padding(10);
			this.panel_Right.Size = new System.Drawing.Size(394, 594);
			this.panel_Right.TabIndex = 1;
			// 
			// groupBox_Mouse
			// 
			this.groupBox_Mouse.Controls.Add(this.label1);
			this.groupBox_Mouse.Controls.Add(this.textBox_Mouse_X);
			this.groupBox_Mouse.Controls.Add(this.label2);
			this.groupBox_Mouse.Controls.Add(this.textBox_Mouse_Y);
			this.groupBox_Mouse.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.groupBox_Mouse.ForeColor = System.Drawing.Color.White;
			this.groupBox_Mouse.Location = new System.Drawing.Point(10, 524);
			this.groupBox_Mouse.Name = "groupBox_Mouse";
			this.groupBox_Mouse.Size = new System.Drawing.Size(374, 60);
			this.groupBox_Mouse.TabIndex = 3;
			this.groupBox_Mouse.TabStop = false;
			this.groupBox_Mouse.Text = "기타 정보";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(17, 28);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(63, 15);
			this.label1.TabIndex = 0;
			this.label1.Text = "마우스 X:";
			// 
			// textBox_Mouse_X
			// 
			this.textBox_Mouse_X.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
			this.textBox_Mouse_X.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBox_Mouse_X.ForeColor = System.Drawing.Color.White;
			this.textBox_Mouse_X.Location = new System.Drawing.Point(86, 25);
			this.textBox_Mouse_X.Name = "textBox_Mouse_X";
			this.textBox_Mouse_X.ReadOnly = true;
			this.textBox_Mouse_X.Size = new System.Drawing.Size(80, 23);
			this.textBox_Mouse_X.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(194, 28);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(62, 15);
			this.label2.TabIndex = 2;
			this.label2.Text = "마우스 Y:";
			// 
			// textBox_Mouse_Y
			// 
			this.textBox_Mouse_Y.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
			this.textBox_Mouse_Y.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBox_Mouse_Y.ForeColor = System.Drawing.Color.White;
			this.textBox_Mouse_Y.Location = new System.Drawing.Point(262, 25);
			this.textBox_Mouse_Y.Name = "textBox_Mouse_Y";
			this.textBox_Mouse_Y.ReadOnly = true;
			this.textBox_Mouse_Y.Size = new System.Drawing.Size(80, 23);
			this.textBox_Mouse_Y.TabIndex = 3;
			// 
			// groupBox_Screen
			// 
			this.groupBox_Screen.Controls.Add(this.tableLayoutPanel_Screen);
			this.groupBox_Screen.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox_Screen.ForeColor = System.Drawing.Color.White;
			this.groupBox_Screen.Location = new System.Drawing.Point(10, 430);
			this.groupBox_Screen.Name = "groupBox_Screen";
			this.groupBox_Screen.Padding = new System.Windows.Forms.Padding(10);
			this.groupBox_Screen.Size = new System.Drawing.Size(374, 88);
			this.groupBox_Screen.TabIndex = 4;
			this.groupBox_Screen.TabStop = false;
			this.groupBox_Screen.Text = "모니터 선택";
			// 
			// tableLayoutPanel_Screen
			// 
			this.tableLayoutPanel_Screen.ColumnCount = 2;
			this.tableLayoutPanel_Screen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel_Screen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel_Screen.Controls.Add(this.radioButton_FirstScreen, 0, 0);
			this.tableLayoutPanel_Screen.Controls.Add(this.radioButton_SecondScreen, 1, 0);
			this.tableLayoutPanel_Screen.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel_Screen.Location = new System.Drawing.Point(10, 26);
			this.tableLayoutPanel_Screen.Name = "tableLayoutPanel_Screen";
			this.tableLayoutPanel_Screen.RowCount = 1;
			this.tableLayoutPanel_Screen.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel_Screen.Size = new System.Drawing.Size(354, 52);
			this.tableLayoutPanel_Screen.TabIndex = 0;
			// 
			// radioButton_FirstScreen
			// 
			this.radioButton_FirstScreen.Appearance = System.Windows.Forms.Appearance.Button;
			this.radioButton_FirstScreen.Dock = System.Windows.Forms.DockStyle.Fill;
			this.radioButton_FirstScreen.FlatAppearance.CheckedBackColor = System.Drawing.Color.DodgerBlue;
			this.radioButton_FirstScreen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.radioButton_FirstScreen.Location = new System.Drawing.Point(3, 3);
			this.radioButton_FirstScreen.Name = "radioButton_FirstScreen";
			this.radioButton_FirstScreen.Size = new System.Drawing.Size(171, 46);
			this.radioButton_FirstScreen.TabIndex = 0;
			this.radioButton_FirstScreen.TabStop = true;
			this.radioButton_FirstScreen.Text = "1번 화면";
			this.radioButton_FirstScreen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.radioButton_FirstScreen.UseVisualStyleBackColor = true;
			// 
			// radioButton_SecondScreen
			// 
			this.radioButton_SecondScreen.Appearance = System.Windows.Forms.Appearance.Button;
			this.radioButton_SecondScreen.Dock = System.Windows.Forms.DockStyle.Fill;
			this.radioButton_SecondScreen.FlatAppearance.CheckedBackColor = System.Drawing.Color.DodgerBlue;
			this.radioButton_SecondScreen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.radioButton_SecondScreen.Location = new System.Drawing.Point(180, 3);
			this.radioButton_SecondScreen.Name = "radioButton_SecondScreen";
			this.radioButton_SecondScreen.Size = new System.Drawing.Size(171, 46);
			this.radioButton_SecondScreen.TabIndex = 1;
			this.radioButton_SecondScreen.TabStop = true;
			this.radioButton_SecondScreen.Text = "2번 화면";
			this.radioButton_SecondScreen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.radioButton_SecondScreen.UseVisualStyleBackColor = true;
			// 
			// groupBox_AutoSell
			// 
			this.groupBox_AutoSell.Controls.Add(this.listBox_SellItems);
			this.groupBox_AutoSell.Controls.Add(this.label_SellListTitle);
			this.groupBox_AutoSell.Controls.Add(this.label_Interval);
			this.groupBox_AutoSell.Controls.Add(this.trackBar_Interval);
			this.groupBox_AutoSell.Controls.Add(this.label_IntervalTitle);
			this.groupBox_AutoSell.Controls.Add(this.pictureBox_Status);
			this.groupBox_AutoSell.Controls.Add(this.checkBox_ToggleAutoSell);
			this.groupBox_AutoSell.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox_AutoSell.ForeColor = System.Drawing.Color.White;
			this.groupBox_AutoSell.Location = new System.Drawing.Point(10, 200);
			this.groupBox_AutoSell.Name = "groupBox_AutoSell";
			this.groupBox_AutoSell.Size = new System.Drawing.Size(374, 230);
			this.groupBox_AutoSell.TabIndex = 2;
			this.groupBox_AutoSell.TabStop = false;
			this.groupBox_AutoSell.Text = "잡템 자동 판매";
			// 
			// listBox_SellItems
			// 
			this.listBox_SellItems.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
			this.listBox_SellItems.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.listBox_SellItems.ForeColor = System.Drawing.Color.White;
			this.listBox_SellItems.FormattingEnabled = true;
			this.listBox_SellItems.ItemHeight = 15;
			this.listBox_SellItems.Location = new System.Drawing.Point(17, 137);
			this.listBox_SellItems.Name = "listBox_SellItems";
			this.listBox_SellItems.Size = new System.Drawing.Size(341, 77);
			this.listBox_SellItems.TabIndex = 6;
			// 
			// label_SellListTitle
			// 
			this.label_SellListTitle.AutoSize = true;
			this.label_SellListTitle.Location = new System.Drawing.Point(17, 119);
			this.label_SellListTitle.Name = "label_SellListTitle";
			this.label_SellListTitle.Size = new System.Drawing.Size(126, 15);
			this.label_SellListTitle.TabIndex = 5;
			this.label_SellListTitle.Text = "판매 목록 (config.json)";
			// 
			// label_Interval
			// 
			this.label_Interval.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
			this.label_Interval.Location = new System.Drawing.Point(284, 69);
			this.label_Interval.Name = "label_Interval";
			this.label_Interval.Size = new System.Drawing.Size(84, 23);
			this.label_Interval.TabIndex = 4;
			this.label_Interval.Text = "60 분마다";
			this.label_Interval.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// trackBar_Interval
			// 
			this.trackBar_Interval.Location = new System.Drawing.Point(13, 69);
			this.trackBar_Interval.Maximum = 300;
			this.trackBar_Interval.Minimum = 5;
			this.trackBar_Interval.Name = "trackBar_Interval";
			this.trackBar_Interval.Size = new System.Drawing.Size(265, 45);
			this.trackBar_Interval.SmallChange = 5;
			this.trackBar_Interval.TabIndex = 3;
			this.trackBar_Interval.TickFrequency = 30;
			this.trackBar_Interval.Value = 60;
			// 
			// label_IntervalTitle
			// 
			this.label_IntervalTitle.AutoSize = true;
			this.label_IntervalTitle.Location = new System.Drawing.Point(17, 51);
			this.label_IntervalTitle.Name = "label_IntervalTitle";
			this.label_IntervalTitle.Size = new System.Drawing.Size(59, 15);
			this.label_IntervalTitle.TabIndex = 2;
			this.label_IntervalTitle.Text = "판매 주기";
			// 
			// pictureBox_Status
			// 
			this.pictureBox_Status.BackColor = System.Drawing.Color.Crimson;
			this.pictureBox_Status.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBox_Status.Location = new System.Drawing.Point(338, 26);
			this.pictureBox_Status.Name = "pictureBox_Status";
			this.pictureBox_Status.Size = new System.Drawing.Size(20, 20);
			this.pictureBox_Status.TabIndex = 1;
			this.pictureBox_Status.TabStop = false;
			// 
			// checkBox_ToggleAutoSell
			// 
			this.checkBox_ToggleAutoSell.Appearance = System.Windows.Forms.Appearance.Button;
			this.checkBox_ToggleAutoSell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
			this.checkBox_ToggleAutoSell.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
			this.checkBox_ToggleAutoSell.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.checkBox_ToggleAutoSell.Location = new System.Drawing.Point(17, 22);
			this.checkBox_ToggleAutoSell.Name = "checkBox_ToggleAutoSell";
			this.checkBox_ToggleAutoSell.Size = new System.Drawing.Size(126, 26);
			this.checkBox_ToggleAutoSell.TabIndex = 0;
			this.checkBox_ToggleAutoSell.Text = "자동판매 활성화";
			this.checkBox_ToggleAutoSell.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.checkBox_ToggleAutoSell.UseVisualStyleBackColor = false;
			// 
			// groupBox_Status
			// 
			this.groupBox_Status.Controls.Add(this.label_CurrentRepetition);
			this.groupBox_Status.Controls.Add(this.label7);
			this.groupBox_Status.Controls.Add(this.label_RemainingTime);
			this.groupBox_Status.Controls.Add(this.label_ElapsedTime);
			this.groupBox_Status.Controls.Add(this.label_TotalTime);
			this.groupBox_Status.Controls.Add(this.label_CurrentTask);
			this.groupBox_Status.Controls.Add(this.label6);
			this.groupBox_Status.Controls.Add(this.label5);
			this.groupBox_Status.Controls.Add(this.label4);
			this.groupBox_Status.Controls.Add(this.label3);
			this.groupBox_Status.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox_Status.ForeColor = System.Drawing.Color.White;
			this.groupBox_Status.Location = new System.Drawing.Point(10, 50);
			this.groupBox_Status.Name = "groupBox_Status";
			this.groupBox_Status.Size = new System.Drawing.Size(374, 150);
			this.groupBox_Status.TabIndex = 1;
			this.groupBox_Status.TabStop = false;
			this.groupBox_Status.Text = "현재 상태";
			// 
			// label_CurrentRepetition
			// 
			this.label_CurrentRepetition.AutoSize = true;
			this.label_CurrentRepetition.Location = new System.Drawing.Point(100, 116);
			this.label_CurrentRepetition.Name = "label_CurrentRepetition";
			this.label_CurrentRepetition.Size = new System.Drawing.Size(29, 15);
			this.label_CurrentRepetition.TabIndex = 9;
			this.label_CurrentRepetition.Text = "0/0";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
			this.label7.Location = new System.Drawing.Point(17, 116);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(59, 15);
			this.label7.TabIndex = 8;
			this.label7.Text = "진행 횟수:";
			// 
			// label_RemainingTime
			// 
			this.label_RemainingTime.AutoSize = true;
			this.label_RemainingTime.Location = new System.Drawing.Point(100, 92);
			this.label_RemainingTime.Name = "label_RemainingTime";
			this.label_RemainingTime.Size = new System.Drawing.Size(56, 15);
			this.label_RemainingTime.TabIndex = 7;
			this.label_RemainingTime.Text = "00:00:00";
			// 
			// label_ElapsedTime
			// 
			this.label_ElapsedTime.AutoSize = true;
			this.label_ElapsedTime.Location = new System.Drawing.Point(100, 68);
			this.label_ElapsedTime.Name = "label_ElapsedTime";
			this.label_ElapsedTime.Size = new System.Drawing.Size(56, 15);
			this.label_ElapsedTime.TabIndex = 6;
			this.label_ElapsedTime.Text = "00:00:00";
			// 
			// label_TotalTime
			// 
			this.label_TotalTime.AutoSize = true;
			this.label_TotalTime.Location = new System.Drawing.Point(100, 44);
			this.label_TotalTime.Name = "label_TotalTime";
			this.label_TotalTime.Size = new System.Drawing.Size(56, 15);
			this.label_TotalTime.TabIndex = 5;
			this.label_TotalTime.Text = "00:00:00";
			// 
			// label_CurrentTask
			// 
			this.label_CurrentTask.AutoSize = true;
			this.label_CurrentTask.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
			this.label_CurrentTask.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			this.label_CurrentTask.Location = new System.Drawing.Point(99, 20);
			this.label_CurrentTask.Name = "label_CurrentTask";
			this.label_CurrentTask.Size = new System.Drawing.Size(47, 17);
			this.label_CurrentTask.TabIndex = 4;
			this.label_CurrentTask.Text = "대기중";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
			this.label6.Location = new System.Drawing.Point(17, 92);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(59, 15);
			this.label6.TabIndex = 3;
			this.label6.Text = "남은 시간:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
			this.label5.Location = new System.Drawing.Point(17, 68);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(59, 15);
			this.label5.TabIndex = 2;
			this.label5.Text = "진행 시간:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
			this.label4.Location = new System.Drawing.Point(17, 44);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(59, 15);
			this.label4.TabIndex = 1;
			this.label4.Text = "예상 시간:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
			this.label3.Location = new System.Drawing.Point(17, 20);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(39, 17);
			this.label3.TabIndex = 0;
			this.label3.Text = "상태:";
			// 
			// label_Title_Status
			// 
			this.label_Title_Status.Dock = System.Windows.Forms.DockStyle.Top;
			this.label_Title_Status.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold);
			this.label_Title_Status.Location = new System.Drawing.Point(10, 10);
			this.label_Title_Status.Name = "label_Title_Status";
			this.label_Title_Status.Size = new System.Drawing.Size(374, 40);
			this.label_Title_Status.TabIndex = 0;
			this.label_Title_Status.Text = "📊 상태 및 도구";
			this.label_Title_Status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// Form_Home
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
			this.ClientSize = new System.Drawing.Size(800, 600);
			this.Controls.Add(this.tableLayoutPanel_Main);
			this.ForeColor = System.Drawing.Color.White;
			this.Name = "Form_Home";
			this.Text = "MOGI Automation";
			this.tableLayoutPanel_Main.ResumeLayout(false);
			this.panel_Left.ResumeLayout(false);
			this.tableLayoutPanel_Actions.ResumeLayout(false);
			this.groupBox_Repetitions.ResumeLayout(false);
			this.groupBox_Repetitions.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBar_Repetitions)).EndInit();
			this.groupBox_Details.ResumeLayout(false);
			this.groupBox_LifeSkills.ResumeLayout(false);
			this.panel_Right.ResumeLayout(false);
			this.groupBox_Mouse.ResumeLayout(false);
			this.groupBox_Mouse.PerformLayout();
			this.groupBox_Screen.ResumeLayout(false);
			this.tableLayoutPanel_Screen.ResumeLayout(false);
			this.groupBox_AutoSell.ResumeLayout(false);
			this.groupBox_AutoSell.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBar_Interval)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_Status)).EndInit();
			this.groupBox_Status.ResumeLayout(false);
			this.groupBox_Status.PerformLayout();
			this.ResumeLayout(false);

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
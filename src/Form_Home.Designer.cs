namespace MOGI
{
	partial class Form_Home
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			button_Harvest = new Button();
			label_CurrentTask = new Label();
			label3 = new Label();
			textBox_Mouse_Y = new TextBox();
			textBox_Mouse_X = new TextBox();
			label2 = new Label();
			label1 = new Label();
			label_TotalTime = new Label();
			label_ElapsedTime = new Label();
			label_RemainingTime = new Label();
			label_CurrentRepetition = new Label();
			label4 = new Label();
			label6 = new Label();
			label5 = new Label();
			label7 = new Label();
			label8 = new Label();
			trackBar1 = new TrackBar();
			label_Scroll = new Label();
			groupBox1 = new GroupBox();
			groupBox2 = new GroupBox();
			button_Stop = new Button();
			tableLayoutPanel1 = new TableLayoutPanel();
			radioButton_Hoeing = new RadioButton();
			radioButton_Wood = new RadioButton();
			radioButton_Mining = new RadioButton();
			radioButton_Harvest = new RadioButton();
			panel_Life = new Panel();
			groupBox3 = new GroupBox();
			tableLayoutPanel2 = new TableLayoutPanel();
			radioButton_FirstScreen = new RadioButton();
			radioButton_SecondScreen = new RadioButton();
			checkBox_KeyMapping = new CheckBox();
			panel1 = new Panel();
			((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
			groupBox1.SuspendLayout();
			groupBox2.SuspendLayout();
			tableLayoutPanel1.SuspendLayout();
			groupBox3.SuspendLayout();
			tableLayoutPanel2.SuspendLayout();
			panel1.SuspendLayout();
			SuspendLayout();
			// 
			// button_Harvest
			// 
			button_Harvest.Location = new Point(24, 352);
			button_Harvest.Name = "button_Harvest";
			button_Harvest.Size = new Size(199, 77);
			button_Harvest.TabIndex = 13;
			button_Harvest.Text = "시작";
			button_Harvest.UseVisualStyleBackColor = true;
			button_Harvest.Click += button_Harvest_Click;
			// 
			// label_CurrentTask
			// 
			label_CurrentTask.AutoSize = true;
			label_CurrentTask.Location = new Point(91, 139);
			label_CurrentTask.Name = "label_CurrentTask";
			label_CurrentTask.Size = new Size(55, 15);
			label_CurrentTask.TabIndex = 12;
			label_CurrentTask.Text = "현재작업";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(24, 139);
			label3.Name = "label3";
			label3.Size = new Size(70, 15);
			label3.TabIndex = 11;
			label3.Text = "현재 상태 : ";
			// 
			// textBox_Mouse_Y
			// 
			textBox_Mouse_Y.Enabled = false;
			textBox_Mouse_Y.Location = new Point(45, 55);
			textBox_Mouse_Y.Name = "textBox_Mouse_Y";
			textBox_Mouse_Y.Size = new Size(100, 23);
			textBox_Mouse_Y.TabIndex = 10;
			// 
			// textBox_Mouse_X
			// 
			textBox_Mouse_X.Enabled = false;
			textBox_Mouse_X.Location = new Point(45, 22);
			textBox_Mouse_X.Name = "textBox_Mouse_X";
			textBox_Mouse_X.Size = new Size(100, 23);
			textBox_Mouse_X.TabIndex = 9;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(18, 58);
			label2.Name = "label2";
			label2.Size = new Size(21, 15);
			label2.TabIndex = 8;
			label2.Text = "Y :";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(18, 25);
			label1.Name = "label1";
			label1.Size = new Size(21, 15);
			label1.TabIndex = 7;
			label1.Text = "X :";
			// 
			// label_TotalTime
			// 
			label_TotalTime.AutoSize = true;
			label_TotalTime.Location = new Point(73, 19);
			label_TotalTime.Name = "label_TotalTime";
			label_TotalTime.Size = new Size(79, 15);
			label_TotalTime.TabIndex = 14;
			label_TotalTime.Text = "전체시간표시";
			// 
			// label_ElapsedTime
			// 
			label_ElapsedTime.AutoSize = true;
			label_ElapsedTime.Location = new Point(73, 40);
			label_ElapsedTime.Name = "label_ElapsedTime";
			label_ElapsedTime.Size = new Size(55, 15);
			label_ElapsedTime.TabIndex = 15;
			label_ElapsedTime.Text = "진행시간";
			// 
			// label_RemainingTime
			// 
			label_RemainingTime.AutoSize = true;
			label_RemainingTime.Location = new Point(73, 59);
			label_RemainingTime.Name = "label_RemainingTime";
			label_RemainingTime.Size = new Size(55, 15);
			label_RemainingTime.TabIndex = 16;
			label_RemainingTime.Text = "남은시간";
			// 
			// label_CurrentRepetition
			// 
			label_CurrentRepetition.AutoSize = true;
			label_CurrentRepetition.Location = new Point(73, 79);
			label_CurrentRepetition.Name = "label_CurrentRepetition";
			label_CurrentRepetition.Size = new Size(55, 15);
			label_CurrentRepetition.TabIndex = 16;
			label_CurrentRepetition.Text = "반복횟수";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(6, 19);
			label4.Name = "label4";
			label4.Size = new Size(70, 15);
			label4.TabIndex = 14;
			label4.Text = "예상 시간 : ";
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Location = new Point(6, 59);
			label6.Name = "label6";
			label6.Size = new Size(62, 15);
			label6.TabIndex = 16;
			label6.Text = "남은시간 :";
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Location = new Point(6, 40);
			label5.Name = "label5";
			label5.Size = new Size(62, 15);
			label5.TabIndex = 15;
			label5.Text = "진행시간 :";
			// 
			// label7
			// 
			label7.AutoSize = true;
			label7.Location = new Point(6, 79);
			label7.Name = "label7";
			label7.Size = new Size(66, 15);
			label7.TabIndex = 16;
			label7.Text = "진행 횟수 :";
			// 
			// label8
			// 
			label8.AutoSize = true;
			label8.Location = new Point(23, 175);
			label8.Name = "label8";
			label8.Size = new Size(90, 15);
			label8.TabIndex = 18;
			label8.Text = "반복횟수 설정 :";
			// 
			// trackBar1
			// 
			trackBar1.Location = new Point(119, 175);
			trackBar1.Maximum = 300;
			trackBar1.Minimum = 1;
			trackBar1.Name = "trackBar1";
			trackBar1.Size = new Size(104, 45);
			trackBar1.TabIndex = 19;
			trackBar1.TickFrequency = 20;
			trackBar1.Value = 1;
			trackBar1.Scroll += trackBar1_Scroll;
			// 
			// label_Scroll
			// 
			label_Scroll.AutoSize = true;
			label_Scroll.Location = new Point(130, 205);
			label_Scroll.Name = "label_Scroll";
			label_Scroll.Size = new Size(39, 15);
			label_Scroll.TabIndex = 20;
			label_Scroll.Text = "label9";
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(textBox_Mouse_X);
			groupBox1.Controls.Add(label1);
			groupBox1.Controls.Add(label2);
			groupBox1.Controls.Add(textBox_Mouse_Y);
			groupBox1.Location = new Point(21, 12);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(163, 96);
			groupBox1.TabIndex = 22;
			groupBox1.TabStop = false;
			groupBox1.Text = "마우스 위치";
			// 
			// groupBox2
			// 
			groupBox2.Controls.Add(label4);
			groupBox2.Controls.Add(label_TotalTime);
			groupBox2.Controls.Add(label_ElapsedTime);
			groupBox2.Controls.Add(label5);
			groupBox2.Controls.Add(label_RemainingTime);
			groupBox2.Controls.Add(label_CurrentRepetition);
			groupBox2.Controls.Add(label6);
			groupBox2.Controls.Add(label7);
			groupBox2.Location = new Point(201, 17);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new Size(174, 109);
			groupBox2.TabIndex = 23;
			groupBox2.TabStop = false;
			groupBox2.Text = "작업시간표";
			// 
			// button_Stop
			// 
			button_Stop.Location = new Point(244, 352);
			button_Stop.Name = "button_Stop";
			button_Stop.Size = new Size(178, 77);
			button_Stop.TabIndex = 25;
			button_Stop.Text = "정지";
			button_Stop.UseVisualStyleBackColor = true;
			button_Stop.Click += button_Stop_Click;
			// 
			// tableLayoutPanel1
			// 
			tableLayoutPanel1.ColumnCount = 1;
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
			tableLayoutPanel1.Controls.Add(radioButton_Hoeing, 0, 3);
			tableLayoutPanel1.Controls.Add(radioButton_Wood, 0, 0);
			tableLayoutPanel1.Controls.Add(radioButton_Mining, 0, 1);
			tableLayoutPanel1.Controls.Add(radioButton_Harvest, 0, 2);
			tableLayoutPanel1.Location = new Point(241, 139);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 4;
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
			tableLayoutPanel1.Size = new Size(112, 134);
			tableLayoutPanel1.TabIndex = 26;
			// 
			// radioButton_Hoeing
			// 
			radioButton_Hoeing.Appearance = Appearance.Button;
			radioButton_Hoeing.AutoSize = true;
			radioButton_Hoeing.Dock = DockStyle.Fill;
			radioButton_Hoeing.Location = new Point(3, 102);
			radioButton_Hoeing.Name = "radioButton_Hoeing";
			radioButton_Hoeing.Size = new Size(106, 29);
			radioButton_Hoeing.TabIndex = 28;
			radioButton_Hoeing.Text = "호미질";
			radioButton_Hoeing.TextAlign = ContentAlignment.MiddleCenter;
			radioButton_Hoeing.UseVisualStyleBackColor = true;
			radioButton_Hoeing.CheckedChanged += RadioButton_LifeContent_CheckedChanged;
			// 
			// radioButton_Wood
			// 
			radioButton_Wood.Appearance = Appearance.Button;
			radioButton_Wood.AutoSize = true;
			radioButton_Wood.Dock = DockStyle.Fill;
			radioButton_Wood.Location = new Point(3, 3);
			radioButton_Wood.Name = "radioButton_Wood";
			radioButton_Wood.Size = new Size(106, 27);
			radioButton_Wood.TabIndex = 27;
			radioButton_Wood.Text = "나무";
			radioButton_Wood.TextAlign = ContentAlignment.MiddleCenter;
			radioButton_Wood.UseVisualStyleBackColor = true;
			radioButton_Wood.CheckedChanged += RadioButton_LifeContent_CheckedChanged;
			// 
			// radioButton_Mining
			// 
			radioButton_Mining.Appearance = Appearance.Button;
			radioButton_Mining.AutoSize = true;
			radioButton_Mining.Dock = DockStyle.Fill;
			radioButton_Mining.Location = new Point(3, 36);
			radioButton_Mining.Name = "radioButton_Mining";
			radioButton_Mining.Size = new Size(106, 27);
			radioButton_Mining.TabIndex = 27;
			radioButton_Mining.Text = "광석";
			radioButton_Mining.TextAlign = ContentAlignment.MiddleCenter;
			radioButton_Mining.UseVisualStyleBackColor = true;
			radioButton_Mining.CheckedChanged += RadioButton_LifeContent_CheckedChanged;
			// 
			// radioButton_Harvest
			// 
			radioButton_Harvest.Appearance = Appearance.Button;
			radioButton_Harvest.AutoSize = true;
			radioButton_Harvest.Checked = true;
			radioButton_Harvest.Dock = DockStyle.Fill;
			radioButton_Harvest.Location = new Point(3, 69);
			radioButton_Harvest.Name = "radioButton_Harvest";
			radioButton_Harvest.Size = new Size(106, 27);
			radioButton_Harvest.TabIndex = 27;
			radioButton_Harvest.TabStop = true;
			radioButton_Harvest.Text = "추수";
			radioButton_Harvest.TextAlign = ContentAlignment.MiddleCenter;
			radioButton_Harvest.UseVisualStyleBackColor = true;
			radioButton_Harvest.CheckedChanged += RadioButton_LifeContent_CheckedChanged;
			// 
			// panel_Life
			// 
			panel_Life.Location = new Point(392, 142);
			panel_Life.Name = "panel_Life";
			panel_Life.Size = new Size(129, 176);
			panel_Life.TabIndex = 27;
			// 
			// groupBox3
			// 
			groupBox3.Controls.Add(tableLayoutPanel2);
			groupBox3.Location = new Point(392, 17);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new Size(200, 100);
			groupBox3.TabIndex = 28;
			groupBox3.TabStop = false;
			groupBox3.Text = "듀얼스크린";
			// 
			// tableLayoutPanel2
			// 
			tableLayoutPanel2.ColumnCount = 2;
			tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
			tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
			tableLayoutPanel2.Controls.Add(radioButton_FirstScreen, 0, 0);
			tableLayoutPanel2.Controls.Add(radioButton_SecondScreen, 1, 0);
			tableLayoutPanel2.Dock = DockStyle.Fill;
			tableLayoutPanel2.Location = new Point(3, 19);
			tableLayoutPanel2.Name = "tableLayoutPanel2";
			tableLayoutPanel2.RowCount = 1;
			tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
			tableLayoutPanel2.Size = new Size(194, 78);
			tableLayoutPanel2.TabIndex = 0;
			// 
			// radioButton_FirstScreen
			// 
			radioButton_FirstScreen.Appearance = Appearance.Button;
			radioButton_FirstScreen.AutoSize = true;
			radioButton_FirstScreen.Dock = DockStyle.Fill;
			radioButton_FirstScreen.Location = new Point(3, 3);
			radioButton_FirstScreen.Name = "radioButton_FirstScreen";
			radioButton_FirstScreen.Size = new Size(91, 72);
			radioButton_FirstScreen.TabIndex = 0;
			radioButton_FirstScreen.Text = "1번화면";
			radioButton_FirstScreen.TextAlign = ContentAlignment.MiddleCenter;
			radioButton_FirstScreen.UseVisualStyleBackColor = true;
			radioButton_FirstScreen.CheckedChanged += RadioButton_Screen_CheckedChanged;
			// 
			// radioButton_SecondScreen
			// 
			radioButton_SecondScreen.Appearance = Appearance.Button;
			radioButton_SecondScreen.AutoSize = true;
			radioButton_SecondScreen.Dock = DockStyle.Fill;
			radioButton_SecondScreen.Location = new Point(100, 3);
			radioButton_SecondScreen.Name = "radioButton_SecondScreen";
			radioButton_SecondScreen.Size = new Size(91, 72);
			radioButton_SecondScreen.TabIndex = 0;
			radioButton_SecondScreen.Text = "2번화면";
			radioButton_SecondScreen.TextAlign = ContentAlignment.MiddleCenter;
			radioButton_SecondScreen.UseVisualStyleBackColor = true;
			radioButton_SecondScreen.CheckedChanged += RadioButton_Screen_CheckedChanged;
			// 
			// checkBox_KeyMapping
			// 
			checkBox_KeyMapping.Appearance = Appearance.Button;
			checkBox_KeyMapping.AutoSize = true;
			checkBox_KeyMapping.Dock = DockStyle.Fill;
			checkBox_KeyMapping.Enabled = false;
			checkBox_KeyMapping.Location = new Point(0, 0);
			checkBox_KeyMapping.Name = "checkBox_KeyMapping";
			checkBox_KeyMapping.Size = new Size(169, 77);
			checkBox_KeyMapping.TabIndex = 29;
			checkBox_KeyMapping.Text = "키맵핑 사용";
			checkBox_KeyMapping.TextAlign = ContentAlignment.MiddleCenter;
			checkBox_KeyMapping.UseVisualStyleBackColor = true;
			// 
			// panel1
			// 
			panel1.Controls.Add(checkBox_KeyMapping);
			panel1.Location = new Point(467, 352);
			panel1.Name = "panel1";
			panel1.Size = new Size(169, 77);
			panel1.TabIndex = 30;
			// 
			// Form_Home
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 534);
			Controls.Add(panel1);
			Controls.Add(groupBox3);
			Controls.Add(panel_Life);
			Controls.Add(tableLayoutPanel1);
			Controls.Add(button_Stop);
			Controls.Add(groupBox2);
			Controls.Add(groupBox1);
			Controls.Add(label_Scroll);
			Controls.Add(trackBar1);
			Controls.Add(label8);
			Controls.Add(button_Harvest);
			Controls.Add(label_CurrentTask);
			Controls.Add(label3);
			Name = "Form_Home";
			Text = "Form_Home";
			FormClosing += Form_Home_FormClosing;
			((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			groupBox2.ResumeLayout(false);
			groupBox2.PerformLayout();
			tableLayoutPanel1.ResumeLayout(false);
			tableLayoutPanel1.PerformLayout();
			groupBox3.ResumeLayout(false);
			tableLayoutPanel2.ResumeLayout(false);
			tableLayoutPanel2.PerformLayout();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button button_Harvest;
		private Label label_CurrentTask;
		private Label label3;
		private TextBox textBox_Mouse_Y;
		private TextBox textBox_Mouse_X;
		private Label label2;
		private Label label1;
		private Label label_TotalTime;
		private Label label_ElapsedTime;
		private Label label_RemainingTime;
		private Label label_CurrentRepetition;
		private Label label4;
		private Label label6;
		private Label label5;
		private Label label7;
		private Label label8;
		private TrackBar trackBar1;
		private Label label_Scroll;
		private GroupBox groupBox1;
		private GroupBox groupBox2;
		private Button button_Stop;
		private TableLayoutPanel tableLayoutPanel1;
		private RadioButton radioButton_Hoeing;
		private RadioButton radioButton_Wood;
		private RadioButton radioButton_Mining;
		private RadioButton radioButton_Harvest;
		private Panel panel_Life;
		private GroupBox groupBox3;
		private TableLayoutPanel tableLayoutPanel2;
		private RadioButton radioButton_FirstScreen;
		private RadioButton radioButton_SecondScreen;
		private CheckBox checkBox_KeyMapping;
		private Panel panel1;
	}
}
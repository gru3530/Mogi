namespace MOGI
{
	partial class Form_Main
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			tableLayoutPanel1 = new TableLayoutPanel();
			panel_Main = new Panel();
			button_Home = new Button();
			button_Auto = new Button();
			tableLayoutPanel1.SuspendLayout();
			SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			tableLayoutPanel1.ColumnCount = 4;
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
			tableLayoutPanel1.Controls.Add(panel_Main, 0, 0);
			tableLayoutPanel1.Controls.Add(button_Home, 0, 1);
			tableLayoutPanel1.Controls.Add(button_Auto, 1, 1);
			tableLayoutPanel1.Dock = DockStyle.Fill;
			tableLayoutPanel1.Location = new Point(0, 0);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 2;
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 93.66086F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 6.339144F));
			tableLayoutPanel1.Size = new Size(800, 631);
			tableLayoutPanel1.TabIndex = 7;
			// 
			// panel_Main
			// 
			tableLayoutPanel1.SetColumnSpan(panel_Main, 4);
			panel_Main.Dock = DockStyle.Fill;
			panel_Main.Location = new Point(3, 3);
			panel_Main.Name = "panel_Main";
			panel_Main.Size = new Size(794, 585);
			panel_Main.TabIndex = 0;
			// 
			// button_Home
			// 
			button_Home.Dock = DockStyle.Fill;
			button_Home.Enabled = false;
			button_Home.Location = new Point(3, 594);
			button_Home.Name = "button_Home";
			button_Home.Size = new Size(194, 34);
			button_Home.TabIndex = 1;
			button_Home.Text = "메인";
			button_Home.UseVisualStyleBackColor = true;
			// 
			// button_Auto
			// 
			button_Auto.Dock = DockStyle.Fill;
			button_Auto.Enabled = false;
			button_Auto.Location = new Point(203, 594);
			button_Auto.Name = "button_Auto";
			button_Auto.Size = new Size(194, 34);
			button_Auto.TabIndex = 2;
			button_Auto.Text = "설정";
			button_Auto.UseVisualStyleBackColor = true;
			// 
			// Form_Main
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 631);
			Controls.Add(tableLayoutPanel1);
			Name = "Form_Main";
			Text = "MOGI";
			tableLayoutPanel1.ResumeLayout(false);
			ResumeLayout(false);
		}

		#endregion
		private TableLayoutPanel tableLayoutPanel1;
		private Panel panel_Main;
		private Button button_Home;
		private Button button_Auto;
	}
}

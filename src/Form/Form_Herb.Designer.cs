namespace MOGI
{
	partial class Form_Herb
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
			tableLayoutPanel = new TableLayoutPanel();
			radioButton6 = new RadioButton();
			radioButton7 = new RadioButton();
			radioButton8 = new RadioButton();
			tableLayoutPanel.SuspendLayout();
			SuspendLayout();
			// 
			// tableLayoutPanel
			// 
			tableLayoutPanel.ColumnCount = 1;
			tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
			tableLayoutPanel.Controls.Add(radioButton6, 0, 0);
			tableLayoutPanel.Controls.Add(radioButton7, 0, 1);
			tableLayoutPanel.Controls.Add(radioButton8, 0, 2);
			tableLayoutPanel.Dock = DockStyle.Fill;
			tableLayoutPanel.Location = new Point(0, 0);
			tableLayoutPanel.Name = "tableLayoutPanel";
			tableLayoutPanel.RowCount = 3;
			tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
			tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
			tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
			tableLayoutPanel.Size = new Size(273, 214);
			tableLayoutPanel.TabIndex = 27;
			// 
			// radioButton6
			// 
			radioButton6.Appearance = Appearance.Button;
			radioButton6.AutoSize = true;
			radioButton6.Dock = DockStyle.Fill;
			radioButton6.Location = new Point(3, 3);
			radioButton6.Name = "radioButton6";
			radioButton6.Size = new Size(267, 65);
			radioButton6.TabIndex = 27;
			radioButton6.Text = "밀";
			radioButton6.TextAlign = ContentAlignment.MiddleCenter;
			radioButton6.UseVisualStyleBackColor = true;
			// 
			// radioButton7
			// 
			radioButton7.Appearance = Appearance.Button;
			radioButton7.AutoSize = true;
			radioButton7.Dock = DockStyle.Fill;
			radioButton7.Location = new Point(3, 74);
			radioButton7.Name = "radioButton7";
			radioButton7.Size = new Size(267, 65);
			radioButton7.TabIndex = 27;
			radioButton7.Text = "옥수수";
			radioButton7.TextAlign = ContentAlignment.MiddleCenter;
			radioButton7.UseVisualStyleBackColor = true;
			// 
			// radioButton8
			// 
			radioButton8.Appearance = Appearance.Button;
			radioButton8.AutoSize = true;
			radioButton8.Checked = true;
			radioButton8.Dock = DockStyle.Fill;
			radioButton8.Location = new Point(3, 145);
			radioButton8.Name = "radioButton8";
			radioButton8.Size = new Size(267, 66);
			radioButton8.TabIndex = 27;
			radioButton8.TabStop = true;
			radioButton8.Text = "콩";
			radioButton8.TextAlign = ContentAlignment.MiddleCenter;
			radioButton8.UseVisualStyleBackColor = true;
			// 
			// Form_Harvest
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(273, 214);
			Controls.Add(tableLayoutPanel);
			FormBorderStyle = FormBorderStyle.None;
			Name = "Form_Harvest";
			Text = "Form_Harvest";
			tableLayoutPanel.ResumeLayout(false);
			tableLayoutPanel.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private TableLayoutPanel tableLayoutPanel;
		private RadioButton radioButton6;
		private RadioButton radioButton7;
		private RadioButton radioButton8;
	}
}
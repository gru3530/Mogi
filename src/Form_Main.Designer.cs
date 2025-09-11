namespace MOGI
{
	partial class Form_Main
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
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.panel_Main = new System.Windows.Forms.Panel();
			this.button_Home = new System.Windows.Forms.Button();
			this.button_Auto = new System.Windows.Forms.Button();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
			this.tableLayoutPanel1.ColumnCount = 4;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.Controls.Add(this.panel_Main, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.button_Home, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.button_Auto, 1, 1);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(816, 638);
			this.tableLayoutPanel1.TabIndex = 7;
			// 
			// panel_Main
			// 
			this.tableLayoutPanel1.SetColumnSpan(this.panel_Main, 4);
			this.panel_Main.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel_Main.Location = new System.Drawing.Point(3, 3);
			this.panel_Main.Name = "panel_Main";
			this.panel_Main.Size = new System.Drawing.Size(810, 580);
			this.panel_Main.TabIndex = 0;
			// 
			// button_Home
			// 
			this.button_Home.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
			this.button_Home.Dock = System.Windows.Forms.DockStyle.Fill;
			this.button_Home.Enabled = false;
			this.button_Home.FlatAppearance.BorderSize = 0;
			this.button_Home.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button_Home.ForeColor = System.Drawing.Color.White;
			this.button_Home.Location = new System.Drawing.Point(3, 589);
			this.button_Home.Name = "button_Home";
			this.button_Home.Size = new System.Drawing.Size(198, 46);
			this.button_Home.TabIndex = 1;
			this.button_Home.Text = "메인";
			this.button_Home.UseVisualStyleBackColor = false;
			// 
			// button_Auto
			// 
			this.button_Auto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
			this.button_Auto.Dock = System.Windows.Forms.DockStyle.Fill;
			this.button_Auto.Enabled = false;
			this.button_Auto.FlatAppearance.BorderSize = 0;
			this.button_Auto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button_Auto.ForeColor = System.Drawing.Color.White;
			this.button_Auto.Location = new System.Drawing.Point(207, 589);
			this.button_Auto.Name = "button_Auto";
			this.button_Auto.Size = new System.Drawing.Size(198, 46);
			this.button_Auto.TabIndex = 2;
			this.button_Auto.Text = "설정";
			this.button_Auto.UseVisualStyleBackColor = false;
			// 
			// Form_Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
			this.ClientSize = new System.Drawing.Size(816, 638);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "Form_Main";
			this.Text = "MOGI";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.ResumeLayout(false);
		}

		#endregion
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Panel panel_Main;
		private System.Windows.Forms.Button button_Home;
		private System.Windows.Forms.Button button_Auto;
	}
}
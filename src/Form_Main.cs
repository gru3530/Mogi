
namespace MOGI
{
	public partial class Form_Main : Form
	{
		private Task_Manager _taskManager;

		private Form_Home _formHome;
		private Form _currentChildForm;

		public Form_Main()
		{
			InitializeComponent();
			_taskManager = Task_Manager.Instance;

			// 서비스 시작/종료는 이제 Program.cs에서 담당하므로 여기서는 제거
			// this.Load += (sender, e) => _taskManager.StartTask(new EmptyTask(new CancellationToken()), new TaskConfiguration());
			// this.FormClosing += (sender, e) => _taskManager.StopAllTasks();

			_formHome = new Form_Home();


			AddFormToPanel(_formHome);


			ShowChildForm(_formHome);
		}

		private void AddFormToPanel(Form childForm)
		{
			childForm.TopLevel = false;
			childForm.FormBorderStyle = FormBorderStyle.None;
			childForm.Dock = DockStyle.Fill;
			panel_Main.Controls.Add(childForm);
			childForm.Hide();
		}

		private void ShowChildForm(Form formToShow)
		{
			foreach (Control control in panel_Main.Controls)
			{
				if (control is Form childForm)
				{
					childForm.Hide();
				}
			}
			formToShow.Show();
			formToShow.BringToFront();
		}

		private void button_Home_Click(object sender, EventArgs e)
		{
			ShowChildForm(_formHome);
		}

		private void button_Life_Click(object sender, EventArgs e)
		{
			
		}
		// Task 시작 로직은 이제 Form_Home으로 이동
	}
}
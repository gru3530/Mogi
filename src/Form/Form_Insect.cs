
namespace MOGI
{
	public partial class Form_Insect : Form
	{
		private BaseContentController<InsectType> _controller;

		public Form_Insect()
		{
			InitializeComponent();

			_controller = new BaseContentController<InsectType>();
			this.Controls.Add(_controller.ContentPanel);
			_controller.ContentPanel.BringToFront();

			// 폼 자체 설정
			this.TopLevel = false;
			this.FormBorderStyle = FormBorderStyle.None;
			this.Dock = DockStyle.Fill;
		}


		public event EventHandler<InsectType> ItemSelected
		{
			add { _controller.ItemSelected += value; }
			remove { _controller.ItemSelected -= value; }
		}
	}
}

namespace MOGI
{
	public partial class Form_Wood : Form
	{
		private BaseContentController<WoodType> _controller;

		public Form_Wood()
		{
			InitializeComponent();

			_controller = new BaseContentController<WoodType>();
			this.Controls.Add(_controller.ContentPanel);
			_controller.ContentPanel.BringToFront();

			// 폼 자체 설정
			this.TopLevel = false;
			this.FormBorderStyle = FormBorderStyle.None;
			this.Dock = DockStyle.Fill;
		}


		public event EventHandler<WoodType> ItemSelected
		{
			add { _controller.ItemSelected += value; }
			remove { _controller.ItemSelected -= value; }
		}
	}
}
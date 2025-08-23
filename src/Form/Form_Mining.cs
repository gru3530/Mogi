
namespace MOGI
{
	public partial class Form_Mining : Form
	{
		private BaseContentController<MineralType> _controller;

		public Form_Mining()
		{
			InitializeComponent();

			_controller = new BaseContentController<MineralType>();
			this.Controls.Add(_controller.ContentPanel);
			_controller.ContentPanel.BringToFront();

			// 폼 자체 설정
			this.TopLevel = false;
			this.FormBorderStyle = FormBorderStyle.None;
			this.Dock = DockStyle.Fill;
		}


		public event EventHandler<MineralType> ItemSelected
		{
			add { _controller.ItemSelected += value; }
			remove { _controller.ItemSelected -= value; }
		}
	}
}
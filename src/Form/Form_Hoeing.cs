
namespace MOGI
{
	public partial class Form_Hoeing : Form
	{
		private BaseContentController<HoeingType> _controller;

		public Form_Hoeing()
		{
			InitializeComponent();

			_controller = new BaseContentController<HoeingType>();
			this.Controls.Add(_controller.ContentPanel);
			_controller.ContentPanel.BringToFront();

			// 폼 자체 설정
			this.TopLevel = false;
			this.FormBorderStyle = FormBorderStyle.None;
			this.Dock = DockStyle.Fill;
		}


		public event EventHandler<HoeingType> ItemSelected
		{
			add { _controller.ItemSelected += value; }
			remove { _controller.ItemSelected -= value; }
		}
	}
}
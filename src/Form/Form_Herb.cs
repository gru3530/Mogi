
namespace MOGI
{
	public partial class Form_Herb : Form
	{
		private BaseContentController<HerbType> _controller;

		public Form_Herb()
		{
			InitializeComponent();

			_controller = new BaseContentController<HerbType>();
			this.Controls.Add(_controller.ContentPanel);
			_controller.ContentPanel.BringToFront();

			// 폼 자체 설정
			this.TopLevel = false;
			this.FormBorderStyle = FormBorderStyle.None;
			this.Dock = DockStyle.Fill;
		}


		public event EventHandler<HerbType> ItemSelected
		{
			add { _controller.ItemSelected += value; }
			remove { _controller.ItemSelected -= value; }
		}
	}
}
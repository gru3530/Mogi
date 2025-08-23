using System;
using System.Windows.Forms;
using MOGI;

namespace MOGI
{
	public partial class Form_Harvest : Form
	{
		private BaseContentController<CropType> _controller;

		public Form_Harvest()
		{
			InitializeComponent();

			_controller = new BaseContentController<CropType>();
			this.Controls.Add(_controller.ContentPanel);
			_controller.ContentPanel.BringToFront();

			// 폼 자체 설정
			this.TopLevel = false;
			this.FormBorderStyle = FormBorderStyle.None;
			this.Dock = DockStyle.Fill;
		}


		public event EventHandler<CropType> ItemSelected
		{
			add { _controller.ItemSelected += value; }
			remove { _controller.ItemSelected -= value; }
		}
	}
}
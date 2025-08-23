using System;
using System.Windows.Forms;
using MOGI; // CommonEnum.cs의 enum들을 사용하기 위해 네임스페이스 명시
using System.ComponentModel;
using System.Reflection;
using System.Drawing;

namespace MOGI
{
	public class BaseContentController<TEnum> where TEnum : Enum
	{
		public event EventHandler<TEnum> ItemSelected;

		public TableLayoutPanel ContentPanel { get; private set; }

		private const float BASE_FONT_SIZE = 10F;

		public BaseContentController()
		{
			this.ContentPanel = new TableLayoutPanel();
			this.ContentPanel.Dock = DockStyle.Fill;
			this.ContentPanel.ColumnCount = 1; 

			this.ContentPanel.Resize += (sender, e) => AdjustFontsToPanelSize();

			InitializeContentUI();
		}

		public void InitializeContentUI()
		{
			TableLayoutPanel panel = this.ContentPanel;

			panel.Controls.Clear();
			panel.RowStyles.Clear();
			panel.RowCount = 0;

			Array enumValues = Enum.GetValues(typeof(TEnum));
			panel.RowCount = enumValues.Length;

			if (enumValues.Length == 0) return;

			float rowHeightPercent = 100f / enumValues.Length;

			for (int i = 0; i < enumValues.Length; i++)
			{
				TEnum enumValue = (TEnum)enumValues.GetValue(i);

				panel.RowStyles.Add(new RowStyle(SizeType.Percent, rowHeightPercent));

				RadioButton radioButton = new RadioButton();
				radioButton.Text = GetEnumDescription(enumValue);
				radioButton.Tag = enumValue;
				radioButton.Appearance = Appearance.Button;
				radioButton.Dock = DockStyle.Fill;
				radioButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

				radioButton.Font = new Font("맑은 고딕", BASE_FONT_SIZE, FontStyle.Regular, GraphicsUnit.Point, ((byte)(129)));
				radioButton.FlatStyle = FlatStyle.Standard;

				radioButton.Click += RadioButton_Item_Click;

				panel.Controls.Add(radioButton, 0, i);
			}

			// 초기 폰트 크기 조절 호출
			AdjustFontsToPanelSize();
		}

		private void AdjustFontsToPanelSize()
		{
			if (ContentPanel.Width == 0 || ContentPanel.Height == 0) return;

			float scaleFactor = ContentPanel.Height / (float)(ContentPanel.RowCount * 40); // 40은 임의의 기준 높이
			float newFontSize = BASE_FONT_SIZE * scaleFactor;

			newFontSize = Math.Min(Math.Max(newFontSize, 8F), 20F);

			foreach (Control control in ContentPanel.Controls)
			{
				if (control is RadioButton radioButton)
				{
					radioButton.Font = new Font(radioButton.Font.FontFamily, newFontSize, FontStyle.Regular, GraphicsUnit.Point, ((byte)(129)));
				}
			}
		}

		private void RadioButton_Item_Click(object sender, EventArgs e)
		{
			RadioButton? clickedButton = sender as RadioButton;
			if (clickedButton != null && clickedButton.Tag is TEnum selectedItem)
			{
				ItemSelected?.Invoke(this, selectedItem);
			}
		}

		private string GetEnumDescription(Enum enumValue)
		{
			FieldInfo? field = enumValue.GetType().GetField(enumValue.ToString());
			if (field == null) return enumValue.ToString();

			DescriptionAttribute? attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
			return attribute == null ? enumValue.ToString() : attribute.Description;
		}
	}
}
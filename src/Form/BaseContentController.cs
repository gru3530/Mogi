using System;
using System.Windows.Forms;
using System.ComponentModel;
using System.Reflection;
using System.Drawing;

namespace MOGI
{
	public class BaseContentController<TEnum> where TEnum : Enum
	{
		public Panel ContentPanel { get; private set; }
		public event EventHandler<TEnum> ItemSelected;

		public BaseContentController()
		{
			ContentPanel = new Panel
			{
				Dock = DockStyle.Fill,
				AutoScroll = true
			};

			InitializeContentUI();
		}

		private void InitializeContentUI()
		{
			var tableLayoutPanel = new TableLayoutPanel
			{
				ColumnCount = 1,
				Dock = DockStyle.Top,
				AutoSize = true,
				AutoSizeMode = AutoSizeMode.GrowAndShrink
			};
			tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));

			foreach (TEnum enumValue in Enum.GetValues(typeof(TEnum)))
			{
				tableLayoutPanel.RowCount++;
				tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
				RadioButton itemButton = CreateItemButton(enumValue);
				tableLayoutPanel.Controls.Add(itemButton, 0, tableLayoutPanel.RowCount - 1);
			}

			ContentPanel.Controls.Add(tableLayoutPanel);
		}

		private RadioButton CreateItemButton(TEnum enumValue)
		{
			var radioButton = new RadioButton
			{
				Text = GetEnumDescription(enumValue),
				Tag = enumValue,
				Appearance = Appearance.Button,
				Dock = DockStyle.Fill,
				TextAlign = ContentAlignment.MiddleCenter,
				Font = new Font("맑은 고딕", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(129)))
			};
			radioButton.Click += (sender, e) =>
			{
				if (sender is RadioButton clickedButton && clickedButton.Tag is TEnum selectedItem)
				{
					ItemSelected?.Invoke(this, selectedItem);
				}
			};
			return radioButton;
		}

		private string GetEnumDescription(Enum enumValue)
		{
			FieldInfo field = enumValue.GetType().GetField(enumValue.ToString());
			if (field == null) return enumValue.ToString();

			DescriptionAttribute attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
			return attribute == null ? enumValue.ToString() : attribute.Description;
		}
	}
}
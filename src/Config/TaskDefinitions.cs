using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace MOGI
{
	public static class TaskDefinition // TaskDefinitions -> TaskDefinition
	{
		public enum TaskType
		{
			None,
			[Description("나무베기")] Woodcutting,
			[Description("광석캐기")] Mining,
			[Description("약초채집")] HerbGathering,
			[Description("추수")] Harvest,
			[Description("호미질")] Hoeing,
			[Description("곤충채집")] InsectGathering
		}

		public static readonly Dictionary<TaskType, string> TaskNames = new Dictionary<TaskType, string>
		{
			{ TaskType.None, "대기 중" },
			{ TaskType.Harvest, "추수 중" },
			{ TaskType.Hoeing, "호미질 중" },
			{ TaskType.HerbGathering, "약초채집 중" },
			{ TaskType.Mining, "광석캐는 중" },
			{ TaskType.Woodcutting, "나무베는 중" },
			{ TaskType.InsectGathering, "곤충채집 중" }
		};

		public enum LifeActivityType
		{
			[Description("나무베기")] Woodcutting = TaskType.Woodcutting,
			[Description("광석캐기")] Mining = TaskType.Mining,
			[Description("약초채집")] HerbGathering = TaskType.HerbGathering,
			[Description("추수")] Harvest = TaskType.Harvest,
			[Description("호미질")] Hoeing = TaskType.Hoeing,
			[Description("곤충채집")] InsectGathering = TaskType.InsectGathering
		}

		public static string GetEnumDescription<TEnum>(TEnum enumValue) where TEnum : Enum
		{
			FieldInfo field = typeof(TEnum).GetField(enumValue.ToString());
			if (field == null) return enumValue.ToString();

			DescriptionAttribute attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
			return attribute == null ? enumValue.ToString() : attribute.Description;
		}
	}
}
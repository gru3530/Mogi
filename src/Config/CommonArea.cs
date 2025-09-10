using System;
using System.Drawing;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using MOGI; // CommonEnum.cs의 enum들을 사용하기 위해 네임스페이스 명시

namespace MOGI
{
	public static class CommonArea
	{
		private static readonly Dictionary<Type, object> _areaMaps = new Dictionary<Type, object>();
		private static Dictionary<Keys, Rectangle> _keyMaps;

		public static readonly Point ScrollStartPoint = new Point(1230, 550);
		public static readonly double ScrollDragDurationSeconds = 0.5;
		public static readonly int ScrollPostDelayMinMs = 500;
		public static readonly int ScrollPostDelayMaxMs = 1000;
		public static readonly int StartX = 1100;
		public static readonly int StartY = 520;
		public static readonly int height = 95;
		public static readonly int width = 650;

		private static readonly Dictionary<int, Rectangle> _defaultSlotAreas = new Dictionary<int, Rectangle>
		{
			{ 0, new Rectangle(StartX, 530, width, height) },
			{ 1, new Rectangle(StartX, 680, width, height) },
			{ 2, new Rectangle(StartX, 820, width, height) },
			{ 3, new Rectangle(StartX, 960, width, height) }
		};

		public static IReadOnlyDictionary<int, Rectangle> DefaultSlotAreas => _defaultSlotAreas;

		private static readonly Dictionary<Enum, Rectangle> _itemSpecificAreas = new Dictionary<Enum, Rectangle>
		{
            { WoodType.Normal, new Rectangle(697, 565, 170, 25) },
			{ WoodType.Pointed, new Rectangle(697, 565, 170, 25) },
			{ WoodType.Thick, new Rectangle(697, 565, 170, 25) },
			{ WoodType.Usable, new Rectangle(690, 620, 170, 25) },

			//얼음 필요없음
			{ MineralType.Ore, new Rectangle(690, 620, 170, 25) },
			{ MineralType.Coal, new Rectangle(690, 620, 170, 25) },
			{ MineralType.Iron, new Rectangle(690, 620, 170, 25) },
		};


		static CommonArea()
		{
			RegisterAreaMap(new Dictionary<AreaType, Rectangle>
			{
				{ AreaType.ProfileClick, new Rectangle(30, 30, 90, 90) }, 
                { AreaType.LifeSkill, new Rectangle(974, 34, 100, 50) },     
                { AreaType.Wood, new Rectangle(370, 159, 150, 240) },
				{ AreaType.Mining, new Rectangle(580, 159, 150, 240) },
				{ AreaType.Harvest, new Rectangle(1190, 159, 150, 240) },
				{ AreaType.Hoeing, new Rectangle(1400, 157, 150, 240) },
				{ AreaType.HerbGathering, new Rectangle(785, 157, 150, 240) },
				{ AreaType.InsectGathering, new Rectangle(1612, 157, 150, 240) },
				{ AreaType.Hoeing, new Rectangle(1400, 157, 150, 240) },
				{ AreaType.LocationMove, new Rectangle(690, 600, 170, 25) },
				{ AreaType.Skip, new Rectangle(1700, 35, 150, 40) },
				{ AreaType.Open, new Rectangle(1064, 960, 150, 60) },
			});

			RegisterKeyMaps();
		}

		private static void RegisterAreaMap<TEnum>(Dictionary<TEnum, Rectangle> map) where TEnum : Enum
		{
			_areaMaps[typeof(TEnum)] = map;
		}


		private static void RegisterKeyMaps()
		{
			_keyMaps = new Dictionary<Keys, Rectangle>
		{
			{ Keys.F1, GetArea(AreaType.Open) },
			{ Keys.F2, GetArea(AreaType.Skip) },
            
            // 새로 추가할 단축키
            { Keys.Control | Keys.Oemcomma, GetArea(AreaType.Open) }, // Ctrl + ,
            { Keys.Control | Keys.OemPeriod, GetArea(AreaType.Skip) }  // Ctrl + .
        };
		}
		public static Dictionary<Keys, Rectangle> GetKeyMaps()
		{
			return _keyMaps;
		}

		public static Rectangle GetArea<TEnum>(TEnum areaType) where TEnum : Enum
		{
			if (_areaMaps.TryGetValue(typeof(TEnum), out object mapObject))
			{
				Dictionary<TEnum, Rectangle> map = mapObject as Dictionary<TEnum, Rectangle>;
				if (map != null)
				{
					if (map.TryGetValue(areaType, out Rectangle area))
					{
						return area;
					}
					throw new KeyNotFoundException($"The specified area type '{areaType}' was not found in the dictionary for {typeof(TEnum).Name}.");
				}
			}
			throw new ArgumentException($"Unsupported enum type or map not registered: {typeof(TEnum).Name}");
		}
		public static Rectangle GetLocationMove<TEnum>(TEnum itemType) where TEnum : Enum
		{
			if (_itemSpecificAreas.TryGetValue(itemType, out Rectangle specificRect))
			{
				return specificRect;
			}

			return GetArea(AreaType.LocationMove);
		}


		public static Rectangle GetScrollableItemArea<TItemEnum>(TItemEnum typeToFindEnum, TItemEnum[] allPossibleEnums) where TItemEnum : Enum
		{
			int index = Array.IndexOf(allPossibleEnums, typeToFindEnum);
			if (index == -1)
			{
				throw new ArgumentException($"Enum value {typeToFindEnum} not found in the provided list of possible enums.");
			}

			if (index < _defaultSlotAreas.Count)
			{
				return _defaultSlotAreas[index];
			}
			else
			{
				return _defaultSlotAreas[0];
			}
		}
	}
}
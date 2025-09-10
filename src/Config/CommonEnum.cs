using System.ComponentModel;

public enum AreaType
{
	[Description("프로필 클릭 영역")] ProfileClick,
	[Description("생활 스킬 영역")] LifeSkill,
	[Description("추수 스킬 영역")] Harvest,
	[Description("나무 베기")] Wood,
	[Description("호미질")] Hoeing,
	[Description("채광")] Mining,
	[Description("약초 채집")] HerbGathering,
	[Description("곤충 채집")] InsectGathering,
	[Description("이동 시작")] LocationMove,
	[Description("장면넘기기")] Skip,
	[Description("계속 열기")] Open,
}

public enum CropType
{
	[Description("밀")] Wheat,
	[Description("옥수수")] Corn,
	[Description("콩")] Bean,
	
}

public enum HoeingType
{
	[Description("감자")] Potato,
	[Description("양파")] Onion,
	[Description("조개")] Clam,
	[Description("파스닙")] Parsnip
}

public enum MineralType
{
	[Description("광맥")] Ore,
	[Description("철광")] Iron,
	[Description("얼음")] Ice,
	[Description("석탄")] Coal,
	[Description("동광")] Copper,
	[Description("백동광")] WhiteCopper,
	[Description("은광")] Silver
}

public enum WoodType
{
	[Description("나무")] Normal,
	[Description("뾰족나무")] Pointed,
	[Description("굵은나무")] Thick,
	[Description("쓸만한나무")] Usable,
	[Description("갑옷나무")] Armor,
	[Description("어스름나무")] Gloomy
}

public enum HerbType
{
	[Description("허브")] Herb,
	[Description("블러디 허브")] BloodyHerb,
	[Description("화살꽃")] ArrowFlower,
	[Description("마나허브")] ManaHerb,
	[Description("새록 버섯")] FreshMushroom,
	[Description("튼튼 버섯")] SturdyMushroom,
	[Description("끈기 풀")] TenacityHerb,
	[Description("쑥쑥 버섯")] GrowthMushroom,
	[Description("숨숨꽃")] HidingFlower,
	[Description("깔끔 버섯")] NeatMushroom,
	[Description("생채기꽃")] WoundFlower,
	[Description("증폭 버섯")] AmplifyMushroom
}

public enum InsectType
{
	[Description("빛 무리")] Light,
	[Description("설원 빛 무리")] SnowfieldLight,
	[Description("곤충 무리")] Insect,
	[Description("고요한 빛 무리")] QuietLight,
	[Description("따스한 빛 무리")] WarmLight,
	[Description("차가운 빛 무리")] ColdLight,
	[Description("삭막한 곤충 무리")] BleakInsect
}
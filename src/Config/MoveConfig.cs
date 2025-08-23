using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOGI
{
	public enum MouseSpeedProfile
	{
		Normal, // 기본 속도
		Slow,   // 느린 속도
		Rapid,  // 빠른 속도
		VerySlow, // 매우 느린 속도 (예시)
		VeryRapid // 매우 빠른 속도 (예시)
	}

	internal class MoveConfig
	{

		public double DurationSeconds { get; set; }
		public double NoiseMagnitude { get; set; }
		public double OvershootChance { get; set; }
		public double OvershootAmount { get; set; }

		public MoveConfig(double duration, double noise, double overshootChance, double overshootAmount)
		{
			DurationSeconds = duration;
			NoiseMagnitude = noise;
			OvershootChance = overshootChance;
			OvershootAmount = overshootAmount;
		}

		private static readonly Dictionary<MouseSpeedProfile, MoveConfig> _mouseSpeedProfiles = new Dictionary<MouseSpeedProfile, MoveConfig>
		{
			//              Duration, Noise, OvershootChance, OvershootAmount
			{ MouseSpeedProfile.Normal,   new MoveConfig(0.4, 3.0, 0.15, 0.05) }, // 현재 기본값
			{ MouseSpeedProfile.Slow,     new MoveConfig(0.8, 5.0, 0.20, 0.07) }, // 느리게 (시간 늘리고 노이즈/오버슈트 증가)
			{ MouseSpeedProfile.Rapid,    new MoveConfig(0.2, 1.5, 0.05, 0.03) }, // 빠르게 (시간 줄이고 노이즈/오버슈트 감소)
			{ MouseSpeedProfile.VerySlow, new MoveConfig(1.5, 7.0, 0.25, 0.10) }, // 매우 느리게
			{ MouseSpeedProfile.VeryRapid,new MoveConfig(0.1, 0.5, 0.01, 0.01) }  // 매우 빠르게
		};

		public static MoveConfig GetMouseSpeedParameters(MouseSpeedProfile profile)
		{
			if (_mouseSpeedProfiles.TryGetValue(profile, out MoveConfig? parameters))
			{
				return parameters;
			}
			else
			{
				throw new KeyNotFoundException($"The specified mouse speed profile '{profile}' was not found in CommonArea dictionary. Please ensure it's defined.");
			}
		}


	}

}

using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;

namespace MOGI
{
	public class ConfigManager
	{
		private static readonly Lazy<ConfigManager> _instance = new Lazy<ConfigManager>(() => new ConfigManager());
		public static ConfigManager Instance => _instance.Value;

		public AppSettings Settings { get; private set; }

		private ConfigManager()
		{
			LoadSettings();
		}

		private void LoadSettings()
		{
			try
			{
				string jsonString = File.ReadAllText("config.json");
				Settings = JsonSerializer.Deserialize<AppSettings>(jsonString);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"config.json 로드 실패: {ex.Message}");
				Settings = new AppSettings
				{
					AutoSell = new AutoSellSettings
					{
						JunkItemNames = new List<string>()
					}
				};
			}
		}
	}
}
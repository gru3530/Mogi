using System.Text.Json;

namespace MOGI
{
	public class ConfigManager
	{
		private static readonly Lazy<ConfigManager> _instance = new Lazy<ConfigManager>(() => new ConfigManager());
		public static ConfigManager Instance => _instance.Value;

		public AppSettings Settings { get; private set; }
		public bool IsConfigLoadedFromFile { get; private set; } = false;
		public const string ConfigFileName = "config.json";

		private ConfigManager()
		{
			LoadSettings();
		}

		private void LoadSettings()
		{
			try
			{
				string jsonString = File.ReadAllText(ConfigFileName);
				Settings = JsonSerializer.Deserialize<AppSettings>(jsonString);
				IsConfigLoadedFromFile = true;
			}
			catch
			{
				IsConfigLoadedFromFile = false;
				Settings = new AppSettings { AutoSell = new AutoSellSettings { JunkItemNames = new List<string>() } };
			}
		}

		public void SaveSettings(AppSettings settings)
		{
			try
			{
				var options = new JsonSerializerOptions { WriteIndented = true };
				string newJsonString = JsonSerializer.Serialize(settings, options);
				File.WriteAllText(ConfigFileName, newJsonString);

				this.Settings = settings;
			}
			catch (Exception ex)
			{
				MessageBox.Show($"{ConfigFileName} 파일 저장에 실패했습니다: {ex.Message}");
			}
		}

		public (List<string> ValidItems, List<string> InvalidItems) ValidateAndGetSellList()
		{
			var validItems = new List<string>();
			var invalidItems = new List<string>();

			var assetManager = AssetManager.Instance;
			var configItems = this.Settings.AutoSell?.JunkItemNames ?? new List<string>();

			var buttonNames = Enum.GetValues(typeof(ButtonType))
								  .Cast<ButtonType>()
								  .Select(e => TaskDefinition.GetEnumDescription(e))
								  .ToList();

			foreach (var itemName in configItems)
			{
				if (assetManager.ItemTemplateNames.Contains(itemName) && !buttonNames.Contains(itemName))
				{
					validItems.Add(itemName);
				}
				else
				{
					invalidItems.Add(itemName);
				}
			}
			return (validItems, invalidItems);
		}
	}
}
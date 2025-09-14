using Emgu.CV;
using Emgu.CV.CvEnum;

namespace MOGI
{
	public class AssetManager : IDisposable
	{
		private static readonly Lazy<AssetManager> _instance = new Lazy<AssetManager>(() => new AssetManager());
		public static AssetManager Instance => _instance.Value;

		public List<string> ItemTemplateNames { get; private set; }
		public List<string> ButtonTemplateNames { get; private set; }
		public Dictionary<string, Mat> ItemTemplates { get; private set; }
		public Dictionary<string, Mat> ButtonTemplates { get; private set; }

		private AssetManager()
		{
			ItemTemplateNames = new List<string>();
			ButtonTemplateNames = new List<string>();
			ItemTemplates = new Dictionary<string, Mat>();
			ButtonTemplates = new Dictionary<string, Mat>();
			LoadTemplatesFromDisk();
		}

		private void LoadTemplatesFromDisk()
		{
			string templateDir = "templates";
			if (!Directory.Exists(templateDir)) return;


			foreach (var filePath in Directory.GetFiles(templateDir, "*.png"))
			{
				string fileName = Path.GetFileNameWithoutExtension(filePath);
				Mat templateMat = CvInvoke.Imread(filePath, ImreadModes.AnyColor);

				if (fileName.Contains("_button"))
				{
					ButtonTemplates[fileName] = templateMat;
					ButtonTemplateNames.Add(fileName);
				}
				else
				{
					ItemTemplates[fileName] = templateMat;
					ItemTemplateNames.Add(fileName);
				}
			}
		}

		public void Dispose()
		{
			foreach (var mat in ItemTemplates.Values) mat.Dispose();
			foreach (var mat in ButtonTemplates.Values) mat.Dispose();
		}
	}
}
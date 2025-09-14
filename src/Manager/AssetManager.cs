using Emgu.CV;
using Emgu.CV.CvEnum;

namespace MOGI
{
	public class AssetManager : IDisposable
	{
		private static readonly Lazy<AssetManager> _instance = new Lazy<AssetManager>(() => new AssetManager());
		public static AssetManager Instance => _instance.Value;

		public Dictionary<string, Mat> ItemTemplates { get; private set; }
		public Dictionary<string, Mat> ButtonTemplates { get; private set; }

		private AssetManager()
		{
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
				}
				else
				{
					ItemTemplates[fileName] = templateMat;
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
using System;
using System.Collections.Generic;
using System.IO;
using Emgu.CV;
using Emgu.CV.CvEnum;

namespace MOGI
{
	public class AssetManager : IDisposable
	{
		private static readonly Lazy<AssetManager> _instance = new Lazy<AssetManager>(() => new AssetManager());
		public static AssetManager Instance => _instance.Value;

		public Dictionary<string, Mat> ItemTemplates { get; } = new Dictionary<string, Mat>();
		public Dictionary<string, Mat> ButtonTemplates { get; } = new Dictionary<string, Mat>();
		public Dictionary<string, Mat> SpecificMasks { get; } = new Dictionary<string, Mat>();

		private AssetManager()
		{
			LoadTemplatesFromDisk();
		}

		private void LoadTemplatesFromDisk()
		{
			string baseDir = "Resource";
			var itemsToLoad = new HashSet<string>(ConfigManager.Instance.Settings.AutoSell.JunkItemNames);

			LoadAssetsFromDirectory(Path.Combine(baseDir, "Buttons"), ButtonTemplates, ImreadModes.AnyColor);
			LoadAssetsFromDirectory(Path.Combine(baseDir, "Items"), ItemTemplates, ImreadModes.AnyColor, name => itemsToLoad.Contains(name));
			LoadAssetsFromDirectory(Path.Combine(baseDir, "Masks"), SpecificMasks, ImreadModes.Grayscale);
		}

		private void LoadAssetsFromDirectory(string directoryPath, Dictionary<string, Mat> targetDictionary, ImreadModes mode, Func<string, bool> filter = null)
		{
			if (!Directory.Exists(directoryPath)) return;

			foreach (var filePath in Directory.GetFiles(directoryPath, "*.png"))
			{
				string fileName = Path.GetFileNameWithoutExtension(filePath);
				if (filter != null && !filter(fileName))
				{
					continue;
				}

				using (Mat sourceMat = CvInvoke.Imread(filePath, mode))
				{
					if (sourceMat.IsEmpty) continue;

					if (mode != ImreadModes.Grayscale)
					{
						Mat grayMat = new Mat();
						CvInvoke.CvtColor(sourceMat, grayMat, ColorConversion.Bgr2Gray);
						targetDictionary[fileName] = grayMat;
					}
					else
					{
						targetDictionary[fileName] = sourceMat.Clone();
					}
				}
			}
		}

		public void Dispose()
		{
			// 관리하는 모든 Mat 객체를 Dispose
			foreach (var mat in ItemTemplates.Values) mat.Dispose();
			foreach (var mat in ButtonTemplates.Values) mat.Dispose();
			foreach (var mat in SpecificMasks.Values) mat.Dispose();
		}
	}
}
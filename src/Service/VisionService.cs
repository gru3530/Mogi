using System.Diagnostics;
using System.Drawing.Imaging;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

namespace MOGI
{
	public class MatchResult
	{
		public string ItemName { get; set; }
		public Rectangle Bounds { get; set; }
		public double Confidence { get; set; }
	}

	public class VisionService
	{
		public Mat CaptureScreenMat(Rectangle area)
		{
			using (var bmp = new Bitmap(area.Width, area.Height))
			{
				using (var g = Graphics.FromImage(bmp))
				{
					g.CopyFromScreen(area.Location, Point.Empty, area.Size);
				}
				return BitmapToMat(bmp);
			}
		}

		public MatchResult FindItemMatch(Mat screenMat, string itemName, float threshold = 0.8f)
		{
			if (!AssetManager.Instance.ItemTemplates.TryGetValue(itemName, out Mat templateMat))
			{
				return null;
			}
			string debugDir = "Debug";

			if(!Directory.Exists(debugDir))
			{
				Directory.CreateDirectory(debugDir);
			}
			
			AssetManager.Instance.SpecificMasks.TryGetValue(itemName, out Mat maskMat);
			if (maskMat == null)
			{
				using (Mat dynamicMask = CreateGenericMask(templateMat))
				using (Mat maskedResult = new Mat())
				{
					CvInvoke.BitwiseAnd(templateMat, templateMat, maskedResult, dynamicMask);
					return FindMatch(screenMat, templateMat, dynamicMask, threshold, itemName);
				}
			}
			return FindMatch(screenMat, templateMat, maskMat, threshold, itemName);
		}

		public MatchResult FindButtonMatch(Rectangle searchArea, string buttonName, float threshold = 0.8f)
		{
			if (!AssetManager.Instance.ButtonTemplates.TryGetValue(buttonName, out Mat templateMat))
			{
				return null;
			}
			AssetManager.Instance.SpecificMasks.TryGetValue(buttonName, out Mat maskMat);

			using (Mat screenMat = CaptureScreenMat(searchArea))
			{
				var result = FindMatch(screenMat, templateMat, maskMat, threshold, buttonName);
				if (result != null)
				{
					Rectangle relativeBounds = result.Bounds;
					relativeBounds.Offset(searchArea.Location);
					result.Bounds = relativeBounds;
				}
				return result;
			}
		}

		private MatchResult FindMatch(Mat screenMat, Mat templateMat, Mat maskMat, float threshold, string itemName = "")
		{
			if (templateMat.IsEmpty || screenMat.IsEmpty) return null;

			using (Mat result = new Mat())
			using (Mat grayScreen = new Mat())
			{
				CvInvoke.CvtColor(screenMat, grayScreen, ColorConversion.Bgr2Gray);

				CvInvoke.MatchTemplate(grayScreen, templateMat, result, TemplateMatchingType.CcoeffNormed, maskMat);

				double minVal = 0, maxVal = 0;
				Point minLoc = default, maxLoc = default;
				CvInvoke.MinMaxLoc(result, ref minVal, ref maxVal, ref minLoc, ref maxLoc);

				if (maxVal >= threshold)
				{
					return new MatchResult
					{
						ItemName = itemName,
						Bounds = new Rectangle(maxLoc.X, maxLoc.Y, templateMat.Width, templateMat.Height),
						Confidence = maxVal
					};
				}
			}
			return null;
		}

		private Mat CreateGenericMask(Mat template)
		{
			Mat mask = new Mat(template.Size, DepthType.Cv8U, 1);
			mask.SetTo(new MCvScalar(255));

			int rectX = (int)(template.Width * 0.31);
			int rectY = (int)(template.Height * 0.38);
			int rectWidth = (int)(template.Width * 0.64);
			int rectHeight = (int)(template.Height * 0.29);

			var maskRect = new Rectangle(rectX, rectY, rectWidth, rectHeight);
			CvInvoke.Rectangle(mask, maskRect, new MCvScalar(0), -1);
			return mask;
		}

		public async Task WaitForUiStability(Rectangle watchArea, CancellationToken token, int stableTimeMs = 200, int timeoutMs = 2000)
		{
			var timeoutStopwatch = Stopwatch.StartNew();
			var stabilityStopwatch = Stopwatch.StartNew();
			byte[] lastHash = GetScreenAreaHash(watchArea);

			while (timeoutStopwatch.ElapsedMilliseconds < timeoutMs)
			{
				if (token.IsCancellationRequested) return;
				await Task.Delay(50, token);
				byte[] currentHash = GetScreenAreaHash(watchArea);

				if (lastHash.SequenceEqual(currentHash))
				{
					if (stabilityStopwatch.ElapsedMilliseconds >= stableTimeMs)
					{
						return;
					}
				}
				else
				{
					lastHash = currentHash;
					stabilityStopwatch.Restart();
				}
			}
		}

		private byte[] GetScreenAreaHash(Rectangle area)
		{
			using (var bmp = new Bitmap(area.Width, area.Height))
			using (var g = Graphics.FromImage(bmp))
			{
				g.CopyFromScreen(area.Location, Point.Empty, area.Size);
				using (var sha256 = System.Security.Cryptography.SHA256.Create())
				using (var ms = new MemoryStream())
				{
					bmp.Save(ms, ImageFormat.Png);
					return sha256.ComputeHash(ms.ToArray());
				}
			}
		}

		private Mat BitmapToMat(Bitmap bmp)
		{
			Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
			BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.ReadOnly, bmp.PixelFormat);

			Mat mat;
			try
			{
				int channels = Image.GetPixelFormatSize(bmp.PixelFormat) / 8;
				using (Mat tempMat = new Mat(bmp.Height, bmp.Width, DepthType.Cv8U, channels, bmpData.Scan0, bmpData.Stride))
				{
					mat = tempMat.Clone();
				}
			}
			finally
			{
				bmp.UnlockBits(bmpData);
			}
			return mat;
		}
	}
}
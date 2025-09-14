using Emgu.CV;
using Emgu.CV.CvEnum;


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
		public List<MatchResult> FindAllMatches(Rectangle searchArea, Mat templateMat, float threshold = 0.8f)
		{
			var matches = new List<MatchResult>();
			if (templateMat.IsEmpty) return matches;

			using (var screenBitmap = new Bitmap(searchArea.Width, searchArea.Height))
			{
				using (var g = Graphics.FromImage(screenBitmap))
				{
					g.CopyFromScreen(searchArea.Location, Point.Empty, searchArea.Size);
				}
				using (Mat screenMat = screenBitmap.ToMat())
				{
					using (Mat result = new Mat())
					{
						CvInvoke.MatchTemplate(screenMat, templateMat, result, TemplateMatchingType.CcoeffNormed);

						double minVal = 0, maxVal = 0;
						Point minLoc = default, maxLoc = default;
						CvInvoke.MinMaxLoc(result, ref minVal, ref maxVal, ref minLoc, ref maxLoc);

						if (maxVal >= threshold)
						{
							var bounds = new Rectangle(searchArea.X + maxLoc.X, searchArea.Y + maxLoc.Y, templateMat.Width, templateMat.Height);
							matches.Add(new MatchResult { Bounds = bounds, Confidence = maxVal });
						}
					}
				}
			}
			return matches;
		}

		public MatchResult FindTemplateOnScreen(string templateName, float threshold = 0.9f)
		{
			if (!AssetManager.Instance.ButtonTemplates.TryGetValue(templateName, out Mat templateMat))
			{
				Console.WriteLine($"{templateName} 템플릿을 AssetManager에서 찾을 수 없습니다.");
				return null;
			}

			var searchArea = Screen.PrimaryScreen.Bounds;
			var matches = this.FindAllMatches(searchArea, templateMat, threshold);

			return matches.FirstOrDefault();
		}
	}
}
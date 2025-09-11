using System.Drawing.Imaging;
using Tesseract;

namespace MOGI
{
	public class TextRecognitionResult
	{
		public string Text { get; set; }
		public Rectangle Bounds { get; set; }
	}

	public class OcrService
	{
		private readonly TesseractEngine _engine;

		public OcrService()
		{
			_engine = new TesseractEngine(@"./tessdata", "kor", EngineMode.Default);
		}

		public List<TextRecognitionResult> RecognizeText(Rectangle area)
		{
			var results = new List<TextRecognitionResult>();

			using (var bmp = new Bitmap(area.Width, area.Height))
			{
				using (var g = Graphics.FromImage(bmp))
				{
					g.CopyFromScreen(area.Location, Point.Empty, area.Size);
				}

				using (var preprocessedBmp = PreprocessImage(bmp))
				{
					Pix pix = null;
					try
					{
						using (var ms = new MemoryStream())
						{
							preprocessedBmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
							pix = Pix.LoadFromMemory(ms.ToArray());
						}

						using (var page = _engine.Process(pix, PageSegMode.Auto))
						{
							using (var iter = page.GetIterator())
							{
								iter.Begin();
								do
								{
									if (iter.TryGetBoundingBox(PageIteratorLevel.Block, out var rect))
									{
										var text = iter.GetText(PageIteratorLevel.Block)?.Trim().Replace("\n", " ");
										if (!string.IsNullOrEmpty(text))
										{
											results.Add(new TextRecognitionResult
											{
												Text = text,
												Bounds = new Rectangle(area.X + rect.X1, area.Y + rect.Y1, rect.Width, rect.Height)
											});
										}
									}
								} while (iter.Next(PageIteratorLevel.Block));
							}
						}
					}
					finally
					{
						pix?.Dispose();
					}
				}
			}
			return results;
		}
		private Bitmap PreprocessImage(Bitmap source)
		{
			var newBitmap = new Bitmap(source.Width, source.Height);
			using (var g = Graphics.FromImage(newBitmap))
			{
				var colorMatrix = new ColorMatrix(
				   new float[][]
				   {
					  new float[] {.3f, .3f, .3f, 0, 0},
					  new float[] {.59f, .59f, .59f, 0, 0},
					  new float[] {.11f, .11f, .11f, 0, 0},
					  new float[] {0, 0, 0, 1, 0},
					  new float[] {0, 0, 0, 0, 1}
				   });

				using (var attributes = new ImageAttributes())
				{
					attributes.SetColorMatrix(colorMatrix);
					g.DrawImage(source, new Rectangle(0, 0, source.Width, source.Height),
								0, 0, source.Width, source.Height, GraphicsUnit.Pixel, attributes);
				}
			}
			return newBitmap;
		}
	}
}
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
			return null;
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
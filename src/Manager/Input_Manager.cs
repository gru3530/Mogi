using System.Runtime.InteropServices;

namespace MOGI
{
	public class Input_Manager
	{
		private static readonly Lazy<Input_Manager> _instance = new Lazy<Input_Manager>(() => new Input_Manager());
		public static Input_Manager Instance => _instance.Value;

		private Random _random;
		public Random RandomInstance => _random;
		private int _monitorXOffset = 0;

		private Input_Manager()
		{
			_random = new Random();
		}

		public void SetMonitorXOffset(int offset)
		{
			_monitorXOffset = offset;
		}

		[DllImport("user32.dll", SetLastError = true)]
		private static extern uint SendInput(uint nInputs, INPUT[] pInputs, int cbSize);

		[StructLayout(LayoutKind.Sequential)]
		private struct INPUT
		{
			public uint type;
			public InputUnion U;
		}

		[StructLayout(LayoutKind.Explicit)]
		private struct InputUnion
		{
			[FieldOffset(0)]
			public MOUSEINPUT mi;
			[FieldOffset(0)]
			public KEYBDINPUT ki;
			[FieldOffset(0)]
			public HARDWAREINPUT hi;
		}

		[StructLayout(LayoutKind.Sequential)]
		private struct MOUSEINPUT
		{
			public int dx;
			public int dy;
			public uint mouseData;
			public uint dwFlags;
			public uint time;
			public IntPtr dwExtraInfo;
		}

		[StructLayout(LayoutKind.Sequential)]
		private struct KEYBDINPUT
		{
			public ushort wVk;
			public ushort wScan;
			public uint dwFlags;
			public uint time;
			public IntPtr dwExtraInfo;
		}

		[StructLayout(LayoutKind.Sequential)]
		private struct HARDWAREINPUT
		{
			public uint uMsg;
			public ushort wParamL;
			public ushort wParamH;
		}

		private const uint INPUT_MOUSE = 0;
		private const uint INPUT_KEYBOARD = 1;
		private const uint MOUSEEVENTF_LEFTDOWN = 0x0002;
		private const uint MOUSEEVENTF_LEFTUP = 0x0004;
		private const uint MOUSEEVENTF_WHEEL = 0x0800;
		private const uint KEYEVENTF_KEYDOWN = 0x0000;
		private const uint KEYEVENTF_KEYUP = 0x0002;

		private double NextGaussian(double mean, double stdDev)
		{
			double u1 = 1.0 - _random.NextDouble();
			double u2 = 1.0 - _random.NextDouble();
			double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);
			return mean + stdDev * randStdNormal;
		}

		public async Task RandomDelay(int minMs, int maxMs, CancellationToken token)
		{
			if (minMs > maxMs) maxMs = minMs;
			int delay = _random.Next(minMs, maxMs + 1);
			await Task.Delay(delay, token);
		}

		public Point GetRandomPointInBox(Rectangle box)
		{
			int x = _random.Next(box.Left, box.Right);
			int y = _random.Next(box.Top, box.Bottom);
			return new Point(x + _monitorXOffset, y);
		}

		public (Point Start, Point End) GetPreciseDragPoints(Rectangle startBox, Rectangle endBox)
		{
			int offsetX = _random.Next(-10, 11);
			int offsetY = _random.Next(-5, 6);

			Point startCenter = new Point((startBox.Left + startBox.Right) / 2, (startBox.Top + startBox.Bottom) / 2);
			Point endCenter = new Point((endBox.Left + endBox.Right) / 2, (endBox.Top + endBox.Bottom) / 2);

			Point startPoint = new Point(startCenter.X + offsetX, startCenter.Y + offsetY);
			Point endPoint = new Point(endCenter.X + offsetX, endCenter.Y + offsetY);

			startPoint.X += _monitorXOffset;
			endPoint.X += _monitorXOffset;

			return (startPoint, endPoint);
		}

		public async Task MoveMouseHumanLike(Point targetPosition, CancellationToken token, double durationSeconds = 0.25, double noiseMagnitude = 3.0, double overshootChance = 0.1, double overshootAmount = 0.1)
		{
			Point startPosition = Cursor.Position;
			double totalDistance = Math.Sqrt(Math.Pow(targetPosition.X - startPosition.X, 2) + Math.Pow(targetPosition.Y - startPosition.Y, 2));

			if (totalDistance < 1) return;

			double controlPointOffsetMagnitude = Math.Min(totalDistance * 0.15, 80);
			Point controlPoint = new Point(
				(int)(startPosition.X + (targetPosition.X - startPosition.X) * 0.5 + NextGaussian(0, controlPointOffsetMagnitude) * (_random.Next(0, 2) * 2 - 1)),
				(int)(startPosition.Y + (targetPosition.Y - startPosition.Y) * 0.5 + NextGaussian(0, controlPointOffsetMagnitude) * (_random.Next(0, 2) * 2 - 1))
			);

			if (totalDistance < 50) controlPoint = new Point((startPosition.X + targetPosition.X) / 2, (startPosition.Y + targetPosition.Y) / 2);

			int calculatedMinSteps = Math.Max(30, (int)(totalDistance / 8.0));
			int calculatedMaxSteps = Math.Max(calculatedMinSteps + 1, (int)(totalDistance / 4.0));
			int finalMinSteps = Math.Min(calculatedMinSteps, 150);
			int finalMaxSteps = Math.Min(calculatedMaxSteps, 200);

			if (finalMinSteps > finalMaxSteps) finalMinSteps = finalMaxSteps;
			int steps = _random.Next(finalMinSteps, finalMaxSteps + 1);
			if (steps == 0) steps = 1;

			long startTime = Environment.TickCount;
			long targetDurationMs = (long)(durationSeconds * 1000);

			for (int i = 0; i <= steps; i++)
			{
				token.ThrowIfCancellationRequested();
				double t = (double)i / steps;
				double smoothed_t = t < 0.5 ? 2 * t * t : 1 - Math.Pow(-2 * t + 2, 2) / 2;

				int currentX = (int)(Math.Pow(1 - smoothed_t, 2) * startPosition.X + 2 * (1 - smoothed_t) * smoothed_t * controlPoint.X + Math.Pow(smoothed_t, 2) * targetPosition.X);
				int currentY = (int)(Math.Pow(1 - smoothed_t, 2) * startPosition.Y + 2 * (1 - smoothed_t) * smoothed_t * controlPoint.Y + Math.Pow(smoothed_t, 2) * targetPosition.Y);

				currentX += (int)NextGaussian(0, noiseMagnitude);
				currentY += (int)NextGaussian(0, noiseMagnitude);

				Cursor.Position = new Point(currentX, currentY);

				long elapsedTimeSinceStart = Environment.TickCount - startTime;
				long expectedTimeAtThisStep = (long)(smoothed_t * targetDurationMs);
				long sleepTime = expectedTimeAtThisStep - elapsedTimeSinceStart;

				if (sleepTime > 0)
				{
					await Task.Delay((int)Math.Min(sleepTime, targetDurationMs / steps * 2 + 1), token);
				}
			}

			if (_random.NextDouble() < overshootChance)
			{
				token.ThrowIfCancellationRequested();
				Point overshootPoint = new Point(
					targetPosition.X + (int)(_random.NextDouble() * totalDistance * overshootAmount * (_random.Next(0, 2) * 2 - 1)),
					targetPosition.Y + (int)(_random.NextDouble() * totalDistance * overshootAmount * (_random.Next(0, 2) * 2 - 1))
				);
				await MoveMouseHumanLike(overshootPoint, token, durationSeconds * 0.15, noiseMagnitude * 0.5, 0.0, 0.0);
				await RandomDelay(30, 100, token);
				token.ThrowIfCancellationRequested();
				await MoveMouseHumanLike(targetPosition, token, durationSeconds * 0.15, noiseMagnitude * 0.5, 0.0, 0.0);
			}
			Cursor.Position = targetPosition;
		}

		public async Task SimulateTapAsync(Rectangle targetArea, CancellationToken token, int minClickDownTimeMs = 30, int maxClickDownTimeMs = 80)
		{
			Point targetPoint = GetRandomPointInBox(targetArea);
			Cursor.Position = targetPoint;
			await SimulateLeftClick(token, minClickDownTimeMs, maxClickDownTimeMs);
		}

		public async Task PerformClickSequence(
			Rectangle targetArea, CancellationToken token,
			int preClickDelayMinMs = 300, int preClickDelayMaxMs = 700,
			int clickDownTimeMinMs = 60, int clickDownTimeMaxMs = 180,
			int postClickDelayMinMs = 700, int postClickDelayMaxMs = 1500,
			double mouseMoveDurationSec = 0.25, double mouseMoveNoise = 3.0, double mouseOvershootChance = 0.15, double mouseOvershootAmount = 0.05,
			double oclickChance = 0.05, double oclickOffset = 20.0)
		{
			Point targetClickPoint = GetRandomPointInBox(targetArea);

			if (RandomInstance.NextDouble() < oclickChance)
			{
				Point oclickPoint = new Point(
					targetClickPoint.X + (int)((RandomInstance.NextDouble() * 2 - 1) * oclickOffset),
					targetClickPoint.Y + (int)((RandomInstance.NextDouble() * 2 - 1) * oclickOffset)
				);

				await MoveMouseHumanLike(oclickPoint, token, durationSeconds: mouseMoveDurationSec * 0.6, noiseMagnitude: mouseMoveNoise * 0.7, overshootChance: 0.0, overshootAmount: 0.0);
				await RandomDelay(100, 300, token);
				await MoveMouseHumanLike(targetClickPoint, token, durationSeconds: mouseMoveDurationSec * 0.8, noiseMagnitude: mouseMoveNoise * 0.8, overshootChance: mouseOvershootChance, overshootAmount: mouseOvershootAmount);
			}
			else
			{
				await MoveMouseHumanLike(targetClickPoint, token, durationSeconds: mouseMoveDurationSec, noiseMagnitude: mouseMoveNoise, overshootChance: mouseOvershootChance, overshootAmount: mouseOvershootAmount);
			}

			await RandomDelay(preClickDelayMinMs, preClickDelayMaxMs, token);
			await SimulateLeftClick(token, clickDownTimeMinMs, clickDownTimeMaxMs);
			await RandomDelay(postClickDelayMinMs, postClickDelayMaxMs, token);
		}

		public async Task SimulateDrag(Point start, Point end, CancellationToken token, double durationSeconds = 0.4, double noiseMagnitude = 3.0)
		{
			await MoveMouseHumanLike(start, token, durationSeconds: durationSeconds * 0.4, noiseMagnitude: noiseMagnitude);
			await RandomDelay(50, 100, token);

			INPUT[] inputs = new INPUT[1];
			inputs[0] = new INPUT { type = INPUT_MOUSE, U = new InputUnion { mi = new MOUSEINPUT { dwFlags = MOUSEEVENTF_LEFTDOWN } } };
			SendInput(1, inputs, Marshal.SizeOf(typeof(INPUT)));
			await RandomDelay(50, 100, token);

			await MoveMouseHumanLike(end, token, durationSeconds: durationSeconds * 0.6, noiseMagnitude: noiseMagnitude);
			
			Point counterMovePoint = new Point(end.X, end.Y + 5); 
			await MoveMouseHumanLike(counterMovePoint, token, durationSeconds: 0.05, noiseMagnitude: 1.0, overshootChance: 0.0);
			await WaitForCursorStability(token);
			await RandomDelay(30, 50, token); 

			inputs[0].U.mi.dwFlags = MOUSEEVENTF_LEFTUP;
			SendInput(1, inputs, Marshal.SizeOf(typeof(INPUT)));
			await RandomDelay(100, 200, token);
		}

		public async Task SimulateLeftClick(CancellationToken token, int minClickDownTimeMs = 50, int maxClickDownTimeMs = 150)
		{
			INPUT[] inputs = new INPUT[2];
			inputs[0] = new INPUT { type = INPUT_MOUSE, U = new InputUnion { mi = new MOUSEINPUT { dwFlags = MOUSEEVENTF_LEFTDOWN } } };
			inputs[1] = new INPUT { type = INPUT_MOUSE, U = new InputUnion { mi = new MOUSEINPUT { dwFlags = MOUSEEVENTF_LEFTUP } } };

			SendInput(1, new INPUT[] { inputs[0] }, Marshal.SizeOf(typeof(INPUT)));
			await RandomDelay(minClickDownTimeMs, maxClickDownTimeMs, token);
			SendInput(1, new INPUT[] { inputs[1] }, Marshal.SizeOf(typeof(INPUT)));
		}

		public async Task SimulateKeyPress(Keys key, CancellationToken token, int minDownTimeMs = 50, int maxDownTimeMs = 150)
		{
			token.ThrowIfCancellationRequested();
			INPUT[] inputs = new INPUT[2];

			inputs[0] = new INPUT { type = INPUT_KEYBOARD, U = new InputUnion { ki = new KEYBDINPUT { wVk = (ushort)key, dwFlags = KEYEVENTF_KEYDOWN } } };
			inputs[1] = new INPUT { type = INPUT_KEYBOARD, U = new InputUnion { ki = new KEYBDINPUT { wVk = (ushort)key, dwFlags = KEYEVENTF_KEYUP } } };

			SendInput(1, new INPUT[] { inputs[0] }, Marshal.SizeOf(typeof(INPUT)));
			await RandomDelay(minDownTimeMs, maxDownTimeMs, token);
			SendInput(1, new INPUT[] { inputs[1] }, Marshal.SizeOf(typeof(INPUT)));
		}

		public async Task SimulateMouseWheelScroll(int wheelDelta, CancellationToken token, double meanScrollDelayMs = 200, double stdDevScrollDelayMs = 50)
		{
			INPUT[] inputs = new INPUT[1];
			inputs[0].type = INPUT_MOUSE;
			inputs[0].U.mi.dwFlags = MOUSEEVENTF_WHEEL;
			inputs[0].U.mi.mouseData = (uint)wheelDelta;

			SendInput(1, inputs, Marshal.SizeOf(typeof(INPUT)));

			int delay = (int)Math.Max(50, NextGaussian(meanScrollDelayMs, stdDevScrollDelayMs));
			await RandomDelay(delay, delay + _random.Next(0, 10), token);
		}

		public Rectangle GetSecondaryMonitorCenterArea(int marginPercent = 10)
		{
			Screen secondaryScreen = Screen.AllScreens.FirstOrDefault(s => !s.Primary);
			if (secondaryScreen == null)
			{
				return GetPrimaryMonitorCenterArea(marginPercent);
			}
			return GetScreenCenterArea(secondaryScreen, marginPercent);
		}

		public Rectangle GetPrimaryMonitorCenterArea(int marginPercent = 10)
		{
			return GetScreenCenterArea(Screen.PrimaryScreen!, marginPercent);
		}

		private Rectangle GetScreenCenterArea(Screen screen, int marginPercent)
		{
			Rectangle bounds = screen.Bounds;
			int marginX = bounds.Width * marginPercent / 100;
			int marginY = bounds.Height * marginPercent / 100;
			return new Rectangle(
				bounds.X + marginX,
				bounds.Y + marginY,
				bounds.Width - 2 * marginX,
				bounds.Height - 2 * marginY
			);
		}

		private async Task WaitForCursorStability(CancellationToken token, int stabilityCheckMs = 50, int timeoutMs = 1000)
		{
			var stopwatch = System.Diagnostics.Stopwatch.StartNew();
			var stabilityStopwatch = System.Diagnostics.Stopwatch.StartNew();
			Point lastPosition = Cursor.Position;

			while (stopwatch.ElapsedMilliseconds < timeoutMs)
			{
				await Task.Delay(25, token);
				Point currentPosition = Cursor.Position;

				if (currentPosition != lastPosition)
				{
					lastPosition = currentPosition;
					stabilityStopwatch.Restart();
				}

				if (stabilityStopwatch.ElapsedMilliseconds >= stabilityCheckMs)
				{
					return;
				}
			}
		}
		public async Task SimulateFlick(Point start, Point end, CancellationToken token, double durationSeconds = 0.2)
		{
			await MoveMouseHumanLike(start, token, durationSeconds: durationSeconds * 0.7, noiseMagnitude: 1.0, overshootChance: 0.0);
			await RandomDelay(30, 50, token);

			INPUT[] inputs = new INPUT[1];
			inputs[0] = new INPUT { type = INPUT_MOUSE, U = new InputUnion { mi = new MOUSEINPUT { dwFlags = MOUSEEVENTF_LEFTDOWN } } };
			SendInput(1, inputs, Marshal.SizeOf(typeof(INPUT)));
			await RandomDelay(30, 50, token);

			await MoveMouseHumanLike(end, token, durationSeconds: durationSeconds * 0.7, noiseMagnitude: 1.0, overshootChance: 0.0);

			inputs[0].U.mi.dwFlags = MOUSEEVENTF_LEFTUP;
			SendInput(1, inputs, Marshal.SizeOf(typeof(INPUT)));
			await RandomDelay(100, 200, token);
		}
	}
}
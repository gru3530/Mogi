using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MOGI
{
	public class MouseTrackerService
	{
		private CancellationTokenSource _cts;
		private Task _trackingTask;
		private Point _lastPosition;

		// 마우스 위치 변경 이벤트
		public event EventHandler<Point> MousePositionChanged;

		public MouseTrackerService()
		{
			_cts = new CancellationTokenSource();
			_lastPosition = Point.Empty;
		}

		public void StartTracking()
		{
			if (_trackingTask != null && !_trackingTask.IsCompleted)
			{
				return; // 이미 트래킹 중이면 시작하지 않음
			}

			_cts = new CancellationTokenSource(); // 새로운 시작을 위해 CTS 재활용
			_trackingTask = Task.Run(() => TrackMouseLoop(_cts.Token), _cts.Token);
		}

		public void StopTracking()
		{
			if (_cts != null && !_cts.IsCancellationRequested)
			{
				_cts.Cancel();
			}
			// Task가 완료될 때까지 기다릴 필요는 없지만, 필요시 _trackingTask.Wait() 사용 가능
		}

		private async Task TrackMouseLoop(CancellationToken token)
		{
			while (!token.IsCancellationRequested)
			{
				Point currentPosition = Control.MousePosition;

				if (currentPosition != _lastPosition)
				{
					MousePositionChanged?.Invoke(this, currentPosition);
					_lastPosition = currentPosition;
				}

				await Task.Delay(50, token); // 50ms마다 위치 확인
			}
		}
	}
}
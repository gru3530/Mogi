// HotkeyManager.cs (수정된 버전)

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace MOGI
{
	public class HotkeyManager : IDisposable
	{
		private readonly HotkeyWindow _window = new HotkeyWindow();
		private int _hotkeyIdCounter = 1;
		private readonly Dictionary<int, Keys> _idToKeyMap = new Dictionary<int, Keys>();

		public event Action<Keys> HotkeyFired;

		public HotkeyManager()
		{
			// HotkeyWindow 내부에서 이벤트가 발생하면 HotkeyManager의 이벤트를 호출
			//_window.HotkeyFired += (keyId) =>
			//{
			//	if (_idToKeyMap.TryGetValue(keyId, out Keys key))
			//	{
			//		HotkeyFired?.Invoke(key);
			//	}
			//};
		}

		public void RegisterHotkey(Keys key)
		{
			int id = _hotkeyIdCounter++;
			if (!NativeMethods.RegisterHotKey(_window.Handle, id, 0, (int)key))
			{
				throw new InvalidOperationException("Failed to register hotkey.");
			}
			_idToKeyMap[id] = key;
		}

		public void Dispose()
		{
			foreach (var id in _idToKeyMap.Keys)
			{
				NativeMethods.UnregisterHotKey(_window.Handle, id);
			}
			_window.DestroyHandle();
		}

		// NativeWindow를 상속받아 메시지를 처리하는 내부 클래스
		private class HotkeyWindow : NativeWindow
		{
			private const int WM_HOTKEY = 0x0312;
			public event Action<int> HotkeyFired;

			public HotkeyWindow()
			{
				// 보이지 않는 메시지 전용 창 생성
				this.CreateHandle(new CreateParams());
			}

			protected override void WndProc(ref Message m)
			{
				// 핫키 메시지를 여기서 직접 처리
				if (m.Msg == WM_HOTKEY)
				{
					int id = m.WParam.ToInt32();
					HotkeyFired?.Invoke(id);
				}
				base.WndProc(ref m);
			}
		}

		// P/Invoke 코드를 별도 내부 클래스로 관리 (가독성)
		private static class NativeMethods
		{
			[DllImport("user32.dll")]
			public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

			[DllImport("user32.dll")]
			public static extern bool UnregisterHotKey(IntPtr hWnd, int id);
		}
	}
}
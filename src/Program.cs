using System.Diagnostics;
using System.Security.Principal;

namespace MOGI
{
	internal static class Program
	{
		[STAThread]
		static void Main()
		{
			if (!IsAdministrator())
			{
				try
				{
					var startInfo = new ProcessStartInfo
					{
						UseShellExecute = true,
						WorkingDirectory = Environment.CurrentDirectory,
						FileName = Application.ExecutablePath,
						Verb = "runas"
					};
					Process.Start(startInfo);
				}
				catch (System.ComponentModel.Win32Exception)
				{
					return;
				}
				Application.Exit();
				return;
			}

			var config = ConfigManager.Instance;

			Task_Manager.Instance.InitializeAndStartServices();
			Application.Run(new Form_Main());

			Task_Manager.Instance.ShutdownServices();
		}

		static bool IsAdministrator()
		{
			using (WindowsIdentity identity = WindowsIdentity.GetCurrent())
			{
				WindowsPrincipal principal = new WindowsPrincipal(identity);
				return principal.IsInRole(WindowsBuiltInRole.Administrator);
			}
		}
	}
}
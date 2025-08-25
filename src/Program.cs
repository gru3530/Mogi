using System.Security.Principal;

namespace MOGI
{
	internal static class Program
	{
		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			if (!IsAdministrator())
			{
				DialogResult result = MessageBox.Show(
					"이 프로그램은 일부 기능 사용을 위해 관리자 권한이 필요할 수 있습니다.\n\n권한 없이 계속 진행할 경우 예기치 않은 오류가 발생할 수 있습니다.\n\n계속하시겠습니까?",
					"권한 확인",
					MessageBoxButtons.OKCancel,
					MessageBoxIcon.Warning
				);

				if (result == DialogResult.Cancel)
				{
					Application.Exit(); 
					return; 
				}
			}

			Task_Manager.Instance.InitializeAndStartServices();
			ApplicationConfiguration.Initialize();
			Application.Run(new Form_Main());

			Task_Manager.Instance.ShutdownServices();
		}

		static bool IsAdministrator()
		{
			WindowsIdentity identity = WindowsIdentity.GetCurrent();
			WindowsPrincipal principal = new WindowsPrincipal(identity);
			return principal.IsInRole(WindowsBuiltInRole.Administrator);
		}
	}
}
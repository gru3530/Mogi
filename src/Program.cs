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
					"�� ���α׷��� �Ϻ� ��� ����� ���� ������ ������ �ʿ��� �� �ֽ��ϴ�.\n\n���� ���� ��� ������ ��� ����ġ ���� ������ �߻��� �� �ֽ��ϴ�.\n\n����Ͻðڽ��ϱ�?",
					"���� Ȯ��",
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
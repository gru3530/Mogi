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
			// To customize application configuration such as set high DPI settings or default font,
			// see https://aka.ms/applicationconfiguration.
			Task_Manager.Instance.InitializeAndStartServices();
			ApplicationConfiguration.Initialize();
			Application.Run(new Form_Main());

			Task_Manager.Instance.ShutdownServices();
		}
	}
}
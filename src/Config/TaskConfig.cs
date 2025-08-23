namespace MOGI
{
	public class TaskConfig
	{
		public int Repetitions { get; set; }
		public bool InitialMonitorClickEnabled { get; set; }

		public TaskConfig(int repetitions = 1)
		{
			Repetitions = repetitions;
			InitialMonitorClickEnabled = false;
		}

		public TaskConfig(int repetitions, bool initialMonitorClickEnabled)
		{
			Repetitions = repetitions;
			InitialMonitorClickEnabled = initialMonitorClickEnabled;
		}
	}
}
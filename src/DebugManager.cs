public static class DebugManager
{
	private static bool debugMode;
	public static bool DebugMode
	{
		get => debugMode;
		set
		{
			debugMode = value;
			Console.WriteLine("Debug mode is now " + (DebugMode ? "enabled" : "disabled") + ".");
		}
	}

	public static bool ToggleDebugMode()
	{
		DebugMode = !DebugMode;
		return DebugMode;
	}
}
public static class DebugManager
{
	const string SaveStatePath = "./debug.ini";

	public static void LoadDebugState()
	{
		if (File.Exists(SaveStatePath) == false) SaveDebugState();
		DebugMode = File.ReadAllText(SaveStatePath) == "true";
	}

	public static void SaveDebugState()
	{
		File.WriteAllText(SaveStatePath, debugMode ? "true" : "false");
	}

	private static bool debugMode;
	public static bool DebugMode
	{
		get => debugMode;
		set
		{
			debugMode = value;
			SaveDebugState();
			Console.WriteLine("Debug mode is now " + (DebugMode ? "enabled" : "disabled") + ".");
		}
	}

	public static bool ToggleDebugMode()
	{
		DebugMode = !DebugMode;
		return DebugMode;
	}
}
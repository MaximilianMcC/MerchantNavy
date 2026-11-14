using System.Collections.Concurrent;
using Raylib_cs;

static class Terminal
{
	private static ConcurrentQueue<string> inputs = [];
	private static List<string> commands = [];

	public static void Run()
	{
		Thread thread = new Thread(GetInput);
		thread.IsBackground = true;
		thread.Start();
	}

	public static void RunCommand(string command)
	{
		inputs.Enqueue(command);
	}

	private static void GetInput()
	{
		while (Raylib.WindowShouldClose() == false)
		{
			// Get input
			string input = Console.ReadLine();

			// Check we're not trolling
			if (input == null || input == "") continue;

			// Add it to the queue for this frame
			inputs.Enqueue(input);
		}
	}

	public static void Update()
	{
		// Get rid of all the stale commands
		commands.Clear();

		// Look at all things written last frame
		while (inputs.TryDequeue(out string input))
		{
			commands.Add(input);
		}
	}

	public static bool CommandRan(string command) => CommandRan(command, out _, false);
	public static bool CommandRan(string command, out string[] args, bool allowExtraArguments = true)
	{
		args = null;

		// Loop over every command entered into the terminal
		foreach (string enteredCommand in commands)
		{
			// split both things into an array
			string[] inputCommandSections = enteredCommand.Split(' ');
			string[] expectedCommandSections = command.Split(' ');

			// Check for if we have the correct amount of arguments
			if (inputCommandSections.Length < expectedCommandSections.Length) continue;
			if (allowExtraArguments == false && inputCommandSections.Length != expectedCommandSections.Length) continue;

			// Check for if our input matches the command we're expecting
			bool hasExpectedCommand = true;
			for (int i = 0; i < expectedCommandSections.Length; i++)
			{
				if (inputCommandSections[i] != expectedCommandSections[i])
				{
					hasExpectedCommand = false;
					break;
				}
			}

			// Check for if we got the whole command
			if (hasExpectedCommand == false) continue;

			// Give back a list of any additional arguments provided
			if (allowExtraArguments)
			{
				// Get rid of the requested command name
				args = inputCommandSections.Skip(expectedCommandSections.Length).ToArray();
			}

			return true;
		}

		// No commands were entered
		return false;
	}

	public static void HandleBuiltInCommands()
	{
		string[] args;

		if (CommandRan("cls") || CommandRan("clear")) Console.Clear();
		
		if (CommandRan("hi")) Console.WriteLine("kia ora");
		if (CommandRan("echo", out args)) Console.WriteLine(String.Join(" ", args));

		if (CommandRan("debug")) DebugManager.ToggleDebugMode();

		if (CommandRan("dir"))
		{
			Console.WriteLine("All game objects (excluding children)");
			foreach (GameObject gameObject in SceneManager.GameObjects)
			{
				Console.WriteLine(gameObject.Name);
				foreach (Component component in gameObject.Components)
				{
					Console.WriteLine(" - " + component);
				}
			}
		}
	}
}
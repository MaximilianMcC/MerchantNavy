using Raylib_cs;

class Program
{
	public static void Main(string[] args)
	{
		Raylib.SetTraceLogLevel(TraceLogLevel.Warning);
		Raylib.InitWindow(960, 540, "a game related to the company of merchants of london trading into the east indies");
		Terminal.Run();

		LocalizationManager.LoadLocalizations();

		while (Raylib.WindowShouldClose() == false)
		{
			Terminal.Update();
			Terminal.HandleBuiltInCommands();

			Test.Update();

			Raylib.BeginDrawing();
			Raylib.ClearBackground(Color.Magenta);
			
			Test.Draw();
			Raylib.EndDrawing();
		}

		Raylib.CloseWindow();
	}
}
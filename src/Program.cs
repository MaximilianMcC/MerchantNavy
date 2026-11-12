using System.Diagnostics;
using Raylib_cs;

class Program
{
	public static void Main(string[] args)
	{
		Raylib.SetTraceLogLevel(TraceLogLevel.Warning);
		Raylib.InitWindow(960, 540, "a game related to the company of merchants of london trading into the east indies");
		Terminal.Run();

		DebugManager.DebugMode = true;
		LocalizationManager.LoadLocalizations();

		GameObject test = new GameObject("test");
		test.AddComponent(new Draggable());
		test.AddComponent(new TextureRenderer());
		test.AddComponent(new Hitbox());

		SceneManager.Add(test);

		while (Raylib.WindowShouldClose() == false)
		{
			Terminal.Update();
			Terminal.HandleBuiltInCommands();
			if (Raylib.IsKeyPressed(KeyboardKey.Grave)) DebugManager.ToggleDebugMode();

			SceneManager.Update();

			Raylib.BeginDrawing();
			Raylib.ClearBackground(Color.Magenta);
			SceneManager.Draw();
			SceneManager.DrawDebug();
			SceneManager.DrawUi();
			SceneManager.DrawUiDebug();
			Raylib.EndDrawing();
		}

		SceneManager.CleanUp();
		Raylib.CloseWindow();
	}
}
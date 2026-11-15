using System.Numerics;
using Raylib_cs;

class Program
{
	public static void Main(string[] args)
	{
		Raylib.SetTraceLogLevel(TraceLogLevel.Warning);
		Raylib.SetConfigFlags(ConfigFlags.ResizableWindow | ConfigFlags.AlwaysRunWindow);
		Raylib.InitWindow(960, 540, "In the hotte sun without hatte");
		Raylib.InitAudioDevice();

		Terminal.Run();
		DebugManager.LoadDebugState();
		LocalizationManager.LoadLocalizations(false);

		SceneManager.Add(new GameObject("test", new Test()));

		SceneManager.Add(new GameObject("envelope")
			.AddComponent(new Draggable())
			.AddComponent(new TextureRenderer("./assets/texture/envelope.png"))
			.AddComponent(new Hitbox())
			.AddComponent(new Envelope())
		);

		while (Raylib.WindowShouldClose() == false)
		{
			Terminal.Update();
			Terminal.HandleBuiltInCommands();
			if (Raylib.IsKeyPressed(KeyboardKey.Grave)) DebugManager.ToggleDebugMode();

			SceneManager.Update();

			Raylib.BeginDrawing();
			Raylib.ClearBackground(Color.Brown);
			SceneManager.Draw();
			SceneManager.DrawDebug();
			SceneManager.DrawUi();
			SceneManager.DrawUiDebug();
			Raylib.EndDrawing();
		}

		SceneManager.CleanUp();
		Raylib.CloseAudioDevice();
		Raylib.CloseWindow();
	}
}
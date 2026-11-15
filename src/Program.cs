using System.Numerics;
using Raylib_cs;

class Program
{
	public static void Main(string[] args)
	{
		Raylib.SetTraceLogLevel(TraceLogLevel.Warning);
		Raylib.SetConfigFlags(ConfigFlags.ResizableWindow | ConfigFlags.AlwaysRunWindow);
		Raylib.InitWindow(960, 540, "a game related to the company of merchants of london trading into the east indies");
		Terminal.Run();

		DebugManager.LoadDebugState();
		LocalizationManager.LoadLocalizations(false);

		SceneManager.Add(new GameObject("test", new Test()));

		// SceneManager.Add(new GameObject("envelope")
		// 	.AddComponent(new Draggable())
		// 	.AddComponent(new TextureRenderer("./assets/texture/envelope.png"))
		// 	.AddComponent(new Hitbox())
		// 	.AddComponent(new Envelope())
		// );

		// SceneManager.Add(new GameObject("envelope")
		// 	.AddComponent(new Draggable())
		// 	.AddComponent(new TextureRenderer("./assets/texture/envelope.png"))
		// 	.AddComponent(new Hitbox())
		// 	.AddComponent(new Envelope())
		// );

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
		Raylib.CloseWindow();
	}
}
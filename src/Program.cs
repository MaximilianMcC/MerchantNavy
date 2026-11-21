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
		Assets.AutomaticallyLoadEverythingFromDirectory();

		SceneManager.Add(new GameObject("test", new Test()));

		SceneManager.Add(new GameObject("Inbox", new Vector2(50), 0.25f)
			.AddComponent(new TextureRenderer("inbox"))
			.AddComponent(new Hitbox())
			.AddComponent(new MailBox())
		);

		SceneManager.Add(new GameObject("Outbox", new Vector2(1920 - 50, 50), 0.25f)
			.AddComponent(new TextureRenderer("outbox"))
			.AddComponent(new Hitbox())
			.AddComponent(new MailBox())
		);

		SceneManager.Add(new GameObject("envelope", 0.7f)
			.AddComponent(new Draggable())
			.AddComponent(new TextureRenderer("envelope"))
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
		Assets.UnloadEverything();
		Raylib.CloseAudioDevice();
		Raylib.CloseWindow();
	}
}
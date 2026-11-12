class SceneManager
{
	private static List<GameObject> gameObjects = [];
	public static IReadOnlyList<GameObject> GameObjects => gameObjects;

	public static void Add(GameObject gameObject)
	{
		gameObjects.Add(gameObject);
		gameObject.Start();
	}

	public static void Update()
	{
		foreach (GameObject gameObject in gameObjects) gameObject.Update();
	}

	public static void Draw()
	{
		foreach (GameObject gameObject in gameObjects) gameObject.Draw();
	}

	public static void DrawDebug()
	{
		if (DebugManager.DebugMode == false) return;
		foreach (GameObject gameObject in gameObjects) gameObject.DrawDebug();
	}

	public static void DrawUi()
	{
		foreach (GameObject gameObject in gameObjects) gameObject.DrawUi();
	}

	public static void DrawUiDebug()
	{
		if (DebugManager.DebugMode == false) return;
		foreach (GameObject gameObject in gameObjects) gameObject.DrawUiDebug();
	}

	public static void CleanUp()
	{
		foreach (GameObject gameObject in gameObjects) gameObject.CleanUp();
	}
}
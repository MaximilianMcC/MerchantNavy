class SceneManager
{
	private static List<GameObject> gameObjects = [];
	private static List<GameObject> newGameObjects = [];

	public static IReadOnlyList<GameObject> GameObjects => gameObjects;

	private static List<Type> staticallyStartedTypes = [];

	public static void Add(GameObject gameObject) => newGameObjects.Add(gameObject);

	public static void Update()
	{
		HandleGameObjectLifecycle();
		ForEachComponent(x => x.Update());
	}

	public static void Draw() => ForEachComponent(x => x.Draw());
	public static void DrawUi() => ForEachComponent(x => x.DrawUi());

	public static void DrawDebug()
	{
		if (DebugManager.DebugMode == false) return;
		ForEachComponent(x => x.DrawDebug());
	}

	public static void DrawUiDebug()
	{
		if (DebugManager.DebugMode == false) return;
		foreach (GameObject gameObject in gameObjects) ForEachComponent(x => x.DrawUiDebug());
	}

	public static void CleanUp()
	{
		ForEachComponent(x => x.CleanUp());
		ForEachComponent(x => x.CleanUpStatic());

		gameObjects.Clear();
		newGameObjects.Clear();

		// TODO: CleanUpStatic method thing
	}



	private static void ForEachComponent(Action<Component> method)
	{
		// Loop over every single game object
		foreach (GameObject gameObject in gameObjects)
		{
			// Call the specified method on every component
			IReadOnlyList<Component> components = gameObject.Components;
			foreach (Component component in components) method(component);
		}
	}

	// Delete old game objects and also add new ones
	private static void HandleGameObjectLifecycle()
	{
		// Check for if we need to kill any game objects
		for (int i = gameObjects.Count - 1; i >= 0 ; i--)
		{
			GameObject gameObject = gameObjects[i];
			if (gameObject.IsQueuedForDeletion == false) continue;

			// Clean up its components
			foreach (Component component in gameObject.Components) component.CleanUp();

			// Remove it
			gameObject.Parent?.RemoveChild(gameObject);
			gameObjects.RemoveAt(i);
		}

		// Check for if we need to add any new game objects
		if (newGameObjects.Count == 0) return;

		// Move everything into a new temporary list so
		// the actual one is 'free' to be added to
		// TODO: Figure out what this even does
		List<GameObject> newStuff = new List<GameObject>(newGameObjects);
		newGameObjects.Clear();

		// Call the start method on all the new stuff
		foreach (GameObject gameObject in newStuff)
		{
			foreach (Component component in gameObject.Components)
			{
				component.Start();

				// StartStatic method thing (ran once per type)
				Type componentType = component.GetType();
				if (staticallyStartedTypes.Contains(componentType) == false)
				{
					staticallyStartedTypes.Add(componentType);
					component.StartStatic();
				}
			}

			// Add it to the actual game
			gameObjects.Add(gameObject);
		}
	}
}
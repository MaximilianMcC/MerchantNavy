using Raylib_cs;

static class Assets
{
	public static readonly TextureAssetManager Textures = new TextureAssetManager();
	public static readonly SoundAssetManager Sounds = new SoundAssetManager();
	public static readonly FontAssetManager Fonts = new FontAssetManager();
	
	public static Localization Texts => LocalizationManager.CurrentLocalization;

	public static void AutomaticallyLoadEverythingFromDirectory()
	{
		Textures.AutomaticallyLoadEverythingFromDirectory();
		Sounds.AutomaticallyLoadEverythingFromDirectory();
		Fonts.AutomaticallyLoadEverythingFromDirectory();
	}

	public static void UnloadEverything()
	{
		Textures.UnloadAll();
		Sounds.UnloadAll();
		Fonts.UnloadAll();
	}

	public static void PrintAllLoadedAssets()
	{
		Textures.PrintAllAssets();
		Sounds.PrintAllAssets();
		Fonts.PrintAllAssets();
	}
}

// TODO: Merge the embedded asset manager stuff in here
abstract class Asset<T>
{
	private static readonly string DefaultAssetsPath = "./assets/";
	protected abstract string DefaultAssetPath { get; }

	protected Dictionary<string, T> assets = [];
	private Dictionary<string, string> keyToPath = [];

	public T this[string key] => assets[key];

	public bool IsLoaded(string key) => assets.ContainsKey(key);
	public void PrintAllAssets()
	{
		string assetName = typeof(T).Name;
		if (assets.Count == 0)
		{
			Console.WriteLine("There are 0 " + assetName + "s loaded.");
			return;
		}

		if (assets.Count == 1) Console.WriteLine("There is 1 " + assetName + " loaded:");
		else Console.WriteLine($"There are {assets.Count} {assetName}s loaded:");
		foreach (string key in assets.Keys) Console.WriteLine($"- {key}\t\t({keyToPath[key]})");
	}

	public T Load(string key, string path)
	{
		if (IsLoaded(key) == false)
		{
			assets[key] = LoadAsset(path);
			keyToPath[key] = path;
		}
		return assets[key];
	}

	public void Unload(string key)
	{
		UnloadAsset(assets[key]);
		assets.Remove(key);
		keyToPath.Remove(key);
	}

	public void UnloadAll()
	{
		foreach (string key in assets.Keys) Unload(key);
	}

	public void AutomaticallyLoadEverythingFromDirectory()
	{
		string[] assetPaths = Directory.GetFiles(DefaultAssetPath);
		foreach (string path in assetPaths)
		{
			string key = Path.GetFileNameWithoutExtension(path);
			Load(key, path);
		}

		PrintAllAssets();
	}

	protected abstract T LoadAsset(string path);
	protected abstract void UnloadAsset(T asset);
}
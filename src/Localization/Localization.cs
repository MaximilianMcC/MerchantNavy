class Localization
{
	private Dictionary<string, string> translations;

	//? Superauto
	public readonly bool IsRootLanguageFile;

	public readonly string ParentsCode;
	public readonly string Code;

	public Localization(string filePath)
	{
		translations = new Dictionary<string, string>();

		// Loop over every line and add it to the dictionary
		// excluding the first one since that's the relational stuff
		string[] lines = File.ReadAllLines(filePath);
		for (int i = 1; i < lines.Length; i++)
		{
			// Make sure it's not a comment or an empty line
			if (lines[i].StartsWith('#')) continue;
			if (lines[i] == "") continue;

			// Split at the first character then add it to the dictionary
			string[] sections = lines[i].Split('=', 2);
			translations.Add(sections[0], sections[1]);
		}

		// Check for if we're an inherited language or not
		IsRootLanguageFile = lines[0] == "superauto";
		ParentsCode = IsRootLanguageFile ? null : lines[0].Split('=')[1];

		// Get the language code (eg: en-nz)
		Code = Path.GetFileNameWithoutExtension(filePath).ToLower();
	}

	// Make the class act as a dictionary (easier to use yk)
	public string this[string key] => GetString(key);

	public string GetString(string key)
	{
		// If we personally have a translation then use that
		bool keyExists = translations.TryGetValue(key, out string value);
		if (keyExists) return value;

		// If we haven't got a translation for that then move 'down' the chain
		if (IsRootLanguageFile == false)
		{
			Localization parent = LocalizationManager.GetLocalizationFromLanguageCode(ParentsCode);
			return parent.GetString(key);
		}

		// If we're last on the chain and no other step has had
		// it then it does not exist. Just give back the key
		return key;
	}

	public Localization FindRootLanguage() => LocalizationManager.FindRootLanguage(this);

	// TODO: Make it so this isn't accessible
	public void Bake()
	{
		Dictionary<string, string> bakedTranslations = new Dictionary<string, string>();

		// Find our parent and loop over all keys in it then save that
		Localization parent = FindRootLanguage();
		foreach (string key in parent.translations.Keys)
		{
			// Get the key
			bakedTranslations[key] = GetString(key);
		}

		// Replace the old translation dictionary with the new one
		translations = bakedTranslations;
	}

	public override string ToString() => Code;
}
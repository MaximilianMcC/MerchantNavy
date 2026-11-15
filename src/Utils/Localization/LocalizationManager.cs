static class LocalizationManager
{
	private static readonly string LocalizationsDirectory = "./assets/lang/";

	public static IReadOnlyList<Localization> Localizations => localizations;
	private static List<Localization> localizations = [];

	// TODO: Put this in some other class
	public static Localization CurrentLocalization;

	public static void LoadLocalizations(bool bake = true)
	{
		// Get all the languages then populate them all
		string[] allLanguageFilePaths = Directory.GetFiles(LocalizationsDirectory, "*.lang");
		foreach (string languageFilePath in allLanguageFilePaths)
		{
			localizations.Add(new Localization(languageFilePath));
		}

		// Merge everything into a single dictionary so we don't
		// have to do the whole recursive lookup thing each time
		if (bake)
		{
			foreach (Localization localization in Localizations)
			{
				//! This saves like literally 0.0050 ms btw but its nice to know its there
				localization.Bake();
			}
		}

		Console.WriteLine($"Loaded and baked {allLanguageFilePaths.Length} language file(s)\n{String.Join(", ", localizations)}");

		// TODO: put this somewhere else
		CurrentLocalization = GetLocalizationFromLanguageCode("en");
	}

	public static Localization GetLocalizationFromLanguageCode(string languageCode)
	{
		languageCode = languageCode.ToLower();
		Localization localization = Localizations.FirstOrDefault(x => x.Code == languageCode);

		// No found localisation
		if (localization == default)
		{
			Console.Error.WriteLine("Couldn't find a localisation with the code " + languageCode);
			return null;
		}

		return localization;
	}

	public static Localization FindRootLanguage(Localization of)
	{
		Localization currentLanguage = of;

		while (true)
		{
			// If we are the root then that's that ig
			if (currentLanguage.IsRootLanguageFile) return currentLanguage;

			// If we have a parent then go there
			currentLanguage = GetLocalizationFromLanguageCode(currentLanguage.ParentsCode);
		}
	}

	public static void SetDynamicStringForAllLocalizations(string key, string translation)
	{
		foreach (Localization localization in localizations)
		{
			localization.SetDynamicString(key, translation);
		}
	}

	public static void SetDynamicStringForAllLocalizations(string key, int translation) => SetDynamicStringForAllLocalizations(key, translation.ToString());
	public static void SetDynamicStringForAllLocalizations(string key, float translation) => SetDynamicStringForAllLocalizations(key, translation, true, 999);
	public static void SetDynamicStringForAllLocalizations(string key, float translation, bool includeCommas, int decimalPlaces)
	{
		//? N is for commas and F is for decimals
		string format = (includeCommas ? "N" : "F") + Math.Max(0, decimalPlaces);
		SetDynamicStringForAllLocalizations(key, translation.ToString(format));
	}
}
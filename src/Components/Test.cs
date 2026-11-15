class Test : Component
{
	public override void Start()
	{
		Localization localization = LocalizationManager.GetLocalizationFromLanguageCode("en");
		// Console.WriteLine(localization["location"]);
		// Console.WriteLine(localization["money"]);
		Console.WriteLine(localization["documents.introduction"]);
		// Console.WriteLine(localization["Test"]);

		// TODO: Test dynamic things
	}
}
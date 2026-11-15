using Raylib_cs;

class Test : Component
{
	private Localization localization;
	private float money = 0f;

	public override void Start()
	{
		localization = LocalizationManager.GetLocalizationFromLanguageCode("en");
		// Console.WriteLine(localization["location"]);
		// Console.WriteLine(localization["money"]);
		// Console.WriteLine(localization["documents.introduction"]);
		// Console.WriteLine(localization["Test"]);

		// TODO: Test dynamic things
	}

	public override void Update()
	{
		if (Raylib.IsKeyPressed(KeyboardKey.Up) || Terminal.CommandRan("money"))
		{
			money += 10f;
			localization.SetDynamicString("money", money, true, 2);
		}
	}

	public override void DrawUi()
	{
		Raylib.DrawText(localization["moneyCount"], 10, 10, 30, Color.White);
	}
}
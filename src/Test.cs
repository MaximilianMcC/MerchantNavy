using System.Diagnostics;
using Raylib_cs;

class Test
{
	private static int index = 0;
	private static Localization localization = LocalizationManager.Localizations[index];

	public static void Update()
	{
		if (Raylib.IsKeyPressed(KeyboardKey.Space))
		{
			index++;
			if (index >= LocalizationManager.Localizations.Count) index = 0;

			localization = LocalizationManager.Localizations[index];
		}
	}

	public static void Draw()
	{
		Raylib.DrawText($"{localization["LanguageName"]}\n{localization["LanguageDescription"]}", 10, 10, 32, Color.White);
	}
}
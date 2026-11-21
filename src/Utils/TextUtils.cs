static class TextUtils
{
	// TODO: Make private
	public static int[] SplitNumberIntoPlaceValues(int number)
	{
		// Get rid of negative stuff
		//? idk if this is actually needed
		number = Math.Abs(number);

		// Figure out how many place values we have
		string stringifiedNumber = number.ToString();
		int placeValuesCount = stringifiedNumber.Length;
		int[] placeValues = new int[placeValuesCount];

		// Loop over every place value
		for (int i = 0; i < placeValuesCount; i++)
		{
			// Get how many zeros are in it (so like 500 → 100, 90 → 10, 3 → 1)
			int placeValue = (int)(Math.Pow(10, (placeValuesCount - i) - 1));

			// Tack the number on front (5 * 100 = 500)
			placeValues[i] = (stringifiedNumber[i] - '0') * placeValue;
		}

		return placeValues;
	}

	public static string NumberToWords(int number)
	{
		string word = "";
		Localization text = LocalizationManager.CurrentLocalization;

		string[] ones = new string[] { text["1"], text["2"], text["3"], text["4"], text["5"], text["6"], text["7"], text["8"], text["9"] };
		string[] tens = new string[] { text["10"], text["11"], text["12"], text["13"], text["14"], text["15"], text["16"], text["17"], text["18"], text["19"] };
		string[] tensBelowNineteen = new string[] { text["20"], text["30"], text["40"], text["50"], text["60"], text["70"], text["80"], text["90"] };
		string[] bigNumbers = new string[] { text["100"], text["1000"], text["1000000"] };

		// If the number is negative then say so
		if (number < 0) word += text["negative"] + " ";

		// loop over every 'digit'

		return word;
	}

	// TODO: Make it so there's a chance some of the numerals are 'malformed' (IIII instead of IV)
	public static string NumberToRomanNumerals(int number)
	{
		// If we have roman numerals turned off then don't do anything
		if (Settings.DisableRomanNumerals) return number.ToString();

		string romanNumerals = "";

		int[] placeValues = SplitNumberIntoPlaceValues(number);
		for (int i = 0; i < placeValues.Length; i++)
		{
			
		}

		return romanNumerals;
	}

	// TODO: Don't have this in a separate method
	private static int GetClosestRomanNumeral(int number)
	{
		Dictionary<int, char> numerals = new Dictionary<int, char>
		{
			{ 1, 'I' },
			{ 5, 'V' },
			{ 10, 'X' },
			{ 50, 'L' },
			{ 100, 'C' },
			{ 500, 'D' },
			{ 1000, 'M' }
		};

		// TODO: Just do a fat if statement or even a switch statement perchance
		int closestNumeral = -1;
		for (int i = 1; i < numerals.Count; i++)
		{
			// Check for if the number is 'in-between' the current numeral
			if (numerals[i - 1] >= number && numerals[i] <= number) closestNumeral = numerals[i - 1];
		}

		return closestNumeral;
	}
}
using System.Numerics;
using Raylib_cs;

public static class Graphics
{
	public static void DrawRectangle(Vector2 position, Vector2 size, Color color)
	{
		Raylib.DrawRectangleRec(new Rectangle(position, size), color);
	}

	public static void DrawTexture(Texture2D texture, Vector2 position, Vector2 size)
	{
		Raylib.DrawTexturePro(
			texture,
			new Rectangle(0, 0, texture.Dimensions),
			new Rectangle(position, size),
			Vector2.Zero,
			0f,
			Color.White
		);
	}

	public static void DrawTextWrapped(string text, Vector2 position, float maxLineWidth, Font font, float fontSize, Color color)
	{
		string[] words = text.Split(' ');
		string wrappedText = "";

		// Loop over every word
		string currentLine = "";
		for (int i = 0; i < words.Length; i++)
		{
			// Add the word to the line
			string newCurrentLine = currentLine + words[i];

			// Check if this word is going to fit on this line
			float currentLineWidth = Raylib.MeasureTextEx(font, newCurrentLine, fontSize, (fontSize / 10f)).X;
			if (currentLineWidth > maxLineWidth)
			{
				// Move onto the next line
				wrappedText += currentLine + "\n";

				// Add the overflowing word to the start of the next line
				currentLine = words[i] + " ";
			}
			else
			{
				// Add ourselves onto the current line
				currentLine = newCurrentLine + " ";
			}
		}

		// Draw the new text
		Raylib.DrawTextEx(font, wrappedText, position, fontSize, (fontSize / 10f), color);
	}
}
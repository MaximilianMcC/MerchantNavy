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
}
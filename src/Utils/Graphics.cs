using System.Numerics;
using Raylib_cs;

public static class Graphics
{
	public static void DrawRectangle(Vector2 position, Vector2 size, Color color)
	{
		Raylib.DrawRectangleRec(new Rectangle(position, size), color);
	}
}
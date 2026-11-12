using System.Numerics;
using Raylib_cs;

class Draggable : Component
{
	public override void DrawUiDebug()
	{
		Graphics.DrawRectangle(Vector2.Zero, new Vector2(10), Color.Orange);
	}
}
using System.Numerics;
using Raylib_cs;

class Draggable : Component
{
	public override void Start()
	{
		Console.WriteLine("hi");
	}

	public override void Draw()
	{
		Graphics.DrawRectangle(GameObject.Transform.Position, new Vector2(100f), Color.White);
	}

	public override void CleanUp()
	{
		Console.WriteLine("bye");
	}
}
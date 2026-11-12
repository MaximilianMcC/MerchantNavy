using System.Numerics;
using Raylib_cs;

class TextureRenderer : Component
{
	public Texture2D Texture;
	private Vector2 Size;

	public override void Start()
	{
		Texture = Raylib.LoadTexture("./assets/texture/envelope.png");
		Size = Texture.Dimensions;
	}

	public override void Draw()
	{
		Graphics.DrawTexture(Texture, GameObject.Transform.WorldPosition, Size);
	}

	public override void CleanUp()
	{
		Raylib.UnloadTexture(Texture);
	}
}
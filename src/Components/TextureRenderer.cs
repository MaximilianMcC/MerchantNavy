using System.Numerics;
using Raylib_cs;

class TextureRenderer : Component
{
	public Texture2D Texture;
	private Vector2 Size;

	public bool Visible { get; set; } = true;

	public TextureRenderer(string filePath)
	{
		Texture = Raylib.LoadTexture(filePath);
	}

	public override void Start()
	{
		Size = Texture.Dimensions;
	}

	public override void Draw()
	{
		if (Visible == false) return;

		Graphics.DrawTexture(Texture, GameObject.Transform.WorldPosition, Size * GameObject.Transform.WorldScale);
	}

	public override void CleanUp()
	{
		Raylib.UnloadTexture(Texture);
	}
}
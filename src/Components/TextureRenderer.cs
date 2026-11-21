using System.Numerics;

class TextureRenderer : Component
{
	public string TextureKey { get; set; }
	public bool Visible { get; set; } = true;

	public TextureRenderer(string key, bool visible = true)
	{
		TextureKey = key;
		Visible = visible;
	}

	public Vector2 Size => Assets.Textures[TextureKey].Dimensions * Transform.WorldScale;

	public override void Draw()
	{
		if (Visible == false) return;

		Graphics.DrawTexture(
			Assets.Textures[TextureKey],
			Transform.WorldPosition,
			Size
		);
	}
}
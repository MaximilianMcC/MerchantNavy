using System.Numerics;
using Raylib_cs;

class Paper : Component
{
	public Vector2 textOffset = new Vector2(15, 20);

	public override void Draw()
	{
		TextureRenderer texture = GetComponent<TextureRenderer>();

		Graphics.DrawTextWrapped(
			Assets.Texts["grant"],
			Transform.WorldPosition + textOffset,
			texture.Size.X - 30f,
			Assets.Fonts["High Empathy"],
			32f,
			Color.Black
		);
	}
}
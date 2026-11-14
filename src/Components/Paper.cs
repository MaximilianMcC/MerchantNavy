using System.Numerics;
using Raylib_cs;

class Paper : Component
{
	public Vector2 textOffset;

	public override void Draw()
	{
		TextureRenderer texture = GameObject.GetComponent<TextureRenderer>();

		Localization texts = LocalizationManager.CurrentLocalization;
		Graphics.DrawTextWrapped(texts["LoremIpsum"], GameObject.Transform.WorldPosition + textOffset, (texture.Texture.Dimensions * GameObject.Transform.WorldScale).X, Raylib.GetFontDefault(), 16f, Color.White);
	}
}
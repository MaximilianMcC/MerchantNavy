using System.Numerics;
using Raylib_cs;

class Paper : Component
{
	public Vector2 textOffset = new Vector2(15, 20);

	public Font font;

	public override void Start()
	{
		font = Raylib.LoadFont("./assets/font/High Empathy.ttf");
	}

	public override void Draw()
	{
		TextureRenderer texture = GameObject.GetComponent<TextureRenderer>();

		Localization texts = LocalizationManager.CurrentLocalization;
		Graphics.DrawTextWrapped(texts["LoremIpsum"], GameObject.Transform.WorldPosition + textOffset, (texture.Texture.Dimensions * GameObject.Transform.WorldScale).X - 30f, font, 32f, Color.Black);
	}

	public override void CleanUp()
	{
		Raylib.UnloadFont(font);
	}
}
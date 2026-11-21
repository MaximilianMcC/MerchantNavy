using Raylib_cs;

class TextureAssetManager : Asset<Texture2D>
{
	protected override string DefaultAssetPath => "./assets/texture/";

	protected override Texture2D LoadAsset(string path) => Raylib.LoadTexture(path);
	protected override void UnloadAsset(Texture2D asset) => Raylib.UnloadTexture(asset);
}

class SoundAssetManager : Asset<Sound>
{
	protected override string DefaultAssetPath => "./assets/sound/";

	protected override Sound LoadAsset(string path) => Raylib.LoadSound(path);
	protected override void UnloadAsset(Sound asset) => Raylib.UnloadSound(asset);
}

class FontAssetManager : Asset<Font>
{
	protected override string DefaultAssetPath => "./assets/font/";

	protected override Font LoadAsset(string path) => Raylib.LoadFont(path);
	protected override void UnloadAsset(Font asset) => Raylib.UnloadFont(asset);
}
using System.Numerics;
using Raylib_cs;

class Hitbox : Component
{
	public Vector2 Size = new Vector2(100f);
	public Rectangle Rectangle => new Rectangle(GameObject.Transform.WorldPosition, Size);

	public bool BeingHoveringOver => PointInside(Raylib.GetMousePosition());

	public bool PointInside(Vector2 point) => Raylib.CheckCollisionPointRec(point, Rectangle);


	public override void Start()
	{
		// if we have a texture renderer on us then use that size
		// TODO: Remove this or add a toggle or something idk
		if (GameObject.TryGetComponent(out TextureRenderer texture))
		{
			Size = texture.Texture.Dimensions;
		}
	}



	private Color blue = new Color(0, 0, 255, 128);

	public override void DrawDebug()
	{
		Raylib.DrawRectangleRec(Rectangle, blue);
	}
}
using System.Numerics;
using Raylib_cs;

class Hitbox : Component
{
	// TODO: Do this some way else
	private Vector2 size = new Vector2(100f);
	public Vector2 Size => size * Transform.WorldScale;

	public Rectangle Rectangle => new Rectangle(Transform.WorldPosition, Size);
	public Vector2 CenterPosition => Transform.WorldPosition - (Size / 2f);

	public bool BeingHoveringOver => PointInside(Raylib.GetMousePosition());

	public bool PointInside(Vector2 point) => Raylib.CheckCollisionPointRec(point, Rectangle);

	public override void Start()
	{
		// if we have a texture renderer on us then use that size
		// TODO: Remove this or add a toggle or something idk
		if (GameObject.TryGetComponent(out TextureRenderer texture))
		{
			size = texture.Texture.Dimensions;
		}
	}



	private Color blue = new Color(0, 0, 255, 128);

	public override void DrawDebug()
	{
		Raylib.DrawRectangleRec(Rectangle, blue);
		Raylib.DrawCircleV(Transform.Position, 5f, Color.White);
	}
}
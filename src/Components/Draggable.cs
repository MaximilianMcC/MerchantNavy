using System.Numerics;
using Raylib_cs;

class Draggable : Component
{
	private Hitbox hitbox;

	public override void Start()
	{
		hitbox = GameObject.GetComponent<Hitbox>();
	}

	public bool CurrentlyBeingDragged { get; private set; }

	private float followSpeed = 8f;
	private Vector2 velocity = Vector2.Zero;
	private float friction = 8f;

	public override void Update()
	{
		// Check for if we're stopping a drag
		if (CurrentlyBeingDragged && Raylib.IsKeyReleased(KeyboardKey.Space))
		{
			CurrentlyBeingDragged = false;
			return;
		}

		// Check for if we're starting a new drag
		if (Raylib.IsKeyPressed(KeyboardKey.Space) && hitbox.BeingHoveringOver)
		{
			CurrentlyBeingDragged = true;
		}

		// Check for if we're doing a drag
		if (CurrentlyBeingDragged)
		{
			Vector2 direction = (Raylib.GetMousePosition() - (hitbox.Size / 2f)) - GameObject.Transform.Position;
			velocity = direction * followSpeed * Raylib.GetFrameTime();

			GameObject.Transform.Position += velocity;
		}

		// If we're not doing a drag then let it 'drift' for a sec
		if (CurrentlyBeingDragged == false)
		{
			GameObject.Transform.Position += velocity;
			
			// Add 'friction'
			velocity *= MathF.Exp(-friction * Raylib.GetFrameTime());
			if (velocity.Length() < 0.01f) velocity = Vector2.Zero;
		}
	}
}
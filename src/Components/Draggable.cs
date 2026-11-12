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
	private Vector2 mouseOffset;

	public override void Update()
	{
		// Check for if we're stopping a drag
		if (CurrentlyBeingDragged && Raylib.IsMouseButtonReleased(MouseButton.Left))
		{
			CurrentlyBeingDragged = false;
			return;
		}

		// Check for if we're starting a new drag
		if (Raylib.IsMouseButtonPressed(MouseButton.Left) && hitbox.BeingHoveringOver)
		{
			CurrentlyBeingDragged = true;
			mouseOffset = GameObject.Transform.Position - Raylib.GetMousePosition();
		}

		// Check for if we're doing a drag
		if (CurrentlyBeingDragged)
		{
			GameObject.Transform.Position = mouseOffset + Raylib.GetMousePosition();
		}
	}
}
using System.Numerics;
using Raylib_cs;

class Envelope : Component
{	
	private Draggable dragStatus;

	private Sound sound;

	public override void StartStatic()
	{
		sound = Raylib.LoadSound("./assets/sound/paper1.wav");
	}

	public override void Start()
	{
		dragStatus = GetComponent<Draggable>();
	}

	public override void Update()
	{
		// Check for if we're selected/being dragged and press E
		if (!(dragStatus.CurrentlyBeingDragged && Raylib.IsKeyPressed(KeyboardKey.E))) return;

		// Play the opening sound effect
		Raylib.PlaySound(sound);

		// Get our centre position so we can spawn the paper there too
		Vector2 spawnPosition = Transform.Position;

		// Spawn a letter
		GameObject paper = new GameObject("paper")
			.AddComponent(new Draggable(), out Draggable paperDragging)
			.AddComponent(new TextureRenderer("./assets/texture/paper1.png"))
			.AddComponent(new Hitbox())
			.AddComponent(new Paper());
		paper.Transform.Position = spawnPosition;
		dragStatus.TransferTo(paperDragging);
		SceneManager.Add(paper);

		// Remove ourself (since we've been opened)
		GameObject.Delete();
	}
}
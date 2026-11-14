using System.Numerics;
using Raylib_cs;

class Envelope : Component
{	
	private Draggable dragStatus;

	public override void Start()
	{
		dragStatus = GetComponent<Draggable>();
	}

	public override void Update()
	{
		// Check for if we're selected/being dragged and press E
		if (!(dragStatus.CurrentlyBeingDragged && Raylib.IsKeyPressed(KeyboardKey.E))) return;

		// Get our centre position so we can spawn the paper there too
		Vector2 spawnPosition = GameObject.Transform.Position;

		// Spawn a letter
		GameObject paper = new GameObject("paper");
		Draggable paperDragging = paper.AddComponent(new Draggable());
		paper.AddComponent(new TextureRenderer("./assets/texture/paper1.png"));
		paper.AddComponent(new Hitbox());
		paper.AddComponent(new Paper());
		paper.Transform.Position = spawnPosition;
		dragStatus.TransferTo(paperDragging);
		SceneManager.Add(paper);

		// Remove ourself (since we've been opened)
		GameObject.Delete();
	}
}
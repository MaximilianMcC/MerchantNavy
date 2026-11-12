abstract class Component
{
	public GameObject GameObject { get; internal set; }

	public virtual void Start() { }
	public virtual void CleanUp() { }

	public virtual void Update() { }

	public virtual void DrawUi() { }
	public virtual void Draw() { }
}
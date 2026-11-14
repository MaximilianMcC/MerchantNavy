abstract class Component
{
	public GameObject GameObject { get; internal set; }

	public T GetComponent<T>() where T : Component => GameObject.GetComponent<T>();
	public IReadOnlyList<T> GetComponents<T>() where T : Component => GameObject.GetComponents<T>();
	public bool ComponentExists<T>() where T : Component => GameObject.ComponentExists<T>();
	public bool TryGetComponent<T>(out T component) where T : Component => GameObject.TryGetComponent(out component);

	public Transform Transform => GameObject.Transform;

	public virtual void Start() { }
	public virtual void StartStatic() { }
	public virtual void CleanUp() { }
	public virtual void CleanUpStatic() { }

	public virtual void Update() { }

	public virtual void Draw() { }
	public virtual void DrawDebug() { }

	public virtual void DrawUi() { }
	public virtual void DrawUiDebug() { }
}
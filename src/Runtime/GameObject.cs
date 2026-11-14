using System.Numerics;

class GameObject
{
	public string Name { get; private set; }

	public GameObject Parent { get; private set; }
	public Transform Transform { get; private set; }
	public bool IsQueuedForDeletion { get; private set; }

	public IReadOnlyList<GameObject> Children => children;
	private List<GameObject> children = [];

	public IReadOnlyList<Component> Components => components;
	private List<Component> components = [];



	public GameObject(string name = "My Game Object")
	{
		Name = name;
		Transform = new Transform() { GameObject = this };		
	}

	public GameObject(string name, Vector2 position)
	{
		Name = name;
		Transform = new Transform()
		{
			GameObject = this,
			Position = position
		};
	}

	public T AddComponent<T>(T component) where T : Component
	{
		// TODO: Transform too
		component.GameObject = this;
		components.Add(component);

		return component;
	}

	public T GetComponent<T>() where T : Component => components.OfType<T>().FirstOrDefault();
	public IReadOnlyList<T> GetComponents<T>() where T : Component => components.OfType<T>().ToList();
	public bool ComponentExists<T>() where T : Component => components.OfType<T>().Count() > 0;

	public bool TryGetComponent<T>(out T component) where T : Component
	{
		component = components.OfType<T>().FirstOrDefault();
		return component != null;
	}

	public void AddChild(GameObject child)
	{
		// Remove the child from their previous parent
		child.Parent?.RemoveChild(child);

		// Attach them to us
		child.Parent = this;
		child.Transform.Parent = Transform;

		children.Add(this);
	}

	public void RemoveChild(GameObject child)
	{
		if (children.Remove(child) == false) return;

		// Clear this stuff if we removed the kid
		child.Parent = null;
		child.Transform.Parent = null;
	}

	public GameObject GetChild(string name) => children.Where(x => x.Name == name).FirstOrDefault();

	public void Delete()
	{
		IsQueuedForDeletion = true;
		foreach (GameObject child in children) child.Delete();
	}

	public override string ToString() => Name;
}
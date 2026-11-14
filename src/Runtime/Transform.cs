using System.Numerics;

class Transform
{
	public GameObject GameObject { get; internal set; }

	// Local stuff
	public Vector2 Position = Vector2.Zero;
	public float Rotation = 0f;
	public Vector2 Scale = Vector2.One;

	public Transform Parent { get; internal set; }

	public Vector2 WorldPosition => Parent == null ? Position :
		Parent.WorldPosition + Vector2.Transform(
			Position,
			Matrix3x2.CreateRotation(Parent.WorldRotation) *
			Matrix3x2.CreateScale(Parent.WorldScale)
		);

	public float WorldRotation => Rotation + (Parent?.WorldRotation?? 0);

	public Vector2 WorldScale => Parent == null ? Scale : Parent.WorldScale * Scale;
}
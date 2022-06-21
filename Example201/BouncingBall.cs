using System.Numerics; // Vector2
using Raylib_cs; // Color

/*
In this class, we have the properties:

- Vector2  Position
- float    Rotation
- Vector2  Scale

- Vector2 TextureSize
- Vector2 Pivot
- Color Color

Methods:

- AddChild(Node child)
- RemoveChild(Node child, bool keepAlive = false)
*/

namespace Movement
{
	class BouncingBall : MoverNode
	{
		// your private fields here (add Velocity, Acceleration, addForce method)


		// constructor + call base constructor
		public BouncingBall() : base("resources/ball.png")
		{
			Position = new Vector2(Settings.ScreenSize.X / 6, Settings.ScreenSize.Y / 4);
			Color = Color.PURPLE;
		}

		// Update is called every frame
		public override void Update(float deltaTime)
		{
			Fall(deltaTime);
			BounceEdges();
		}

		// your own private methods
		private void Fall(float deltaTime)
		{
			// TODO implement
			// Position += Velocity * deltaTime;

			Vector2 wind = new Vector2(15.0f, 0.0f);
			Vector2 gravity = new Vector2(0.0f, 20.0f);

			AddForce(wind);
			AddForce(gravity);

			Position += Velocity * deltaTime;
			Velocity += Acceleration;
			Acceleration = Vector2.Normalize(Acceleration);
		}

		private void addForce(Vector2 force)
		{
			Acceleration += force;
		}
	}
}

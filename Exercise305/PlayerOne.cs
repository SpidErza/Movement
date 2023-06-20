using System; // Console
using System.Drawing;
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
	class PlayerOne : MoverNode
	{
		// your private fields here (rotSpeed, thrustForce)
		private float rotSpeed;
		// private float thrustForce;
		private float thrustForce;

		public int health;
		public int MaxHealth;
		// constructor + call base constructor
		public PlayerOne() : base("resources/spaceship.png")
		{
			rotSpeed = (float)Math.PI; // rad/second
			thrustForce = 100f;
			Position = new Vector2(300, 400);
			maxSpeed = 100f;
			MaxHealth = 100;
			health = MaxHealth;
		}

		// Update is called every frame
		public override void Update(float deltaTime)
		{
			Move(deltaTime);
			WrapEdges();
		}

		// your own private methods

		public void RotateRight(float deltaTime)
		{
			Rotation += rotSpeed * deltaTime;
		}

		public void RotateLeft(float deltaTime)
		{
			Rotation -= rotSpeed * deltaTime;
		}

		public void Thrust()
		{
			// TODO implement
			// use thrustForce somewhere here
			float x = thrustForce * MathF.Cos((float)(Rotation));
			float y = thrustForce * MathF.Sin((float)(Rotation));
			Acceleration = new Vector2(x, y);
		}

		public void Reverse()
		{
			float x = thrustForce * MathF.Cos((float)(Rotation));
			float y = thrustForce * MathF.Sin((float)(Rotation));
			Acceleration = new Vector2(-x, -y);
		}

		public void Damage(int amount)
		{
			health -= amount;
		}

		public bool IsAlive()
		{
			if (health <= 0)
			{
				return false;
			}
			return true;
		}

		public void ShowHealth()
		{
			Console.WriteLine("P1_HP: " + health);
		}

		public PlayerOneLazer Shoot()
		{
			PlayerOneLazer l = new PlayerOneLazer();
			l.Position.X = this.Position.X + (float)Math.Cos(Rotation);
			l.Position.Y = this.Position.Y + (float)Math.Sin(Rotation);
			l.Rotation = Rotation;
			l.Velocity = new Vector2(1500 * (float)Math.Cos(Rotation), 1500 * (float)Math.Sin(Rotation));

			return l;
		}

	}
}

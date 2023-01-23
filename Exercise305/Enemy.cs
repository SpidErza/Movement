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
	class Enemy : MoverNode
	{
		// your private fields here (rotSpeed, thrustForce)
		private float rotSpeed;
		// private float thrustForce;
		private float thrustForce;

		private int health;
		// constructor + call base constructor
		public Enemy() : base("resources/Enemy.png")
		{
			rotSpeed = (float)Math.PI; // rad/second
			thrustForce = 100f;
			Position = new Vector2(Settings.ScreenSize.X / 2, Settings.ScreenSize.Y / 2);
			maxSpeed = 100f;
			health = 100;
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
			Console.WriteLine("P2_HP: " + health);
		}

		public EnemyLazer Shoot()
		{
			EnemyLazer e = new EnemyLazer();
			e.Position.X = this.Position.X + (float)Math.Cos(Rotation);
			e.Position.Y = this.Position.Y + (float)Math.Sin(Rotation);
			e.Rotation = Rotation;
			e.Velocity = new Vector2(1500 * (float)Math.Cos(Rotation), 1500 * (float)Math.Sin(Rotation));

			return e;
		}
		//public Circle();

	}
}
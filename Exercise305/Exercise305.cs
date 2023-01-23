using System;
using System.Collections.Generic;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Raylib_cs;

namespace Movement
{
	class Exercise305 : SceneNode
	{
		// private fields
		private SpaceShip spaceship;
		private Enemy enemy;
		private List<Planet> planets;
		List<Lazer> lazers;
		List<EnemyLazer> enemylazers;
		private PoneWins pone;
		private PtwoWins ptwo;

		Random rand = new Random();

		// constructor + call base constructor
		public Exercise305(String t) : base(t)
		{
			PlanetMaker();
			spaceship = new SpaceShip();
			AddChild(spaceship);
			enemy = new Enemy();
			AddChild(enemy);
			lazers = new List<Lazer>();
			enemylazers = new List<EnemyLazer>();
			pone = new PoneWins();
			ptwo = new PtwoWins();
		}

		// Update is called every frame
		public override void Update(float deltaTime)
		{
			if (!spaceship.IsAlive()) 
			{
				AddChild(ptwo);
				return; 
			}

			if (!enemy.IsAlive()) 
			{
				AddChild(pone);
				return; 
			}

			base.Update(deltaTime);
			HandleInput(deltaTime);

			// loop door lijst met lazers
			// check distance met player
			for (int i = enemylazers.Count-1; i >= 0; i--)
			{
				if (CalculateDistance(enemylazers[i].Position, spaceship.Position) < 40)
				{
					Console.WriteLine("boom");
					RemoveChild(enemylazers[i]);
					enemylazers.RemoveAt(i);
					spaceship.Damage(10);
				}
			}

			for (int i = lazers.Count-1; i >= 0; i--)
			{
				if (CalculateDistance(lazers[i].Position, enemy.Position) < 40)
				{
					Console.WriteLine("boom");
					RemoveChild(lazers[i]);
					lazers.RemoveAt(i);
					enemy.Damage(10);
				}
			}
		}

		private void HandleInput(float deltaTime)
		{
			if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
			{
				spaceship.RotateLeft(deltaTime);
			}
			if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
			{
				spaceship.RotateRight(deltaTime);
			}
			if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
			{
				spaceship.Thrust();
			}
			if (Raylib.IsKeyPressed(KeyboardKey.KEY_S))
			{
				Lazer l = spaceship.Shoot();
				if (l != null)
				{
					AddChild(l);
					lazers.Add(l);
				}
			}

			if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
			{
				enemy.RotateLeft(deltaTime);
			}
			if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
			{
				enemy.RotateRight(deltaTime);
			}
			if (Raylib.IsKeyDown(KeyboardKey.KEY_UP))
			{
				enemy.Thrust();
			}
			if (Raylib.IsKeyPressed(KeyboardKey.KEY_DOWN))
			{
				EnemyLazer e = enemy.Shoot();
				if (e != null)
				{
					AddChild(e);
					enemylazers.Add(e);
				}
			}
		}

		private void PlanetMaker()
		{
			planets = new List<Planet>();
			for (int i = 0; i < 10; i++)
			{
				Planet p = new Planet();
				planets.Add(p);
				AddChild(p);

				p.Position.X = rand.Next(0, 1200);
				p.Position.Y = rand.Next(0, 650);
			}
		}

		private float CalculateDistance(Vector2 a, Vector2 b)
		{
			return Vector2.Distance(a, b);
		}
	}
} // namespace
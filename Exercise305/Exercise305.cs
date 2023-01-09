using System;
using System.Collections.Generic;
using System.Drawing;
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
		}

		// Update is called every frame
		public override void Update(float deltaTime)
		{
			base.Update(deltaTime);
			
			HandleInput(deltaTime);
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
			for (int i=0; i<10; i++)
			{
				Planet p = new Planet();
				planets.Add(p);
				AddChild(p);

				p.Position.X = rand.Next(0, 1200);
				p.Position.Y = rand.Next(0, 650);
			}
		}

	} // class

} // namespace

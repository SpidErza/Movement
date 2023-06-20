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
	class GameScene : SceneNode
	{
		// private fields
		private PlayerOne playerone;
		private PlayerTwo playertwo;
		private List<Planet> planets;
		List<PlayerOneLazer> playeronelazers;
		List<PlayerTwoLazer> playertwolazers;
		private PoneWins ponewins;
		private PtwoWins ptwowins;
		private PlayerOneHealthBar playeronehpbar;
		private PlayerTwoHealthBar playertwohpbar;

		Random rand = new Random();

		// constructor + call base constructors
		public GameScene(String t) : base(t)
		{
			Restart();
		}

		// Update is called every frame
		public override void Update(float deltaTime)
		{
			if (!playerone.IsAlive()) 
			{
				AddChild(ptwowins);
				if (Raylib.IsKeyDown(KeyboardKey.KEY_R))
				{
					RemoveChild(playerone);
					RemoveChild(playertwo);
					RemoveChild(playeronehpbar);
					RemoveChild(playertwohpbar);
					RemoveChild(ptwowins);
					PlanetRemover();
					Restart();
				}
				return;
			}

			if (!playertwo.IsAlive()) 
			{
				AddChild(ponewins);
				if (Raylib.IsKeyDown(KeyboardKey.KEY_R))
				{
					RemoveChild(playerone);
					RemoveChild(playertwo);
					RemoveChild(playeronehpbar);
					RemoveChild(playertwohpbar);
					RemoveChild(ponewins);
					PlanetRemover();
					Restart();
				}
				return;
			}

			base.Update(deltaTime);
			HandleInput(deltaTime);

			// loop door lijst met lazers
			// check distance met player
			for (int i = playertwolazers.Count-1; i >= 0; i--)
			{
				if (CalculateDistance(playertwolazers[i].Position, playerone.Position) < 40)
				{
					Console.WriteLine("boom");
					RemoveChild(playertwolazers[i]);
					playertwolazers.RemoveAt(i);
					playerone.Damage(10);
				}
			}

			for (int i = playeronelazers.Count-1; i >= 0; i--)
			{
				if (CalculateDistance(playeronelazers[i].Position, playertwo.Position) < 40)
				{
					Console.WriteLine("boom");
					RemoveChild(playeronelazers[i]);
					playeronelazers.RemoveAt(i);
					playertwo.Damage(10);
				}
			}
			playeronehpbar.Scale.X = playerone.health / 10;
			playertwohpbar.Scale.X = playertwo.health / 10;
		}

		private void HandleInput(float deltaTime)
		{
			if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
			{
				playerone.RotateLeft(deltaTime);
			}
			if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
			{
				playerone.RotateRight(deltaTime);
			}
			if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
			{
				playerone.Thrust();
			}
			if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
			{
				playerone.Reverse();
			}
			if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
			{
				PlayerOneLazer l = playerone.Shoot();
				if (l != null)
				{
					AddChild(l);
					playeronelazers.Add(l);
				}
			}

			if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
			{
				playertwo.RotateLeft(deltaTime);
			}
			if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
			{
				playertwo.RotateRight(deltaTime);
			}
			if (Raylib.IsKeyDown(KeyboardKey.KEY_UP))
			{
				playertwo.Thrust();
			}
			if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN))
			{
				playertwo.Reverse();
			}
			if (Raylib.IsKeyPressed(KeyboardKey.KEY_KP_ENTER))
			{
				PlayerTwoLazer e = playertwo.Shoot();
				if (e != null)
				{
					AddChild(e);
					playertwolazers.Add(e);
				}
			}
		}

		public void PlanetMaker()
		{
			planets = new List<Planet>();
			for (int i = 0; i < 15; i++)
			{
				Planet p = new Planet();
				planets.Add(p);
				AddChild(p);

				p.Position.X = rand.Next(0, 1200);
				p.Position.Y = rand.Next(0, 650);
			}
		}

		public void PlanetRemover()
		{
			for (int i = 0; i < planets.Count; i++)
			{
				RemoveChild(planets[i]);
			}
			planets.Clear();
		}


		private float CalculateDistance(Vector2 a, Vector2 b)
		{
			return Vector2.Distance(a, b);
		}

		void Restart()
		{
			//restart the game
			PlanetMaker();
			playerone = new PlayerOne();
			AddChild(playerone);
			playertwo = new PlayerTwo();
			AddChild(playertwo);
			playeronelazers = new List<PlayerOneLazer>();
			playertwolazers = new List<PlayerTwoLazer>();
			ponewins = new PoneWins();
			ptwowins = new PtwoWins();
			playeronehpbar = new PlayerOneHealthBar();
			AddChild(playeronehpbar);
			playertwohpbar = new PlayerTwoHealthBar();
			AddChild(playertwohpbar);
		}
	}
} // namespace
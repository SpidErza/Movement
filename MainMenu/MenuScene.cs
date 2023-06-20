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
	class MenuScene : SceneNode
	{
		// private fields
		private List<MenuButton> menubuttons;

		// constructor + call base constructors
		public MenuScene(String t) : base(t)
		{
			MenuButtons();
		}

		// Update is called every frame
		public override void Update(float deltaTime)
		{
			
		}

		public void MenuButtons()
		{
			menubuttons = new List<MenuButton>();

			MenuButton start = new MenuButton();
			menubuttons.Add(start);
			AddChild(start);
			start.Position.X = 400;
			start.Position.Y = 200;
			start.Color = Raylib_cs.Color.ORANGE;

			MenuButton options = new MenuButton();
			menubuttons.Add(options);
			AddChild(options);
			options.Position.X = 400;
			options.Position.Y = 300;
			options.Color = Raylib_cs.Color.BLUE;

			MenuButton quit = new MenuButton();
			menubuttons.Add(quit);
			AddChild(quit);
			quit.Position.X = 400;
			quit.Position.Y = 400;
			quit.Color = Raylib_cs.Color.ORANGE;
		}
	}
} // namespace
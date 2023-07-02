using System;
using System.Drawing;
using Raylib_cs;
using System.Numerics;
using System.Dynamic;

namespace Movement
{
	class PlayerOneLazer : MoverNode
	{
		public PlayerOneLazer() : base("resources/Lazer.png")
		{
			
		}

		public override void Update(float deltaTime)
		{
			Move(deltaTime);
			//WrapEdges();
			//BounceEdges();
		}
    }
}
using System;
using System.Drawing;
using Raylib_cs;
using System.Numerics;

namespace Movement
{
	class Lazer : MoverNode
	{
		public Lazer() : base("resources/Lazer.png")
		{

		}

		public override void Update(float deltaTime)
		{
			Move(deltaTime);
		}
    }
}
using System;
using System.Drawing;
using Raylib_cs;
using System.Numerics;

namespace Movement
{
	class PlayerTwoLazer : MoverNode
	{
		public PlayerTwoLazer() : base("resources/EnemyLazer.png")
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
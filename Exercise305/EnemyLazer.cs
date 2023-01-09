using System;
using System.Drawing;
using Raylib_cs;
using System.Numerics;

namespace Movement
{
	class EnemyLazer : MoverNode
	{
		public EnemyLazer() : base("resources/EnemyLazer.png")
		{

		}

		public override void Update(float deltaTime)
		{
			Move(deltaTime);
		}
    }
}
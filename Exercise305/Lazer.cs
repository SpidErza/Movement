using System;
using System.Drawing;
using Raylib_cs;
using System.Numerics;
using System.Dynamic;

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

		//public bool impactchecker()
		//{
		//	bool deletelazer = false;
		//	if (Console.WriteLine("boom"))
		//	{
		//		deletelazer = true;
		//	}
		//	return deletelazer;
		//}
    }
}
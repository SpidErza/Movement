using System; // Console
using System.Drawing;
using System.Numerics; // Vector2
using Raylib_cs; // Color

namespace Movement
{
	class PlayerOneHealthBar : SpriteNode
	{
		public PlayerOneHealthBar() : base("resources/health_bar.png")
		{
			Position = new Vector2(100, 50);
			//Pivot = new Vector2(0, 0);
		}

		void Update()
		{

		}
	} 

}
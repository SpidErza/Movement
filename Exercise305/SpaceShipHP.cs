using System; // Console
using System.Drawing;
using System.Numerics; // Vector2
using Raylib_cs; // Color

namespace Movement
{
	class SpaceShipHP : SpriteNode
	{
		public SpaceShipHP() : base("resources/health_bar.png")
		{
			Position = new Vector2(100, 50);
		}

		void Update()
		{

		}
	} 

}
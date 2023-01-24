using System; // Console
using System.Drawing;
using System.Numerics; // Vector2
using Raylib_cs; // Color

namespace Movement
{
	class EnemyHP : SpriteNode
	{
		public EnemyHP() : base("resources/enemy_health_bar.png")
		{
			Position = new Vector2(100, 70);
		}

		void Update()
		{

		}
	} 

}
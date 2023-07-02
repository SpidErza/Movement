using System;
using Raylib_cs;
using System.Numerics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Collections.Generic;

namespace Movement 
{
    class Planet : SpriteNode
    {
        public Planet() : base("resources/planet.png")
        {
			Color = Raylib_cs.Color.VIOLET;
		}
	}
}
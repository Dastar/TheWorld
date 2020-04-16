using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace SheepGame.Desktop
{
    public class Tiles
    {
        public List<Vector2> Positions = new List<Vector2>();
        public int Type;

        public Tiles(int type)
        {
            Type = type;
        }

        public void Add(int x, int y)
        {
            Positions.Add(new Vector2(x, y));
        }
    }
}

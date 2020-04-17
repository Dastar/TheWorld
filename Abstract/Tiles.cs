using System;
using System.Collections;
using Microsoft.Xna.Framework;

namespace SheepGame.Desktop
{
    public class Tiles
    {
        public Tile[,] Positions { get; private set; }

        public Tile this[int x, int y]
        {
            get
            {
                return Positions[x, y];
            }
            set
            {
                Positions[x, y] = value;
            }
        }

        public Tiles(int x, int y)
        {
            Positions = new Tile[x, y];
        }

        public IEnumerator GetEnumerator()
        {
            return Positions.GetEnumerator();
        }
    }
}

using System;
using System.Collections;
using Microsoft.Xna.Framework;

namespace SheepGame.Desktop
{
    public class Tiles
    {
        public ITile[,] Positions { get; private set; }

        public ITile this[int x, int y]
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
            Positions = new ITile[x, y];
        }

        public IEnumerator GetEnumerator()
        {
            return Positions.GetEnumerator();
        }
    }

}

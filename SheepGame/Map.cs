using System;
using Abstract;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SheepGame.Desktop
{
    public class Map
    {
        Tiles bar;
        public Map()
        {
        }

        public void CreateTiles(Asset a)
        {
            var foo = new List<Vector2>();
            for (int i = 0; i <= 832; i += 64)
            {
                for (int j = 0; j <= 448; j += 64)
                {
                    foo.Add(new Vector2(i, j));
                }
            }

            bar = new Tiles(a, 0, foo);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            bar.Draw(spriteBatch);
        }
    }
}

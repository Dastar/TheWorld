using System;
using Microsoft.Xna.Framework;

namespace SheepGame.Desktop
{
    public class Tile
    {
        public Vector2 Position { get; private set; }
        public int Type { get; private set; }
        public float X => Position.X;
        public float Y => Position.Y;

        public Tile(Vector2 position, int type)
        {
            Position = position;
            Type = type;
        }
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Abstract
{
    public class Asset
    {
        public readonly Texture2D Texture;
        public readonly int Rows;
        public readonly int Cols;
        public readonly int TotalFrames;

        public int Width
        {
            get { return Texture.Width; }
        }
        public int Height
        {
            get { return Texture.Height; }
        }

        public Asset(Texture2D texture, int rows, int cols)
        {
            Texture = texture;
            Rows = rows > 0 ? rows : 1;
            Cols = cols > 0 ? cols : 1;
            TotalFrames = rows * cols;
        }
    }
}

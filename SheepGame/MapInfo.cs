using System;
using Abstract;

namespace SheepGame.Desktop
{
    public class MapInfo: Info
    {
        public string Name;
        public int MapWidth;
        public int MapHeight;
        public Asset Tile;
        public string ImgDir;

        public MapInfo()
        {
        }
    }
}

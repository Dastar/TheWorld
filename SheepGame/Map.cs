using System;
using System.Xml;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Abstract;

namespace SheepGame.Desktop
{
    public class Map: AbstractObject
    {
        private string _name;
        private readonly Tiles[] _positions;
        private int _mapWidth;
        private int _mapHeight;
        private int _screenWidth;
        private int _screenHeight;

        private readonly string line = "Line";
        private readonly string x = "x";
        private readonly string y = "y";
        private readonly string name = "name";
        private readonly string type = "type";
        private readonly string dimension = "dimension";

        public Map(Asset asset, int screenWidth, int screenHeight): base(asset, Vector2.Zero)
        {
            _positions = new Tiles[asset.TotalFrames];
            for (int frame = 0; frame < asset.TotalFrames; frame++)
            {
                _positions[frame] = new Tiles(frame);
            }

            _screenWidth = screenWidth;
            _screenHeight = screenHeight;
        }


        // Throws: XmlReader, int.Parse 
        public void GenerateMapFromXML(string link)
        {
            using (var reader = XmlReader.Create(link))
            {
                reader.Read();
                reader.Read();
                reader.Read();

                _name = reader.GetAttribute(name);
                var d = reader.GetAttribute(dimension).Split(',');
                _mapWidth = int.Parse(d[0]) * _width;
                _mapHeight = int.Parse(d[1]) * _height;

                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == line)
                    {
                        var x_point = int.Parse(reader.GetAttribute(x));
                        do
                        {
                            reader.Read();
                            if (reader.NodeType != XmlNodeType.Element) continue;
                            var y_point = int.Parse(reader.GetAttribute(y));
                            var tile_type = int.Parse(reader.GetAttribute(type));
                            _positions[tile_type].Add(x_point * _width, y_point * _height);
                        }
                        while (reader.Name != line || reader.NodeType != XmlNodeType.EndElement);

                    }


                }
            }
            
        }

        public new void Draw(SpriteBatch spriteBatch)
        {
            var xFactor = 0;
            if (_screenWidth > _mapWidth)
                xFactor = (_screenWidth - _mapWidth) / 2;

            var yFactor = 0;
            if (_screenHeight > _mapHeight)
                yFactor = (_screenHeight - _mapHeight) / 2;

            Vector2 factor = new Vector2(xFactor, yFactor);
            spriteBatch.Begin();
            foreach (var tile in _positions)
            {
                ChangeFrame(tile.Type);
                var sourceRectangle = SourceRectangle();
                foreach (var p in tile.Positions)
                {
                    _position = p + factor;
                    spriteBatch.Draw(_texture.Texture, DestinationRectangle(), sourceRectangle, Color.White);
                }

            }
            spriteBatch.End();
        }

        public override void Update()
        {
        }
    }
}

using System.Xml;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Abstract;

namespace SheepGame.Desktop
{
    public class Map: AbstractObject
    {
        #region Fields
        public int MapWidth { get; private set; }
        public int MapHeight { get; private set; }
        private Tiles _tiles;

        private readonly int _screenWidth;
        private readonly int _screenHeight;

        public string MapName { get; private set; }
        #endregion

        #region XML Tags
        private readonly string XMLLine = "Line";
        private readonly string XMLX = "x";
        private readonly string XMLY = "y";
        private readonly string XMLName = "name";
        private readonly string XMLType = "type";
        private readonly string XMLDimension = "dimension";
        private readonly string XMLMap = "Map";
        private readonly char XMLDelimeter = ',';
        #endregion

        public Map(Asset asset, int screenWidth, int screenHeight): 
            base(asset, Vector2.Zero)
        {
            _screenWidth = screenWidth;
            _screenHeight = screenHeight;
        }


        /// <summary>
        /// Generates the map from xml.
        /// </summary>
        /// <param name="link">link to xmp-map</param>
        /// <exception>From XmlReader and int.Parse</exception>
        public void GenerateMapFromXML(string link)
        {
            using (var reader = XmlReader.Create(link))
            {
                while (reader.Name != XMLMap)
                {
                    reader.Read();
                }

                // Geting map parameters
                MapName = reader.GetAttribute(XMLName);
                var dimension = reader.GetAttribute(XMLDimension).Split(XMLDelimeter);

                int dimensionX = int.Parse(dimension[0]);
                int dimensionY = int.Parse(dimension[1]);

                _tiles = new Tiles(dimensionX, dimensionY);

                MapWidth = dimensionX * _width;
                MapHeight = dimensionY * _height;

                // Generating map from xml
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == XMLLine)
                    {
                        var x = int.Parse(reader.GetAttribute(XMLX));
                        do
                        {
                            reader.Read();
                            if (reader.NodeType != XmlNodeType.Element) continue;

                            var y = int.Parse(reader.GetAttribute(XMLY));
                            var type = int.Parse(reader.GetAttribute(XMLType));

                            Tile tile = new Tile(new Vector2(x * _width, y * _height), type);
                            _tiles[x, y] = tile;
                        }
                        while (reader.Name != XMLLine || reader.NodeType != XmlNodeType.EndElement);

                    }


                }
            }
            
        }

        public new void Draw(SpriteBatch spriteBatch)
        {
            // If the map is smaller then the screen, put the map in the 
            // middle of the screen
            // TODO: when the map is bigger then the screen
            var xFactor = 0;
            if (_screenWidth > MapWidth)
                xFactor = (_screenWidth - MapWidth) / 2;

            var yFactor = 0;
            if (_screenHeight > MapHeight)
                yFactor = (_screenHeight - MapHeight) / 2;

            Vector2 factor = new Vector2(xFactor, yFactor);


            // Drawing
            spriteBatch.Begin();
            foreach (Tile tile in _tiles)
            {
                // Changing the frame and the position
                ChangeFrame(tile.Type);
                var sourceRectangle = SourceRectangle();
                _position = tile.Position + factor;

                spriteBatch.Draw(_texture.Texture, 
                                DestinationRectangle(), 
                                sourceRectangle, 
                                Color.White);
                if (!(tile.Object is null))
                {
                    tile.Object.Draw(spriteBatch);
                }
            }
            spriteBatch.End();
        }

        public override void Update()
        {
        }

        public bool IsTileFree(int x, int y)
        {
            x %= _width;
            y %= _height;

            return ((Tile)_tiles[x, y]).Object is null;
        }

        public void PutOnTile(AbstractObject t)
        {
            int x = (int)t.X % _width;
            int y = (int)t.Y % _height;

            ((Tile)_tiles[x, y]).Object = t;
        }

        public void RemoveFromTile(int x, int y)
        {
            x %= _width;
            y %= _height;

            ((Tile)_tiles[x, y]).Object = null;

        }
    }
}

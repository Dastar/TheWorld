using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Abstract;


namespace SheepGame.Desktop
{
    public class Engine
    {
        private Zoo _zoo;
        private Map _map;

        private readonly string AssetSheep = "sheep";
        private readonly string AssetTiles = "tiles";
        private readonly string DefaultMap = "../../../../maps/defaultMap.xml";

        public Engine(ContentManager content, GraphicsDeviceManager graphics)
        {
            var tiles = content.Load<Texture2D>(AssetTiles);
            _map = new Map(new Asset(tiles, 2, 2),
                graphics.PreferredBackBufferWidth,
                graphics.PreferredBackBufferHeight);
            // TODO: catch exeption
            _map.GenerateMapFromXML(DefaultMap);

            var sheep = content.Load<Texture2D>(AssetSheep);
            _zoo = new Zoo(new List<Asset>() { new Asset(sheep, 5, 4) });
            _zoo.CreateAnimals(_map.MapWidth, _map.MapHeight);
            _zoo.Move(12,7);
        }

        double delta = 0;
        public void Update(GameTime gameTime)
        {
            _map.Update();

            if (delta >= 250)
            {
                delta = 0;
                _zoo.Update();
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _map.Draw(spriteBatch);
            _zoo.Draw(spriteBatch);
        }
    }
}

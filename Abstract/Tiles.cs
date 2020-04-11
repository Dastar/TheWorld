using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Abstract
{
    public class Tiles : AbstractObject
    {
        public List<Vector2> Positions;
        public Tiles(Asset asset, int kind, List<Vector2> positions) :
            base(asset, Vector2.Zero)
        {
            Positions = positions;
            ChangeFrame(kind);
        }

        public override void Update()
        {
        }

        public new void Draw(SpriteBatch spriteBatch)
        {
            var sourceRectangle = SourceRectangle();

            spriteBatch.Begin();
            foreach (var position in Positions)
            {
                _position = position;
                spriteBatch.Draw(_texture.Texture, DestinationRectangle(), sourceRectangle, Color.White);
            }
            spriteBatch.End();

        }
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Abstract
{
    /// <summary>
    /// Abstract object.
    /// </summary>
    abstract public class AbstractObject
    {
        protected Vector2 _position;
        protected Asset _texture;
        protected readonly int _width;
        protected readonly int _height;
        private int _currentFrame;

        public float X => _position.X;
        public float Y => _position.Y;


        /// <summary>
        /// Initializes a new instance of the <see cref="T:TheWorld.Desktop.AbstractObject"/> class.
        /// </summary>
        /// <param name="asset">Asset.</param>
        /// <param name="position">Position.</param>
        protected AbstractObject(Asset asset, Vector2 position, int currentFrame = 0)
        {
            _texture = asset;
            _position = position;
            _currentFrame = currentFrame;
            _width = _texture.Width / _texture.Cols;
            _height = _texture.Height / _texture.Rows;
        }

        /// <summary>
        /// Changes the frame.
        /// </summary>
        /// <param name="toFrame">To frame.</param>
        protected void ChangeFrame(int toFrame)
        {
            _currentFrame = toFrame % _texture.TotalFrames;
        }

        /// <summary>
        /// Creates rectangle in specific position
        /// </summary>
        /// <returns>rectangle in specific position</returns>
        protected Rectangle DestinationRectangle()
        {
            return new Rectangle((int)_position.X, (int)_position.Y, _width, _height);
        }

        /// <summary>
        /// Creates rectangle of the frame
        /// </summary>
        /// <returns>Frame rectangle</returns>
        protected Rectangle SourceRectangle()
        {
            // Calculating frame dimension and position
            int row = (int)((float)_currentFrame / (float)_texture.Cols);
            int column = _currentFrame % _texture.Cols;

            return new Rectangle(_width * column, _height * row, _width, _height);
        }

        /// <summary>
        /// Drawing specific frame from the texture. 
        /// </summary>
        /// <param name="spriteBatch">Sprite batch.</param>
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Begin();
            spriteBatch.Draw(_texture.Texture, DestinationRectangle(), SourceRectangle(), Color.White);
            //spriteBatch.End();
        }

        abstract public void Update();
    }
}

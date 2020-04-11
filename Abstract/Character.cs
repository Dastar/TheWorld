using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Abstract
{
    public class Character : AbstractObject
    {
        public MovingPosition Position = MovingPosition.Standing;
        private Vector2 _destination;

        public int Speed { get; set; }

        private int _moveFrame = 0;
        private int _moveWay = 1;

        public Character(Asset asset, Vector2 position) : base(asset, position)
        {
            Speed = 4;
            _destination = position;
        }

        public void GoTo(Vector2 destination)
        {
            _destination = destination;
            if (Position == MovingPosition.Standing)
                Position = MovingPosition.Moving;
        }

        public override void Update()
        {
            if (Position != MovingPosition.Standing)
            {
                if (_position.X.CompareTo(_destination.X) != 0)
                {
                    _position.X = MoveCharacter(_position.X, _destination.X, MovingPosition.Right, MovingPosition.Left);
                }
                else if (_position.Y.CompareTo(_destination.Y) != 0)
                {
                    _position.Y = MoveCharacter(_position.Y, _destination.Y, MovingPosition.Down, MovingPosition.Up);
                }
                else
                {
                    ChangeFrame((int)Position - 1);
                    Position = MovingPosition.Standing;
                    _moveFrame = 1;
                }
            }
        }

        /// <summary>
        /// Movings character one *speed* pixels towards the destination.
        /// </summary>
        /// <param name="position">Starting position</param>
        /// <param name="dest">Final destination</param>
        /// <param name="plus">Negative direction, object is in the origin</param>
        /// <param name="minus">Positive direction, object is in the origin<param>
        /// <return>New position of the character</return>
        private float MoveCharacter(float position, float dest, MovingPosition plus, MovingPosition minus)
        {
            if (position.CompareTo(dest) == 0) return position;

            // Determinating to which side we need to go
            var move = (dest - position) / Math.Abs(dest - position);
            Position = (move > 0) ? plus : minus;

            // Determinating next frame
            ChangeFrame((int)Position * (_texture.Rows - 1) + _moveFrame);
            _moveFrame += _moveWay;

            if (_moveFrame == _texture.Cols - 1)
                _moveWay = -1;
            else if (_moveFrame == 0)
                _moveWay = 1;

            // Actual moving. Be carefull not to past the destination
            var newPosition = position + move * Speed;
            if (position < dest && newPosition > dest || position > dest && newPosition < dest)
                position = dest;
            else
                position = newPosition;

            return position;
        }
    }

    public enum MovingPosition
    {
        Standing = 0,
        Down = 1,
        Right = 2,
        Up = 3,
        Left = 4,
        Moving = 5
    }
}

using System;
using System.Collections.Generic;
using Abstract;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SheepGame.Desktop
{
    public class Zoo
    {
        private List<Character> _animals = new List<Character>();
        private List<Asset> _assets;
        private Random rnd = new Random();

        public Zoo(List<Asset> assets)
        {
            _assets = assets;
        }

        public void CreateAnimals(int windowWidth, int windowHeight)
        {
            for (int i = 0; i < 2; i++)
            {
                Vector2 position = new Vector2(rnd.Next(windowWidth - 64), rnd.Next(windowHeight - 64));
                _animals.Add(new Character(_assets[rnd.Next(_assets.Count)], position));
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var animal in _animals)
            {
                animal.Draw(spriteBatch);
            }
        }

        public void Update()
        {
            foreach (var animal in _animals)
            {
                animal.Update();
            }
        }

        public void Move(int windowWidth, int windowHeight)
        {
            foreach (var animal in _animals)
            {
                if (animal.Position != MovingPosition.Standing) continue;
                Vector2 position = new Vector2(rnd.Next(windowWidth), rnd.Next(windowHeight));
                animal.GoTo(position);
            }
        }
    }
}

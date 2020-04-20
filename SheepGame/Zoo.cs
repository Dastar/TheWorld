using System;
using System.Collections.Generic;
using Abstract;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SheepGame.Desktop
{
    public class Zoo
    {
        private List<NPC> _animals = new List<NPC>();
        private List<Asset> _assets;
        private Random rnd = new Random();
        public delegate bool IsFreeMap(int x, int y);
        private IsFreeMap IsFree;

        public Zoo(List<Asset> assets, IsFreeMap isFree)
        {
            _assets = assets;
            IsFree = isFree;
        }

        public void CreateAnimals(int mapWidth, int mapHeight)
        {
            for (int i = 0; i < 2; i++)
            {
                Vector2 position = new Vector2(rnd.Next(mapWidth), rnd.Next(mapHeight));
                _animals.Add(new NPC(_assets[rnd.Next(_assets.Count)], position));
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
            if (IsFree(0, 0)) return;
            foreach (NPC animal in _animals)
            {
                if (animal.Position != MovingPosition.Standing) continue;
                Vector2 position = new Vector2(rnd.Next(windowWidth), rnd.Next(windowHeight));
                animal.GoTo(position);
            }
        }
    }
}

﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Abstract;
using System.Collections.Generic;

namespace SheepGame.Desktop
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Zoo _sheeps;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsFixedTimeStep = false;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }
        Map myMap;
        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            Asset a = new Asset(Content.Load<Texture2D>("sheep"), 5, 4);
            _sheeps = new Zoo(new List<Asset>() { a });
            _sheeps.CreateAnimals(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            Asset b = new Asset(Content.Load<Texture2D>("tiles"), 2, 2);
            myMap = new Map(b, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            myMap.GenerateMapFromXML("../../../../maps/defaultMap.xml");

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        double delta = 0;
        double delta2 = 0;
        bool foo = true;
        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            delta += gameTime.ElapsedGameTime.TotalMilliseconds;
            if (delta >= 250)
            {
                delta2 += delta;
                delta = 0;
                _sheeps.Update();
            }

            if (foo)
            {
                foo = false;
                //delta2 = 0;
                _sheeps.Move(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            myMap.Draw(spriteBatch);
            _sheeps.Draw(spriteBatch);

            base.Draw(gameTime);
        }
    }
}

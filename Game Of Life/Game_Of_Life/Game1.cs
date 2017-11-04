using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using WinForms = System.Windows.Forms;

namespace Game_Of_Life
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        Settings config;
        Texture2D cell;
        GameOfLife gameOfLife;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        int timeElapsed = 0;

        public Game1(Settings settings, IntPtr desktopHandler)
        {
            graphics = new GraphicsDeviceManager(this);
            config = settings;

            graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            graphics.IsFullScreen = false;

            W32.SetParent(Window.Handle, desktopHandler);
            var form = WinForms.Control.FromHandle(this.Window.Handle) as WinForms.Form;
            form.FormBorderStyle = WinForms.FormBorderStyle.None;
        }

        public Game1(Settings settings)
        {
            graphics = new GraphicsDeviceManager(this);
            config = settings;

            graphics.PreferredBackBufferWidth = config.Width;
            graphics.PreferredBackBufferHeight = config.Height;
            graphics.IsFullScreen = config.Fullscreen;
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

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            gameOfLife = new GameOfLife(graphics.PreferredBackBufferWidth / config.PixelSize, graphics.PreferredBackBufferHeight / config.PixelSize, config.Density, config.Reproductors, config.Survivors);
            spriteBatch = new SpriteBatch(GraphicsDevice);
            cell = new Texture2D(graphics.GraphicsDevice, 1, 1);
            cell.SetData(new Color[] { Color.White });
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            timeElapsed += (int)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (timeElapsed > config.TickTime)
            {
                gameOfLife.Tick();
                timeElapsed = 0;
            }

            spriteBatch.Begin();

            for (int x = 0; x < graphics.PreferredBackBufferWidth / config.PixelSize; x++)
            {
                for (int y = 0; y < graphics.PreferredBackBufferHeight / config.PixelSize; y++)
                {
                    Rectangle rectangle = new Rectangle(x * config.PixelSize, y * config.PixelSize, config.PixelSize, config.PixelSize);
                    spriteBatch.Draw(cell, rectangle, gameOfLife.GetColor(x, y));
                }
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}

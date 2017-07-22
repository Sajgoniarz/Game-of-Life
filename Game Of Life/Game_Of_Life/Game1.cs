using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game_Of_Life
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {

        Texture2D cell;
        GameOfLife gameOfLife;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        int timeElapsed = 0;

        const int WINDOW_WIDTH = 800;
        const int WINDOW_HEIGHT = 600;
        const int GAME_TICK = 80;
        const int PIXEL_SIZE = 4;
        const int LIFE_DENSITY = 20;
        readonly int[] SURVIVORS = { 2, 3 };
        readonly int[] REPRODUCTORS = { 3 };

        public Game1()
        {
            this.Window.Title = "Game of Life";
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
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
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferWidth = WINDOW_WIDTH;
            graphics.PreferredBackBufferHeight = WINDOW_HEIGHT;
            graphics.ApplyChanges();
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
            gameOfLife = new GameOfLife(WINDOW_WIDTH / PIXEL_SIZE, WINDOW_HEIGHT / PIXEL_SIZE, LIFE_DENSITY, REPRODUCTORS, SURVIVORS);
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

            if (timeElapsed > GAME_TICK)
            {
                gameOfLife.Tick();
                timeElapsed = 0;
            }

            spriteBatch.Begin();

            for (int x = 0; x < WINDOW_WIDTH; x += PIXEL_SIZE)
            {
                for (int y = 0; y < WINDOW_HEIGHT; y += PIXEL_SIZE)
                {
                    Rectangle rectangle = new Rectangle(x, y, PIXEL_SIZE, PIXEL_SIZE);
                    spriteBatch.Draw(cell, rectangle, gameOfLife.GetColor(x / PIXEL_SIZE, y / PIXEL_SIZE));
                }
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}

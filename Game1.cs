using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SPACEGAME
{
    public enum DIRECTION { NONE, NORTH, SOUTH, EAST, WEST };
    public enum VISIBILITY { HIDDEN, HIDING, SHOWN, SHOWING }
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        TextureManager TM;
        map M;
        HudManager HM;
        DateTime DT;
        Globals G;
        SpriteFont defaultFont;
        int elapsedSeconds = 0;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 720;
            graphics.PreferredBackBufferWidth = 1280;
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

            gameInit();
        }

        public void gameInit()
        {
            populateTextureManager();

            defaultFont = Content.Load<SpriteFont>("Arial");
            DT = new DateTime();
            M = new map("no bias", TM.tileTextures);
            G = new Globals();
            HM = new HudManager(TM);
            G.graphicsWidth = 1280;
            G.graphicsHeight = 720;
            G.tileSize = 40;
            G.timeStamp = 0;
            G.movementCooldown = 100;
            G.mouseText = "";
            G.mouseSubText = "";
        }


        public void populateTextureManager()
        {
            TM = new TextureManager();

            //floor tiles
            TM.tileTextures.Add(Content.Load<Texture2D>("tiles/lush"));
            TM.tileTextures.Add(Content.Load<Texture2D>("tiles/jungle"));
            TM.tileTextures.Add(Content.Load<Texture2D>("tiles/desert"));
            TM.tileTextures.Add(Content.Load<Texture2D>("tiles/snow"));
            TM.tileTextures.Add(Content.Load<Texture2D>("tiles/mountain"));
            TM.tileTextures.Add(Content.Load<Texture2D>("tiles/twilight"));
            TM.tileTextures.Add(Content.Load<Texture2D>("tiles/hellscape"));

            //UI elements
            TM.UI.Add(Content.Load<Texture2D>("UI/show"));
            TM.UI.Add(Content.Load<Texture2D>("UI/hide"));
            TM.UI.Add(Content.Load<Texture2D>("UI/blackBar"));
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
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
            KeyboardState keyState = Keyboard.GetState();
            MouseState mouseState = Mouse.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

                //arrow keys move camera around
            if (keyState.IsKeyDown(Keys.Down))
            { M.adjustCamera(0, 1, G); }
            if (keyState.IsKeyDown(Keys.Up))
            { M.adjustCamera(0, -1, G); }
            if (keyState.IsKeyDown(Keys.Left))
            { M.adjustCamera(-1, 0, G); }
            if (keyState.IsKeyDown(Keys.Right))
            { M.adjustCamera(1, 0, G); }

            //get current mouse state
            MouseState pos = Mouse.GetState();
            G.mouseX = pos.X;
            G.mouseY = pos.Y;

            //how about left click?
            if (mouseState.LeftButton == ButtonState.Released)
            {
                /*SOME CLICK ACTION*/
            }

            //populate flavor text
            //tile T = M.getTileAt(pos.X / 40, pos.Y / 40);

            //get current seconds
            elapsedSeconds = (int)gameTime.TotalGameTime.TotalSeconds;
            DT.updateDay(elapsedSeconds);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            int WIDTH = (G.graphicsWidth / G.tileSize);
            int HEIGHT = (G.graphicsHeight / G.tileSize);
            int i, j = 0;
            int camX = 0;
            int camY = 0;

            GraphicsDevice.Clear(Color.TransparentBlack);

            spriteBatch.Begin();

            //draw TILES
            camX = M.getCamX();
            camY = M.getCamY();

            for (i = 0; i < HEIGHT; i++)
            {
                for (j = 0; j < WIDTH; j++)
                {
                    tile T = M.getTileAt(camX + j, camY + i);
                    Vector2 pos = new Vector2(j * G.tileSize, i * G.tileSize);
                    spriteBatch.Draw(T.getTexture(), pos, null, Color.White, 0, Vector2.Zero, 1f, SpriteEffects.None, 1f);
                }
            }

            //draw TEXT
            if (!G.mouseText.Equals(""))
            {
                //draw box
                //spriteBatch.DrawString(defaultFont, G.mouseText,new Vector2((G.mouseX + 5), (G.mouseY+5)),Color.White, 0, new Vector2(0, 0), 1f, SpriteEffects.None,0);
                //spriteBatch.DrawString(defaultFont, G.mouseSubText, new Vector2((G.mouseX +5), (G.mouseY+25)), Color.White,0,new Vector2(0,0),1f,SpriteEffects.None,0);
            }

            for (i = 0; i < HM.hudGraphicsCount(); i++)
            {
                HudGraphic HG = HM.getGraphicAt(i);
                spriteBatch.Draw(HG.getTexture(), HG.getPosition(), null, Color.Transparent, 0, Vector2.Zero, 1f, SpriteEffects.None, 1f);
            }

            //draw bottom bar
            //spriteBatch.Draw(TM.UI[0], new Vector2(0, 700), null, Color.White, 0, Vector2.Zero, 1f, SpriteEffects.None, 1f);

            //draw current position
            //string position = "pos:(" + camX + "," + camY + ")";
            //spriteBatch.DrawString(defaultFont, position, new Vector2(0, 702), Color.White, 0, new Vector2(0, 0), 1f, SpriteEffects.None, 0);

            //draw current time
            //string date = "day:" + DT.getDay();
            //spriteBatch.DrawString(defaultFont, date, new Vector2(150, 702), Color.White, 0, new Vector2(0, 0), 1f, SpriteEffects.None, 0);

            //draw resources

            base.Draw(gameTime);

            spriteBatch.End();

            return;
        }
    }
}

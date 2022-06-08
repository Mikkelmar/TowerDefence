using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Renderers;
using MonoGame.Extended.ViewportAdapters;
using System.Diagnostics;
using TestGame.Graphics;
using TestGame.Managers;
using TestGame.Pages;
using TiledSharp;

namespace TestGame
{
    public class Game1 : Game
    {

     

        // page
        public PageManager pageManager { get; private set; } = new PageManager();
        public PageGame pageGame;
        public OrthographicCamera gameCamera;

        public Game1()
        {
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            //init graphics
            
            Drawing.Initialize(this);  

        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();


            // window
            IsFixedTimeStep = false;
            Window.Title = Drawing.TITLE;

            //init pages
            pageManager.Add(pageGame, this);
            pageManager.Set(pageGame);

            //init camera
            var viewportadapter = new BoxingViewportAdapter(Window, GraphicsDevice, Drawing.WINDOW_WIDTH, Drawing.WINDOW_HEIGHT);
            gameCamera = new OrthographicCamera(viewportadapter);
            gameCamera.Zoom = pageGame.cam.Zoom;
           



        }

        protected override void LoadContent()
        {

            // TODO: use this.Content to load your game content here
            Textures.Load(this);
            pageGame = new PageGame();
        }

        protected override void Update(GameTime gameTime)
        {
            //Window.Title = Drawing.fps.ToString();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed) // || Keyboard.GetState().IsKeyDown(Keys.Escape)
                Exit();

            // update drawing
            Drawing.Update(gameTime, this);

            // TODO: Add your update logic here
            pageManager.Update(gameTime, this);


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            //Draw gameobjects
            Drawing._spriteBatch.Begin(SpriteSortMode.BackToFront, null, SamplerState.PointClamp, transformMatrix: gameCamera.GetViewMatrix());
            base.Draw(gameTime);
            pageManager.Draw(this);
            
            Drawing._spriteBatch.End();

            //Draw UI
            gameCamera.Zoom = 1f;
            Drawing._spriteBatch.Begin(SpriteSortMode.BackToFront, null, SamplerState.PointClamp, transformMatrix: gameCamera.GetViewMatrix());
            gameCamera.Zoom = pageGame.cam.Zoom;

            pageManager.DrawUI(this);

            Drawing._spriteBatch.End();

        }
    }
}

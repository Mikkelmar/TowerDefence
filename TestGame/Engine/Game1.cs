using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using TestGame.Graphics;
using TestGame.Managers;
using TestGame.Pages;
using TiledSharp;

namespace TestGame
{
    public class Game1 : Game
    {

        //private TiledMap map;
        //private TiledMapRenderer mapRender;
        public TmxMap Map;

        // page
        public PageManager pageManager { get; private set; } = new PageManager();
        public PageGame pageGame;

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
        }

        protected override void LoadContent()
        {

            // TODO: use this.Content to load your game content here
            Textures.Load(this);
            Map = new TmxMap("Content/Island.tmx");
            pageGame = new PageGame();
        }

        protected override void Update(GameTime gameTime)
        {
            //Window.Title = Drawing.fps.ToString();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // update drawing
            Drawing.Update(gameTime, this);

            // TODO: Add your update logic here
            pageManager.Update(gameTime, this);

            

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {            
            pageManager.Draw(this);

            base.Draw(gameTime);
        }
    }
}

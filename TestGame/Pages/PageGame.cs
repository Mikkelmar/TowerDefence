using Microsoft.Xna.Framework;
using MonoGame.Extended;
using System;
using TestGame.Containers.Items;
using TestGame.Huds;
using TestGame.Managers;
using TestGame.Objects;
using TestGame.Scenes;

namespace TestGame.Pages
{
    public class PageGame : Page
    {
        
        public Player player = new Player(328, 398);
        public BuildHandler buildHandler;
        public Camera cam = new Camera(new Vector2(0, 0));
        public OrthographicCamera _camera;

        public SceneManager sceneManager { get; } = new SceneManager();
        public HudManager hudManager { get; } = new HudManager();
        public MouseManager mouseManager { get; } = new MouseManager();
        public KeyBoardManager keyBoardManager { get; } = new KeyBoardManager();
        public Player GetPlayer() { return player; }
        public PageGame() : base(PageID.game) { }


        public override void Init(Game1 g)
        {
            //Managers
            buildHandler = new BuildHandler(g);

            //init scenes
            sceneManager.Add(new World1(g), g);
            sceneManager.Add(new HomeScene(g), g);
            sceneManager.Set(0);

            //init craftin
            CraftingRecepies.Init(g);  

            //buildHandler = new BuildHandler(objectManager, sceneManager, g);

            hudManager.Add(new PlayerHud(player));

            player.inventory.AddToSlot(new Bow(), 6);
            player.inventory.AddToSlot(new IronArrow(80), 12);
        }

        public override void Update(GameTime gt, Game1 g)
        {
            mouseManager.Update(gt, g);
            keyBoardManager.Update(gt, g);
            sceneManager.Update(gt, g);
            cam.Update(player.GetPosCenter(), g);
        }
        public override void Draw(Game1 g)
        {
            
            sceneManager.Draw(g);
            buildHandler.Draw(g);

        }
        public override void DrawUI(Game1 g)
        {
            hudManager.Draw(g);
        }
        public ObjectManager getObjectManager()
        {
            return sceneManager.GetScene().objectManager;
        }
    }
}

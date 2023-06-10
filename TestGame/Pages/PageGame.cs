using Microsoft.Xna.Framework;
using MonoGame.Extended;
using System;
using TestGame.Huds;
using TestGame.Managers;
using TestGame.Objects;
using TestGame.Objects.Monsters;
using TestGame.Scenes;

namespace TestGame.Pages
{
    public class PageGame : Page
    {
        public Camera cam = new Camera(new Vector2(0, 0));
        public OrthographicCamera _camera;
        public Player player = new Player();
        public bool gamePaused = false;
        public SceneManager sceneManager { get; } = new SceneManager();
        public MonsterHandler monsterHandler = new MonsterHandler();
        public KeyBoardManager keyBoardManager { get; } = new KeyBoardManager();
        public PageGame() : base(PageID.game) { }


        public override void Init(Game1 g)
        {

            //init scenes
            sceneManager.Add(new World1(g), g);
            sceneManager.Add(new World2(g), g);
            sceneManager.Add(new World3(g), g);
            sceneManager.Add(new World4(g), g);
            sceneManager.Add(new World0(g), g);
            sceneManager.Add(new World6(g), g);
            sceneManager.Add(new World7(g), g);
            sceneManager.Add(new CaveWorld2(g), g);
            
            sceneManager.gotoScene(g, 0);
      
        }

        public override void Update(GameTime gt, Game1 g)
        {
            mouseManager.Update(gt, g);
            keyBoardManager.Update(gt, g);
            if (!gamePaused)
            {
                sceneManager.Update(gt, g);
            }
            
            //cam.Update(player.GetPosCenter(), g);
        }
        public override void Draw(Game1 g)
        {
            
            sceneManager.Draw(g);

        }
        public override void DrawUI(Game1 g)
        {
            hudManager.Draw(g);
        }
        public ObjectManager getObjectManager()
        {
            return sceneManager.GetScene().objectManager;
        }
        public HudManager getHudManager()
        {
            return sceneManager.GetScene().hudManager;
        }

        public override void Load(Game1 g)
        {
        }
    }
}

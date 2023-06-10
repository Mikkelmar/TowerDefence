using Microsoft.Xna.Framework;
using MonoGame.Extended;
using System;
using TestGame.Graphics;
using TestGame.Huds;
using TestGame.Huds.levelMenu;
using TestGame.Managers;
using TestGame.Objects;
using TestGame.Scenes;

namespace TestGame.Pages
{
    public class LevelMap : Page
    {
        public Camera cam = new Camera(new Vector2(0, 0));
        public OrthographicCamera _camera;
        public PlayerData playerData = new PlayerData();

        public KeyBoardManager keyBoardManager { get; } = new KeyBoardManager();
        public LevelMap() : base(PageID.map) { }
        protected Sprite background = new Sprite(Textures.levelmap);

        public override void Init(Game1 g)
        {
        }
        public override void Load(Game1 g)
        {
            hudManager.Clear(g);

            hudManager.Add(new UpgradesButton(40, 15), g);
            hudManager.Add(new UpgradeHeroButton(40, 65), g);
            hudManager.Add(new MapTravel(219, 154, 0, new Sprite(Textures.point)), g);
            hudManager.Add(new MapTravel(245, 239, 4, new Sprite(Textures.point), 0), g);
            hudManager.Add(new MapTravel(219, 339, 2, new Sprite(Textures.point), 4), g);
            hudManager.Add(new MapTravel(282, 490, 3, new Sprite(Textures.point), 2), g);
            hudManager.Add(new MapTravel(482, 490, 5, new Sprite(Textures.point), 3), g);
            hudManager.Add(new MapTravel(482, 350, 6, new Sprite(Textures.point), 5), g);
            hudManager.Add(new MapTravel(642, 370, 7, new Sprite(Textures.point), 6), g);
        }

        public override void Update(GameTime gt, Game1 g)
        {
            mouseManager.Update(gt, g);
            keyBoardManager.Update(gt, g);
            playerData.Update(gt, g);
        }
        public override void Draw(Game1 g)
        {
            hudManager.Draw(g);
            background.Draw(0, 0, Drawing.WINDOW_WIDTH, Drawing.WINDOW_HEIGHT, layerDepth: 0.9f);

        }
        public override void DrawUI(Game1 g)
        {
            hudManager.Draw(g);
        }
    }
}

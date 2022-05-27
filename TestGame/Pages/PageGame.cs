using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Renderers;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Containers.Items;
using TestGame.Graphics;
using TestGame.Huds;
using TestGame.Managers;
using TestGame.Objects;
using TestGame.Objects.Entities;
using TestGame.Objects.Entities.Creatures;
using TestGame.Objects.Entities.Structures;
using TestGame.Scenes;
using TiledSharp;

namespace TestGame.Pages
{
    public class PageGame : Page
    {
        
        public Player player = new Player(128, 198);
        public BuildHandler buildHandler;
        public Camera cam = new Camera(new Vector2(0, 0));
        public SceneManager sceneManager { get; } = new SceneManager();
        public HudManager hudManager { get; } = new HudManager();

        public Player GetPlayer() { return player; }
        public PageGame() : base(PageID.game) { }
        

        public override void Init(Game1 g)
        {

            //init scenes
            sceneManager.Add(new World1(g), g);
            sceneManager.Set(0);


            objectManager.Add(new Block(128, 128), g);
            objectManager.Add(new Tree(428, 128), g);
            objectManager.Add(new ItemEntity(528, 128, new Wood()), g);
            objectManager.Add(new ItemEntity(568, 128, new Stone()), g);
            objectManager.Add(new ItemEntity(608, 128, new Apple()), g);
            Wood wood1 = new Wood();
            wood1.addAmmount(5);
            objectManager.Add(new ItemEntity(828, 128, wood1), g);
            objectManager.Add(new Zombie(228, 228, 16*4, 16*4), g);
            objectManager.Add(player, g);

            buildHandler = new BuildHandler(objectManager, sceneManager, g);

            hudManager.Add(new InventoryHud(player));
        }

        public override void Update(GameTime gt, Game1 g)
        {
            objectManager.Update(gt, g);
            //sceneManager.Update(gt, g);
            cam.Update(player.GetPosCenter(), g);
        }
        public override void Draw(Game1 g)
        {
            g.GraphicsDevice.Clear(Color.Green);
            
            Drawing._spriteBatch.Begin(SpriteSortMode.BackToFront, null, SamplerState.PointClamp, transformMatrix: cam.transform);
            
            objectManager.Draw(g);
            sceneManager.Draw(g);
            hudManager.Draw(g);

            Drawing._spriteBatch.End();

        }
    }
}

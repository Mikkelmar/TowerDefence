using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Renderers;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Containers;
using TestGame.Containers.Items;
using TestGame.Containers.Items.ItemList;
using TestGame.Containers.Items.ItemTypes.ItemList;
using TestGame.Graphics;
using TestGame.Huds;
using TestGame.Managers;
using TestGame.Objects;
using TestGame.Objects.Entities;
using TestGame.Objects.Entities.Buildings;
using TestGame.Objects.Entities.Creatures;
using TestGame.Objects.Entities.Structures;
using TestGame.Scenes;

namespace TestGame.Pages
{
    public class PageGame : Page
    {
        
        public Player player = new Player(128, 198);
        public BuildHandler buildHandler;
        public Camera cam = new Camera(new Vector2(0, 0));
        public SceneManager sceneManager { get; } = new SceneManager();
        public HudManager hudManager { get; } = new HudManager();
        public MouseManager mouseManager { get; } = new MouseManager();
        public KeyBoardManager keyBoardManager { get; } = new KeyBoardManager();

        public Player GetPlayer() { return player; }
        public PageGame() : base(PageID.game) { }


        public override void Init(Game1 g)
        {

            //init scenes
            sceneManager.Add(new World1(g), g);
            sceneManager.Set(0);

            //init craftin
            CraftingRecepies.Init(g);
            //init objects
            objectManager.Add(new Block(128, 128), g);
            objectManager.Add(new Tree(428, 128), g);
            objectManager.Add(new ItemEntity(528, 128, new Wood()), g);
            objectManager.Add(new ItemEntity(568, 128, new Stone()), g);
            objectManager.Add(new ItemEntity(608, 128, new Apple()), g);
            objectManager.Add(new CraftingTable(608, 628), g);
            objectManager.Add(new Furnace(208, 328), g);
            objectManager.Add(new Furnace(108, 328), g);
            objectManager.Add(new Chest(408, 798, new SpecializedSlotContainer(5, Item.ItemType.Food, 1, 5)), g);
            objectManager.Add(new Chest(608, 798), g);
            Chest largeChest = new Chest(698, 798, 16, 4, 4);
            ItemContainer ic = new StackContainer(new List<Item>{new Wood(40), new Stone(8), new IronArrow(64), new MultiBow(), new IronSword() });
            largeChest.container.Add(ic);
            objectManager.Add(largeChest, g);
            Wood wood1 = new Wood();
            wood1.addAmmount(5);
            objectManager.Add(new ItemEntity(828, 128, wood1), g);
            objectManager.Add(new Zombie(228, 228), g);
            objectManager.Add(new ZombieArcher(728, 128), g);
            objectManager.Add(player, g);

            buildHandler = new BuildHandler(objectManager, sceneManager, g);

            hudManager.Add(new PlayerHud(player));

            player.inventory.AddToSlot(new Bow(), 6);
            player.inventory.AddToSlot(new Bow(), 12);
        }

        public override void Update(GameTime gt, Game1 g)
        {
            mouseManager.Update(gt, g);
            keyBoardManager.Update(gt, g);
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

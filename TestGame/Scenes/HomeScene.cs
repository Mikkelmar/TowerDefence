using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TestGame.Containers;
using TestGame.Containers.Items;
using TestGame.Managers;
using TestGame.Objects.Entities.Buildings;
using TestGame.Objects.Entities.Creatures;
using TestGame.Objects.Entities.Structures;
using TiledSharp;

namespace TestGame.Scenes
{
    public class HomeScene : Scene
    {
        public HomeScene(Game1 g) : base(g)
        {
            fileName = "maps/Home";
            LevelZoom = 4f;
        }

        public override void Close(Game1 g)
        {
        }

        public override void Init(Game1 g)
        {
            base.Init(g);
            objectManager.Add(g.pageGame.player);
            objectManager.Add(new Door(128, 50, 0, new Microsoft.Xna.Framework.Vector2(448, 330)), g);

            ItemContainer icArmour = new StackContainer(new List<Item> { new LeatherBoots(), new BronzeChestPlate(), new IronHelmet() });
            Chest mediumChest = new Chest(170, 80);
            mediumChest.container.Add(icArmour);
            objectManager.Add(mediumChest, g);
        }
        public override void Load(Game1 g)
        {
            //load scene
            base.Load(g);
        }
    }
}

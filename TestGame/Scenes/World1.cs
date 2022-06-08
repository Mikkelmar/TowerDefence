using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TestGame.Containers;
using TestGame.Containers.Items;
using TestGame.Containers.Items.ItemList;
using TestGame.Containers.Items.ItemTypes.ItemList;
using TestGame.Managers;
using TestGame.Objects.Entities;
using TestGame.Objects.Entities.Buildings;
using TestGame.Objects.Entities.Creatures;
using TestGame.Objects.Entities.Structures;
using TiledSharp;

namespace TestGame.Scenes
{
    public class World1 : Scene
    {
        public World1(Game1 g) : base(g)
        {
            fileName = "maps/Island";
        }

        public override void Init(Game1 g)
        {
            base.Init(g);
            //init objects
            objectManager.Add(new Door(448, 290, 1, new Microsoft.Xna.Framework.Vector2(128, 95)), g);

            objectManager.Add(new Tree(428 , 328 / 4), g);
            objectManager.Add(new Tree(200, 628 / 4), g);
            objectManager.Add(new Tree(232, 618 / 4), g);
            objectManager.Add(new Tree(264, 678 / 4), g);
            objectManager.Add(new Tree(296, 728 / 4), g);

            objectManager.Add(new CopperOre(1258 / 4, 1128 / 4), g);
            objectManager.Add(new CopperOre(1458 / 4, 1128 / 4), g);
            objectManager.Add(new CopperOre(300 / 4, 1000 / 4), g);
            objectManager.Add(new CopperOre(900 / 4, 1040 / 4), g);
            objectManager.Add(new CopperOre(270 / 4, 900 / 4), g);

            objectManager.Add(new TinOre(1900 / 4, 2840 / 4), g);
            objectManager.Add(new TinOre(1270 / 4, 580), g);
            objectManager.Add(new TinOre(1470 / 4, 500), g);

            objectManager.Add(new ItemEntity(328, 328, new Wood()), g);
            objectManager.Add(new ItemEntity(368, 328, new Stone()), g);
            objectManager.Add(new ItemEntity(308, 328, new Apple()), g);

            objectManager.Add(new CraftingTable(164, 228), g);
            objectManager.Add(new Furnace(100, 228), g);
            objectManager.Add(new Furnace(132, 228), g);

            //Chests
            objectManager.Add(new Chest(100, 300, new SpecializedSlotContainer(5, Item.ItemType.Food, 1, 5)), g);
            Chest largeChest = new Chest(164, 300, 16, 4, 4);
            ItemContainer ic = new StackContainer(new List<Item> { new Wood(40), new Stone(8), new IronArrow(64), new MultiBow(), new IronSword(), new IronAxe(), new TwoHandSword(), new IronPickaxe(), new FineBow(), new FlintSpear() });
            largeChest.container.Add(ic);
            objectManager.Add(largeChest, g);

            objectManager.Add(g.pageGame.player, g);
        }
        public override void Load(Game1 g)
        {
            //load scene
            base.Load(g);
        }
        public override void Close(Game1 g)
        {
        }
    }
}

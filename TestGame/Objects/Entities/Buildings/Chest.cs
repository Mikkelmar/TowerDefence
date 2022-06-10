using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Containers;
using TestGame.Containers.Items;
using TestGame.Graphics;
using TestGame.Huds.ActiveHuds;

namespace TestGame.Objects.Entities.Buildings
{
    public class Chest : Building
    {
        public SlotContainer container;
        public Chest(int x, int y, int capacity = 8, int Xrow = 4, int Yrow = 2) : base(x, y, 32, 32, 5, new Sprite(Textures.spriteSheet_1, new Rectangle(16*29, 16 * 14, 32, 32)))
        {
            this.solid = true;
            container = new SlotContainer(capacity, Xrow, Yrow);
            //hitbox = new Rectangle(16, 16, 16, 16);
        }
        public Chest(int x, int y, SlotContainer container) : base(x, y, 32, 32, 5, new Sprite(Textures.spriteSheet_1, new Rectangle(16 * 29, 16 * 14, 32, 32)))
        {
            this.solid = true;
            this.container = container;
            //hitbox = new Rectangle(16, 16, 16, 16);
        }
        public override void Update(GameTime gt, Game1 g)
        {
        }
        protected override void Break(Game1 g)
        {
            int x = (int)GetPosCenter().X;
            int y = (int)GetPosCenter().Y;
            foreach (Item i in container.GetItems())
            {
                g.pageGame.getObjectManager().Add(new ItemEntity(x, y, i), g);
            }
            g.pageGame.getObjectManager().Add(new ItemEntity(x, y, new Wood()), g);
            base.Break(g);
        }

        protected override void Open(Game1 g)
        {
            g.pageGame.hudManager.Open(new ChestUI(g, container), g);
        }
    }
}

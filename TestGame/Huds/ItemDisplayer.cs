using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TestGame.Containers;
using TestGame.Containers.Items;
using TestGame.Graphics;
using TestGame.Managers;

namespace TestGame.Huds
{
    class ItemDisplayer : Hud, Clickable, RightClickable, HoverLisner
    {
        private SlotContainer slotContainer;
        private int widthAddmount, heightAddmount;
        private Sprite sprite;
        private int size;
        private int space = 12;
        private List<ItemSlot> slots = new List<ItemSlot>();
        public ItemDisplayer(SlotContainer slotContainer, int widthAddmount, int heightAddmount, float xpos, float ypos, Game1 g, int size = 64)
        {
            this.slotContainer = slotContainer;
            this.widthAddmount = widthAddmount;
            this.heightAddmount = heightAddmount;
            X = xpos;
            Y = ypos;
            this.size = size;
            this.sprite = new Sprite(Textures.itemContainer);
            Init(g);
            
        }
        public void Clicked(float x, float y, Game1 g)
        {
            foreach(ItemSlot itemSlot in slots)
            {
                itemSlot.Clicked(x, y, g);
            }
        }

        public override void Draw(Game1 g)
        {
            sprite.Draw(
                GetPos(g),
                widthAddmount * size + space * 2,
                heightAddmount * size + space * 2,
                depth*0.9f
               );
            foreach (ItemSlot itemSlot in slots)
            {
                itemSlot.Draw(g);
            }
        }

        public void RightClicked(float x, float y, Game1 g)
        {
            foreach (ItemSlot itemSlot in slots)
            {
                itemSlot.RightClicked(x, y, g);
            }
        }

        private void Init(Game1 g)
        {
            Vector2 itemPos = new Vector2(this.X + 12, this.Y + 12);
            float startXpos = itemPos.X;
            for (int y = 0; y < heightAddmount; y++)
            {
                for (int i = 0; i < widthAddmount; i++)
                {
                    slots.Add(new ItemSlot(i + (y * widthAddmount), slotContainer, itemPos, depth*0.8f));
                    itemPos.X += 64;
                }
                itemPos.X = startXpos;
                itemPos.Y += 64;
            }
            g.pageGame.mouseManager.Add(this, true);
            g.pageGame.mouseManager.AddRight(this, true);
            g.pageGame.mouseManager.AddHover(this, true);
        }
        public override void Destroy(Game1 g)
        {
            base.Destroy(g);
            g.pageGame.mouseManager.Remove(this);
            g.pageGame.mouseManager.RemoveRight(this);
            g.pageGame.mouseManager.RemoveHover(this);
        }

        public void Hover(float x, float y, Game1 g)
        {
            foreach (ItemSlot itemSlot in slots)
            {
                itemSlot.Hover(x, y, g);
            }
        }
    }
}

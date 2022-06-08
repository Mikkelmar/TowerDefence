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
    class ArmourDisplayer : Hud, Clickable, RightClickable, HoverLisner
    {
        private List<SpecializedSlotContainer> Wearing;
        private int size;
        private List<ItemSlot> slots = new List<ItemSlot>();
        public ArmourDisplayer(List<SpecializedSlotContainer> Wearing, Vector2 pos, Game1 g, int size = 64)
        {
            this.Wearing = Wearing;
            X = pos.X;
            Y = pos.Y;
            this.size = size;
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
            Vector2 itemPos = new Vector2(X, Y);
            int index = 0;
            foreach(SpecializedSlotContainer slc in Wearing)
            {
                slots.Add(new ItemSlot(0, slc, itemPos, depth * 0.8f, sprite: new Sprite(Textures.armourSheet, 
                    new Rectangle(0, 0 + (16 * index), 16, 17)
                    )
                   ));
                index++;
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

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Containers;
using TestGame.Containers.Items;
using TestGame.Graphics;
using TestGame.Managers;

namespace TestGame.Huds
{
    class ItemSlot : Hud, Clickable, RightClickable, HoverLisner
    {

        private SlotContainer inContainer;
        private int slotID;
        private Sprite slot;
        private bool beingHovred = false;
        private float mouseX, mouseY;
        public ItemSlot(int slotID, SlotContainer inContainer)
        {
            this.slotID = slotID;
            this.inContainer = inContainer;
            this.slot = new Sprite(Textures.slot);
        }
        public ItemSlot(int slotID, SlotContainer inContainer, Vector2 pos, float depth, int size = 64) : this(slotID, inContainer)
        {
            X = pos.X;
            Y = pos.Y;
            Width = size;
            Height = size;
            this.depth = depth;
        }
        
        public void Clicked(float x, float y, Game1 g)
        {
            if(new Rectangle((int)X, (int)Y, Width, Height).Contains(new Point((int)x, (int)y)))
            {
                Item holding = g.pageGame.hudManager.Holding;
                Item itemAtSlot = inContainer.GetItemAtSlot(slotID);

                if (itemAtSlot == null && holding != null)
                {
                    if (inContainer.CanAdd(holding))
                    {
                        inContainer.AddToSlot(holding, slotID);
                        g.pageGame.hudManager.Holding = null;
                    }
                }
                else if (itemAtSlot == null || itemAtSlot.Equals(holding)){
                    {
                        if (inContainer.CanAdd(holding))
                        {
                            inContainer.AddToSlot(holding, slotID);
                            g.pageGame.hudManager.Holding = null;
                        }
                    }
                }
                else if (itemAtSlot != null || !itemAtSlot.Equals(holding))
                {
                    if(holding == null || inContainer.CanAdd(holding))
                    {
                        Item swappedItem = inContainer.RemoveItemAtSlot(slotID);
                        inContainer.AddToSlot(holding, slotID);
                        g.pageGame.hudManager.Holding = swappedItem;
                    }
                    
                }
            }
        }

        public override void Draw(Game1 g)
        {
            Vector2 CurrentPos = new Vector2((int)X + g.pageGame.cam.position.X, (int)Y + g.pageGame.cam.position.Y);
            slot.Draw(CurrentPos, (depth * 0.6f), 4);
            if(inContainer.GetItemAtSlot(slotID) != null)
            {
                inContainer.GetItemAtSlot(slotID).Draw(CurrentPos, 64, (depth * 0.5f));
                if (beingHovred) {
                    //Item.DrawItemInfo(inContainer.GetItemAtSlot(slotID), X, Y);
                    //Drawing.DrawText(inContainer.GetItemAtSlot(slotID).ToString(), CurrentPos.X, CurrentPos.Y, 0);
                    ItemHoverInfo.DrawItemInfo(inContainer.GetItemAtSlot(slotID), CurrentPos.X+Width/2, CurrentPos.Y+Height, depth*0.4f);
                }
            }
        }

        public void Hover(float x, float y, Game1 g)
        {
            if (new Rectangle((int)X, (int)Y, Width, Height).Contains(new Point((int)x, (int)y)))
            {
                beingHovred = true;
                mouseX = x;
                mouseY = y;
            }
            else{
                beingHovred = false;
            }
        }

        public void RightClicked(float x, float y, Game1 g)
        {
            if (new Rectangle((int)X, (int)Y, Width, Height).Contains(new Point((int)x, (int)y)))
            {
                Item holding = g.pageGame.hudManager.Holding;
                Item itemAtSlot = inContainer.GetItemAtSlot(slotID);

                if ((itemAtSlot == null || itemAtSlot.Equals(holding)) && holding != null)
                {
                    if (inContainer.CanAdd(holding)) { 
                        Item clonedItem = holding.Clone();
                        holding.addAmmount(-1);
                        clonedItem.Ammount = 1;
                        inContainer.AddToSlot(clonedItem, slotID);
                        if(holding.Ammount == 0)
                        {
                            g.pageGame.hudManager.Holding = null;
                        }
                    }

                }
                else if (holding == null && itemAtSlot != null)
                {
                    Item clonedItem = itemAtSlot.Clone();
                    if(itemAtSlot.Ammount == 1)
                    {
                        inContainer.RemoveItemAtSlot(slotID);
                        g.pageGame.hudManager.Holding = clonedItem;
                    }
                    else
                    {
                        clonedItem.Ammount = (int)Math.Round((float)((float)clonedItem.Ammount / 2));
                        itemAtSlot.Ammount = (int)Math.Floor((float)((float)itemAtSlot.Ammount / 2));
                        g.pageGame.hudManager.Holding = clonedItem;
                    }
                    
                }
                else if (holding != null && itemAtSlot != null && holding.Equals(itemAtSlot))
                {
                    if (inContainer.CanAdd(holding))
                    {
                        Item swappedItem = inContainer.RemoveItemAtSlot(slotID);
                        inContainer.AddToSlot(holding, slotID);
                        g.pageGame.hudManager.Holding = swappedItem;
                    }
                        
                }
            }
        }
    }
}

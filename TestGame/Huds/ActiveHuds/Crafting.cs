﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Containers;
using TestGame.Containers.Items;
using TestGame.Managers;

namespace TestGame.Huds.ActiveHuds
{
    public class Crafting : ActiveUI
    {
        private ItemDisplayer itemDisplayer;
        public Crafting(Game1 g)
        {
            CraftingList craftingList = new CraftingList();
            
            Add(craftingList);
            Add(new ArmourDisplayer(g.pageGame.player.Wearing, new Vector2(craftingList.X + 9 * 4, craftingList.Y + 15 * 4), g));
            int index = 0;
            foreach(Recepie r in CraftingRecepies.crafting1)
            {
                CraftingSlot cs = new CraftingSlot(r, craftingList.X + 660, craftingList.Y + 52 * index);
                g.pageGame.mouseManager.Add(cs, true);
                Add(cs);
                index++;
            }

            itemDisplayer = new ItemDisplayer(g.pageGame.player.inventory, 8, 5, 310, 140, g);
            Add(itemDisplayer);
        }
    }
}

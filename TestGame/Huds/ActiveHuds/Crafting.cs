using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Containers;
using TestGame.Containers.Items;
using TestGame.Managers;

namespace TestGame.Huds.ActiveHuds
{
    public class Crafting : ActiveUI, KeyboardLisner
    {
        public Crafting(Game1 g)
        {
            CraftingList craftingList = new CraftingList();
            Add(craftingList);

            int index = 0;
            foreach(Recepie r in CraftingRecepies.crafting1)
            {
                CraftingSlot cs = new CraftingSlot(r, craftingList.X + 660, craftingList.Y + 52 * index);
                g.pageGame.mouseManager.Add(cs, true);
                Add(cs);
                index++;
            }
            g.pageGame.keyBoardManager.Add(this);
        }

        public void KeyPressed(KeyboardState kb, Game1 g)
        {
            if (kb.IsKeyDown(Keys.E))
            {
                g.pageGame.hudManager.Close(g);
                g.pageGame.keyBoardManager.Remove(this);
            }
        }
    }
}

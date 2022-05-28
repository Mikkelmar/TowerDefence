using System;
using System.Collections.Generic;
using System.Text;

namespace TestGame.Containers.Items
{
    public static class CraftingRecepies
    {
        public static List<Recepie> crafting1 = new List<Recepie>();
        public static void Init(Game1 g)
        {
            ItemContainer ic = new ItemContainer(new List<Item>(){
                new Wood(2), new Apple()});
            crafting1.Add(new Recepie(ic, new Stone(4)));

            ic = new ItemContainer(new List<Item>(){
                new Stone()});
            crafting1.Add(new Recepie(ic, new Wood(3)));
        }
    }
}

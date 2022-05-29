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
            ItemContainer ic = new StackContainer(new List<Item>(){
                new Wood(), new Iron(4)});
            crafting1.Add(new Recepie(ic, new IronHelmet()));

            ic = new StackContainer(new List<Item>(){
                new Stone()});
            crafting1.Add(new Recepie(ic, new Wood(3)));

            ic = new StackContainer(new List<Item>(){
                new Wood(3)});
            crafting1.Add(new Recepie(ic, new Bow()));

            ic = new StackContainer(new List<Item>(){
                new Apple()});
            crafting1.Add(new Recepie(ic, new Iron(5)));
        }
    }
}

using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Containers.Items;

namespace TestGame.Containers
{
    public class Recepie
    {
        public ItemContainer required;
        public Item creates;
        public bool know = true;

        public Recepie(ItemContainer required, Item creates, bool know = true)
        {
            this.required = required;
            this.creates = creates;
            this.know = know;
        }
        public bool CanCreate(ItemContainer inevntory)
        {
            return inevntory.Contain(required);
        }
        public void Create(ItemContainer inevntory)
        {
            inevntory.Take(required);
            Item item = (Item)Activator.CreateInstance(creates.GetType(), creates.Ammount);
            inevntory.Add(item); 
        }
    }
}

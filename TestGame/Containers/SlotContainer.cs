using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Containers.Items;

namespace TestGame.Containers
{
    /**
     *  TODO Finish this
     *  skal holde styr på hvilken "slot" gjenstandene beffiner seg på
     */
    public class SlotContainer : ItemContainer
    {
        public SlotContainer(int capacity)
        {
            this.Capacity = capacity;
        }

        public override void Add(Item item)
        {
    
        }
        public void AddToSlot()
        {

        }
    }
}

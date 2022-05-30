using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Containers.Items;

namespace TestGame.Containers
{
    public class SpecializedSlotContainer : SlotContainer
    {
        private Item.ItemType allowedType;
        public SpecializedSlotContainer(int capcity, Item.ItemType allowedType, int xRow, int yRow) : base(capcity, xRow, yRow){
            this.allowedType = allowedType;
        }

        public override bool CanAdd(Item item)
        {
            if(item == null || item.itemType != allowedType)
            {
                return false;
            }
            return base.CanAdd(item);
        }
    }
}

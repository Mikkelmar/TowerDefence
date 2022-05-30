using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;

namespace TestGame.Containers.Items.ItemTypes
{
    public abstract class MeltAble : Item
    {
        protected Item meltsTo;
        public MeltAble(Sprite sprite, string name, Item meltsTo, int ammount = 1)
           : base(sprite, name, ammount)
        {
            itemType = ItemType.Meltable;
            this.meltsTo = meltsTo;
        }
        public Item GetMeltsTo()
        {
            return meltsTo.Clone();
        }
    }
}

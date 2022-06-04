using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;

namespace TestGame.Containers.Items.ItemTypes
{
    public class Arrow : Item
    {
        public int Damage;
        public readonly bool DropAfterMiss = true;
        public Arrow(Sprite sprite, string name, int Damage, int ammount = 1)
           : base(sprite, name, ammount)
        {
            itemType = ItemType.Arrow;
            this.Damage = Damage;
            Description = "Damage: " + Damage;
        }
    }
}

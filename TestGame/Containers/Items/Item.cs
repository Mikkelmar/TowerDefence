using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;

namespace TestGame.Containers.Items
{
    public class Item
    {
        public Sprite Sprite;
        public enum ItemType { Weapon, Food, Bulding, Misc, Armour };
        public string Name { get; }
        public ItemType itemType;
        public int Ammount { get; set; }

        public Item(Sprite texture, String name)
        {
            this.Sprite = texture;
            this.Name = name;
            this.Ammount = 1;
            this.itemType = ItemType.Misc;
        }
        public void addAmmount(int ammount)
        {
            this.Ammount += ammount;
        }
    }
}

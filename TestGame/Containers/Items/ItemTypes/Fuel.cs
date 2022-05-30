using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Containers.Items;
using TestGame.Graphics;

namespace TestGame.Containers.ItemTypes
{
    public abstract class Fuel : Item
    {
        private TimeSpan fuelTime;
        public Fuel(Sprite sprite, string name, TimeSpan fuelTime, int ammount = 1)
           : base(sprite, name, ammount)
        {
            itemType = ItemType.Fuel;
            this.fuelTime = fuelTime;
        }
        public TimeSpan GetFuelTime() { return fuelTime; }
    }
}

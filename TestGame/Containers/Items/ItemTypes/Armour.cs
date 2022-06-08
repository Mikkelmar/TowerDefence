using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Containers.Items;
using TestGame.Graphics;
using TestGame.Objects.Entities.Creatures;

namespace TestGame.Containers.Items.ItemTypes
{
    public abstract class Armour : Item
    {
        public int Defencepoint;
        public Armour(Sprite sprite, string name, int Defencepoint = 0, int ammount = 1)
           : base(sprite, name, ammount)
        {
            this.Defencepoint = Defencepoint;
        }
        public override List<string> GetDescription()
        {
            List<string>  desctList = new List<string>();
            desctList.Add("+" + Defencepoint + " Armour");
            return desctList;
        }
        public virtual void Wearing(Creature creature, Game1 g)
        {

        }
    }
}

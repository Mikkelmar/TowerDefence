using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;
using TestGame.Managers;
using TestGame.Objects;

namespace TestGame.Containers.Items.ItemTypes
{
    public abstract class Food : Item, Useable
    {
        protected int foodAmmount;
        public Food(Sprite sprite, string name, int foodAmmount, int ammount = 1)
           : base(sprite, name, ammount)
        {
            itemType = ItemType.Food;
            this.foodAmmount = foodAmmount;
        }
        public override List<string> GetDescription()
        {
            List<string> newList = new List<string>();
            newList.Add("Restore: " + foodAmmount);
            return newList;
        }
        protected virtual bool CanEat(Game1 g)
        {
            return g.pageGame.player.Health < g.pageGame.player.BaseHealth;
        }

        public virtual void Eat(Game1 g)
        {
            g.pageGame.player.Health += foodAmmount;
            g.pageGame.player.inventory.RemoveAmmountAtSlot(g.pageGame.player.ActiveSlot, 1);
        }


        public void Update(Entity user, GameTime gt, Game1 g)
        {
        }

        public void Activate(Entity user, float x, float y, Game1 g, bool leftClick)
        {
            if(CanUse(user, g)){
                Eat(g);
            }
        }

        public bool IsUsing()
        {
            return false;
        }

        public bool UseableOnClick(bool isLeftClick = true)
        {
            return !isLeftClick;
        }

        public bool CanUse(Entity user, Game1 g)
        {
            return CanEat(g) && g.pageGame.hudManager.activeUI == null;
        }
    }
}

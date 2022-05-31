using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TestGame.Graphics;
using TestGame.Managers;
using TestGame.Objects;
using TestGame.Objects.Entities;

namespace TestGame.Containers.Items.ItemTypes
{
    public abstract class Weapon : Item, Useable
    {
        public int Damage;
        private ItemSwing itemSwing;
        public float Speed = 300;
        public Weapon(Sprite sprite, string name, int Damage, int ammount = 1)
           : base(sprite, name, ammount)
        {
            itemType = ItemType.Weapon;
            this.Damage = Damage;
        }

        protected virtual void Attack(float x, float y, Game1 g)
        {

        }

        public void Use(Entity user, float x, float y, GameTime gt, Game1 g, bool leftClick)
        {
        }
        public virtual void Activate(Entity user, float x, float y, Game1 g, bool leftClick)
        {
            if (CanUse(user, g))
            {
                Debug.WriteLine(this);
                itemSwing = new ItemSwing(user, 64, 64, this);
                g.pageGame.objectManager.Add(itemSwing, g);
            }
        }
        public void DoneUsing()
        {
            itemSwing = null;
        }

        public bool IsUsing()
        {
            return itemSwing == null;
        }

        public virtual bool CanUse(Entity user, Game1 g)
        {
            return IsUsing() && (!(user is Player) || g.pageGame.hudManager.activeUI == null);
        }

        public bool UseableOnClick(bool isLeftClick = true)
        {
            return isLeftClick;
        }
    }
}

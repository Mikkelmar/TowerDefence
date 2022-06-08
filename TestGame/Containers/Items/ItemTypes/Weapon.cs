using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TestGame.Graphics;
using TestGame.Managers;
using TestGame.Objects;
using TestGame.Objects.Entities;
using TestGame.Objects.Entities.Creatures;
using TestGame.Objects.StatusEffects;

namespace TestGame.Containers.Items.ItemTypes
{
    public abstract class Weapon : Item, Useable
    {
        public int Damage;
        public int KnockBack;
        protected ItemHolding itemHolding;
        public float Speed;
        public TimeSpan WeaponSpeed = new TimeSpan(0, 0, 0, 0, 200); //the attack default lasts 500 millisecunds
        public Weapon(Sprite sprite, string name, int Damage, int ammount = 1, float Speed=90, int KnockBack = 30)
           : base(sprite, name, ammount)
        {
            itemType = ItemType.Weapon;
            this.Damage = Damage;
            this.Speed = Speed;
            this.KnockBack = KnockBack;
        }
        public override List<string> GetDescription()
        {
            List<string> newList = new List<string>();
            newList.Add("Damage: " + Damage);
            newList.Add("Speed: " + WeaponSpeed.Seconds + "." + (WeaponSpeed.Milliseconds / 100) + "s");
            newList.Add("Knockback: " + (KnockBack / 30 - KnockBack % 30));
            return newList;
        }
        protected virtual void Attack(float x, float y, Game1 g)
        {

        }

        public virtual void Update(Entity user, GameTime gt, Game1 g)
        {
        }
        public virtual void Activate(Entity user, float x, float y, Game1 g, bool leftClick)
        {
            if (CanUse(user, g))
            {
                itemHolding = new ItemSwing(user, 16, 16, this,
                    (float)((float)(-Math.Atan2(x-user.GetPosCenter().X, y-user.GetPosCenter().Y))-(Math.PI/3)));
                g.pageGame.getObjectManager().Add(itemHolding, g);
                if(user is Creature)
                {
                    ((Creature)user).AddStatusEffect(new Slow(0.2f, WeaponSpeed));
                }
            }
        }
        public void DoneUsing()
        {
            itemHolding = null;
        }

        public virtual bool IsUsing()
        {
            return itemHolding != null;
        }

        public virtual bool CanUse(Entity user, Game1 g)
        {
            return !IsUsing() && (!(user is Player) || g.pageGame.hudManager.activeUI == null);
        }

        public bool UseableOnClick(bool isLeftClick = true)
        {
            return isLeftClick;
        }
    }
}

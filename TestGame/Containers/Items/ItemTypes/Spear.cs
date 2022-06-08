using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TestGame.Graphics;
using TestGame.Objects;
using TestGame.Objects.Entities;
using TestGame.Objects.Entities.Creatures;
using TestGame.Objects.StatusEffects;

namespace TestGame.Containers.Items.ItemTypes
{
    public abstract class Spear : Weapon
    {
        public Spear(Sprite sprite, string name, int Damage, int ammount = 1, float Speed = 20, int KnockBack = 25)
           : base(sprite, name, Damage, ammount: ammount, Speed: Speed, KnockBack: KnockBack)
        {
        }

        public override void Activate(Entity user, float x, float y, Game1 g, bool leftClick)
        {
            if (CanUse(user, g))
            {
                itemHolding = new ItemPush(user, 16, 16, this,
                    (float)((float)(Math.Atan2(y - user.GetPosCenter().Y, x - user.GetPosCenter().X)) - (Math.PI) - (Math.PI / 4))
                    );
                g.pageGame.getObjectManager().Add(itemHolding, g);
                if (user is Creature)
                {
                    ((Creature)user).AddStatusEffect(new Slow(0.1f, WeaponSpeed));
                }
            }
        }
    }
}

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;
using TestGame.Objects.Monsters;
using TestGame.Objects.Particles;
using TestGame.Objects.StatusEffects;
using TestGame.Objects.Towers;

namespace TestGame.Objects.Projectile
{
    public class FireArrow : Projectile
    {
        public FireArrow(int x, int y, Monster target = null, Tower caster = null, float speed = 340f) : base(x, y, target, caster, 16)
        {
            sprite = new Sprite(Textures.fireArrow);
            Speed = speed;
            Damage = caster.damage;
            if(target != null)
            {
                rotation = (float)(Math.Atan2(target.Y - y, target.X - x) + (Math.PI / 4));
            }
        }
        protected override void hitTarget(Game1 g)
        {
            base.hitTarget(g);
            StatusEffect e = new Burning(1, TimeSpan.FromSeconds(3), TimeSpan.FromMilliseconds(250));
            if (Target.canBeAffactedBy(e.Name))
            {
                if (!Target.BeingEffectedBy(e.Name))
                {
                    g.pageGame.getObjectManager().Add(new BurningEffect(Target.GetPosCenter(), Target),g);
                }
                Target.GiveStatusEffect(e);
            }
            

        }
    }
}

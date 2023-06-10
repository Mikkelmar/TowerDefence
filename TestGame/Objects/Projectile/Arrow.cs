using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;
using TestGame.Objects.Monsters;
using TestGame.Objects.Towers;

namespace TestGame.Objects.Projectile
{
    public class Arrow : Projectile
    {
        public Arrow(int x, int y, Monster target = null, Tower caster = null, int damage = -1) : base(x, y, target, caster, 16)
        {
            sprite = new Sprite(Textures.arrow);
            Speed = 340f;
            if (damage != -1)
            {
                Damage = damage;
            }
            else
            {
                Damage = caster.damage;
            }

            origionVector = new Vector2(8, 8);
            if (target != null)
            {
                rotation = (float)(Math.Atan2(target.Y - y, target.X - x) + (Math.PI / 4));
            }
        }
      
    }
        
}

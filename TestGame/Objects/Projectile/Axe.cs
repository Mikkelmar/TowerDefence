using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;
using TestGame.Objects.Monsters;
using TestGame.Objects.Towers;

namespace TestGame.Objects.Projectile
{
    public class Axe : Projectile
    {
        public Axe(int x, int y, Monster target = null, Tower caster = null, int damage = -1) : base(x, y, target, caster, 20)
        {
            sprite = new Sprite(Textures.iconsSheet, new Rectangle(16 * 15, 16 * 1, 16, 16));
            Speed = 280f;
            if (damage != -1)
            {
                Damage = damage;
            }
            else
            {
                Damage = caster.damage;
            }
            origionVector = new Vector2(10, 10);
        }
        public override void Update(GameTime gt, Game1 g)
        {
            base.Update(gt, g);
            rotation += Drawing.delta * 16f;
        }

    }
        
}

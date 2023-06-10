using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;
using TestGame.Objects.Monsters;
using TestGame.Objects.Particles;
using TestGame.Objects.Towers;

namespace TestGame.Objects.Projectile
{
    public class OrbitBall : Projectile
    {
        private TimeSpan orbitTime;
        private List<Monster> hitTargets = new List<Monster>();
        public OrbitBall(int x, int y, Tower caster = null, int size=16) : base(x, y, null, caster, size)
        {
            sprite = new Sprite(Textures.mageball);
            Speed = 300f;
            Damage = caster.damage;
            depth = depth * 0.1f;
            damageType = Monster.Damagetype.Magic;
            orbitTime = new TimeSpan();
        }
        public override void Update(GameTime gt, Game1 g)
        {

            orbitTime += gt.ElapsedGameTime;
            Vector2 pos = Caster.GetPosCenter();
            X = (float)(pos.X + 64 * Math.Sin((orbitTime.TotalMilliseconds /1000 + orbitTime.TotalSeconds)*1.2));
            Y = (float)(pos.Y + 64 * Math.Cos((orbitTime.TotalMilliseconds /1000 + orbitTime.TotalSeconds) * 1.2));

            foreach (Monster m in g.pageGame.getObjectManager().GetMonsters())
            {
                if (!hitTargets.Contains(m) && m.Intersect(this))
                {
                    hitTargets.Add(m);
                    m.takeDamage(Damage, g, damageType);
                }
            }
            if (orbitTime.TotalSeconds > 4)
            {
                orbitTime.Subtract(TimeSpan.FromSeconds(4));
                //hitTargets.Clear();
            }
        }
    }
}

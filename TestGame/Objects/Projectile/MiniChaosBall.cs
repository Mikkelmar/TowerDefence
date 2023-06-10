using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;
using TestGame.Managers;
using TestGame.Objects.Monsters;
using TestGame.Objects.Particles;
using TestGame.Objects.Towers;

namespace TestGame.Objects.Projectile
{
    public class MiniChaosBall : SearchingProjectile
    {
        private TimeSpan fadeTime, vibeTime = new TimeSpan();
        private int DamageRadius = 40;
        private static Sound impactSound = new Sound(Sounds.miniImpact, 0.1f, SoundManager.types.Tower);
        private Vector2 origo;
        public MiniChaosBall(int x, int y, Monster target = null, Tower caster = null, int size=8) : base(x, y, target, caster, size)
        {
            sprite = new Sprite(Textures.miniChaosBall);
            Speed = 300f;
            Damage = caster.damage;
            fadeTime = new TimeSpan();
            depth = depth * 0.1f;
            damageType = Monster.Damagetype.Magic;
            origo = new Vector2(x, y);
            despawnTimer = TimeSpan.FromSeconds(5);
        }
        public override void Update(GameTime gt, Game1 g)
        {
            base.Update(gt, g);
            if(Target == null)
            {
                shakeAnimation(gt, g);
            }
            else
            {
                fadeTime += gt.ElapsedGameTime;
                if (fadeTime.Milliseconds > 30)
                {
                    FadingParticle afterImage = new FadingParticle(new Vector2(X, Y), new Sprite(Textures.chaosBall), TimeSpan.FromMilliseconds(200), size: (int)Width);
                    afterImage.Spawn(g);
                    fadeTime = new TimeSpan();
                }
            }
            
            
        }
        private void shakeAnimation(GameTime gt, Game1 g)
        {
            vibeTime += gt.ElapsedGameTime;
            if (vibeTime.TotalMilliseconds >= 80)
            {
                vibeTime = new TimeSpan();
                Random rnd = new Random();
                X = origo.X + rnd.Next(7) - 3;
                Y = origo.Y + rnd.Next(7) - 3;
            }
            fadeTime += gt.ElapsedGameTime;
            if (fadeTime.Milliseconds > 70)
            {
                FadingParticle afterImage = new FadingParticle(new Vector2(X, Y), new Sprite(Textures.chaosBall), TimeSpan.FromMilliseconds(100), size: (int)Width);
                afterImage.Spawn(g);
                fadeTime = new TimeSpan();
            }
        }
        protected override void hitTarget(Game1 g)
        {
            impactSound.play(g);
            ObjectManager om = g.pageGame.getObjectManager();
            foreach (Monster m in om.GetAllObjectsWith(p => p is Monster && (int)om.FromToDir(this, p).Length() <= DamageRadius))
            {
                m.takeDamage(
                    Math.Min(Damage, Math.Max((int)(Damage * ((DamageRadius * 3 / 2) - om.FromToDir(this, m).Length()) / DamageRadius), 1)), 
                    g,
                    damageType);
            }
            for (int i = 0; i < 5; i++)
            {
                Random rnd = new Random();
                om.Add(new Explotion(new Vector2(X + rnd.Next(DamageRadius / 2 ) - (DamageRadius / 4), Y + rnd.Next(DamageRadius / 2 ) - (DamageRadius / 4)), 16, rnd.Next(100) - 50, 0), g);
            }
            g.pageGame.getObjectManager().Remove(this, g);
        }
    }
}

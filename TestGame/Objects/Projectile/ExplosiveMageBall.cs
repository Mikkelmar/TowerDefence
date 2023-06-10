using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;
using TestGame.Managers;
using TestGame.Objects.Monsters;
using TestGame.Objects.Particles;
using TestGame.Objects.StatusEffects;
using TestGame.Objects.Towers;

namespace TestGame.Objects.Projectile
{
    public class ExplosiveMageBall : Projectile
    {
        private TimeSpan fadeTime;
        private int DamageRadius = 40;
        private static Sound impactSound = new Sound(Sounds.miniImpact, 0.1f, SoundManager.types.Tower);
        public ExplosiveMageBall(int x, int y, Monster target = null, Tower caster = null, int size=10) : base(x, y, target, caster, size)
        {
            sprite = new Sprite(Textures.mageball);
            Speed = 300f;
            Damage = caster.damage;
            fadeTime = new TimeSpan();
            depth = depth * 0.1f;
            damageType = Monster.Damagetype.Magic;
        }
        public override void Update(GameTime gt, Game1 g)
        {
            base.Update(gt, g);
            fadeTime += gt.ElapsedGameTime;
            if(fadeTime.Milliseconds > 30)
            {
                FadingParticle afterImage = new FadingParticle(new Vector2(X, Y), new Sprite(Textures.ballFade), TimeSpan.FromMilliseconds(200), size: (int)Width);
                afterImage.Spawn(g);
                fadeTime = new TimeSpan();
            }
            
        }
        protected override void hitTarget(Game1 g)
        {
            impactSound.play(g);
            if (g.levelMap.playerData.starUpgrades["MAGE4"])
            {
                StatusEffect e = new Slow(0.334f, TimeSpan.FromSeconds(1));
                if (Target.canBeAffactedBy(e.Name))
                {
                    if (!Target.BeingEffectedBy(e.Name))
                    {
                        //g.pageGame.getObjectManager().Add(new BurningEffect(Target.GetPosCenter(), Target),g);
                    }
                    Target.GiveStatusEffect(e);
                }
                
            }
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
                om.Add(new Explotion(new Vector2(X + rnd.Next(DamageRadius / 2 ) - (DamageRadius / 4), Y + rnd.Next(DamageRadius / 2 ) - (DamageRadius / 4)), 16, rnd.Next(100) - 50, 1), g);
            }
            g.pageGame.getObjectManager().Remove(this, g);
        }
    }
}

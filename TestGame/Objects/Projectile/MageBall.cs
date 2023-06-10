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
    public class MageBall : Projectile
    {
        private TimeSpan fadeTime;
        public MageBall(int x, int y, Monster target = null, Tower caster = null, int size=10) : base(x, y, target, caster, size)
        {
            sprite = new Sprite(Textures.mageball);
            Speed = 300f;
            Damage = caster.damage;
            fadeTime = new TimeSpan();
            depth = depth * 0.1f;
            damageType = Monster.Damagetype.Magic;
        }
        protected override void hitTarget(Game1 g)
        {
            base.hitTarget(g);
            if (Target.hp <= 0 && g.levelMap.playerData.starUpgrades["MAGE2"])
            {
                if(new Random().Next(10) == 1)
                {
                    g.pageGame.player.money += 1;
                }
            }else if (g.levelMap.playerData.starUpgrades["MAGE3"])
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
    }
}

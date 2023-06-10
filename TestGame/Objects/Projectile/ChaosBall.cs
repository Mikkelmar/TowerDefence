using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TestGame.Graphics;
using TestGame.Objects.Monsters;
using TestGame.Objects.Particles;
using TestGame.Objects.StatusEffects;
using TestGame.Objects.Towers;

namespace TestGame.Objects.Projectile
{
    public class ChaosBall : Projectile
    {
        public bool canFire { get { return !returningToTower && Target == null; } }
        private int xOffset, yOffset;
        private bool returningToTower = false;
        private TimeSpan vibeTime = new TimeSpan(), travelTime = new TimeSpan(), minimumCdTime = new TimeSpan();
        public float baseSpeed;
        private TimeSpan fadeTime;
        public StatusEffect afflict = null;
        public bool shakeVibe = false;
        public ChaosBall(int x, int y, Tower caster = null, int size = 10, float speed = 100f) : base(0, 0, target: null, caster: caster, Size: size)
        {
            Vector2 centerPos = Caster.GetPosCenter();
            xOffset = x;
            yOffset = y;
            sprite = new Sprite(Textures.chaosBall);
            Speed = speed;
            baseSpeed = speed;
            Damage = caster.damage;
            depth = depth * 0.1f;
            damageType = Monster.Damagetype.Magic;
        }
        public override void Init(Game1 g)
        {
            base.Init(g);
            Vector2 centerPos = Caster.GetPosCenter();
            X = (int)centerPos.X + xOffset - (Width / 2);
            Y = (int)centerPos.Y + yOffset - (Height / 2);
        }
        public override void Update(GameTime gt, Game1 g)
        {
            if (Target != null)
            {
                if(minimumCdTime.TotalMilliseconds > 0)
                {
                    minimumCdTime -= gt.ElapsedGameTime;
                    return;
                }
                targetMove(gt, g);
                return;
            }
            if (returningToTower)
            {
                returningMove(gt, g);
                return;
            }
           if (shakeVibe)
            {
                shakeAnimation(gt, g);
            }
            else
            {
                floatAnimation(gt, g);
            } 

        }
        private void targetMove(GameTime gt, Game1 g)
        {
            fadeTime += gt.ElapsedGameTime;
            if (fadeTime.Milliseconds > 20)
            {
                FadingParticle afterImage = new FadingParticle(new Vector2(X, Y), new Sprite(Textures.chaosBall), TimeSpan.FromMilliseconds(100), size: (int)Width);
                afterImage.Spawn(g);
                fadeTime = new TimeSpan();
            }

            travelTime += gt.ElapsedGameTime;
            Speed = baseSpeed + (float)Math.Pow((travelTime.TotalMilliseconds / 10), 2);
            Move(g);
            checkTargetCollision(g);
        }
        private void returningMove(GameTime gt, Game1 g)
        {
            travelTime += gt.ElapsedGameTime;
            Speed = baseSpeed + (float)Math.Pow((travelTime.TotalMilliseconds / 10), 2);
            Vector2 centerPos = Caster.GetPosCenter();
            Move(g, (int)centerPos.X + xOffset, (int)centerPos.Y + yOffset);
            if (Vector2.Distance(position, new Vector2((int)centerPos.X + xOffset, (int)centerPos.Y + yOffset)) < 4)
            {
                X = (int)centerPos.X + xOffset - (Width / 2);
                Y = (int)centerPos.Y + yOffset - (Height / 2);
                returningToTower = false;
                vibeTime = new TimeSpan();
                Speed = baseSpeed;
                minimumCdTime = TimeSpan.FromMilliseconds(200) - travelTime;
                travelTime = new TimeSpan();
            }
        }
        private void shakeAnimation(GameTime gt, Game1 g)
        {
            vibeTime += gt.ElapsedGameTime;
            if (vibeTime.TotalMilliseconds >= 80)
            {

                vibeTime = new TimeSpan();
                Random rnd = new Random();
                Vector2 centerPos = Caster.GetPosCenter();
                Vector2 origo = new Vector2(centerPos.X+ xOffset, centerPos.Y+ yOffset);
                X = origo.X + rnd.Next(9)-4;
                Y = origo.Y + rnd.Next(9)-4;
            }
            fadeTime += gt.ElapsedGameTime;
            if (fadeTime.Milliseconds > 70)
            {
                FadingParticle afterImage = new FadingParticle(new Vector2(X, Y), new Sprite(Textures.chaosBall), TimeSpan.FromMilliseconds(100), size: (int)Width);
                afterImage.Spawn(g);
                fadeTime = new TimeSpan();
            }
        }
        private void floatAnimation(GameTime gt, Game1 g)
        {
            vibeTime += gt.ElapsedGameTime;
            if (vibeTime.TotalSeconds <= 200 / Speed)
            {
                Y += Drawing.delta * Speed / 5;
            }
            else if (vibeTime.TotalSeconds <= 400 / Speed)
            {
                Y -= Drawing.delta * Speed / 5;
            }
            else
            {
                vibeTime = new TimeSpan();
            }
        }
        protected override bool findNewTarget(Game1 g)
        {
            if (!base.findNewTarget(g))
            {
                returningToTower = true;
                Target = null;
            }
            return true;
        }
        protected override void hitTarget(Game1 g)
        {
            int extraDamage = 0;
            if (g.levelMap.playerData.starUpgrades["CHAOS2"])
            { 
                if(new Random().Next(10) < 4)
                {
                    extraDamage += new Random().Next(3) + 1;
                }

            }
            if (g.levelMap.playerData.starUpgrades["CHAOS3"])
            {
                extraDamage+=Math.Min((int)Math.Round(travelTime.TotalMilliseconds / 100), 5);
            }
            if (g.levelMap.playerData.starUpgrades["CHAOS4"])
            {
                extraDamage += (int)Math.Round((float)ChaosTower.TotalChaosTowers/3);
            }
            Target.takeDamage(Damage+ extraDamage, g, damageType);
            if (afflict != null && Target.canBeAffactedBy(afflict.Name))
            {
                if (!Target.BeingEffectedBy(afflict.Name))
                {
                    g.pageGame.getObjectManager().Add(new WeaknessEffect(Target.GetPosCenter(), Target), g);
                }
                Target.GiveStatusEffect(afflict.clone());
                
            }

            returningToTower = true;
            Target = null;
            Speed = baseSpeed;
            travelTime = new TimeSpan();
            
        }
    }
}

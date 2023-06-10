using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TestGame.Graphics;
using TestGame.Managers;
using TestGame.Objects.Monsters;
using TestGame.Objects.Particles;
using TestGame.Objects.StatusEffects;
using TestGame.Objects.Towers;

namespace TestGame.Objects.Projectile
{
    public class TowersSlowBomb : Projectile
    {
        private int range = 64;
        private StatusEffect effect;
        public SoulTower_1 spawnTower;
        public bool inPos = false;
        private float xOffset, yOffset;
        private Animation animation;
        public TowersSlowBomb(int x, int y, float speed, SoulTower_1 caster, StatusEffect effect = null) : base(x, y, Size: 22)
        {
            this.animation = new Animation(Textures.blueFire, TimeSpan.FromMilliseconds(80));
            Speed = speed;
            this.spawnTower = caster;
            Damage = spawnTower.damage;
            if (effect == null)
            {
                effect = new Slow(0.5f, TimeSpan.FromSeconds(3));
            }
            haveShadow = true;
            Random random = new Random();

            xOffset = (float)(random.Next(0, 48) - 24);
            yOffset = (float)(random.Next(0, 48) - 24);
            this.effect = effect;
        }
        public override void Init(Game1 g)
        {
            base.Init(g);
            shadow.xOffset = -8;
        }
        public override void Update(GameTime gt, Game1 g)
        {
            animation.Update(gt, g);
            if (!inPos)
            {
                targetPos = spawnTower.targetPos + new Vector2(xOffset,yOffset);
                Move(g, targetPos.X, targetPos.Y);
                checkTargetPosCollision(g);
                return;
            }
            
            if (Target == null)
            {
                findNewTarget(g);
                return;
            }
            else
            {
                if (Target.BeingEffectedBy("Slow"))
                {
                    Target = null;
                    if (!findNewTarget(g))
                    {
                        inPos = false;
                        return;
                    }
                    
                }
                Move(g);
                checkTargetCollision(g);
            }
                  
        }
        protected override void checkTargetCollision(Game1 g)
        {
            if (Target.hp <= 0)
            {
                if (!findNewTarget(g))
                {
                    inPos = false;
                }

            }
            else if (g.pageGame.getObjectManager().FromToDir(this, Target).Length() <= Width / 2 + Target.Width / 2)
            {
                hitTarget(g);
            }
        }
        protected override void hitPos(Game1 g)
        {
            inPos = true;
        }
        public override void Destroy(Game1 g)
        {
            base.Destroy(g);
            spawnTower.slowBombs.Remove(this);
        }
        protected override bool findNewTarget(Game1 g)
        {
            List<GameObject> newTargets = g.pageGame.getObjectManager().GetAllObjectsWith(p => 
                p is Monster && 
                p.DistanceTo(position) < range && 
                (p as Monster).canBeAffactedBy("Slow")
               );
            if (newTargets.Count != 0)
            {
                Target = (Monster)newTargets[0];
                return true;
            }
            Target = null;
            return false;
        }
        protected override void hitTarget(Game1 g)
        {
            base.hitTarget(g);
            if (Target.canBeAffactedBy(effect.Name))
            {
                if (!Target.BeingEffectedBy(effect.Name))
                {
                    //g.pageGame.getObjectManager().Add(new BurningEffect(Target.GetPosCenter(), Target),g);
                }
                Target.GiveStatusEffect(effect);
            }   
        }
        public override void Draw(Game1 g)
        {
            sprite = animation.getFrame();
            base.Draw(g);
        }
    }
}

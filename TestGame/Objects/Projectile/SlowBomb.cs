using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;
using TestGame.Managers;
using TestGame.Objects.Monsters;
using TestGame.Objects.Particles;
using TestGame.Objects.StatusEffects;

namespace TestGame.Objects.Projectile
{
    public class SlowBomb : Projectile
    {
        private int range = 64;
        private TimeSpan despawnTimer = TimeSpan.FromSeconds(18);
        private StatusEffect effect;
        public SlowBomb(int x, int y, float speed, StatusEffect effect = null) : base(x, y)
        {
            sprite = new Sprite(Textures.sticky_bombs);
            Speed = speed;
            if(effect == null)
            {

                effect = new Slow(0.5f, TimeSpan.FromSeconds(3));
            }
            this.effect = effect;
        }
        public override void Update(GameTime gt, Game1 g)
        {
            despawnTimer -= gt.ElapsedGameTime;
            if(despawnTimer.TotalMilliseconds < 0)
            {
                g.pageGame.getObjectManager().Remove(this, g);
                return;
            }
            if (Target == null)
            {
                findNewTarget(g);
                return;
            }
            if (Target.BeingEffectedBy("Slow"))
            {
                Target = null;
                return;
            }
            base.Update(gt, g);
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
    }
}

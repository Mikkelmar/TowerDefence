using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Managers;
using TestGame.Objects.Monsters;
using TestGame.Objects.Towers;

namespace TestGame.Objects.Projectile
{
    public class SearchingProjectile : Projectile
    {
        public SearchingProjectile(int x, int y, Monster target = null, Tower caster = null, int Size = 16) :base(x, y, target, caster, Size) 
        { }
        public TimeSpan despawnTimer = TimeSpan.FromSeconds(2);
        public float range = 64;
        public override void Update(GameTime gt, Game1 g)
        {
            despawnTimer -= gt.ElapsedGameTime;
            if (despawnTimer.TotalMilliseconds < 0)
            {
                g.pageGame.getObjectManager().Remove(this, g);
                return;
            }
            if (Target == null)
            {
                findNewTarget(g);
                return;
            }
            base.Update(gt, g);
        }
        protected override bool findNewTarget(Game1 g)
        {
            List<GameObject> newTargets = g.pageGame.getObjectManager().GetAllObjectsWith(p =>
                p is Monster &&
                p.DistanceTo(position) < range
               );
            if (newTargets.Count != 0)
            {
                Target = (Monster)newTargets[0];
                return true;
            }
            return false;
        }

    }
}

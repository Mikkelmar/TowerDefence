using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Containers.Items;
using TestGame.Objects.Particles;

namespace TestGame.Objects.Entities.Structures
{
    public abstract class ResourceBlock : Structure
    {
        protected int hp = 30;
        protected int basehp = 30;
        protected Item drop;
        public ResourceBlock(int x, int y, int w, int h) : base(x, y, w, h, 401, null)
        {}
        public override void TakeDamage(int damage, Game1 g)
        {
            hp -= damage;
            new DamageParticle(GetPosCenter(), damage).Spawn(g);
            if (hp <= 0)
            {
                Die(g);
            }
        }
        protected void Die(Game1 g)
        {
            g.pageGame.getObjectManager().Add(new ItemEntity((int)GetPosCenter().X, (int)(Y + Height), drop), g);
            g.pageGame.getObjectManager().Remove(this, g);
        }

        public override void Destroy(Game1 g)
        { }

        public override void Update(GameTime gt, Game1 g)
        { }
    }
}

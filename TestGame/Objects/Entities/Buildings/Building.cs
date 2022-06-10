using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Containers.Items;
using TestGame.Graphics;
using TestGame.Managers;
using TestGame.Objects.Particles;

namespace TestGame.Objects.Entities.Buildings
{
    public abstract class Building : Structure, RightClickable
    {
        protected int hp = 30;
        protected int basehp = 30;
        public Building(int x, int y, int width, int height, int id, Sprite sprite) : base(x, y, width, height, id, sprite)
        {

        }
        public void RightClicked(float x, float y, Game1 g)
        {
            if (g.pageGame.hudManager.activeUI == null && Intersect(new Vector2(x, y)))
            {
                Open(g);
            }
        }
        protected abstract void Open(Game1 g);
        public override void Init(Game1 g)
        {
            base.Init(g);
            g.pageGame.mouseManager.AddRight(this, false);

        }
        public override void Destroy(Game1 g)
        {
            g.pageGame.mouseManager.RemoveRight(this);
        }

        public override Predicate<Item> CanDestroy()
        {
            return p => true;
        }

        public override void TakeDamage(int damage, Game1 g)
        {
            hp -= damage;
            new DamageParticle(GetPosCenter(), damage).Spawn(g);
            if (hp <= 0)
            {
                Break(g);
            }
        }
        protected virtual void Break(Game1 g)
        {
            g.pageGame.getObjectManager().Remove(this, g);
        }

        public override void Update(GameTime gt, Game1 g)
        {
            throw new NotImplementedException();
        }
    }
}

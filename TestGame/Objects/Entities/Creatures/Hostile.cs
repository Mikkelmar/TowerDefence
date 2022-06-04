using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TestGame.Containers.Items;

namespace TestGame.Objects.Entities.Creatures
{
    public abstract class Hostile : Creature
    {
        protected Item loot = null;
        protected TimeSpan attackTimer = new TimeSpan(), AttackSpeed = new TimeSpan(0,0,3);
        public Hostile(int x, int y, int w, int h, int id, Texture2D texture) : base(x, y, w, h, id, texture)
        {

        }
        public override void Update(GameTime gt, Game1 g)
        {
            base.Update(gt, g);
            Player player = g.pageGame.GetPlayer();
            if (CanSee(player))
            {
                float _speed = Speed * Drawing.delta;
                this.MoveTowards(player, g, _speed);
            }  
        }
        public override void Destroy(Game1 g)
        {
            base.Destroy(g);
        }
        protected virtual void Attack(Game1 g)
        {
            attackTimer = new TimeSpan();
        }
        protected void RechargeAttack(GameTime gt)
        {
            attackTimer += gt.ElapsedGameTime;
        }
        protected virtual bool CanAttack()
        {
            return AttackSpeed < attackTimer;
        }

        public override void Die(Game1 g)
        {
            if(loot != null)
            {
                g.pageManager.GetPage().objectManager.Add(new ItemEntity((int)this.X, (int)this.Y, loot.Clone()), g);
            }
            g.pageManager.GetPage().objectManager.Remove(this, g);
        }

        public override void Init(Game1 g)
        {
            base.Init(g);
        }
    }
}

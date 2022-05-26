using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Managers;

namespace TestGame.Objects.Entities.Creatures
{
    public abstract class Creature : Entity
    {
        public int Health;
        public float Speed;
        public String Name;
        public bool DamageAble = true;
        public Creature(int x, int y, int w, int h, int id, Texture2D texture) : base(x, y, w, h, id, texture)
        {
            collision = true;

        }
        public abstract void Die(Game1 g);
        public void TakeDamage(int damage, Game1 g)
        {
            if (DamageAble)
            {
                Health -= damage;
                if (Health <= 0)
                {
                    Die(g);
                }
            }  
        }
        public override void Draw(Game1 g)
        {
            Drawing.FillRect(new Rectangle((int)this.X, (int)this.Y - 30, (int)this.Width, 20), Color.Aqua, 0.9f, g);
            base.Draw(g);
        }
        protected void MoveTowards(GameObject obj, Game1 g, float moveSpeed)
        {
            Vector2 dir = g.pageGame.objectManager.FromToDir(this, obj);
            this.Move(new Vector2(X + (-moveSpeed * dir.X / dir.Length()), Y + (-moveSpeed * dir.Y / dir.Length())), g);
        }
        protected void MoveAwayFrom(GameObject obj, Game1 g, float moveSpeed)
        {
            MoveTowards(obj, g, -moveSpeed);
        }
    }
}

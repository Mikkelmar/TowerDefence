using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Containers.Items;
using TestGame.Managers;

namespace TestGame.Objects.Entities.Creatures
{
    public abstract class Creature : Entity, Destructable
    {
        public int Health=5, BaseHealth;
        public float Speed, BaseSpeed;
        public String Name;
        public bool DamageAble = true;
        protected bool DisplayHealth = true;
        public Creature(int x, int y, int w, int h, int id, Texture2D texture) : base(x, y, w, h, id, texture)
        {
            collision = true;
        }
        public override void Init(Game1 g)
        {
            base.Init(g);
            BaseHealth = Health;
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
            //Drawing.FillRect(new Rectangle((int)this.X, (int)this.Y - 30, (int)this.Width, 20), Color.Aqua, 0.9f, g);
            base.Draw(g);
            if (DisplayHealth)
            {
                Drawing.FillRect(new Rectangle((int)GetPosCenter().X - 32, (int)Y - 16, 32*2, 16), Color.Red, depth*0.0001f, g);
                Drawing.FillRect(new Rectangle((int)GetPosCenter().X - 32, (int)Y - 16, (int)((32 * 2)*((float)Health /BaseHealth)), 16), Color.LawnGreen, depth * 0.00001f, g);
            }
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
        protected bool CanSee(GameObject obj, int range = 300)
        {
            //TODO: expand on how this works
            //rn tar den kun avtaden som en faktor
            if (obj.DistanceTo(this.position) <= range)
            {
                return true;
            }
            return false;
        }

        public virtual Predicate<Item> CanDestroy()
        {
            return (i) => true;
        }

    }
}

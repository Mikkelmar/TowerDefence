using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Containers.Items;
using TestGame.Managers;
using TestGame.Objects.Particles;
using TestGame.Objects.StatusEffects;

namespace TestGame.Objects.Entities.Creatures
{
    public abstract class Creature : Entity, Destructable
    {
        public int Health=5, BaseHealth;
        public int Armour;
        public float Speed, BaseSpeed;
        public String Name;
        public bool DamageAble = true;
        protected bool DisplayHealth = true;
        private List<StatusEffect> StatusEffects = new List<StatusEffect>();
        public Creature(int x, int y, int w, int h, int id, Texture2D texture) : base(x, y, w, h, id, texture)
        {
            collision = true;
            haveShadow = true;
        }
        public override void Init(Game1 g)
        {
            base.Init(g);
            BaseHealth = Health;
            BaseSpeed = Speed;
        }
        public override void Update(GameTime gt, Game1 g)
        {
            Speed = BaseSpeed;
            UpdateStatusEffects(gt, g);
        }
        public abstract void Die(Game1 g);
        public void TakeDamage(int damage, Game1 g)
        {
            if (DamageAble)
            {
                int finalDamage = CalculateDamage(damage);
                Health -= finalDamage;
                new DamageParticle(GetPosCenter(), finalDamage).Spawn(g);
                if (Health <= 0)
                {
                    Die(g);
                }
            }  
        }
        protected virtual int CalculateDamage(int damage)
        {
            double damageMultiplier = damage / ((double)Armour+damage);
            return (int)Math.Round(damage * damageMultiplier);
        }
        public override void Draw(Game1 g)
        {
            //Drawing.FillRect(new Rectangle((int)this.X, (int)this.Y - 30, (int)this.Width, 20), Color.Aqua, 0.9f, g);
            base.Draw(g);
            if (DisplayHealth)
            {
                Drawing.FillRect(new Rectangle((int)GetPosCenter().X - 8, (int)Y - 4, 16, 4), Color.Red, depth*0.0001f, g);
                Drawing.FillRect(new Rectangle((int)GetPosCenter().X - 8, (int)Y - 4, (int)((16)*((float)Health /BaseHealth)), 4), Color.LawnGreen, depth * 0.00001f, g);
            }
        }
        protected void MoveTowards(GameObject obj, Game1 g, float moveSpeed)
        {
            Vector2 dir = g.pageGame.getObjectManager().FromToDir(this, obj);
            this.Move(new Vector2(X + (-moveSpeed * dir.X / dir.Length()), Y + (-moveSpeed * dir.Y / dir.Length())), g);
        }
        protected void MoveAwayFrom(GameObject obj, Game1 g, float moveSpeed)
        {
            MoveTowards(obj, g, -moveSpeed);
        }
        protected bool CanSee(GameObject obj, int range = 100)
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
        private void UpdateStatusEffects(GameTime gt, Game1 g)
        {
            List<StatusEffect> currentStatusEffects = new List<StatusEffect>(StatusEffects);
            foreach (StatusEffect sf in currentStatusEffects)
            {
                sf.Affect(this, gt.ElapsedGameTime, g);
            }
        }
        public void AddStatusEffect(StatusEffect se)
        {
            if (StatusEffects.Contains(se))
            {
                StatusEffects.Remove(se);
            }
            StatusEffects.Add(se);
        }
        public void RemoveStatusEffect(StatusEffect se)
        {
            StatusEffects.Remove(se);
        }
    }
}

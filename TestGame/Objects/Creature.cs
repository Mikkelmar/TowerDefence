using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;
using TestGame.Huds;
using TestGame.Managers;
using TestGame.Objects.Particles;
using TestGame.Objects.PlayerLogic;

namespace TestGame.Objects
{
    public abstract class Creature : Entity, InfoDisplay, Clickable
    {
        public int reward, attackDamage = 1;
        public float Speed = 130f, hp, baseHp;
        public enum Damagetype { Magic, Normal, None }
        public enum AmourLevels { None, Low, Medium, High }
        public AmourLevels armor = AmourLevels.None, magicArmor = AmourLevels.None;
        protected bool drawHealth = true;
        protected bool LeaveCorpse = true;

        protected float xOffset = 0, yOffset = 0;
        protected static Sound deathSound = new Sound(Sounds.death, 0.5f, SoundManager.types.Monster);
        protected static Sound smallHit = new Sound(Sounds.smallHit, 1f, SoundManager.types.Monster);
        public int FacingRight = 1; //if FacingRight == 1 if FacingLeft == -1
        protected bool haveAttacked = false;

        protected TimeSpan attackTimer;
        public TimeSpan attackSpeed = new TimeSpan(0, 0, 0, 0, 900);
        public Creature(int width = 32, int height = 32) : base(0, 0, width, height)
        {
            haveShadow = true;
        }
        public override void Init(Game1 g)
        {
            base.Init(g);
            g.pageGame.mouseManager.Add(this);
        }
        protected void attackSwingAnimation(Game1 g, float x)
        {
            float dist = Drawing.delta * 130f;
            Vector2 dir = new Vector2(x - X, 0);
            if (dir.Length() == 0)
            {
                return;
            }
            dir = Vector2.Normalize(dir) * dist;
            if (!(dir.X == float.NaN || dir.Y == float.NaN))
            {
                SetPosition(X + dir.X, Y + dir.Y);
            }
        }

        protected virtual void Move(Game1 g, float x, float y)
        {
            float dist = Drawing.delta * Speed;
            Vector2 dir = new Vector2(x - X, y - Y);
            if (dir.Length() == 0)
            {
                return;
            }
            if (x > X)
            {
                FacingRight = 1;
            }
            else if (x < X)
            {
                FacingRight = -1;
            }
            if (dir.Length() <= dist)
            {
                SetPosition(x, y);
                return;
            }
            dir = Vector2.Normalize(dir) * dist;
            
            if (!(dir.X == float.NaN || dir.Y == float.NaN))
            {
                SetPosition(X + dir.X, Y + dir.Y);
            }
        }
        protected abstract void die(Game1 g);
        public virtual void takeDamage(int damageGiven, Game1 g, Damagetype damagetype = Damagetype.Normal)
        {
            int damageToTake = calculateDamage(damageGiven, damagetype);
            g.pageGame.getObjectManager().Add(new DamageParticle(this.GetPosCenter(), damageToTake));
            hp -= damageToTake;
            smallHit.play(g);
            if (hp <= 0)
            {
                die(g);
            }
        }
        private int calculateDamage(int damageGiven, Damagetype damagetype)
        {
            float damageMultiplier = 1f;

            if (damagetype == Damagetype.Normal)
            {
                damageMultiplier = getArmourValue(armor);
            }
            else if (damagetype == Damagetype.Magic)
            {
                damageMultiplier = getArmourValue(magicArmor);
            }
            return Math.Max((int)Math.Round(damageGiven * damageMultiplier), 1);

        }
        private float getArmourValue(AmourLevels armour)
        {
            switch (armour)
            {
                case AmourLevels.Low:
                    return 1 - 0.25f;
                case AmourLevels.Medium:
                    return 1 - 0.5f;
                case AmourLevels.High:
                    return 1 - 0.75f;
            }
            return 1f;
        }
        public virtual void select(Game1 g) { }

        public virtual void close(Game1 g) { }

        public void Clicked(float x, float y, Game1 g)
        {
            if (Intersect(new Vector2(x, y)))
            {
                if (!(g.pageGame.getHudManager().activeObject is PlayerPower))
                {
                    g.pageGame.getHudManager().setActiveObject(this, g);
                }

            }
        }
        public override void Destroy(Game1 g)
        {
            base.Destroy(g);
            g.pageGame.mouseManager.Remove(this);
        }
        public override void Draw(Game1 g)
        {
            //Drawing.FillRect(GetHitbox(), Color.Red, 0.000000001f, g); //Debug hitboxes
            SpriteEffects facing = SpriteEffects.None;
            if (FacingRight == 1)
            {
                facing = SpriteEffects.FlipHorizontally;
            }
            sprite.Draw(new Vector2(X, Y), Width, Height, layerDepth: depth, spriteEffects: facing);
            
            if (drawHealth && baseHp != 0 && baseHp != hp)
            {
                Drawing.FillRect(new Rectangle((int)(X), (int)(Y - 12), (int)Width - 4, 8), Color.Red, this.depth, g);
                Drawing.FillRect(new Rectangle((int)(X), (int)(Y - 12), (int)((Width - 4) * (hp / (double)baseHp)), 8), Color.Green, this.depth - this.depth * 0.1f, g);
            }
        }
        protected void attackAnimation(Game1 g)
        {
            //ATTACK "ANIMATION"
            if (attackTimer / attackSpeed >= .9)
            {
                attackSwingAnimation(g, X + 10 * FacingRight);
            }
            if (haveAttacked && attackTimer / attackSpeed <= .1)
            {
                attackSwingAnimation(g, X - 10 * FacingRight);
            }
        }
    }
}

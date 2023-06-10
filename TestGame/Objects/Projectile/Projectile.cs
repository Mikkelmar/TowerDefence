using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Managers;
using TestGame.Objects.Monsters;
using TestGame.Objects.Towers;

namespace TestGame.Objects.Projectile
{
    public class Projectile : Entity
    {
        protected float Speed = 1f;
        public int Damage;
        public Monster Target;
        public Vector2 targetPos;
        protected Vector2 origionVector;
        protected Tower Caster;
        protected float rotation = 0f;
        protected Monster.Damagetype damageType = Monster.Damagetype.Normal;
        public Projectile(int x, int y, Monster target = null, Tower caster = null, int Size = 16) : base(x, y,Size, Size)
        {
            Target = target;
            Caster = caster;
            Width = Size;
            Height = Size;
            if(caster != null)
            {
                depth = caster.depth * 0.1f;
            }
            else
            {
                depth = 0.00001f;
            }
            
        }

        protected virtual void Move(Game1 g) { 
            Move(g, Target.GetPosCenter().X, Target.GetPosCenter().Y);
        }
        protected virtual void Move(Game1 g, float x, float y)
        {
            float dist = Drawing.delta * Speed;
            Vector2 dir = new Vector2(x - X, y - Y);
            if(dir.Length() == 0)
            {
                return;
            }
            dir = Vector2.Normalize(dir) * dist;
            if (!(dir.X == float.NaN || dir.Y == float.NaN))
            {
                SetPosition(X + dir.X, Y + dir.Y);
            }
        }
        public override void Update(GameTime gt, Game1 g)
        {
            if (Target == null)
            {
                Move(g, targetPos.X, targetPos.Y);
                checkTargetPosCollision(g);
                return;
            }
            Move(g);
            checkTargetCollision(g);
        }
        protected virtual void checkTargetCollision(Game1 g)
        {
            if (Target.hp <= 0)
            {
                if (!findNewTarget(g))
                {
                    g.pageGame.getObjectManager().Remove(this, g);
                }

            }
            //else if (g.pageGame.getObjectManager().FromToDir(this, Target).Length() <= Width / 2 + Target.Width/2)
            else if (Vector2.Distance(position, Target.GetPosCenter()) <= Width / 2 + Target.Width / 3)
            {
                hitTarget(g);
            }
        }
        protected virtual void checkTargetPosCollision(Game1 g)
        {
            if (Vector2.Distance(position, targetPos) <= Width/2)
            {
                hitPos(g);
            }
        }
        protected virtual bool findNewTarget(Game1 g)
        {
            List<GameObject> newTargets = g.pageGame.getObjectManager().GetAllObjectsWith(p => p is Monster && p.DistanceTo(Target.position) < 64 && (p != Target));
            if(newTargets.Count != 0)
            {
                Target = (Monster)newTargets[0];
                return true;
            }
            return false;
        }
        protected virtual void hitTarget(Game1 g)
        {
            Target.takeDamage(Damage, g, damageType);
            g.pageGame.getObjectManager().Remove(this, g);
        }
        protected virtual void hitPos(Game1 g)
        {
            g.pageGame.getObjectManager().Remove(this, g);
        }
        public override void Draw(Game1 g)
        {
            //Vector2 drawPos = new Vector2(X - Width / 2, Y - Height / 2);
            Vector2 drawPos = new Vector2(X, Y);
            //Drawing.FillRect(GetHitbox(), Color.Red, 0.000000001f, g); //Debug hitboxes
            sprite.Draw(drawPos, Width, Height, depth, rotation: rotation, origin: origionVector);
        }
    }
}

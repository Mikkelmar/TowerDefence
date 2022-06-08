using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TestGame.Containers.Items;
using TestGame.Containers.Items.ItemTypes;
using TestGame.Graphics;
using TestGame.Managers;
using TestGame.Objects.Entities.Creatures;
using TestGame.Objects.StatusEffects;

namespace TestGame.Objects.Entities
{
    public class ArrowProjectile : Entity
    {
        private int Damage;
        private float Speed, Knockback, rotation = 0.0f;
        private Vector2 Direction;
        private Creature caster;
        private Arrow ArrowItem;
        private bool DropProjectile;
        private TimeSpan deSpawn = new TimeSpan(0,0,30);
        public ArrowProjectile(float x, float y, Sprite sprite, int Damage, float Speed, Vector2 Direction, Creature caster, Arrow arrow, float Knockback = 150, bool DropProjectile = true) : base((int)x, (int)y, 8, 8, 0, sprite)
        {
            this.Damage = Damage;
            this.Speed = Speed;
            this.Direction = Direction;
            this.caster = caster;
            ArrowItem = arrow;
            rotation = (float)Math.Atan2(Direction.Y, Direction.X);
            rotation = (float)(rotation - (Math.PI/4)+ Math.PI);
            this.Knockback = Knockback;
            this.DropProjectile = DropProjectile;
        }
        public override void Update(GameTime gt, Game1 g)
        {
            if(Speed != 0)
            {
                Move(new Vector2(X + Direction.X * Speed*Drawing.delta, Y + Direction.Y * Speed * Drawing.delta), g);
            }
            deSpawn -= gt.ElapsedGameTime;

            if(deSpawn.Ticks <= 0)
            {
                g.pageGame.getObjectManager().Remove(this, g);
            }

        }
        private void Hit(GameObject obj, Game1 g)
        {
            if(obj is Creature)
            {
                ((Creature)obj).TakeDamage(Damage, g);

                ((Creature)obj).AddStatusEffect(new Knockback(-Direction, Knockback, new TimeSpan(0, 0, 0, 0, 120)));

                g.pageGame.getObjectManager().Remove(this, g);
            }
            else
            {
                if (DropProjectile)
                {
                    g.pageGame.getObjectManager().Add(new ItemEntity((int)X, (int)Y, ArrowItem), g);
                    g.pageGame.getObjectManager().Remove(this, g);
                }
            }
            Speed = 0;
        }
        public override void Move(Vector2 newPos, Game1 g)
        {
            Vector2 nextPos = new Vector2(this.X, this.Y);
            GameObject hitTarget = g.pageGame.getObjectManager().CanMove(this,
                new Rectangle(
                    (int)newPos.X + hitbox.X,
                    (int)this.Y + hitbox.Y,
                    (int)hitbox.Width,
                    (int)hitbox.Height),
                (s) => ((s.solid == true) || (s.collision == true)) && !s.Equals(this) && !s.Equals(caster)
                 );

            if (hitTarget == null)
            {
                nextPos.X = newPos.X;
            }
            else
            {
                Hit(hitTarget, g);
                return;
            }
             hitTarget = g.pageGame.getObjectManager().CanMove(this,
                new Rectangle(
                    (int)this.X + hitbox.X,
                    (int)newPos.Y + hitbox.Y,
                    (int)hitbox.Width,
                    (int)hitbox.Height),
                (s) => ((s.solid == true) || (s.collision == true)) && !s.Equals(this) && !s.Equals(caster)
                );
            if (hitTarget == null)
            {
                nextPos.Y = newPos.Y;
            }
            else
            {
                Hit(hitTarget, g);
                return;
            }
            SetPosition(nextPos.X, nextPos.Y);
        }
        public override void Draw(Game1 g)
        {
            sprite.Draw(position, Width, Height, depth, rotation);
        }
    }
}

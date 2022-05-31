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

namespace TestGame.Objects.Entities
{
    public class ArrowProjectile : Entity
    {
        private int BaseDamage;
        private float Speed, rotation = 0.0f;
        private Vector2 Direction;
        private Creature caster;
        private Arrow ArrowItem;
        public ArrowProjectile(float x, float y, Sprite sprite, int Damage, float Speed, Vector2 Direction, Creature caster, Arrow arrow) : base((int)x, (int)y, 32, 32, 0, sprite)
        {
            this.BaseDamage = Damage;
            this.Speed = Speed;
            this.Direction = Direction;
            this.caster = caster;
            ArrowItem = arrow;
            rotation = (float)Math.Atan2(Direction.Y, Direction.X);
            rotation = (float)(rotation - (Math.PI/4)+ Math.PI);
        }
        public override void Update(GameTime gt, Game1 g)
        {
            if(Speed != 0)
            {
                Move(new Vector2(X + Direction.X * Speed*Drawing.delta, Y + Direction.Y * Speed * Drawing.delta), g);
            }
            

        }
        private void Hit(GameObject obj, Game1 g)
        {
            if(obj is Creature)
            {
                ((Creature)obj).TakeDamage(BaseDamage + ArrowItem.Damage, g);
                g.pageGame.objectManager.Remove(this, g);
            }
            else
            {
                g.pageGame.objectManager.Add(new ItemEntity((int)X, (int)Y, ArrowItem), g);
                g.pageGame.objectManager.Remove(this, g);
            }
            Speed = 0;
        }
        public override void Move(Vector2 newPos, Game1 g)
        {
            Vector2 nextPos = new Vector2(this.X, this.Y);
            GameObject hitTarget = g.pageManager.GetPage().objectManager.CanMove(this,
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
             hitTarget = g.pageManager.GetPage().objectManager.CanMove(this,
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

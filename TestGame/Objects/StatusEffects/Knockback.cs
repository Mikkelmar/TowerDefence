using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TestGame.Objects.Entities.Creatures;

namespace TestGame.Objects.StatusEffects
{
    public class Knockback : StatusEffect
    {
        private Vector2 direction;
        float speed;
        public Knockback(Vector2 dir, float speed, TimeSpan duration)
        {
            Duration = duration;
            direction = dir;
            this.speed = speed;
            Name = "Knockback";
        }
        protected override void TriggerTick(Creature creature, TimeSpan elapsedTime, Game1 g)
        {
            creature.Move(new Vector2(
                creature.X + (-speed * direction.X * Drawing.delta / direction.Length()),
                creature.Y + (-speed * direction.Y * Drawing.delta / direction.Length())),
                g
               );
        }
    }
}

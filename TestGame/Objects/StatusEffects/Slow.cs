using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Objects.Entities.Creatures;

namespace TestGame.Objects.StatusEffects
{
    public class Slow : StatusEffect
    {
        float scale;
        public Slow(float scale, TimeSpan duration)
        {
            Duration = duration;
            this.scale = scale;
            Name = "Slow";
        }
        protected override void TriggerTick(Creature creature, TimeSpan elapsedTime, Game1 g)
        {
            creature.Speed = creature.Speed*scale;
        }
    }
}

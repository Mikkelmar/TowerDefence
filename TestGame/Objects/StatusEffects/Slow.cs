using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Objects.Monsters;

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
        protected override void TriggerTick(Monster creature, TimeSpan elapsedTime, Game1 g)
        {
            creature.Speed = creature.Speed*scale;
        }
        public override StatusEffect clone()
        {
            return new Slow(scale, Duration);
        }
    }
}

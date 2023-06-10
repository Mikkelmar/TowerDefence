using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Objects.Monsters;

namespace TestGame.Objects.StatusEffects
{
    public class Weakness : StatusEffect
    {
        public float scale;
        public Weakness(float scale, TimeSpan duration)
        {
            Duration = duration;
            this.scale = scale;
            Name = "Weakness";
        }
        protected override void TriggerTick(Monster creature, TimeSpan elapsedTime, Game1 g)
        {
            
        }
        public override StatusEffect clone()
        {
            return new Weakness(scale, Duration);
        }
    }
}

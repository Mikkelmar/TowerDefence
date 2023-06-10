using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TestGame.Objects.Monsters;

namespace TestGame.Objects.StatusEffects
{
    public class Poison : StatusEffect
    {
        private int tickDamage;
        private TimeSpan damageRate, startTime= new TimeSpan();
        public Poison(int tickDamage, TimeSpan duration, TimeSpan damageRate)
        {
            Duration = duration;
            this.tickDamage = tickDamage;
            this.damageRate = damageRate;
            Name = "Poison";
        }

        public override StatusEffect clone()
        {
            return new Burning(tickDamage, Duration, damageRate);
        }

        protected override void TriggerTick(Monster creature, TimeSpan elapsedTime, Game1 g)
        {
            startTime += elapsedTime;
            if(startTime >= damageRate)
            {
                startTime = new TimeSpan();
                creature.takeDamage(tickDamage, g);
            }
            
        }
    }
}

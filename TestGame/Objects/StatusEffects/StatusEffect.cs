using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Objects.Monsters;

namespace TestGame.Objects.StatusEffects
{
    public abstract class StatusEffect
    {
        public TimeSpan Duration;
        public string Name;
        public void Affect(Monster creature, TimeSpan elapsedTime, Game1 g)
        {
            Duration -= elapsedTime;
            if(Duration.Ticks <= 0)
            {
                creature.RemoveStatusEffect(this);
                return;
            }
            TriggerTick(creature, elapsedTime, g);
        }
        public abstract StatusEffect clone();
        protected abstract void TriggerTick(Monster creature, TimeSpan elapsedTime, Game1 g);
      
    }
}

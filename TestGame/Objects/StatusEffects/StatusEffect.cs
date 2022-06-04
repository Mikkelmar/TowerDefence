using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Objects.Entities.Creatures;

namespace TestGame.Objects.StatusEffects
{
    public abstract class StatusEffect
    {
        protected TimeSpan Duration;
        public string Name;
        public void Affect(Creature creature, TimeSpan elapsedTime, Game1 g)
        {
            Duration -= elapsedTime;
            if(Duration.Ticks <= 0)
            {
                creature.RemoveStatusEffect(this);
                return;
            }
            TriggerTick(creature, elapsedTime, g);
        }
        protected abstract void TriggerTick(Creature creature, TimeSpan elapsedTime, Game1 g);

        public override bool Equals(object obj)
        {
            if(obj is StatusEffect)
            {
                return Name.Equals(((StatusEffect)obj).Name);
            }
            return base.Equals(obj);
        }
    }
}

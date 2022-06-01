using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Containers.Items;

namespace TestGame.Objects.Entities
{
    public interface Destructable
    {
        public Predicate<Item> CanDestroy();

        public void TakeDamage(int damage, Game1 g);
    }
}

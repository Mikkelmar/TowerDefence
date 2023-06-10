using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;
using TestGame.Pages;

namespace TestGame.Objects.Monsters
{
    public class GobblerDestroyer : Monster
    {
        public GobblerDestroyer(Path path, int startDistance = 0) : base(path, startDistance, width: 48, height: 48)
        {

            attackDamage = 14;
            attackSpeed = new TimeSpan(0, 0, 0, 1, 500);
            Speed = 36;
            hp = 80;
            reward = 5;
            damage = 2;
            armor = AmourLevels.Medium;
            sprite = new Sprite(Textures.monster_armour);
            name = "Globber Destroyer";
            description = "50% Resistance to normal damage. And a large health pool";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;
using TestGame.Pages;

namespace TestGame.Objects.Monsters
{
    public class HelmetMonster : Monster
    {
        public HelmetMonster(Path path, int startDistance = 0) : base(path, startDistance)
        {
            attackDamage = 4;
            attackSpeed = new TimeSpan(0, 0, 0, 0, 960);
            Speed = 45;
            hp = 15;
            reward = 3;
            armor = Creature.AmourLevels.Medium;
            sprite = new Sprite(Textures.helmetMonster);
            name = "Globber Knight";
            description = "50% Resistance to normal damage";

        }
    }
}

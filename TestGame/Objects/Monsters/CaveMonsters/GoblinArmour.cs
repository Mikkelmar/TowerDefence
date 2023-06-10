using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;
using TestGame.Pages;

namespace TestGame.Objects.Monsters
{
    public class GoblinArmour : Monster
    {
        public GoblinArmour(Path path, int startDistance = 0) : base(path, startDistance)
        {
            attackDamage = 10;
            attackSpeed = new TimeSpan(0, 0, 0, 0, 800);
            Speed = 45;
            hp = 50;
            reward = 3;
            armor = Creature.AmourLevels.Medium;
            sprite = new Sprite(Textures.monsterSheet2, new Rectangle(32 * 1, 32 * 3, 32, 32));
            name = "Armoured goblin";
            description = "Goblin deez steel nutz";
        }
    }
}

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;
using TestGame.Pages;

namespace TestGame.Objects.Monsters
{
    public class RatHood : Monster
    {
        public RatHood(Path path, int startDistance = 0) : base(path, startDistance)
        {
            attackDamage = 6;
            attackSpeed = new TimeSpan(0, 0, 0, 0, 600);
            Speed = 45;
            hp = 35;
            reward = 2;
            sprite = new Sprite(Textures.monsterSheet2, new Rectangle(32 * 1, 32 * 2, 32, 32));
            armor = Creature.AmourLevels.Low;
            name = "Rattler Assassin";
            description = "Deep dwellers";
        }
    }
}

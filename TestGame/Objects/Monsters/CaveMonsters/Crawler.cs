using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;
using TestGame.Pages;

namespace TestGame.Objects.Monsters
{
    public class Crawler : Monster
    {
        public Crawler(Path path, int startDistance = 0) : base(path, startDistance)
        {
            attackDamage = 4;
            attackSpeed = new TimeSpan(0, 0, 0, 0, 600);
            Speed = 70;
            hp = 15;
            reward = 2;
            sprite = new Sprite(Textures.monsterSheet2, new Rectangle(32 * 0, 32 * 0, 32, 32));
            magicArmor = Creature.AmourLevels.High;
            name = "Crawler";
            description = "75% Resistance to magic damage, pesky creatures";
        }
    }
}

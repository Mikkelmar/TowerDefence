using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;
using TestGame.Pages;

namespace TestGame.Objects.Monsters
{
    public class OTron : Monster
    {
        public OTron(Path path, int startDistance = 0) : base(path, startDistance)
        {
            Speed = 40;
            hp = 30;
            reward = 3;
            attackDamage = 6;
            attackSpeed = new TimeSpan(0, 0, 0, 0, 900);
            sprite = new Sprite(Textures.monsterSheet, new Rectangle(32 * 5, 32 * 2, 32, 32));
            name = "O'Tron";
            magicArmor = Creature.AmourLevels.High;
            description = "75% Resistance to magic damage";
        }
    }
}

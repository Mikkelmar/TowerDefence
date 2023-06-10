using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;
using TestGame.Pages;

namespace TestGame.Objects.Monsters
{
    public class GibliGuy : Monster
    {
        public GibliGuy(Path path, int startDistance = 0) : base(path, startDistance)
        {
            attackDamage = 8;
            Speed = 45;
            hp = 14;
            reward = 2;
            sprite = new Sprite(Textures.monsterSheet, new Rectangle(32 * 0, 32 * 2, 32, 32));
            name = "Shroom Walker";
            magicArmor = Creature.AmourLevels.Low;
            description = "25% Resistance to magic damage";
        }
    }
}

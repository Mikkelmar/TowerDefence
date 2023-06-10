using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;
using TestGame.Pages;

namespace TestGame.Objects.Monsters
{
    public class CaveGoblin : Monster
    {
        public CaveGoblin(Path path, int startDistance = 0) : base(path, startDistance)
        {
            attackDamage = 7;
            attackSpeed = new TimeSpan(0, 0, 0, 0, 600);
            Speed = 45;
            hp = 45;
            reward = 2;
            sprite = new Sprite(Textures.monsterSheet2, new Rectangle(32 * 0, 32 * 3, 32, 32));
            name = "Cave goblin";
            description = "Goblin deez nutz";
        }
    }
}

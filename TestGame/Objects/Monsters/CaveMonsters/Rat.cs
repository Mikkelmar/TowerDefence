using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;
using TestGame.Pages;

namespace TestGame.Objects.Monsters
{
    public class Rat : Monster
    {
        public Rat(Path path, int startDistance = 0) : base(path, startDistance)
        {
            attackDamage = 4;
            attackSpeed = new TimeSpan(0, 0, 0, 0, 500);
            Speed = 45;
            hp = 25;
            reward = 2;
            sprite = new Sprite(Textures.monsterSheet2, new Rectangle(32 * 0, 32 * 2, 32, 32));
            name = "Rattler";
            description = "Deep dwellers";
        }
    }
}

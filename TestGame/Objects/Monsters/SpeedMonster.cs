using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;
using TestGame.Pages;

namespace TestGame.Objects.Monsters
{
    public class SpeedMonster : Monster
    {
        public SpeedMonster(Path path, int startDistance = 0) : base(path, startDistance)
        {
            attackDamage = 2;
            attackSpeed = new TimeSpan(0, 0, 0, 0, 600);
            Speed = 90;
            hp = 5;
            reward = 1;
            sprite = new Sprite(Textures.speedMonster);
            name = "Zoomer";
            description = "Very fast, blink and you will miss it";
        }
    }
}

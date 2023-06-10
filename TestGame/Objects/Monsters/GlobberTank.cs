using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;
using TestGame.Pages;

namespace TestGame.Objects.Monsters
{
    public class GlobberTank : Monster
    {
        public GlobberTank(Path path, int startDistance = 0) : base(path, startDistance, width: 48, height: 48)
        {
            attackDamage = 13;
            attackSpeed = new TimeSpan(0, 0, 0, 1, 400);
            Speed = 36;
            hp = 60;
            reward = 5;
            damage = 2;
            sprite = new Sprite(Textures.monster_big);
            name = "Globber Tank";
            description = "Massive health pool! Deals more damage to you!";
        }
    }
}

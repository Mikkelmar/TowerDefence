using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;
using TestGame.Objects.Monsters;
using TestGame.Objects.Projectile;

namespace TestGame.Objects.Towers
{
    public class BombTower_2 : BombTower
    {
        public BombTower_2(int x, int y) : base(x, y)
        {
            name = "Bomb tower II";
            this.damage = 6;
            this.reloadTimer = new TimeSpan(0, 0, 0, 0, 1800);
            this.range = 130;
            cost = 180;
            sprite = new Sprite(Textures.bombTower_2);
            optionsID = new List<int>() { 13 };
        }

    }
}

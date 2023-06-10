using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;
using TestGame.Objects.Monsters;
using TestGame.Objects.Projectile;

namespace TestGame.Objects.Towers
{
    public class BombTower_3 : BombTower
    {
        public BombTower_3(int x, int y) : base(x, y)
        {
            name = "Bomb tower III";
            this.damage = 10;
            this.reloadTimer = new TimeSpan(0, 0, 0, 0, 1600);
            this.range = 140;
            cost = 270;
            sprite = new Sprite(Textures.bombTower_3);
            optionsID = new List<int>() { 14, 20 };
        }

    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TestGame.Graphics;
using TestGame.Objects.Monsters;
using TestGame.Objects.Projectile;

namespace TestGame.Objects.Towers
{
    public class ArcherTower_3 : ArcherTower
    {
        public ArcherTower_3(int x, int y) : base(x, y)
        {
            name = "Archer tower III";
            this.damage = 6;
            this.reloadTimer = new TimeSpan(0, 0, 0, 0, 360);
            this.range = 180;
            cost = 200;
            sprite = new Sprite(Textures.archerTower_2);
            optionsID = new List<int>() { 4, 5 };

        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TestGame.Graphics;
using TestGame.Objects.Monsters;
using TestGame.Objects.Projectile;

namespace TestGame.Objects.Towers
{
    public class ArcherTower_2 : ArcherTower
    {
        public ArcherTower_2(int x, int y) : base(x, y)
        {
            name = "Archer tower II";
            this.damage = 3;
            this.reloadTimer = new TimeSpan(0, 0, 0, 0, 400);
            this.range = 165;
            cost = 120;
            sprite = new Sprite(Textures.archerTower_1);
            optionsID = new List<int>() { 3 };

        }
    }
}

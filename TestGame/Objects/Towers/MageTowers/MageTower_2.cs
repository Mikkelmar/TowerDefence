using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;
using TestGame.Objects.Monsters;
using TestGame.Objects.Projectile;

namespace TestGame.Objects.Towers
{
    public class MageTower_2 : MageTower
    {
        public MageTower_2(int x, int y) : base(x, y)
        {
            name = "Mage tower II";
            this.damage = 9;
            this.reloadTimer = new TimeSpan(0, 0, 0, 0, 1100);
            this.range = 140;
            cost = 160;
            sprite = new Sprite(Textures.mageTower_2);
            optionsID = new List<int>() { 8 };
        }
    }
}

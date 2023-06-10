using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;
using TestGame.Objects.Monsters;
using TestGame.Objects.Projectile;

namespace TestGame.Objects.Towers
{
    public class MageTower_3 : MageTower
    {
        public MageTower_3(int x, int y) : base(x, y)
        {
            name = "Mage tower III";
            this.damage = 17;
            this.reloadTimer = new TimeSpan(0, 0, 0, 0, 1000);
            this.range = 150;
            cost = 240;
            sprite = new Sprite(Textures.mageTower_3);
            optionsID = new List<int>() { 9, 10 };
        }
    }
}

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;
using TestGame.Objects.Projectile;

namespace TestGame.Objects.Towers
{
    public class ChaosTower_3 : ChaosTower
    {
        public ChaosTower_3(int x, int y) : base(x, y) {
            name = "Chaos tower III";
            this.damage = 9;
            this.range = 160;
            cost = 240;
            sprite = new Sprite(Textures.chaosTower_ultimate);
            optionsID = new List<int>() { 18, 19 };
            orb = new ChaosBall(-1, -60, this, size: 14, speed: 190f);
        }
    }
}

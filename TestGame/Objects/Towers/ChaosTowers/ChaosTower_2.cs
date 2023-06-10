using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;
using TestGame.Objects.Monsters;
using TestGame.Objects.Projectile;

namespace TestGame.Objects.Towers
{
    public class ChaosTower_2 : ChaosTower
    {
        public ChaosTower_2(int x, int y) : base(x, y) {
            name = "Chaos tower II";
            this.damage = 5;
            this.range = 155;
            cost = 160;
            sprite = new Sprite(Textures.chaosTower_2);
            optionsID = new List<int>() { 17 };
            orb = new ChaosBall(-1, -60, this, size: 14, speed: 125f);
        }
    }
}

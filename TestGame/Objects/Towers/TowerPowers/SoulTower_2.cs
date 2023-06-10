using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TestGame.Graphics;
using TestGame.Managers;
using TestGame.Objects.Monsters;
using TestGame.Objects.Projectile;
using TestGame.Objects.StatusEffects;

namespace TestGame.Objects.Towers
{
    public class SoulTower_2 : SoulTower_1
    {
        public SoulTower_2(int x, int y) : base(x, y) {
            name = "Soul tower II";
            damage = 8;
            reloadTimer = new TimeSpan(0, 0, 0, 2, 200);
            range = 128;
            capacity = 5;
            cost = 130;
            sprite = new Sprite(Textures.spawnTower_2);
            optionsID = new List<int>() {23 };

        }     
    }
}

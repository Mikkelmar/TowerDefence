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
    public class SoulTower_3 : SoulTower_1
    {
        public SoulTower_3(int x, int y) : base(x, y) {
            name = "Soul tower III";
            damage = 8;
            reloadTimer = new TimeSpan(0, 0, 0, 2, 0);
            range = 136;
            capacity = 8;
            cost = 210;
            sprite = new Sprite(Textures.spawnTower_3);
            optionsID = new List<int>() { };

        }     
    }
}

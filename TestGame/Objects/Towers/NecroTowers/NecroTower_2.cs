using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;
using TestGame.Managers;
using TestGame.Objects.Monsters;
using TestGame.Objects.Projectile;

namespace TestGame.Objects.Towers.NectoTowers
{
    public class NecroTower_2 : NecroTower
    {

        public NecroTower_2(int x, int y) : base(x, y) {
            name = "Necro Tower II";
            this.damage = 7;
            beamDamage = 5;
            this.reloadTimer = new TimeSpan(0, 0, 0, 0, 850);
            this.range = 140;
            maxCharge = 15;
            drainRate = 0.5f;
            cost = 140;
            sprite = new Sprite(Textures.necroTower_2);
            optionsID = new List<int>() { 28 };

        }

    }
}

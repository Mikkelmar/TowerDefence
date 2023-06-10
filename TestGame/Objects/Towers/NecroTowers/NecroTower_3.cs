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
    public class NecroTower_3 : NecroTower
    {

        public NecroTower_3(int x, int y) : base(x, y) {
            name = "Necro Tower III";
            this.damage = 11;
            beamDamage = 6;
            this.reloadTimer = new TimeSpan(0, 0, 0, 0, 850);
            this.range = 155;
            drainRate = 0.75f;
            maxCharge = 20;
            cost = 210;
            sprite = new Sprite(Textures.necroTower_3);
            optionsID = new List<int>() { 29, 30 };

        }

    }
}

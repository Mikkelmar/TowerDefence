using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;
using TestGame.Managers;
using TestGame.Objects.Monsters;
using TestGame.Objects.Projectile;
using TestGame.Objects.StatusEffects;
using TestGame.Objects.Towers.TowerPowers;

namespace TestGame.Objects.Towers.NectoTowers
{
    public class NecroTower_Death : NecroTower
    {

        public NecroTower_Death(int x, int y) : base(x, y) {
            name = "Death Tower";
            this.damage = 16;
            beamDamage = 7;
            this.reloadTimer = new TimeSpan(0, 0, 0, 0, 850);
            this.range = 165;
            drainRate = 1f;
            maxCharge = 20;
            cost = 300;
            sprite = new Sprite(Textures.necroTower_death);
            optionsID = new List<int>() {  };
            powers = new List<TowerPower>() {
                new TowerPower {
                    name = "Toxic",
                    desc="Primary fire applies a poision effect",
                    color = Color.MediumPurple,
                    cost=200,
                    icon = new Sprite(Textures.jelly)
                }, };

        }
        protected override void fire(Game1 g, Monster target)
        {
            if(powers[0].stage > 0)
            {
                StatusEffect e = new Poison(2, TimeSpan.FromSeconds(8), TimeSpan.FromMilliseconds(600));
                if (target.canBeAffactedBy(e.Name))
                {
                    target.GiveStatusEffect(e);
                }
            }
            base.fire(g, target);
        }
        

    }
}

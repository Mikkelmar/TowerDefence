using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TestGame.Graphics;
using TestGame.Objects.Monsters;
using TestGame.Objects.Projectile;
using TestGame.Objects.Towers.TowerPowers;

namespace TestGame.Objects.Towers
{
    public class BombTower : Tower
    {
        public BombTower(int x, int y) : base(x, y)
        {
            name = "Bomb tower";
            this.damage = 3;
            this.reloadTimer = new TimeSpan(0, 0, 0, 0, 1800);
            this.range = 120;
            cost = 90;
            sprite = new Sprite(Textures.bombTower_1);

            optionsID = new List<int>() { 12 };

        }

        protected override void fire(Game1 g, Monster target)
        {
            int damageRadius = 44;
            if (g.levelMap.playerData.starUpgrades["BOMB1"])
            {
                damageRadius = 56;
            }
            g.pageGame.getObjectManager().Add(new Bomb((int)GetPosCenter().X, (int)GetPosCenter().Y, target, this) {
                DamageRadius = damageRadius
            });
        }
        public override Tower LoadUpgrades(Game1 g)
        {
            if (g.levelMap.playerData.starUpgrades["BOMB0"])
            {
                damage += 1;
            }
            if (g.levelMap.playerData.starUpgrades["BOMB2"])
            {
                range += (int)(range*0.15f);
            }
            if (g.levelMap.playerData.starUpgrades["BOMB3"])
            {
                foreach(TowerPower power in powers)
                {
                    power.cost -= power.cost / 4;
                    TowerPower nextTier = power.nextTier;
                    while (nextTier != null)
                    {
                        nextTier.cost -= nextTier.cost / 4;
                        nextTier = nextTier.nextTier;
                    }

                }
            }
            return base.LoadUpgrades(g);
        }
    }
}

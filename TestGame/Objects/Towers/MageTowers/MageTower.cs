using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;
using TestGame.Managers;
using TestGame.Objects.Monsters;
using TestGame.Objects.Projectile;
using TestGame.Objects.Towers.TowerPowers;

namespace TestGame.Objects.Towers
{
    public class MageTower : Tower
    {
        protected static Sound attackSound = new Sound(Sounds.mageAttack, 0.5f, SoundManager.types.Tower);
        public MageTower(int x, int y) : base(x, y)
        {
            name = "Mage tower";
            this.damage = 5;
            this.reloadTimer = new TimeSpan(0, 0, 0, 0, 1200);
            this.range = 130;
            cost = 80;
            sprite = new Sprite(Textures.mageTower_1);

            optionsID = new List<int>() { 7 };

        }

        public override Tower LoadUpgrades(Game1 g)
        {
            if (g.levelMap.playerData.starUpgrades["MAGE0"])
            {
                cost -= 10;
            }
            if (g.levelMap.playerData.starUpgrades["MAGE2"])
            {
                range += (int)(range *0.15f);
            }

            if (g.levelMap.playerData.starUpgrades["MAGE3"])
            {
                foreach (TowerPower power in powers)
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
        protected override void fire(Game1 g, Monster target)
        {
            attackSound.play(g);
            
            g.pageGame.getObjectManager().Add(new MageBall((int)GetPosCenter().X, (int)GetPosCenter().Y, target, this));
        }
    }
}

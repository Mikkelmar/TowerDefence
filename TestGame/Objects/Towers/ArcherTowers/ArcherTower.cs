using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;
using TestGame.Managers;
using TestGame.Objects.Monsters;
using TestGame.Objects.Projectile;

namespace TestGame.Objects.Towers
{

    public class ArcherTower : Tower
    {
        protected static Sound attackSound = new Sound(Sounds.shoot_1, 0.5f, SoundManager.types.Tower);
        public ArcherTower(int x, int y) : base(x, y) {
            name = "Archer tower";
            this.damage = 1;
            this.reloadTimer = new TimeSpan(0, 0, 0, 0, 450);
            this.range = 150;
            cost = 60;
            sprite = new Sprite(Textures.archerTower_0);
            optionsID = new List<int>() { 1 };

        }
        protected override void fire(Game1 g, Monster target)
        {
            attackSound.play(g);
            int doubleDamage = 1;
            if (g.levelMap.playerData.starUpgrades["ARCHER4"] && new Random().Next(100) < 8)
            {
                doubleDamage = 2;
            }
            g.pageGame.getObjectManager().Add(new Arrow((int)GetPosCenter().X, (int)GetPosCenter().Y, target, this) { 
            Damage = damage* doubleDamage
            });
            //target.takeDamage(this.damage, g);
        }
        public override Tower LoadUpgrades(Game1 g)
        {
            if (g.levelMap.playerData.starUpgrades["ARCHER0"])
            {
                damage += 1;
            }
            if (g.levelMap.playerData.starUpgrades["ARCHER1"])
            {
                range += (int)(range *0.1f);
            }
            if (g.levelMap.playerData.starUpgrades["ARCHER3"])
            {
                range += (int)(range *0.1f);
            }
            return base.LoadUpgrades(g);
        }
    }
}

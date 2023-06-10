using Microsoft.Xna.Framework;
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
    public class ArcherTower_Fire : ArcherTower
    {
        private TimeSpan vollyTime = new TimeSpan();
        private bool activeVolly = false;
        public ArcherTower_Fire(int x, int y) : base(x, y)
        {
            name = "Fire archer tower";
            this.damage = 9;
            this.reloadTimer = new TimeSpan(0, 0, 0, 0, 320);
            this.range = 200;
            cost = 300;
            sprite = new Sprite(Textures.archerTower_fire);
            optionsID = new List<int>() {};
            powers = new List<TowerPower>() { 
                new TowerPower { 
                    name = "fire arrows", 
                    desc="Fire arrows. Tower will not prioritize none burning targets",
                    color = Color.Red,
                    cost=250, 
                    icon = new Sprite(Textures.fireArrow)
                },
                new TowerPower {
                    name = "Rapid fire",
                    desc="Shoot a volly. cd: 15s",
                    color = Color.Yellow,
                    cost=200,
                    coolDown = TimeSpan.FromSeconds(15),
                    icon = new Sprite(Textures.arrow),
                    nextTier = new TowerPower {
                        name = "Volly arrows II",
                        desc="Shoot a volly. cd: 11s",
                        cost=100,
                        coolDown = TimeSpan.FromSeconds(11),
                        icon = new Sprite(Textures.arrow)
                    }
                }
            };
        }
        public override void Update(GameTime gt, Game1 g)
        {
            base.Update(gt, g);
            if (powers[1].stage > 0)
            {
                vollyTime += gt.ElapsedGameTime;
                if(vollyTime.TotalSeconds >= powers[1].coolDown.TotalSeconds)
                {
                    activeVolly = true;
                    reloadTimer = new TimeSpan(0, 0, 0, 0, 80);
                }
                if (vollyTime.TotalSeconds >= powers[1].coolDown.TotalSeconds+2)
                {
                    activeVolly = false;
                    reloadTimer = new TimeSpan(0, 0, 0, 0, 300);
                    vollyTime = new TimeSpan();
                }
            }
        }
        protected override bool findTarget(Game1 g)
        {
            if(powers[0].stage == 0)
            {
                return base.findTarget(g);
            }
            Monster bestTarget = null;
            foreach (Monster m in g.pageGame.getObjectManager().GetMonsters())
            {
                if (!m.BeingEffectedBy("Burning") && canTarget(m, g))
                {
                    if (bestTarget == null || bestTarget.distance < m.distance)
                    {
                        bestTarget = m;
                    }
                }
            }
            if (bestTarget != null)
            {
                fire(g, bestTarget);
                return true;
            }
            return base.findTarget(g);
        }
        protected override void fire(Game1 g, Monster target)
        {
            new Sound(Sounds.shoot_1, 0.05f).play(g);
            int doubleDamage = 1;
            if (g.levelMap.playerData.starUpgrades["ARCHER4"] && new Random().Next(100) < 8)
            {
                doubleDamage = 2;
            }
            if (powers[0].stage > 0)
            {
                if (activeVolly)
                {
                    g.pageGame.getObjectManager().Add(new FireArrow((int)GetPosCenter().X, (int)GetPosCenter().Y, target, this, 500f)
                    {
                        Damage = damage * doubleDamage
                    }, g);
                }
                else
                {
                    g.pageGame.getObjectManager().Add(new FireArrow((int)GetPosCenter().X, (int)GetPosCenter().Y, target, this)
                    {
                        Damage = damage * doubleDamage
                    }, g);
                }
                
            }
            else
            {
                base.fire(g, target);
            }
            
            //target.takeDamage(this.damage, g);
        }
        public override Tower LoadUpgrades(Game1 g)
        {
            if (g.levelMap.playerData.starUpgrades["ARCHER2"])
            {
                cost -= 50;
            }
            return base.LoadUpgrades(g);
        }
    }
}

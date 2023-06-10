using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using TestGame.Graphics;
using TestGame.Objects.Monsters;
using TestGame.Objects.Projectile;
using TestGame.Objects.Towers.TowerPowers;

namespace TestGame.Objects.Towers
{
    public class ArcherTower_Sniper : ArcherTower
    {
        private TimeSpan vollyTime = new TimeSpan(), killerTime = new TimeSpan();
        public ArcherTower_Sniper(int x, int y) : base(x, y)
        {
            name = "Sniper tower";
            this.damage = 16;
            this.reloadTimer = new TimeSpan(0,0, 0, 0, 600);
            this.range = 250;
            cost = 300;
            sprite = new Sprite(Textures.archerTower_sniper);
            optionsID = new List<int>() { };
            powers = new List<TowerPower>() {
                new TowerPower {
                    name = "Arrow frenzy",
                    desc="Fire at 10 random targets. CD: 16s",
                    color = Color.Yellow,
                    cost=250,
                    icon = new Sprite(Textures.arrow),
                    coolDown = TimeSpan.FromSeconds(16)
                },
                new TowerPower {
                    name = "Dealy Arrow",
                    desc="Shoot an arrow dealing 80! damage. CD: 12s",
                    color = Color.Purple,
                    cost=250,
                    icon =  new Sprite(Textures.icons, new Rectangle(32 * 0, 32 * 0, 32, 32)),
                    coolDown = TimeSpan.FromSeconds(12)
                }
            };

        }
        public override void Update(GameTime gt, Game1 g)
        {
            base.Update(gt, g);
            if (powers[0].stage > 0)
            {
                
                vollyTime += gt.ElapsedGameTime;
                if (vollyTime.TotalSeconds >= powers[0].coolDown.TotalSeconds)
                {
                    Random rnd = new Random();
                    foreach (Monster m in g.pageGame.getObjectManager().GetMonsters().FindAll(m => canTarget(m, g)).OrderBy(x => rnd.Next()).Take(10))
                    {
                        fire(g, m);
                    }
                    vollyTime = new TimeSpan();
                }
            }
            if (powers[1].stage > 0)
            {

                killerTime += gt.ElapsedGameTime;
                if (killerTime.TotalSeconds >= powers[1].coolDown.TotalSeconds)
                {
                    Monster m = findMonster(g);
                    if (m != null)
                    {
                        killerTime = new TimeSpan();
                        attackSound.play(g);
                        g.pageGame.getObjectManager().Add(new Arrow((int)GetPosCenter().X, (int)GetPosCenter().Y, m, this, 80) { 
                            Width = 24,
                            Height = 24
                        });
                    }
                }
            }
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

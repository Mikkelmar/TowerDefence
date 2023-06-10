using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;
using TestGame.Objects.Monsters;
using TestGame.Objects.Particles;
using TestGame.Objects.Projectile;
using TestGame.Objects.Soldiers;
using TestGame.Objects.Towers.SpawnTower;
using TestGame.Objects.Towers.TowerPowers;

namespace TestGame.Objects.Towers
{
    public class ChaosTower_Crazy : ChaosTower
    {

        private TimeSpan spawnSMoke = TimeSpan.FromMilliseconds(600);
        public ChaosTower_Crazy(int x, int y) : base(x, y) {
            name = "Chaos unleashed";
            this.damage = 10;
            this.range = 180;
            cost = 240;
            sprite = new Sprite(Textures.chaosTower_crazy);
            optionsID = new List<int>() { };
            this.reloadTimer = new TimeSpan(0, 0, 0, 1, 800);
            this.spawnTimer = new TimeSpan(0, 0, 0, 4, 800);
            orb = new ChaosBall(-1, -50, this, size: 14, speed: 210f) {shakeVibe = false};
            powers = new List<TowerPower>() {
                new TowerPower {
                    name = "Collapse",
                    desc="Your matter orbs deal more damage",
                    cost=150,
                    icon = new Sprite(Textures.gunpowder),
                    color = Color.DarkOrange,
                    nextTier = new TowerPower {
                        name = "Collapse",
                        desc="Your matter orbs deal more damage",
                        cost=150,
                        icon = new Sprite(Textures.gunpowder),
                    }
                },
                new TowerPower {
                    name = "Greater madness",
                    desc="Your matter orbs spawn quicker",
                    cost=150,
                    icon = new Sprite(Textures.ruby),
                    color = Color.DarkRed,
                    coolDown = TimeSpan.FromMilliseconds(400),
                    nextTier =new TowerPower {
                        name = "Greater madness",
                        desc="Your matter orbs spawn quicker",
                        cost=120,
                        icon = new Sprite(Textures.ruby),
                        nextTier =new TowerPower {
                            name = "Greater madness",
                            coolDown = TimeSpan.FromMilliseconds(600),
                            desc="Your matter orbs spawn quicker",
                            cost=120,
                            icon = new Sprite(Textures.ruby)
                        }
                    }
                },
                new TowerPower {
                    name = "Void fiend",
                    desc="Summon a void fiend to fight for you",
                    cost=180,
                    icon = new Sprite(Textures.tomb),
                    color = Color.DarkOrange,
                    nextTier = new TowerPower {
                        name = "Collapse",
                        desc="Your matter orbs deal more damage",
                        cost=200,
                        icon = new Sprite(Textures.tomb),
                    }
                }
            };
        }
        protected override void alertBuy(Game1 g, TowerPower tp)
        {
            if (powers.IndexOf(tp) == 2)
            {
                capacity++;
                canSelectTarget = true;
                spawnMinion(g);
            }
            else if (powers.IndexOf(tp) == 1)
            {

                reloadTimer -= powers[1].coolDown;
                
            }
        }
        protected override Soldier getMinion()
        {
            VoidFiend soldier = new VoidFiend((int)GetPosCenter().X, (int)GetPosCenter().Y, spriteTexture: new Sprite(Textures.voidFiend))
            {
                armor = Creature.AmourLevels.Low,
                damage = damage,
                Width = 42,
                Height = 42,
                Speed = 80f,
                attackSpeed = TimeSpan.FromMilliseconds(1800),
                baseHp = 200,
                hp = 200,
                name = "Void fiend"
            };
            return soldier;
        }
        public override void Update(GameTime gt, Game1 g)
        {
            spawnSMoke += gt.ElapsedGameTime;
            if (spawnSMoke.TotalMilliseconds > 1000)
            {
                spawnSMoke = new TimeSpan();
                new SmokeParticle(new Vector2(X + 16, Y - 16), 32, 1000).Spawn(g);
                new SmokeParticle(new Vector2(X + 28, Y + 8), 32, 1000).Spawn(g);
                new SmokeParticle(new Vector2(X + 2, Y + 2), 32, 1000).Spawn(g);
            }
            if (orb.canFire)
            {
                if (findTarget(g))
                {
                    //
                }
            }
            currentTimer += gt.ElapsedGameTime;
            if (currentTimer >= reloadTimer)
            {
                Random rnd = new Random();
                g.pageGame.getObjectManager().Add(new MiniChaosBall((int)GetPosCenter().X + rnd.Next(65) - 32, (int)GetPosCenter().Y + rnd.Next(65) - 32, null, this) 
                { 
                    range = this.range,
                    Damage = (int)(this.damage/2)+(powers[0].stage*3)
                }, g);
                currentTimer = new TimeSpan(0, 0, 0);
            }
            if (capacity > 0)
            {
                updateMinionSpawn(gt, g);
            }
        }
    }
}

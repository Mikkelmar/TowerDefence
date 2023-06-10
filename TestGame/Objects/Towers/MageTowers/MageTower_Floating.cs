using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TestGame.Graphics;
using TestGame.Managers;
using TestGame.Objects.Monsters;
using TestGame.Objects.Particles;
using TestGame.Objects.Projectile;
using TestGame.Objects.Towers.TowerPowers;

namespace TestGame.Objects.Towers
{
    public class MageTower_Floating : MageTower
    {
        private float moveSpeed = 40f;
        private Vector2 origin;
        SimpleParticle hole;
        private TimeSpan vibeTime = new TimeSpan();
        private TimeSpan spawnTimer = new TimeSpan();
        private int orbs = 0;
        private List<OrbitBall> orbitBalls = new List<OrbitBall>();
        private static Sound teleportSound = new Sound(Sounds.teleport, 0.5f, SoundManager.types.Tower);
        public MageTower_Floating(int x, int y) : base(x, y)
        {
            name = "Floating tower";
            this.damage = 23;
            this.reloadTimer = new TimeSpan(0, 0, 0, 0, 760);
            this.range = 140;
            cost = 300;
            sprite = new Sprite(Textures.mageTower_floating);
            optionsID = new List<int>() { };
            powers = new List<TowerPower>() {
                new TowerPower {
                    name = "Teleport",
                    desc="Teleports instead of moving",
                    color = Color.Cyan,
                    cost=100,
                    icon = new Sprite(Textures.teleport),
                },{
                new TowerPower {
                    name = "Spawn orbs",
                    desc="Spawn sloworbs. CD: 8s",
                    cost=300,
                    icon = new Sprite(Textures.sticky_bombs_icon),
                    coolDown = TimeSpan.FromSeconds(8),
                    nextTier =new TowerPower {
                        name = "Spawn orbs",
                        desc="Spawn sloworbs. CD: 6s",
                        cost=150,
                        icon = new Sprite(Textures.sticky_bombs_icon),
                        coolDown = TimeSpan.FromSeconds(6),
                        nextTier =new TowerPower {
                            name = "Spawn orbs",
                            desc="Spawn sloworbs. CD: 4s",
                            cost=150,
                            icon = new Sprite(Textures.sticky_bombs_icon),
                            coolDown = TimeSpan.FromSeconds(4)
                            }
                        }
                    }
                },{
                new TowerPower {
                    name = "Orbit",
                    desc="Magic orb floating in orbit",
                    color = Color.DarkCyan,
                    cost=150,
                    icon = new Sprite(Textures.mageball),
                    nextTier = new TowerPower {
                        name = "Orbit",
                        desc="Another one",
                        cost=150,
                        icon = new Sprite(Textures.mageball),
                        }
                    }
                }
            };
            drawGround = false;
            canSelectTarget = true;
        }
        public override void Init(Game1 g)
        {
            base.Init(g);
            origin = new Vector2(X, Y);
            hole = new SimpleParticle(X+Width/2, Y+Height/2+16, (int)Width, (int)Height, new Sprite(Textures.hole));
            hole.Spawn(g);
            X -= 16;
            shadow = new Shadow(position, this,32);
            g.pageGame.getObjectManager().Add(shadow, g);
        }
        public override void Destroy(Game1 g)
        {
            base.Destroy(g);
            g.pageGame.getObjectManager().Remove(hole, g);
            g.pageGame.getObjectManager().Remove(shadow, g);
            foreach(OrbitBall o in orbitBalls)
            {
                g.pageGame.getObjectManager().Remove(o, g);
            }
        }
        protected override void fire(Game1 g, Monster target)
        {
            base.fire(g, target);
            
        }
        public override void Update(GameTime gt, Game1 g)
        {
            if (powers[2].stage > orbs)
            {
                OrbitBall o = new OrbitBall((int)X, (int)Y, this);
                g.pageGame.getObjectManager().Add(o, g);
                orbitBalls.Add(o);
                orbs++;
            }
            if (targetPos.Length() != 0)
            {
                
                Vector2 newvector = new Vector2(targetPos.X - X-32, targetPos.Y - 32 - Y);
                if(newvector.Length() > 12)
                {
                    
                if (powers[0].stage > 0)
                    {
                        teleportSound.play(g);
                        g.pageGame.getObjectManager().Add(
                            new FadingParticle(new Vector2(X + 32, Y + 32),
                            new Sprite(Textures.teleport),
                            TimeSpan.FromMilliseconds(1600),
                            64), g);
                        X = targetPos.X - 32;
                        Y = targetPos.Y - 32;
                        g.pageGame.getObjectManager().Add(
                            new FadingParticle(new Vector2(X+32, Y + 32),
                            new Sprite(Textures.teleport),
                            TimeSpan.FromMilliseconds(1600),
                            64), g);
                        vibeTime = new TimeSpan();
                    }
                    else
                    {
                        float distance = (float)(moveSpeed * Drawing.delta);
                        newvector = Vector2.Normalize(newvector) * distance;
                        SetPosition(X + Math.Min(Math.Max(newvector.X, -distance), distance), Y + Math.Min(Math.Max(newvector.Y, -distance), distance));
                    }
                }
               
            }
            vibeTime += gt.ElapsedGameTime;
            if (vibeTime.TotalSeconds <= 100 / moveSpeed)
            {
                Y += Drawing.delta * moveSpeed / 10;
            }
            else if (vibeTime.TotalSeconds <= 200 / moveSpeed)
            {
                Y -= Drawing.delta * moveSpeed / 10;
            }
            else
            {
                vibeTime = new TimeSpan();
            }
            base.Update(gt, g);
            spawnTimer += gt.ElapsedGameTime;
            if (powers[1].stage > 0)
            {
                if (spawnTimer >= powers[1].coolDown)
                {
                    spawnTimer = new TimeSpan();
                    g.pageGame.getObjectManager().Add(
                    new SlowBomb((int)X+16, (int)Y+32, 100f)
                    {
                        Damage = 2
                    });
                }
            }
        }
        public override void Sell(Game1 g)
        {
            //TODO: MONEY???
            g.pageGame.getObjectManager().Add(new Plot((int)origin.X + 32, (int)origin.Y + 32), g);
            g.pageGame.getObjectManager().Remove(this, g);
            g.pageGame.getHudManager().closeActiveObject(g);
        }

    }
}

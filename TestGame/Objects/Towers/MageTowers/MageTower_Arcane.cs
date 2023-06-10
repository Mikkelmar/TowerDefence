using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;
using TestGame.Managers;
using TestGame.Objects.Monsters;
using TestGame.Objects.Particles;
using TestGame.Objects.Projectile;
using TestGame.Objects.Towers.TowerPowers;

namespace TestGame.Objects.Towers
{
    public class MageTower_Arcane : MageTower
    {
        private TimeSpan teleportTimer = new TimeSpan();
        private static Sound teleportSound = new Sound(Sounds.teleport, 0.5f, SoundManager.types.Tower);
        public MageTower_Arcane(int x, int y) : base(x, y)
        {
            name = "Arcane tower";
            this.damage = 35;
            this.reloadTimer = new TimeSpan(0, 0, 0, 0, 900);
            this.range = 180;
            cost = 300;
            sprite = new Sprite(Textures.mageTower_arcane);
            optionsID = new List<int>() { };
            powers = new List<TowerPower>() {
                new TowerPower {
                    name = "teleport",
                    desc="Teleprt a group of enemies back. cd: 14s",
                    cost=300,
                    icon = new Sprite(Textures.teleport),
                    color = Color.Cyan,
                    coolDown =  new TimeSpan(0, 0, 0, 14),
                    nextTier =  new TowerPower {
                        name = "teleport",
                        desc="Teleprt a group of enemies back. cd: 11s",
                        cost=100,
                        icon = new Sprite(Textures.teleport),
                        coolDown =  new TimeSpan(0, 0, 0, 11),
                        nextTier = new TowerPower {
                            name = "teleport",
                            desc="Teleprt a group of enemies back. cd: 8s",
                            cost=100,
                            icon = new Sprite(Textures.teleport),
                            coolDown =  new TimeSpan(0, 0, 0, 8),
                        }
                    }
                },{
                new TowerPower {
                    name = "Explosive orbs",
                    color = Color.LightBlue,
                    desc="Primary fire explodes on impact and deals ao damage",
                    cost=300,
                    icon = new Sprite(Textures.mageball),
                    } 
                }
            };
        }
        protected override void fire(Game1 g, Monster target)
        {
            if(powers[1].stage > 0)
            {
                attackSound.play(g);
                g.pageGame.getObjectManager().Add(new ExplosiveMageBall((int)GetPosCenter().X, (int)GetPosCenter().Y, target, this));
            }
            else {
                base.fire(g, target);
            }
            
        }
        public override void Update(GameTime gt, Game1 g)
        {
            base.Update(gt, g);
            
            if (powers[0].stage > 0)
            {
                if (teleportTimer >= powers[0].coolDown)
                {
                    Monster monster = findMonster(g);
                    if(monster != null)
                    {
                        teleportSound.play(g);
                        teleportTimer = new TimeSpan();
                        Vector2 pos = monster.path.GetPos(monster.distance);
                        g.pageGame.getObjectManager().Add(
                            new FadingParticle(new Vector2(pos.X - 32, pos.Y - 32),
                            new Sprite(Textures.teleport),
                            TimeSpan.FromMilliseconds(1600),
                            64), g);

                        List<GameObject> list = g.pageGame.getObjectManager().GetAllObjectsWith(p => p is Monster && !(p is Boss) && p.DistanceTo(monster.position) < 60+(powers[0].stage*10) );
                        foreach (GameObject o in list)
                        {
                            Monster m = (Monster)o;
                            m.distance -= 230;
                            m.path = monster.path;
                        }

                        pos = monster.path.GetPos(monster.distance);
                        g.pageGame.getObjectManager().Add(
                            new FadingParticle(new Vector2(pos.X-32,pos.Y-32),
                            new Sprite(Textures.teleport),
                            TimeSpan.FromMilliseconds(1600), 
                            64), g);
                    }
                    
                }
                else
                {
                    teleportTimer += gt.ElapsedGameTime;
                }
            }
        }
 
    }
}

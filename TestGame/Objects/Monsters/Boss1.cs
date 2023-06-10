using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using TestGame.Graphics;
using TestGame.Managers;
using TestGame.Objects.MapObjects;
using TestGame.Objects.Projectile;
using TestGame.Objects.Towers;
using TestGame.Objects.Towers.SpawnTower;
using TestGame.Pages;

namespace TestGame.Objects.Monsters
{
    public class Boss1 : Boss
    {
        private static Sound summonRoatSound = new Sound(Sounds.Monster_Groan1, 3f, SoundManager.types.Monster);
        private static Sound summonVinesSound = new Sound(Sounds.Monster_Roar2, 3f, SoundManager.types.Monster);
        
        public Boss1(Path path, int startDistance = 0) : base(path, width: 64, height: 64, -90)
        {

            attackDamage = 60;
            attackSpeed = new TimeSpan(0, 0, 0, 1, 200);
            Speed = 20;
            hp = 2800;
            sprite = new Sprite(Textures.monster_big);
            name = "Forest beast";
            description = "The guardian of the forest has come to face you, behold it's deformity, it's terror, and it's wrath...";
            coolDowns = new List<TimeSpan>() { TimeSpan.FromSeconds(15), TimeSpan.FromSeconds(23) };
            bossMusic = Sounds.bossFight1;
        }
        
        private int spawnType = -1, scaleingPower = 0;
        private bool summoning = false;
        private TimeSpan animationTime;
        public override void Update(GameTime gt, Game1 g)
        {
            if (summoning)
            {
                animationTime -= gt.ElapsedGameTime;
                if(animationTime.TotalMilliseconds <= 0)
                {
                    summoning = false;
                    sprite = new Sprite(Textures.monster_big);
                }
                else
                {
                    return;
                }
            }
            base.Update(gt, g);
        }
        protected override void activatePower(Game1 g, int i)
        {
            if(i == 0)
            {
                animationTime = TimeSpan.FromSeconds(2);
                summoning = true;
                summonRoatSound.play(g);
                sprite = new Sprite(Textures.monster_tank_animation);
                if (spawnType == 1)
                {
                    for (int a = 0; a < 6 + Math.Max(0,9-3*scaleingPower); a++)
                    {
                        
                        float midway = (g.pageGame.sceneManager.GetScene().Paths[0].totalDistance + g.pageGame.sceneManager.GetScene().Paths[1].totalDistance - (path.totalDistance)) / 2;
                        if (g.pageGame.sceneManager.GetScene().Paths[1].totalDistance - midway > distance){
                                g.pageGame.getObjectManager().Add(new HelmetMonster(g.pageGame.sceneManager.GetScene().Paths[1], (int)distance), g);
                        }
                        else
                        {
                            g.pageGame.getObjectManager().Add(new HelmetMonster(g.pageGame.sceneManager.GetScene().Paths[0], 
                                (int)(path.totalDistance-distance)), 
                                g);
                        }
                        
                        
                    }
                }
                else
                {
                    for(int pi = 0;pi<4;pi++)
                    {
                        Path p = g.pageGame.sceneManager.GetScene().Paths[pi];
                        for (int a = 0; a < (scaleingPower < 2 ? 4 : 0) + 8; a++)
                        {
                            g.pageGame.getObjectManager().Add(new SpeedMonster(p, -30 * a), g);
                        }
                    }
                }
                spawnType *= -1;
                
            }
            if (i == 1)
            {
                animationTime = TimeSpan.FromSeconds(2);
                summoning = true;
                summonVinesSound.play(g);
                sprite = new Sprite(Textures.monster_tank_animation2);
                Random rnd = new Random();
                foreach (Tower t in g.pageGame.getObjectManager().gameObjects.FindAll(m => (m is Tower) && !(m is SoldierTower) && !(m is Plot)).OrderBy(x => rnd.Next()).Take(2+ scaleingPower))
                {
                    g.pageGame.getObjectManager().Add(new VeinOrb((int)X,(int)Y,t), g);
                }
                scaleingPower++;
            }
        }
    }
}

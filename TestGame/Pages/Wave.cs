using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TestGame.Graphics;
using TestGame.Huds;
using TestGame.Huds.PopupDisplays;
using TestGame.Managers;
using TestGame.Objects.Monsters;

namespace TestGame.Pages
{
    public class Wave
    {
        public TimeSpan startCoolDown, WaveCompletedTime = new TimeSpan(0);
        private TimeSpan spawningTime = new TimeSpan(0);
        public Scene level;
        public Dictionary<int, string> monsterSpawnTimer = new Dictionary<int, string>();
        public Wave(Scene scene)
        {
            level = scene;
        }
        public void AddMonsterSpawns(int delay, string data)
        {
            monsterSpawnTimer.Add(delay, data);
        }

        public void Update(GameTime gt, Game1 g)
        {
            if(monsterSpawnTimer.Count == 0)
            {
                WaveCompletedTime += gt.ElapsedGameTime;
            }
            else
            {
                spawningTime += gt.ElapsedGameTime;
            }
            
            foreach(int spawnTime in monsterSpawnTimer.Keys)
            {
                if(spawningTime.TotalMilliseconds >= spawnTime)
                {
                    //string name:ammount:pathID
                    string[] _subStrings = monsterSpawnTimer[spawnTime].Split(":");

                    Monster monsterSPawn = ObjectCreator.createMonster(_subStrings[0], level.Paths[Int32.Parse(_subStrings[2])]);
                    if (monsterSPawn != null)
                    {
                        for(int i = 0; i < Int32.Parse(_subStrings[1]); i++)
                        {
                            monsterSPawn = (ObjectCreator.createMonster(_subStrings[0], level.Paths[Int32.Parse(_subStrings[2])]));
                            monsterSPawn.distance -= i * 6;
                            if(monsterSPawn is Boss)
                            {
                                //Spawner kun boss i normal mode
                                if(g.pageGame.sceneManager.GetScene().mode == 0)
                                {
                                    g.pageGame.sceneManager.GetScene().waveManager.boss = (Boss)monsterSPawn;
                                }           
                            }
                            else
                            {
                                g.pageGame.getObjectManager().Add(monsterSPawn, g);
                            }
                            
                        }
                    }
                    monsterSpawnTimer.Remove(spawnTime);

                    //TODO vurdere om if check skal gjøres her eller i handleren
                    g.pageGame.sceneManager.GetScene().discoverMonsterHandler.addNewMonster(g, monsterSPawn);
                    
                    
                }
            }
        }
    }
}

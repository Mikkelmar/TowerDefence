using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TestGame.Objects.Monsters;
using TestGame.Pages;

namespace TestGame.Managers
{
    public class WaveManager
    {
        public int waveNumber = 0;
        public List<Wave> waves = new List<Wave>();
        public bool gameStarted = false;
        public Boss boss;
        public bool hasNextWave() { return waves.Count > waveNumber+1; }
        public TimeSpan getTimeUntillNextWave() {
            if (hasNextWave()) { return new TimeSpan(); }
            return getNextWaveStartTime() - getTimeSinceWaveCompleted();
        }
        public TimeSpan getNextWaveStartTime()
        {
            return waves[waveNumber + 1].startCoolDown;
        }
        public TimeSpan getTimeSinceWaveCompleted()
        {
            return waves[waveNumber].WaveCompletedTime;
        }
        
        public bool waveComplete() {
            if(!(waves.Count > waveNumber))
            {
                return false;
            }
            return waves[waveNumber].WaveCompletedTime.TotalSeconds > 1;  }
        public void NextWave(Game1 g)
        {
            if (hasNextWave())
            {
                waveNumber++;
            }
        }
        public void Update(GameTime gt, Game1 g)
        {
            if (gameStarted)
            {
                waves[waveNumber].Update(gt, g);
                if (hasNextWave())
                {
                    if (waves[waveNumber].WaveCompletedTime >= waves[waveNumber + 1].startCoolDown)
                    {
                        NextWave(g);
                    }
                }
            }
            if(!hasNextWave() && waveComplete())
            {
                if(g.pageGame.getObjectManager().GetMonsters().Count <= 0)
                {
                    //win
                    if(boss == null)
                    {
                        g.pageGame.player.Win(g);
                    }
                    else
                    {
                        g.pageGame.getObjectManager().Add(boss, g);
                        boss = null;
                    }
                    

                }
            }
        }
    }
}

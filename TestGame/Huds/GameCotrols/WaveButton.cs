using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TestGame.Graphics;
using TestGame.Managers;
using TestGame.Objects.Particles;
using TestGame.Objects.Towers;
using TestGame.Objects.Towers.SpawnTower;

namespace TestGame.Huds
{
    public class WaveButton : Button
    {
        public WaveButton(int x, int y) : base(x,y)
        {
            relative = true;
        }

        private static Sound moneySound = new Sound(Sounds.sell, 0.4f, SoundManager.types.Normal);
        public override void activate(Game1 g)
        {
            WaveManager wm = g.pageGame.sceneManager.GetScene().waveManager;
            if (!wm.gameStarted)
            {
                wm.gameStarted = true;
                MediaPlayer.IsRepeating = true;
                if(g.pageGame.sceneManager.GetScene().levelSong != null)
                {
                    MediaPlayer.Play(g.pageGame.sceneManager.GetScene().levelSong); 
                }
                //If soldier power BARRACKS2, build a random soldier tower
                if (g.levelMap.playerData.starUpgrades["BARRACKS2"])
                {
                    List<GameObject> plots = g.pageGame.getObjectManager().GetAllObjectsWith(o => o is Plot);
                    if(plots.Count != 0)
                    {
                        var random = new Random();
                        Plot plot = (Plot)plots[random.Next(plots.Count)];
                        foreach (Tower t in plot.options)
                        {
                            if (t is SoldierTower)
                            {
                                g.pageGame.getObjectManager().Add(t, g);
                                g.pageGame.getObjectManager().Remove(plot, g);
                                break;
                            }
                        }
                    }
                }

            }
            else
            {
                if (wm.waveComplete() && wm.hasNextWave())
                {
                    
                    double completePercent = wm.getTimeSinceWaveCompleted().TotalMilliseconds / wm.getNextWaveStartTime().TotalMilliseconds;
                    int bonusMoney = Math.Max((int)(g.pageGame.sceneManager.GetScene().waveStartMoneyValue * (1-completePercent)), 1);
                    g.pageGame.player.money += bonusMoney;
                    g.pageGame.player.rechargePowers(wm.getNextWaveStartTime()-wm.getTimeSinceWaveCompleted(), g);
                    g.pageGame.getObjectManager().Add(new DamageParticle(new Vector2(X+80, Y), bonusMoney), g);
                    wm.NextWave(g);
                    moneySound.play(g);

                }
            }
            //TODO: REMOVE (JUST FOR TESTING)
            //g.pageGame.player.takeDamage(100, g);
        }
        public override void Draw(Game1 g)
        {
            base.Draw(g);
            Vector2 cords = GetPos(g);
            if (g.pageGame.sceneManager.GetScene().waveManager.hasNextWave()) { 
                double completePercent = g.pageGame.sceneManager.GetScene().waveManager.getTimeSinceWaveCompleted().TotalMilliseconds / g.pageGame.sceneManager.GetScene().waveManager.getNextWaveStartTime().TotalMilliseconds;
                Drawing.FillRect(new Rectangle((int)cords.X, (int)cords.Y, Width, (int)(Height*completePercent)), Color.Yellow, depth*0.1f, g);
            }
            Drawing.DrawText("GO", cords.X + 10, cords.Y + 8, layerDepth: depth * 0.5f);
        }
    }
}

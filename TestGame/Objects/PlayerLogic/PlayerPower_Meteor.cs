using Microsoft.Xna.Framework;
using System;
using TestGame.Graphics;
using TestGame.Managers;
using TestGame.Objects.Projectile;
using TestGame.Pages;

namespace TestGame.Objects.PlayerLogic
{
    public class PlayerPower_Meteor : PlayerPower
    {

        private static Sound spawnSound = new Sound(Sounds.fireSpawn, 1f, SoundManager.types.Normal);
        private int yDefaultOffset = Drawing.WINDOW_HEIGHT;
        public PlayerPower_Meteor(int x, int y) : base(x,y)
        {
            icon = new Sprite(Textures.meteor);
            
            coolDown = TimeSpan.FromSeconds(50);
            currentTime = coolDown;
        }

        protected override void triggerPower(float x, float y, Game1 g)
        {
            spawnSound.play(g);
            int damage = 12;
            if (g.levelMap.playerData.starUpgrades["METEOR1"])
            {
                damage += 10;
            }
            int meteorAmmount = 4;
            if (g.levelMap.playerData.starUpgrades["METEOR0"])
            {
                meteorAmmount += 2;
            }
            if (g.levelMap.playerData.starUpgrades["METEOR4"])
            {
                if(g.pageGame.sceneManager.GetScene().Paths.Count != 0)
                {
                    
                    Random rnd = new Random();
                    for (int i = 0; i < 6; i++)
                    {
                        Path path = g.pageGame.sceneManager.GetScene().Paths[rnd.Next(g.pageGame.sceneManager.GetScene().Paths.Count)];
                        float totDistance = path.totalDistance;
                        Vector2 spawnPos = path.GetPos(rnd.Next((int)totDistance - 200) + 100);
                        g.pageGame.getObjectManager().Add(
                            new Meteor((int)spawnPos.X, (int)spawnPos.Y - yDefaultOffset -350+ rnd.Next(300), true)
                            {
                                targetPos = new Vector2(spawnPos.X, spawnPos.Y),
                                Damage = damage
                            }
                        );
                    }
                        
                }
                
            }

            for (int i = 0; i < meteorAmmount; i++)
            {
                bool spawnFire = false;
                if(g.levelMap.playerData.starUpgrades["METEOR3"])//i == 0 && 
                {
                    spawnFire = true;
                }
                Random rnd = new Random();
                Vector2 randomOffset = new Vector2(rnd.Next(31) - 15, rnd.Next(31) - 15);
                g.pageGame.getObjectManager().Add(
                new Meteor((int)(x+ randomOffset.X), (int)(y+ randomOffset.Y- yDefaultOffset - rnd.Next(10 * i) - i * 40), spawnFire) 
                {
                    targetPos = new Vector2(x + randomOffset.X, y + randomOffset.Y),
                    Damage = damage
                });
                if (g.levelMap.playerData.starUpgrades["METEOR2"])
                {
                    coolDown = TimeSpan.FromSeconds(40);
                }
            }
            
        }
    }
}

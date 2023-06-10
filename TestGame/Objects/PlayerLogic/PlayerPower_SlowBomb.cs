using Microsoft.Xna.Framework;
using System;
using TestGame.Graphics;
using TestGame.Managers;
using TestGame.Objects.Projectile;
using TestGame.Objects.StatusEffects;

namespace TestGame.Objects.PlayerLogic
{
    public class PlayerPower_SlowBomb : PlayerPower
    {
        private static Sound spawnSound = new Sound(Sounds.use, 1f, SoundManager.types.Normal);
        public PlayerPower_SlowBomb(int x, int y) : base(x,y)
        {
            icon = new Sprite(Textures.sticky_bombs_icon);
            coolDown = TimeSpan.FromSeconds(20);
            currentTime = coolDown;
        }

        protected override void triggerPower(float x, float y, Game1 g)
        {
            spawnSound.play(g);
            //ammount
            int spawnAmmount = 3;
            if (g.levelMap.playerData.starUpgrades["SLOW2"])
            {
                spawnAmmount++;
            }
            //damage
            int damage = 2;
            if (g.levelMap.playerData.starUpgrades["SLOW0"])
            {
                damage += 3;
            }
            //effect
            StatusEffect effect;
            if (g.levelMap.playerData.starUpgrades["SLOW4"])
            {
                effect = new Slow(-0.4f, TimeSpan.FromSeconds(4));
            }
            else if (g.levelMap.playerData.starUpgrades["SLOW1"])
            {
                effect = new Slow(0.4f, TimeSpan.FromSeconds(4));
            }
            else
            {
                effect = new Slow(0.5f, TimeSpan.FromSeconds(3));
            }

            //spawn
            for (int i = 0; i < spawnAmmount; i++)
            {
                Random rnd = new Random();
                    
                g.pageGame.getObjectManager().Add(
                new SlowBomb((int)x+rnd.Next(27)-13, (int)y+ rnd.Next(27)-13, 100f, effect.clone())
                {
                    Damage = damage
                });
            }
            if (g.levelMap.playerData.starUpgrades["SLOW3"])
            {
                coolDown = TimeSpan.FromSeconds(15);
            }

        }
    }
}

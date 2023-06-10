using Microsoft.Xna.Framework;
using System;
using TestGame.Graphics;
using TestGame.Managers;
using TestGame.Objects.Projectile;
using TestGame.Objects.StatusEffects;

namespace TestGame.Objects.PlayerLogic
{
    public class PlayerPower_FireOil : PlayerPower
    {
        private static Sound spawnSound = new Sound(Sounds.use, 1f, SoundManager.types.Normal);
        public PlayerPower_FireOil(int x, int y) : base(x,y)
        {
            icon = new Sprite(Textures.oil);
            coolDown = TimeSpan.FromSeconds(25);
            currentTime = coolDown;
        }

        protected override void triggerPower(float x, float y, Game1 g)
        {
            spawnSound.play(g);
            g.pageGame.getObjectManager().Add(
                new AreaOfEffect(
                    (int)x, 
                    (int)y,
                    new Burning(1, TimeSpan.FromSeconds(5), TimeSpan.FromMilliseconds(800)
                   ),
                    new Sprite(Textures.oil),
                    74
                 ), g);
            
        }
    }
}

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;

namespace TestGame.Objects.Particles
{
    public class Explotion : Particle
    {
        private int Size;
        private float rotation;
        private TimeSpan delay;
        private int explotionType;
        public Explotion(Vector2 pos, int Size, int delay =0, int explotionType=0) : base(pos, null)
        {
            
            Duration = new TimeSpan(0, 0, 0, 0, 600);
            Random rnd = new Random();
            this.Size = Size + (rnd.Next(16) - 8);
            rotation = (float)(Math.PI * rnd.Next(200))/100;
            this.delay = new TimeSpan(0, 0, 0, 0, delay);
            this.explotionType = explotionType;
            depth = 0.00000005f;

        }
        public override void Update(GameTime gt, Game1 g)
        {
            if(delay.TotalMilliseconds > 0)
            {
                delay -= gt.ElapsedGameTime;
            }
            else
            {
                base.Update(gt, g);
            }
            
        }
        private Sprite getExplotionStage()
        {
            double percentLeft = 1-(Duration.TotalMilliseconds / new TimeSpan(0, 0, 0, 0, 800).TotalMilliseconds);
            if(explotionType == 1)
            {
                return new Sprite(Textures.blueExplotion, new Rectangle(32 * (int)(percentLeft * 8), 0, 32, 32));
            }
            return new Sprite(Textures.explotionSheet, new Rectangle(32*(int)(percentLeft*8), 0,32,32)); 
        }

        public override void Draw(Game1 g)
        {
            if (!(delay.TotalMilliseconds > 0))
            {
                getExplotionStage().Draw(position, Size, Size, rotation: rotation, layerDepth: depth);
            }
                
        }
    }
}

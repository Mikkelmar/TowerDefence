using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;

namespace TestGame.Objects.Particles
{
    public class SmokeParticle : Particle
    {
        private int Size, totMiliseconds;
        public SmokeParticle(Vector2 pos, int Size, int totMiliseconds=600) : base(pos, null)
        {
            
            Duration = new TimeSpan(0, 0, 0, 0, totMiliseconds);
            this.totMiliseconds = totMiliseconds;
            this.Size = Size; 
        }
        public override void Update(GameTime gt, Game1 g)
        {
            base.Update(gt, g);
        }
        private Sprite getAnimationStage()
        {
            double percentLeft = 1-(Duration.TotalMilliseconds / totMiliseconds);
            return new Sprite(Textures.smoke, new Rectangle(32*(int)(percentLeft*8), 0,32,32)); 
        }

        public override void Draw(Game1 g)
        {

            getAnimationStage().Draw(position, width: Size, height: Size);

        }
    }
}

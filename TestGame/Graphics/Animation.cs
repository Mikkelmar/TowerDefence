using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestGame.Graphics
{
    public class Animation
    {
        private Texture2D images;
        private int width, height, currentFrame = 0, frames;
        private TimeSpan frameSpeed, currentTime = new TimeSpan();

        public Animation(Texture2D images, TimeSpan frameSpeed)
        {
            this.images = images;
            this.width = images.Height;
            this.height = images.Height;
            this.frameSpeed = frameSpeed;
            frames = (images.Width / images.Height)-1;
        }
        public void Update(GameTime gt, Game1 g)
        {
            currentTime += gt.ElapsedGameTime;
            if(currentTime >= frameSpeed)
            {
                currentTime = new TimeSpan();
                currentFrame++;
                if(currentFrame > frames)
                {
                    currentFrame = 0;
                }
            }
        }
        public Sprite getFrame()
        {
            return new Sprite(images, new Rectangle(width * currentFrame, 0, width, height));
        }
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TestGame.Graphics;

namespace TestGame.Objects.Particles
{
    public class Corps : Particle
    {
        private int direction;
        public Corps(Entity creature, Sprite sprite, int directionFacing = 1) : base(
            new Vector2(creature.position.X+ creature.Width / 2, creature.position.Y+ creature.Height/2), 
            sprite)
        {
            this.direction = directionFacing;
            depth = 0.9f;
            Width = creature.Width;
            Height = creature.Height;
            Duration = TimeSpan.FromSeconds(5);
        }

        public override void Draw(Game1 g)
        {
            if (sprite != null)
            {
                float rotation = (float)Math.PI * 0.5f* (-direction);
                int fallTime = 400;
                if (Duration.CompareTo(TimeSpan.FromMilliseconds(5000-fallTime)) >= 0){
                    rotation = (float)(Math.PI*.5*(TimeSpan.FromSeconds(5).TotalMilliseconds-Duration.TotalMilliseconds)/ fallTime) * (-direction);
                }
                SpriteEffects directionFacing = SpriteEffects.FlipHorizontally;
                if(direction != 1)
                {
                    directionFacing = SpriteEffects.None;
                }
                Vector2 drawPos = new Vector2(X , Y);
                sprite.Draw(drawPos, Width, Height, layerDepth: depth, 
                    rotation: rotation, 
                    alpha: (float)Math.Min(Math.Max(0f, (((float)Duration.TotalMilliseconds) / 4000)), .9f), 
                    origin: new Vector2(Width / 2, Height),
                    spriteEffects: directionFacing);

            }
        }
    }
}

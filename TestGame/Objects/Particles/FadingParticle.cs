using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TestGame.Graphics;

namespace TestGame.Objects.Particles
{
    public class FadingParticle : Particle
    {
        private TimeSpan startTime;
        public FadingParticle(Vector2 pos, Sprite sprite, TimeSpan time, int size=32) : base(pos, sprite)
        {
            Duration = time;
            startTime = time;
            Height = size;
            Width = size;
        }


        public override void Draw(Game1 g)
        {
            Vector2 drawPos = new Vector2(X, Y);
            sprite.Draw(drawPos, layerDepth: depth, alpha: (float)((Duration.TotalSeconds*1000 + Duration.Milliseconds)/(startTime.TotalSeconds * 1000 + startTime.Milliseconds)), width: (int)Width, height: (int)Height);
        }
    }
}

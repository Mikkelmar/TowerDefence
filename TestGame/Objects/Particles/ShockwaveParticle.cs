using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TestGame.Graphics;

namespace TestGame.Objects.Particles
{
    public class ShockwaveParticle : Particle
    {
        private TimeSpan startTime;
        private float FinalSize;
        public ShockwaveParticle(Vector2 pos, TimeSpan time, int size = 32) : base(pos, null)
        {
            Duration = time;
            startTime = time;
            FinalSize = size;

        }


        public override void Draw(Game1 g)
        {
            Width = (float)(1 - Duration.TotalMilliseconds / startTime.TotalMilliseconds) * FinalSize;
            Vector2 drawPos = new Vector2(X - Width / 2, Y - Width / 2);
            new Sprite(Textures.shockWave).Draw(drawPos, layerDepth: depth, width: (int)Width, height: (int)Width);
        }
    }
}

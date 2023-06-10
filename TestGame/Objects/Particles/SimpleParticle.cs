using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;

namespace TestGame.Objects.Particles
{
    public class SimpleParticle : Particle
    {
        public SimpleParticle(float x, float y, int width, int height, Sprite sprite) : base(x,y, sprite, width, height)
        {


        }
        public override void Update(GameTime gt, Game1 g)
        {
        }
    }
}

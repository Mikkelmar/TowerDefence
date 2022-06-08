using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;
using TestGame.Managers;

namespace TestGame.Objects.Particles
{
    public class Shadow : Particle
    {
        private GameObject follow;
        private float heightOffSet;
        public Shadow(Vector2 pos, GameObject follow, float heightOffSet=0) : base(pos, new Sprite(Textures.shadow), (int)follow.Width/2, (int)follow.Width / 2)
        {
            this.follow = follow;
            this.heightOffSet = heightOffSet;
            depth = 0.9f;
        }
        public override void Update(GameTime gt, Game1 g)
        {
            X = follow.X+ follow.Width/4;
            Y = follow.Y + follow.Height-(Height*2/3) + heightOffSet;
        }
    }
}

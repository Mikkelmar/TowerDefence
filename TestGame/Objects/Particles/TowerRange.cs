using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;
using TestGame.Managers;

namespace TestGame.Objects.Particles
{
    public class TowerRange : Particle
    {
        private GameObject follow;
        private float heightOffSet;
        public TowerRange(Vector2 pos, GameObject follow, float size, float heightOffSet=0) : base(new Vector2(pos.X- size/2, pos.Y - size / 2), new Sprite(Textures.range), (int)size, (int)size)
        {
            this.follow = follow;
            this.heightOffSet = heightOffSet;
            depth = 0.9f;
        }
        public override void Update(GameTime gt, Game1 g)
        {
        }
    }
}

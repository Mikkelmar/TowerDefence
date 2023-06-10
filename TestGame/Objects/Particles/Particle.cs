using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;
using TestGame.Managers;

namespace TestGame.Objects
{
    public class Particle : GameObject
    {
        protected TimeSpan Duration = new TimeSpan(0,0,1);
        protected Sprite sprite;
        public Particle(Vector2 pos, Sprite sprite, int width=64, int height=64) : this(pos.X, pos.Y, sprite, width, height)
        {
            depth = depth * depth; //??? why
        }
        public Particle(float x, float y, Sprite sprite, int width = 64, int height = 64) : base(x, y, width, height)
        {
            this.collision = false;
            this.solid = false;
            this.sprite = sprite;

        }
        public override void Destroy(Game1 g)
        {}
        public void Spawn(Game1 g)
        {
            g.pageGame.getObjectManager().Add(this, g);
        }

        public override void Draw(Game1 g)
        {
            if (sprite != null)
            {
                Vector2 drawPos = new Vector2(X - Width / 2, Y - Height / 2);
                sprite.Draw(drawPos, Width, Height, depth);

            }
        }

        public override void Init(Game1 g)
        {}

        public override void Update(GameTime gt, Game1 g)
        {
            Duration -= gt.ElapsedGameTime;
            if (Duration.CompareTo(TimeSpan.Zero) <= 0)
            {
                g.pageGame.getObjectManager().Remove(this, g);
            }
        }
    }
}

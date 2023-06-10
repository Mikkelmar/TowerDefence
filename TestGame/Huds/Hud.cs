using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestGame.Huds
{
    public abstract class Hud
    {

        public float X, Y;
        public int Width, Height;
        public float depth = 0.00000001f;
        public bool rendered = true, visiable = true;
        protected bool relative = false;

        protected Vector2 GetPos(Game1 g)
        {
            float cx = 0, cy = 0;
            if (relative)
            {
                cx = g.gameCamera.Position.X;
                cy = g.gameCamera.Position.Y;
            }
            return new Vector2(X + cx, Y + cy);
        }
        protected Rectangle GetRectangle(Game1 g)
        {
            float cx = 0, cy = 0;
            if (relative)
            {
                cx = g.gameCamera.Position.X;
                cy = g.gameCamera.Position.Y;
            }
            return new Rectangle(
                (int)(X + cx),
                (int)(Y + cy),
                Width,
                Height);
        }
        public virtual void Destroy(Game1 g)
        {

        }
        public virtual void Init(Game1 g)
        { }

        public abstract void Draw(Game1 g);
        
            //Drawing.FillRect(GetHitbox(), Color.Red, 0.000000001f, g);
           // sprite.Draw(Drawing._spriteBatch, this.position, depth, new Rectangle((int)this.X, (int)this.Y, (int)Width, (int)Height));
        
    }
}

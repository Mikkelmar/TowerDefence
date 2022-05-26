using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;
using TestGame.Managers;

namespace TestGame.Objects
{
    public abstract class Structure : GameObject
    {
        protected Sprite sprite;
        public Structure(int x, int y, int w, int h, int id, Texture2D texture=null) : base(x, y, w, h, id) {
            this.solid = true;
            if (texture != null) {
                sprite = new Sprite(texture);
            }
            
        }
        public override void Draw(Game1 g)
        {
            Drawing.FillRect(GetHitbox(), Color.Red, 0.000000001f, g);
            sprite.Draw(Drawing._spriteBatch, this.position, depth, new Rectangle((int)this.X, (int)this.Y, (int)Width, (int)Height));
        }
    }
}

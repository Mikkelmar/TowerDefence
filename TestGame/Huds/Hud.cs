using System;
using System.Collections.Generic;
using System.Text;

namespace TestGame.Huds
{
    public abstract class Hud
    {

        public float X, Y;
        public float depth = 0.00000000001f;
        public bool rendered = true, visiable = true;
        public abstract void Draw(Game1 g);
        
            //Drawing.FillRect(GetHitbox(), Color.Red, 0.000000001f, g);
           // sprite.Draw(Drawing._spriteBatch, this.position, depth, new Rectangle((int)this.X, (int)this.Y, (int)Width, (int)Height));
        
    }
}

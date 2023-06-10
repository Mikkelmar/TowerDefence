using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;
using TestGame.Objects.StatusEffects;

namespace TestGame.Objects.Projectile
{
    public class FirePit : AreaOfEffect
    {
        private float alpha = 1f;
        public FirePit(int x, int y, StatusEffect effect, Sprite sprite, int size) : base(x, y, effect, sprite, size)
        {
        }
        public override void Update(GameTime gt, Game1 g)
        {
            if (despawnTimer.TotalMilliseconds + (despawnTimer.TotalSeconds * 1000) < 3200)
            {
                alpha = (float)((despawnTimer.TotalMilliseconds + (despawnTimer.TotalSeconds * 1000) )/ 3200);
            }
            base.Update(gt, g);
            
        }
        public override void Draw(Game1 g)
        {
            base.Draw(g);
            Vector2 drawPos = new Vector2(X, Y);
            //Drawing.FillRect(GetHitbox(), Color.Red, 0.000000001f, g); //Debug hitboxes
            sprite.Draw(drawPos, width: Width, height: Height, layerDepth: depth, rotation: rotation, alpha: alpha);
        }
    }
}

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TestGame.Managers;

namespace TestGame.Huds
{
    public abstract class HoverHud : Hud, HoverLisner
    {
        protected bool BeingHoverd = false;
        public override void Init(Game1 g)
        {
            base.Init(g);
            //Debug.WriteLine(g.pageManager.GetPage());
            //Debug.WriteLine(this);
            g.pageManager.GetPage().mouseManager.AddHover(this, true);
            
        }
        public override void Destroy(Game1 g)
        {
            base.Destroy(g);
            g.pageManager.GetPage().mouseManager.RemoveHover(this);
        }
        protected virtual void TriggerHoverd(float x, float y, Game1 g)
        {

        }
        public void Hover(float x, float y, Game1 g)
        {
            Vector2 cords = GetPos(g);
            if (new Rectangle((int)cords.X, (int)cords.Y, Width, Height).Contains(new Vector2(x, y)))
            {
                if (!BeingHoverd) {
                    TriggerHoverd(x, y, g);
                }
                BeingHoverd = true;
                
            }
            else
            {
                BeingHoverd = false;
            }
        }
    }
}

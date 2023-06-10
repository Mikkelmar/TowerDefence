using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace TestGame.Huds.PopupDisplays.OptionScreen
{
    public class FullScreenDisplayButton : DisplayButton
    {
        public FullScreenDisplayButton(PopupDisplay pd, float x, float y) : base(pd, x,y, "FullScreen") { }
        public override void activate(Game1 g)
        {
            //Drawing.graphics.IsFullScreen = true;// !Drawing.graphics.IsFullScreen;
            //Drawing.graphics.ToggleFullScreen();
            if (!Drawing.graphics.IsFullScreen)
            {
                Drawing.graphics.PreferredBackBufferWidth = g.GraphicsDevice.Adapter.CurrentDisplayMode.Width;
                Drawing.graphics.PreferredBackBufferHeight = g.GraphicsDevice.Adapter.CurrentDisplayMode.Height;
                Drawing.graphics.ApplyChanges();
                Drawing.graphics.IsFullScreen = true;
                Drawing.graphics.ApplyChanges();
            }
            else
            {
                Drawing.graphics.IsFullScreen = false;
                Drawing.graphics.ApplyChanges();
            }
            
        }
    }
}

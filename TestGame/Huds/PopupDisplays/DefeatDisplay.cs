using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;
using TestGame.Managers;

namespace TestGame.Huds.PopupDisplays
{
    public class DefeatDisplay : Hud
    {
        private PopupDisplay pd;
        public DefeatDisplay(PopupDisplay pd)
        {
            this.pd = pd;
            X = pd.X + 200;
            Y = pd.Y + 50;

        }

        public override void Init(Game1 g)
        {
            base.Init(g);

            pd.hm.Add(new RestartButton(pd)
            {
                depth = pd.depth * 0.5f
            }, g);
            pd.hm.Add(new MapButton(pd, "Leave")
            {
                depth = pd.depth * 0.5f
            }, g);
        }

        public override void Draw(Game1 g)
        {
            
            Drawing.DrawText("Defeat", X, Y+20, scale: 3f, layerDepth: pd.depth*0.1f);
        }
    }
}

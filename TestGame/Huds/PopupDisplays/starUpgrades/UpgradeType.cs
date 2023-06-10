using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TestGame.Graphics;
using TestGame.Managers;

namespace TestGame.Huds.PopupDisplays.starUpgrades
{
    public class UpgradeType : Hud
    {

        private Sprite icon;
        private string text;
        public UpgradeType(PopupDisplay pd, float x, float y, Sprite icon, string text) 
        {
            X = pd.X + x;
            Y = pd.Y + y;
            this.text = text;
            this.icon = icon;
            depth = pd.depth * 0.1f;
            Width = 64;
            Height = 64;
        }


        public override void Draw(Game1 g)
        {
            //Sprite boarder = new Sprite(Textures.gui, new Rectangle(49 + 32, 97, 30, 30));
            //boarder.Draw(X, Y, Width, Height, depth);
            icon.Draw(X,Y, Width, Height, depth*0.3f);
            Drawing.DrawText(text, X+Width/2-TextHandler.textLength(text)* Math.Min(1f, TextHandler.GetFitScale(text, Width + Width / 2)) / 2, Y + Height, layerDepth: depth*0.1f, scale: Math.Min(1f, TextHandler.GetFitScale(text, Width + Width / 2)));
        }
    }
}

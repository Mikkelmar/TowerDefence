using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;
using TestGame.Objects.Towers;
using TestGame.Objects.Towers.TowerPowers;

namespace TestGame.Huds
{
    public class PowerInfo : Hud
    {
        private TowerPower power;
        private int size = 64;
        public PowerInfo(TowerPower power)
        {
            this.power = power;
            depth *= 0.0001f;
        }
        public override void Draw(Game1 g)
        {
            int boxSize = 160;
            Vector2 pos = g.pageGame.mouseManager.GetMousePos(g);
            new Sprite(Textures.gui, new Rectangle(96, 36, 26, 24)).Draw(pos.X + size / 4, pos.Y-32, boxSize+10, boxSize+10, layerDepth: depth*10);
            Drawing.DrawText(power.name.ToUpper(), pos.X+ size/2, pos.Y-12, scale: Math.Min(TextHandler.GetFitScale(power.name.ToUpper(), 130),1f), layerDepth: depth, color: power.color);
            //Drawing.DrawText(power.desc, pos.X + size / 2, pos.Y + 18, scale: 0.8f, layerDepth: depth);
            int i= 0;
            foreach(string s in TextHandler.FitText(power.desc, boxSize-22, 0.7f))
            {
                Drawing.DrawText(s, pos.X + size / 2, pos.Y + 18+i*(TextHandler.textHeight(s)*0.7f), scale: 0.7f, layerDepth: depth);
                i++;
            }
            




        }
    }
}

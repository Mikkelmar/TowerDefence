using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;
using TestGame.Objects.Towers;

namespace TestGame.Huds
{
    public class UpgradeInfo : Hud
    {
        private Tower tower;
        private int size = 64;
        public UpgradeInfo(Tower tower)
        {
            this.tower = tower;
            depth *= 0.0001f;
        }
        public override void Draw(Game1 g)
        {
            if(tower != null)
            {
                Vector2 pos = g.pageGame.mouseManager.GetMousePos(g);
                new Sprite(Textures.gui, new Rectangle(96, 36, 26, 24)).Draw(pos.X + size / 4, pos.Y-32, 140, 140, layerDepth: depth*10);
                Drawing.DrawText(tower.name, pos.X+ size/2, pos.Y-12, scale: TextHandler.GetFitScale(tower.name, 110), layerDepth: depth);
                Drawing.DrawText("Range: " + tower.range, pos.X + size / 2, pos.Y + 18, scale: 0.8f, layerDepth: depth);
                Drawing.DrawText("Damage: " + tower.damage, pos.X + size / 2, pos.Y + 36, scale: 0.8f, layerDepth: depth);
                Drawing.DrawText("Speed: " + (Math.Round(1/tower.fireRate, 1))+"/s", pos.X + size / 2, pos.Y + 54, scale: 0.8f, layerDepth: depth);
            }
            
        }
    }
}

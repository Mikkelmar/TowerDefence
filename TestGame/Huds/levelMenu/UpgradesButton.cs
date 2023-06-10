using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TestGame.Graphics;
using TestGame.Huds.PopupDisplays.starUpgrades;
using TestGame.Managers;
using TestGame.Objects.Particles;
using TestGame.Objects.Towers;

namespace TestGame.Huds.levelMenu
{
    public class UpgradesButton : Button
    {
        public UpgradesButton(int x, int y) : base(x,y)
        {
            relative = true;
        }

        public override void activate(Game1 g)
        {
            g.levelMap.hudManager.closeActiveObject(g);
            PopupDisplay pd = new PopupDisplay()
            {
                Width = 48 * 21,
                Height = 32 * 21
            };
            g.levelMap.hudManager.Add(pd, g);

            pd.hm.Add(new StarUpgradeDisplay(pd)
            {
                depth = pd.depth * 0.5f
            }, g);
        }
        
            
        public override void Draw(Game1 g)
        {
            base.Draw(g);
            Vector2 cords = GetPos(g);
            //Drawing.DrawText("Upgrades", cords.X + 4, cords.Y + 4, layerDepth: depth*0.5f);
            new Sprite(Textures.gold_star).Draw(cords.X + 10, cords.Y + 8, size: 26, layerDepth: depth * 0.5f);
            Drawing.DrawText(g.levelMap.playerData.getTotalStars(g).ToString(), cords.X + Width+4, cords.Y + 12, layerDepth: depth * 0.5f);
        }
    }
}

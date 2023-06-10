using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TestGame.Graphics;
using TestGame.Huds.PopupDisplays.heroUpgrades;
using TestGame.Huds.PopupDisplays.starUpgrades;
using TestGame.Managers;
using TestGame.Objects.Particles;
using TestGame.Objects.Towers;

namespace TestGame.Huds.levelMenu
{
    public class UpgradeHeroButton : Button
    {
        public UpgradeHeroButton(int x, int y) : base(x,y)
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

            pd.hm.Add(new HeroSelectDisplay(pd)
            {
                depth = pd.depth * 0.5f
            }, g);
        }
        
            
        public override void Draw(Game1 g)
        {
            base.Draw(g);
            Vector2 cords = GetPos(g);
            //Drawing.DrawText("Upgrades", cords.X + 4, cords.Y + 4, layerDepth: depth*0.5f);
            
            new Sprite(Textures.icons, new Rectangle(32 * 6, 32 * 20, 32, 32)).Draw(cords.X + 10, cords.Y + 8, size: 26, layerDepth: depth * 0.5f);
            Drawing.DrawText(g.pageGame.player.getHero().getLevel().ToString(), cords.X + Width+4, cords.Y + 12, layerDepth: depth * 0.5f);
        }
    }
}

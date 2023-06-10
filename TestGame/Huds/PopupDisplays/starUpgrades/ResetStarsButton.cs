using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TestGame.Graphics;
using TestGame.Managers;
using TestGame.Objects.Particles;
using TestGame.Objects.Towers;

namespace TestGame.Huds.PopupDisplays.starUpgrades
{
    public class ResetStarsButton : DisplayButton
    {
        private StarUpgradeDisplay sud;
        public ResetStarsButton(PopupDisplay pd, StarUpgradeDisplay sud, int x, int y) : base(pd, x, y, "Reset")
        {
            this.sud = sud;
        }

        public override void activate(Game1 g)
        {
            List<string> keys = new List<string>(g.levelMap.playerData.starUpgrades.Keys);
            foreach (string upgradeKey in keys)
            {
                g.levelMap.playerData.starUpgrades[upgradeKey] = false;
            }
            sud.starsLeft = g.levelMap.playerData.getTotalStars(g);
        }
    }
}

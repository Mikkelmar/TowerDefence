using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TestGame.Graphics;
using TestGame.Managers;
using TestGame.Objects.Particles;
using TestGame.Objects.Soldiers;
using TestGame.Objects.Towers;

namespace TestGame.Huds.PopupDisplays.heroUpgrades
{
    public class ResetSkillPointsButton : DisplayButton
    {
        private HeroUpgradeDisplay sud;
        private Hero hero;
        public ResetSkillPointsButton(PopupDisplay pd, HeroUpgradeDisplay sud, Hero hero, int x, int y) : base(pd, x, y, "Reset")
        {
            this.sud = sud;
            this.hero = hero;
        }

        public override void activate(Game1 g)
        {
            List<string> keys = new List<string>(hero.Powers.Keys);
            foreach (string upgradeKey in keys)
            {
                hero.Powers[upgradeKey] = false;
            }
            sud.SkillPoints = (hero.getLevel()-1)*2;
            hero.resetHeroPowers();
        }
    }
}

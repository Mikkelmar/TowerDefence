using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TestGame.Graphics;
using TestGame.Managers;
using TestGame.Objects;
using TestGame.Objects.Particles;
using TestGame.Objects.Towers;

namespace TestGame.Huds.PopupDisplays.heroUpgrades
{
    public class SetActiveHeroButtonButton : DisplayButton
    {
        private int heroID;
        public SetActiveHeroButtonButton(PopupDisplay pd, int x, int y, int heroID, string text= "Select") : base(pd, x, y, text)
        {
            this.heroID = heroID;
        }

        public override void activate(Game1 g)
        {
            Player.activeHero = heroID;
            new Sound(Sounds.unpause, 0.8f).play(g);
            g.saveManager.updateSave(g);
        }
    }
}

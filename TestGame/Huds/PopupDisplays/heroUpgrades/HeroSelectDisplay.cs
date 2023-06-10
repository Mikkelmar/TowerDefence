using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestGame.Graphics;
using TestGame.Managers;
using TestGame.Objects.Soldiers;

namespace TestGame.Huds.PopupDisplays.heroUpgrades
{
    public class HeroSelectDisplay : Hud
    {
        private PopupDisplay pd;
        private List<HeroOptionButton> heroOptions = new List<HeroOptionButton>();
        public HeroSelectDisplay(PopupDisplay pd)
        {
            this.pd = pd;
            X = pd.X + 200;
            Y = pd.Y + 50;

        }

        public override void Init(Game1 g)
        {
            base.Init(g);
            pd.hm.Add(new ContinueButton(pd, pd.Width - 160, 40)
            {
                depth = pd.depth * 0.5f
            }, g);

            foreach(var item in g.pageGame.player.heros.Select((hero, index) => (hero, index)))
            {
                heroOptions.Add(new HeroOptionButton(pd, 100+220* item.index, 180, item.hero, item.index));
            }
            foreach (HeroOptionButton option in heroOptions)
            {
                pd.hm.Add(option, g);
                if (g.pageGame.player.heros[option.heroID].isUnlocked)
                {
                    pd.hm.Add(new SetActiveHeroButtonButton(pd, (int)option.X - option.Width / 2, (int)option.Y + option.Height - 10, option.heroID), g);
                }
            }
        }

        public override void Draw(Game1 g)
        {
            
            Drawing.DrawText("Select you hero", X, Y+20, scale: 3f, layerDepth: pd.depth*0.1f);
        }
    }
}

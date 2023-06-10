using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Huds.PopupDisplays.OptionScreen;

namespace TestGame.Huds.PopupDisplays
{
    public class OptionsButton : DisplayButton
    {
        public OptionsButton(PopupDisplay pd, int x, int y) : base(pd, x, y, "Options")
        { }

        public override void activate(Game1 g)
        {
            pd.close(g);
            pd = new PopupDisplay();
            pd.hm.Add(new OptionsDisplay(pd)
            {
                depth = pd.depth * 0.5f
            }, g);
            //new Sound(Sounds.pause, 0.1f).play(g);
            //MediaPlayer.Pause();
            g.pageGame.hudManager.Add(pd, g);
        }
    }
}

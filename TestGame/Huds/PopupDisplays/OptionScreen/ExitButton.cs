using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace TestGame.Huds.PopupDisplays.OptionScreen
{
    public class ExitButton : DisplayButton
    {
        public ExitButton(PopupDisplay pd, float x, float y) : base(pd, x,y, "Exit Game") { }
        public override void activate(Game1 g)
        {
            g.saveManager.updateSave(g);
            g.Exit();
        }
    }
}

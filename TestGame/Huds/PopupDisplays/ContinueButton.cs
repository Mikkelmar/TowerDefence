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

namespace TestGame.Huds.PopupDisplays
{
    public class ContinueButton : DisplayButton
    {
        public ContinueButton(PopupDisplay pd, int x, int y, string text= "Continue") : base(pd, x, y, text)
        {}

        public override void activate(Game1 g)
        {
            pd.close(g);
            new Sound(Sounds.unpause, 0.8f).play(g);
            MediaPlayer.Resume();
        }
    }
}

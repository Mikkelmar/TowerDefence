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
    public class MapButton : DisplayButton
    {
        public MapButton(PopupDisplay pd, string displayText) : base(pd, 400, -100 + pd.Height, displayText)
        {
        }

        public override void activate(Game1 g)
        {
            pd.close(g);
            g.pageManager.Set(1, g);
            g.pageGame.sceneManager.GetScene().Close(g);
            new Sound(Sounds.confirm, 0.8f).play(g);
            MediaPlayer.Pause();
        }
    }
}

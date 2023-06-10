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
    public class RestartButton : DisplayButton
    {
        public RestartButton(PopupDisplay pd) : base(pd, 200, pd.Height - 100, "Try again")
        {}

        public override void activate(Game1 g)
        {
            pd.close(g);
            g.pageGame.sceneManager.GetScene().Close(g);
            g.pageGame.sceneManager.GetScene().Load(g);
            new Sound(Sounds.confirm, 0.8f).play(g);
            MediaPlayer.Pause();
        }
    }
}

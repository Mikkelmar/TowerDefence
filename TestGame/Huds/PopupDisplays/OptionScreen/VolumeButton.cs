using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TestGame.Graphics;
using TestGame.Managers;

namespace TestGame.Huds.PopupDisplays.OptionScreen
{
    public class VolumeButton : DisplayButton
    {
        private SoundManager.types type;
        private int add;
        private static Sound clickSound = new Sound(Sounds.click2, 0.1f, SoundManager.types.Normal);
        public VolumeButton(PopupDisplay pd, float x, float y, SoundManager.types type, int add = 1) : base(pd, x, y)
        {
            this.type = type;
            this.add = add;
            if (add == 1)
            {
                displayText = "+";
            }
            else if (add == -1)
            {
                displayText = "-";
            }
            Width = 32;
            Height = 32;
        }
        public override void activate(Game1 g)
        {
            if(type == SoundManager.types.Music)
            {
                g.soundManager.changeMusicVolume(0.05f * add);
            }
            else
            {
                g.soundManager.changeGameVolume(0.1f * add);
            }
            clickSound.play(g);

        }
    }
}

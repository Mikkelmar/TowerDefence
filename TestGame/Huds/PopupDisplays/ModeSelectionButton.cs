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
using TestGame.Pages;

namespace TestGame.Huds.PopupDisplays
{
    public class ModeSelectionButton : DisplayButton
    { 
        private int sceneID;
        private int mode;
        private LevelSelectDisplay display;
        public ModeSelectionButton(PopupDisplay pd, int sceneID, float x, float y, int mode, LevelSelectDisplay display) : base(pd,x,y)
        {
            this.sceneID = sceneID;
            this.mode = mode;
            this.display = display;
            displayText = getDisplayText();
        }

        public override void activate(Game1 g)
        {
            if((mode == 2 || mode == 1) && g.pageGame.sceneManager.scenes[sceneID].levelClearStars == 0)
            {
                new Sound(Sounds.denied, 0.6f).play(g);
                return;
            }
            //Debug.WriteLine(g.pageGame.sceneManager.scenes[sceneID].levelClearStars);

            display.mode = mode;
            new Sound(Sounds.confirm, 0.8f).play(g);
        }
        private string getDisplayText()
        {
            if (mode == 0)
            {
                return displayText = "Normal";
            }
            else if (mode == 1)
            {
                return displayText = "Special";
            }
            else if (mode == 2)
            {
                return displayText = "Swarm";
            }
            return "null";
        }
        public override void Draw(Game1 g)
        {
            if(g.pageGame.sceneManager.scenes[sceneID].levelClearStars == 0 && mode != 0)
            {
                displayText = "LOCKED";
            }
            else
            {
                displayText = getDisplayText();
            }
            drawText(g);
            int i = 0;
            if (mode == display.mode)
            {
                i = 48;
            }
            else if (BeingHoverd)
            {
                i = 32;
            }
            new Sprite(Textures.gui, new Rectangle(113, 81 + i, 30, 14)).Draw(X, Y, Width, Height, depth);
            
        }

    }
}

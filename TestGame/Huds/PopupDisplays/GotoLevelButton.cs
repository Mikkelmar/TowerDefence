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
    public class GotoLevelButton : DisplayButton
    { 
        private int sceneID;

        private LevelSelectDisplay display;
        public GotoLevelButton(PopupDisplay pd, int sceneID, float x, float y, LevelSelectDisplay display) : base(pd,x,y)
        {
            this.sceneID = sceneID;
            this.display = display;
            displayText = "FIGHT";
        }

        public override void activate(Game1 g)
        {
            if((display.mode == 2 || display.mode == 1) && g.pageGame.sceneManager.scenes[sceneID].levelClearStars == 0)
            {
                new Sound(Sounds.denied, 0.6f).play(g);
                return;
            }
            //Debug.WriteLine(g.pageGame.sceneManager.scenes[sceneID].levelClearStars);
            pd.close(g);
            g.pageManager.Set(PageID.game, g);
            g.pageGame.sceneManager.scenes[sceneID].mode = display.mode;
            g.pageGame.sceneManager.gotoScene(g, sceneID);
           
            new Sound(Sounds.confirm, 0.8f).play(g);
            MediaPlayer.Pause();
        }

    }
}

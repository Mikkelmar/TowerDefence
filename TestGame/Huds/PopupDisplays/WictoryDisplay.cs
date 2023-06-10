using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;
using TestGame.Managers;
using TestGame.Objects.Soldiers;

namespace TestGame.Huds.PopupDisplays
{
    public class WictoryDisplay : Hud
    {
        private PopupDisplay pd;
        public WictoryDisplay(PopupDisplay pd)
        {
            this.pd = pd;
            X = pd.X+200;
            Y = pd.Y+50;

        }
        public override void Init(Game1 g)
        {
            base.Init(g);

            pd.hm.Add(new MapButton(pd, "Continue")
            {
                depth = pd.depth * 0.5f,
                X = pd.X + 480
            }, g);
        }
        public override void Draw(Game1 g)
        {
            
            Drawing.DrawText("Victory", X+200, Y+20, scale: 3f, layerDepth: pd.depth*0.1f);
            //Drawing.DrawText("Stars: "+g.pageGame.sceneManager.GetScene().levelClearStars.ToString(), X + 200, Y + 120, scale: 3f, layerDepth: pd.depth * 0.1f);
            int size = 64;
            for (int i = 0; i < 3; i++)
            {
                if (i < g.pageGame.sceneManager.GetScene().levelClearStars)
                {

                    new Sprite(Textures.gold_star).Draw(X + i * size + 240, Y + 110, size, size, pd.depth * 0.1f);
                }
                else
                {
                    new Sprite(Textures.empty_star).Draw(X + i * size + 240, Y + 110, size, size, pd.depth * 0.1f);
                }
            }
            Hero _hero = g.pageGame.player.getHero();
            Drawing.DrawText("Level "+_hero.getLevel(), X + 50, Y + 200, scale: 3f, layerDepth: pd.depth * 0.1f);
            Drawing.FillRect(new Rectangle((int)(X+50), (int)(Y + 280), 200, 26), Color.Red, pd.depth * 0.1f, g);
            Drawing.FillRect(new Rectangle((int)(X + 50), (int)(Y + 280), (int)(200 * (_hero.getXp() / (double)_hero.xpNeeded())), 26), Color.Green, pd.depth * 0.01f, g);
            
        }
    }
}

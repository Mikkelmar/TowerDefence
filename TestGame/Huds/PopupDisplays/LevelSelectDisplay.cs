using Microsoft.Xna.Framework;
using System;
using TestGame.Graphics;
using TestGame.Managers;
using TestGame.Pages;

namespace TestGame.Huds.PopupDisplays
{
    public class LevelSelectDisplay : Hud
    {
        private PopupDisplay pd;
        private Scene scene;
        public int mode = 0;
        public LevelSelectDisplay(PopupDisplay pd, Scene scene)
        {
            this.pd = pd;
            X = pd.X + 100;
            Y = pd.Y + 50;
            this.scene = scene;

        }
        public override void Init(Game1 g)
        {
            base.Init(g);
            pd.hm.Add(new ModeSelectionButton(pd, scene.sceeneID, 100, pd.Height - 80, 0, this), g);
            pd.hm.Add(new ModeSelectionButton(pd, scene.sceeneID, 250, pd.Height - 80, 1, this), g);
            pd.hm.Add(new ModeSelectionButton(pd, scene.sceeneID, 400, pd.Height - 80, 2, this), g);
            pd.hm.Add(new GotoLevelButton(pd, scene.sceeneID, 600, pd.Height - 80, this), g);
            pd.hm.Add(new ContinueButton(pd, 620, 20, "Close"), g);
        }

        public override void Draw(Game1 g)
        {
            int space = 6;
            new Sprite(Textures.infobox).Draw(X- space, Y + 80- space, Drawing.WINDOW_WIDTH / 3+ space*2, Drawing.WINDOW_HEIGHT / 3+ space*2, layerDepth: pd.depth*0.2f);
            scene.background.Draw(X, Y + 80, Drawing.WINDOW_WIDTH / 3, Drawing.WINDOW_HEIGHT / 3, layerDepth: pd.depth * 0.1f); ;
            Drawing.DrawText(scene.name, X, Y-20, scale: 3f, layerDepth: pd.depth*0.1f);

            float xPos = X + 20 + Drawing.WINDOW_WIDTH / 3;
            float yPos = Y + 80 - space;
            new Sprite(Textures.towerInfo).Draw(xPos, yPos, 180, Drawing.WINDOW_HEIGHT / 3+ space * 2, layerDepth: pd.depth * 0.2f);
            int y_index = 0, towerSize = 64;
            foreach(int towerId in scene.getTowersIDs(g, mode))
            {
                ObjectCreator.createTower(towerId, 0, 0, g).getSprite().Draw(new Vector2(xPos+16+ towerSize*(y_index%2), yPos+ (y_index/2)* towerSize), towerSize, towerSize, layerDepth: pd.depth * 0.1f);
                y_index++;
            }
            for (int i = 0; i < 3; i++)
            {
                if (i < scene.levelClearStars)
                {

                    new Sprite(Textures.gold_star).Draw(X + i * 32 + 16, Y + 340, 32, 32, pd.depth * 0.1f);
                }
                else
                {
                    new Sprite(Textures.empty_star).Draw(X + i * 32 + 16, Y + 340, 32, 32, pd.depth * 0.1f);
                }

            }
            if (scene.specialStar==1)
            {

                new Sprite(Textures.gold_star).Draw(X + 180 + 16, Y + 340, 32, 32, pd.depth * 0.1f);
            }
            else
            {
                new Sprite(Textures.empty_star).Draw(X + 180 + 16, Y + 340, 32, 32, pd.depth * 0.1f);
            }
            if (scene.endlessStar == 1)
            {

                new Sprite(Textures.gold_star).Draw(X + 325 + 16, Y + 340, 32, 32, pd.depth * 0.1f);
            }
            else
            {
                new Sprite(Textures.empty_star).Draw(X + 325 + 16, Y + 340, 32, 32, pd.depth * 0.1f);
            }

        }

    }
}

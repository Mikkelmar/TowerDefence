using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;
using TestGame.Managers;
using TestGame.Objects.Towers;

namespace TestGame.Huds.PopupDisplays
{
    public class TowerDisplay : Hud
    {
        private PopupDisplay pd;
        private Tower tower;
        public TowerDisplay(PopupDisplay pd, Tower tower)
        {
            this.pd = pd;
            X = pd.X + 200;
            Y = pd.Y + 20;
            this.tower = tower;

        }
        public override void Init(Game1 g)
        {
            base.Init(g);
            pd.hm.Add(new ContinueButton(pd, 200, 440), g);
        }
        public override void Draw(Game1 g)
        {
            
            Drawing.DrawText("New Tower!", X, Y, scale: 2.5f, layerDepth: pd.depth*0.1f);
            
            Vector2 sizeDesc = Textures.font.MeasureString(tower.description);
            int i = 0;
            foreach(string s in TextHandler.FitText(tower.description, 300)){
                Drawing.DrawText(s, pd.X + pd.Width * 0.25f - TextHandler.textLength(s) * 0.5f, pd.Y + 185 + i*40, scale: 1f, layerDepth: pd.depth * 0.1f);
                i++;
            }
            

            new Sprite(Textures.gui, new Rectangle(49, 97, 30, 30)).Draw(pd.X + 380, pd.Y + 20, 360, 360, layerDepth: pd.depth * 0.2f);
            tower.getSprite().Draw(pd.X+340+40,pd.Y-20, 360 ,layerDepth: pd.depth*0.1f);

            Drawing.DrawText(tower.name.ToUpper(), pd.X+ 20, pd.Y+80, layerDepth: pd.depth * 0.1f, scale: 1.2f);

            //new Sprite(Textures.icons, new Rectangle(32*0,32*1,32,32)).Draw(pd.X + 20, pd.Y + 150, 64, layerDepth: pd.depth * 0.1f);
            //Drawing.DrawText(tower.reloadTimer.ToString(), pd.X + 50 + 40, pd.Y + 170, layerDepth: pd.depth * 0.1f, scale: 1.5f);

            //new Sprite(Textures.icons, new Rectangle(32 * 0, 32 * 0, 32, 32)).Draw(pd.X + 20, pd.Y + 200, 64, layerDepth: pd.depth * 0.1f);
            //Drawing.DrawText(tower.damage.ToString(), pd.X + 40 + 50, pd.Y + 220, layerDepth: pd.depth * 0.1f, scale: 1.5f);

            //new Sprite(Textures.icons, new Rectangle(32 * 10, 32 * 17, 32, 32)).Draw(pd.X + 20, pd.Y + 250, 64, layerDepth: pd.depth * 0.1f);
            // Drawing.DrawText(MonsterHandler.getSpeedLevel(monster.baseSpeed), pd.X + 40 + 50, pd.Y + 270, layerDepth: pd.depth * 0.1f, scale: 1.5f);

            //new Sprite(Textures.icons, new Rectangle(32 * 7, 32 * 7, 32, 32)).Draw(pd.X + 20, pd.Y + 300, 64, layerDepth: pd.depth * 0.1f);
            // Drawing.DrawText(monster.armor.ToString(), pd.X + 40 + 50, pd.Y + 320, layerDepth: pd.depth * 0.1f, scale: 1.5f);


        }
    }
}

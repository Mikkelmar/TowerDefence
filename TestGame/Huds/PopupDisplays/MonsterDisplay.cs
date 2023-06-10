using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;
using TestGame.Managers;
using TestGame.Objects.Monsters;

namespace TestGame.Huds.PopupDisplays
{
    public class MonsterDisplay : Hud
    {
        private PopupDisplay pd;
        private Monster monster;
        public MonsterDisplay(PopupDisplay pd, Monster monster)
        {
            this.pd = pd;
            X = pd.X + 200;
            Y = pd.Y + 20;
            this.monster = monster;

        }
        public override void Init(Game1 g)
        {
            base.Init(g);
            pd.hm.Add(new ContinueButton(pd, 200, 440), g);
        }
        public override void Draw(Game1 g)
        {
            
            Drawing.DrawText("New Enemy!", X, Y, scale: 2.5f, layerDepth: pd.depth*0.1f);
            
            Vector2 sizeDesc = Textures.font.MeasureString(monster.description);
            int i = 0;
            foreach(string s in TextHandler.FitText(monster.description, 400)){
                Drawing.DrawText(s, pd.X + pd.Width * 0.5f - TextHandler.textLength(s) * 0.5f, pd.Y + 385 + i*40, scale: 1f, layerDepth: pd.depth * 0.1f);
                i++;
            }
            

            new Sprite(Textures.gui, new Rectangle(49, 97, 30, 30)).Draw(pd.X + 240 + 40, pd.Y + 80, 280, 280, layerDepth: pd.depth * 0.2f);
            monster.getSprite().Draw(pd.X+260+60,pd.Y+120, 200 ,layerDepth: pd.depth*0.1f);

            Drawing.DrawText(monster.name.ToUpper(), pd.X+ 40, pd.Y+100, layerDepth: pd.depth * 0.1f, scale: 1.2f);
            
            new Sprite(Textures.icons, new Rectangle(32*0,32*1,32,32)).Draw(pd.X + 20, pd.Y + 150, 64, layerDepth: pd.depth * 0.1f);
            Drawing.DrawText(monster.baseHp.ToString(), pd.X + 50 + 40, pd.Y + 170, layerDepth: pd.depth * 0.1f, scale: 1.5f);
           
            new Sprite(Textures.icons, new Rectangle(32 * 0, 32 * 0, 32, 32)).Draw(pd.X + 20, pd.Y + 200, 64, layerDepth: pd.depth * 0.1f);
            Drawing.DrawText(monster.damage.ToString(), pd.X + 40 + 50, pd.Y + 220, layerDepth: pd.depth * 0.1f, scale: 1.5f);
            
            new Sprite(Textures.icons, new Rectangle(32 * 10, 32 * 17, 32, 32)).Draw(pd.X + 20, pd.Y + 250, 64, layerDepth: pd.depth * 0.1f);
            Drawing.DrawText(MonsterHandler.getSpeedLevel(monster.baseSpeed), pd.X + 40 + 50, pd.Y + 270, layerDepth: pd.depth * 0.1f, scale: 1.5f);
            if (monster.armor > 0)
            {
                new Sprite(Textures.icons, new Rectangle(32 * 7, 32 * 7, 32, 32)).Draw(pd.X + 20, pd.Y + 300, 64, layerDepth: pd.depth * 0.1f);
                Drawing.DrawText(monster.armor.ToString(), pd.X + 40 + 50, pd.Y + 320, layerDepth: pd.depth * 0.1f, scale: 1.5f);
            }
            else if (monster.magicArmor > 0)
            {
                new Sprite(Textures.icons, new Rectangle(32 * 8, 32 * 7, 32, 32)).Draw(pd.X + 20, pd.Y + 300, 64, layerDepth: pd.depth * 0.1f);
                Drawing.DrawText(monster.magicArmor.ToString(), pd.X + 40 + 50, pd.Y + 320, layerDepth: pd.depth * 0.1f, scale: 1.5f);
            }
        }
    }
}

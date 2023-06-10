using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;
using TestGame.Managers;
using TestGame.Objects;
using TestGame.Objects.Monsters;
using TestGame.Objects.Soldiers;

namespace TestGame.Huds
{
    public class SoldierInfo : Hud
    {
        public SoldierInfo()
        {
            relative = true;
        }
        public override void Draw(Game1 g)
        {
            if(g.pageGame.getHudManager().activeObject is Soldier)
            {
                
                Vector2 cords = GetPos(g);

                Soldier monster = (Soldier)g.pageGame.getHudManager().activeObject;
                monster.getSprite().Draw(new Vector2(cords.X+1116, cords.Y+400),100,100, layerDepth: 0.0001f);
                new Sprite(Textures.gui, new Rectangle(49, 97, 30, 30)).Draw(1090 + 16, 390, 120, 120, layerDepth: 0.0003f);

                float nameScale = Math.Min(1f, TextHandler.GetFitScale(monster.name.ToUpper(), 200));
                Drawing.DrawText(monster.name.ToUpper(), 
                    1106+60 -TextHandler.textLength(monster.name.ToUpper())*nameScale*0.5f, 
                    360, 
                    scale: nameScale);
                Drawing.DrawText(monster.hp + "/" + monster.baseHp, 1100, 525, layerDepth: 0.000001f) ;
                if (monster.baseHp != 0)
                {
                    Drawing.FillRect(new Rectangle(1090, 520, 140, 32), Color.Red, 0.00002f, g);
                    Drawing.FillRect(new Rectangle(1090, 520, (int)(140 * (monster.hp / (double)monster.baseHp)), 32), Color.Green, 0.00001f, g);
                }

                

               
                new Sprite(Textures.icons, new Rectangle(32 * 1, 32 * 5, 32, 32)).Draw(1090, 560, 30);
                Drawing.DrawText(monster.damage.ToString(), 1140, 560);
                new Sprite(Textures.icons, new Rectangle(32 * 10, 32 * 17, 32, 32)).Draw(1090, 590, 30);
                Drawing.DrawText((1000/monster.attackSpeed.TotalMilliseconds).ToString("N1")+"/s", 1140, 590);
                if(monster.armor > 0)
                {

                    new Sprite(Textures.icons, new Rectangle(32 * 7, 32 * 7, 32, 32)).Draw(1090, 620, 30);
                    Drawing.DrawText(monster.armor.ToString(), 1140, 620);
                }else if (monster.magicArmor > 0)
                {
                    new Sprite(Textures.icons, new Rectangle(32 * 8, 32 * 7, 32, 32)).Draw(1090, 620, 30);
                    Drawing.DrawText(monster.magicArmor.ToString(), 1140, 620);
                }
               

                new Sprite(Textures.towerInfo).Draw(1050, 330, 230, 380, layerDepth: 0.001f);

            }
        }
    }
}

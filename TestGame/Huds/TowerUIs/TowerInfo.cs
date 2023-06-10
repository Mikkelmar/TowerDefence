using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;
using TestGame.Managers;
using TestGame.Objects;
using TestGame.Objects.Towers;

namespace TestGame.Huds
{
    public class TowerInfo : Hud
    {
        SellTower sellButton;
        public TowerInfo()
        {
            X = 1000;
            Y = 400;
            relative = true;
            sellButton = new SellTower(1100, 620);
        }
        public override void Init(Game1 g)
        {
            base.Init(g);
            
            g.pageGame.mouseManager.Add(sellButton);
        }
        public override void Destroy(Game1 g)
        {
            base.Destroy(g);
            g.pageGame.mouseManager.Remove(sellButton);
        }
        public override void Draw(Game1 g)
        {
            if(g.pageGame.getHudManager().activeObject is Tower && (g.pageGame.getHudManager().activeObject as Tower).range > 0)
            {
                Vector2 cords = GetPos(g);

                Tower tower = (Tower)g.pageGame.getHudManager().activeObject;
                tower.getSprite().Draw(new Vector2(cords.X + 116, cords.Y),100,100, layerDepth: 0.0001f);
                new Sprite(Textures.gui, new Rectangle(49, 97, 30, 30)).Draw(cords.X+90 + 16, cords.Y-10, 120, 120, layerDepth: 0.0002f);

                Drawing.DrawText(tower.name.ToUpper(), cords.X+80, cords.Y-40, scale: TextHandler.GetFitScale(tower.name.ToUpper(), 170));
                Drawing.DrawText("Range: "+tower.range, cords.X+100, cords.Y+120);
                Drawing.DrawText("Damage: " + tower.damage, cords.X+100, cords.Y+150);
                Drawing.DrawText("Firerate: " + (Math.Round(1 / tower.fireRate, 1)) + "/s", cords.X+100, cords.Y+180);
                
                new Sprite(Textures.towerInfo).Draw(cords.X+50, cords.Y-70, 230, 380, layerDepth: 0.001f);

                if (tower.canSell)
                {
                    sellButton.tower = (Tower)g.pageGame.getHudManager().activeObject;
                    sellButton.X = cords.X+100;
                    sellButton.Y = cords.Y+220;


                    Drawing.DrawText("SELL", cords.X+110, cords.Y+240, layerDepth: 0.000000001f, scale: 0.9f, color: Color.Black);
                    Drawing.DrawText(tower.getSellValue(g).ToString(), cords.X+170, cords.Y+240, color: Color.PaleGoldenrod,border: true);
                    Vector2 posGold = new Vector2(cords.X + 170+ TextHandler.textLength(tower.getSellValue(g).ToString()), cords.Y + 240);
                    new Sprite(Textures.icons, new Rectangle(32 * 7, 32 * 12, 32, 32)).Draw(posGold, 32, 32, depth);


                    sellButton.Draw(g);
                }

                

                /*new Sprite(Textures.gui, new Rectangle(49 + 32, 97, 30, 30)).Draw(pos, size, size, depth);
                if (host.canSell)
                {
                    options.Add();
                }*/

            }
            else
            {
                sellButton.tower = null;
            }
        }
    }
}

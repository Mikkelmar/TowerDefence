using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TestGame.Graphics;
using TestGame.Managers;
using TestGame.Objects.Towers;

namespace TestGame.Huds
{
    public class TowerOption : Hud, Clickable, HoverLisner
    {
        private Tower tower;
        private Upgradable host;
        private bool beingHoverd = false, stopedHovering = false;
        private int size = 64;
        public TowerOption(Upgradable host, int x, int y, Tower tower = null)
        {
            X = x;
            Y = y;
            this.tower = tower;
            this.host = host;
        }
        public void Clicked(float x, float y, Game1 g)
        {
            if (new Rectangle((int)X, (int)Y, size, size).Contains(new Vector2(x,y)))
            {
                if(tower == null)
                {
                    host.Sell(g);
                    return;
                }
                if (g.pageGame.player.money >= tower.cost)
                {
                    host.Buy(g, tower);
                }
                else
                {
                    new Sound(Sounds.denied, 0.8f).play(g);
                }
            }
                
        }

        public override void Draw(Game1 g)
        {
            Vector2 pos = GetPos(g);
            new Sprite(Textures.gui, new Rectangle(49+32, 97, 30, 30)).Draw(pos, size, size, depth);

            if (tower == null){
                return;
            }
            else{
                Vector2 tp = new Vector2(pos.X +4, pos.Y +4);
                tower.getSprite().Draw(tp, size-4, size-4, depth*0.1f);
                Drawing.DrawText(
                    tower.cost.ToString(), 
                    pos.X+(size/2)-((TextHandler.textLength(tower.cost.ToString()) + 16) / 2), 
                    pos.Y- size/2, 
                    layerDepth: depth * 0.1f,
                    color: Color.PaleGoldenrod,
                    border: true);
                Vector2 posGold = new Vector2(pos.X + (size / 2) + ((TextHandler.textLength(tower.cost.ToString())-8) / 2)-6, pos.Y-2- size / 2);
                new Sprite(Textures.icons, new Rectangle(32*7, 32*12, 32, 32)).Draw(posGold, 32, 32, depth);
            }
            if (beingHoverd){
                UpgradeInfo info = new UpgradeInfo(tower);
                info.Draw(g);
                g.pageGame.player.displayTange = tower.range;
                stopedHovering = true;
            }else if (stopedHovering)
            {
                stopedHovering = false;
                if(host is Tower)
                {
                    g.pageGame.player.displayTange = (host as Tower).range;
                }
                
            }
            
        }

        public void Hover(float x, float y, Game1 g)
        {
            beingHoverd = (new Rectangle((int)X, (int)Y, size, size).Contains(new Vector2(x, y)));
            
        }
    }
}

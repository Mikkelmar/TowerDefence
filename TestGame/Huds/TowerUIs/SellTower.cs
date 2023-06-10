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
    public class SellTower : Hud, Clickable
    {
        public Tower tower;
        private int size = 64;
        public SellTower(int x, int y)
        {
            X = x;
            Y = y;
        }
        public void Clicked(float x, float y, Game1 g)
        {
            if(tower != null && tower.canSell)
            {
                if (new Rectangle((int)X, (int)Y, size, size).Contains(new Vector2(x, y)))
                {
                    tower.Sell(g);
                }
            }
            
                
        }

        public override void Draw(Game1 g)
        {
            Vector2 pos = GetPos(g);
            new Sprite(Textures.gui, new Rectangle(49+32, 97, 30, 30)).Draw(pos, size, size, depth);
            
        }
    }
}

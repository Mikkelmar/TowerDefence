using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TestGame.Graphics;
using TestGame.Managers;
using TestGame.Objects.Soldiers;
using TestGame.Objects.Towers;
using TestGame.Objects.Towers.TowerPowers;

namespace TestGame.Huds
{
    public class HeroUI : Hud, Clickable, HoverLisner
    {
        private Hero host;
        private TargetButton targetButton;
        private bool selectingTarget = false;
        
        public HeroUI(Hero host, int x, int y, Game1 g)
        {
            X = x;
            Y = y;
            Vector2 pos = GetPos(g);
            x = (int)pos.X;
            y = (int)pos.Y;
            targetButton = new TargetButton(x,y+64, uiH: this);
            this.host = host;
        }

        public void Clicked(float x, float y, Game1 g)
        { 
            if (selectingTarget)
            {
                host.stationedPos = new Vector2(x,y);
                host.inPos = false;
                selectingTarget = false;
                return;
            }
            else 
            {
                selectingTarget = false;
                targetButton.Clicked(x,y,g);
            }
        }

        public override void Draw(Game1 g)
        {  
            if (selectingTarget)
            {
                Vector2 pos = g.pageGame.mouseManager.GetMousePos(g);
                new Sprite(Textures.target).Draw(pos.X - 16, pos.Y - 16, 32, 32, layerDepth: depth);
                return;
            }
            targetButton.X = host.X-host.Width/2;
            targetButton.Y = host.Y+host.Height + 12;
            targetButton.Draw(g);
        }
        public void selectedOption(int id)
        {
            if (id == -1)
            {
                selectingTarget = true;
            }
        }

        public void Hover(float x, float y, Game1 g)
        {
        }
    }
}

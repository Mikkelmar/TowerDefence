using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TestGame.Graphics;
using TestGame.Managers;
using TestGame.Objects.Towers;
using TestGame.Objects.Towers.TowerPowers;

namespace TestGame.Huds
{
    public class TowerUI : Hud, Clickable, HoverLisner
    {
        private List<TowerOption> options = new List<TowerOption>();
        private List<TowerPowerOption> powerOptions = new List<TowerPowerOption>();
        private int size=64;
        private Upgradable host;
        private TargetButton targetButton;
        private bool selectingTarget = false;
        
        public TowerUI(Upgradable host, int x, int y, Game1 g)
        {
            X = x;
            Y = y;
            Vector2 pos = GetPos(g);
            x = (int)pos.X;
            y = (int)pos.Y;
            int i = 0;
            targetButton = new TargetButton(x,y+64, this);
            this.host = host;
            foreach (Tower t in host.options)
            {
                options.Add(new TowerOption(host, x+i* size-((host.options.Count+ host.powers.Count - 1)*size/2), y- size, t));
                i++;
            }
            foreach (TowerPower t in host.powers)
            {
                powerOptions.Add(new TowerPowerOption(host, x + i * size - ((host.options.Count + host.powers.Count - 1) * size / 2), y - size, t));
                i++;
            }
            

        }

        public void Clicked(float x, float y, Game1 g)
        { 
            if (host is Tower)
            {
                if (selectingTarget)
                {
                    (host as Tower).setTargetPos(g, new Vector2(x,y));
                    selectingTarget = false;
                    return;
                }
                else if ((host as Tower).canSelectTarget)
                {
                    selectingTarget = false;
                    targetButton.Clicked(x,y,g);
                }

            }
            foreach (TowerOption o in options)
            {
                o.Clicked(x, y, g);
            }
            foreach (TowerPowerOption o in powerOptions)
            {
                o.Clicked(x, y, g);
            }
        }

        public override void Draw(Game1 g)
        {
            if(host is Tower)
            {
                if((host as Tower).canSelectTarget)
                {
                    
                    if (selectingTarget)
                    {
                        Vector2 pos = g.pageGame.mouseManager.GetMousePos(g);
                        new Sprite(Textures.target).Draw(pos.X - 16, pos.Y - 16, 32, 32, layerDepth: depth);
                        return;
                    }
                    targetButton.Draw(g);
                }
                
            }
            foreach (Hud h in options)
            {
                h.Draw(g);
            }
            foreach (TowerPowerOption h in powerOptions)
            {
                h.Draw(g);
            }
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
            foreach (TowerOption o in options)
            {
                o.Hover(x, y, g);
            }
            foreach (TowerPowerOption h in powerOptions)
            {
                h.Hover(x, y, g);
            }
        }
    }
}

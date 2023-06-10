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
    public class TowerPowerOption : Hud, Clickable, HoverLisner
    {
        private TowerPower power;
        private Upgradable host;
        private bool beingHoverd = false;
        private int size = 64;
        public TowerPowerOption(Upgradable host, int x, int y, TowerPower power)
        {
            X = x;
            Y = y;
            this.power = power;
            this.host = host;
        }
        public void Clicked(float x, float y, Game1 g)
        {
            if (new Rectangle((int)X, (int)Y, size, size).Contains(new Vector2(x,y)))
            {
                if (g.pageGame.player.money >= power.cost)
                {
                    if (power.CanUpgrade())
                    {
                        host.Buy(g, power);
                    }
                    else
                    {
                        //TODO SOUND TYPE
                        new Sound(Sounds.denied, 0.8f).play(g);
                    }
                    
                }
            }
                
        }

        public override void Draw(Game1 g)
        {
            Vector2 pos = GetPos(g);
            if (power.CanUpgrade())
            {
                new Sprite(Textures.gui, new Rectangle(49 + 32, 97, 30, 30)).Draw(pos, size, size, depth);
            }
            else
            {
                new Sprite(Textures.gui, new Rectangle(49 + 32, 97, 30, 30)).Draw(pos, size, size, depth);
            }
            for(int i = 0; i < power.TotalUpgrades(); i++)
            {
                Sprite img = new Sprite(Textures.greyCheck);
                if (power.stage > i)
                {
                    img = new Sprite(Textures.greenCheck);
                }
                img.Draw(new Vector2(pos.X+52, pos.Y+8+ (size*i / 4)), size/4, size/4, depth*0.01f);
            }
            Vector2 tp = new Vector2(pos.X + 6, pos.Y + 6);
            power.icon.Draw(tp, size-12, size-12, depth*0.1f);
            Drawing.DrawText(
                    power.cost.ToString(),
                    pos.X + (size / 2) - ((TextHandler.textLength(power.cost.ToString()) + 16) / 2),
                    pos.Y - size / 2,
                    layerDepth: depth * 0.1f,
                    color: Color.PaleGoldenrod,
                    border: true);
            Vector2 posGold = new Vector2(pos.X + (size / 2) + ((TextHandler.textLength(power.cost.ToString()) - 8) / 2) - 6, pos.Y - 2 - size / 2);
            new Sprite(Textures.icons, new Rectangle(32 * 7, 32 * 12, 32, 32)).Draw(posGold, 32, 32, depth);


            if (beingHoverd){
                PowerInfo info = new PowerInfo(power);
                info.Draw(g);
            }

        }

        public void Hover(float x, float y, Game1 g)
        {
            beingHoverd = (new Rectangle((int)X, (int)Y, size, size).Contains(new Vector2(x, y)));
        }
    }
}

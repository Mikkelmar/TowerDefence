using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TestGame.Graphics;
using TestGame.Managers;
using TestGame.Objects.Particles;
using TestGame.Objects.Towers;

namespace TestGame.Huds
{
    public class GameSpeedButton : Button
    {
        private float speed;
        public GameSpeedButton(int x, int y, float speed) : base(x,y)
        {
            this.speed = speed;
        }

        public override void activate(Game1 g)
        {
            g.gameSpeed = speed;
        }
        public override void Draw(Game1 g)
        {
            Vector2 cords = GetPos(g);
            if(speed == 1)
            {
                new Sprite(Textures.speed1).Draw(cords.X + 10, cords.Y + 6, 30, layerDepth: depth * 0.5f);
                
            }
            else if (speed == 2)
            {
                new Sprite(Textures.speed2).Draw(cords.X + 6, cords.Y + 6, 30, layerDepth: depth * 0.5f);
            }
            if (g.gameSpeed == speed)
            {
                new Sprite(Textures.gui, new Rectangle(16, 80, 16, 16)).Draw(GetPos(g), Width, Height, depth);
            }
            else
            {
                base.Draw(g);
            }
            
        }
    }
}

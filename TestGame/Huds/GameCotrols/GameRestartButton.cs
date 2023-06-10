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
    public class GameRestartButton : Button
    {
        public GameRestartButton(int x, int y) : base(x,y)
        {
            relative = true;
        }

        public override void activate(Game1 g)
        {
            g.pageGame.sceneManager.GetScene().Close(g);
            g.pageGame.sceneManager.GetScene().Load(g);
        }
        public override void Draw(Game1 g)
        {
            base.Draw(g);
            Vector2 cords = GetPos(g);
            Drawing.DrawText("r", cords.X + 4, cords.Y + 4, layerDepth: depth*0.5f);
        }
    }
}

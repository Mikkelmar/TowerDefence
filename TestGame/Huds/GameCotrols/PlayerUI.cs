using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TestGame.Managers;
using TestGame.Objects;

namespace TestGame.Huds
{
    public class PlayerUI : Hud
    {
        public PlayerUI()
        {
            relative = true;
        }
        public override void Draw(Game1 g)
        {
            Vector2 pos = GetPos(g);
            Player p = g.pageGame.player;
            WaveManager wm = g.pageGame.sceneManager.GetScene().waveManager;
            Drawing.DrawText(p.money.ToString()+" gold", pos.X+100, pos.Y + 20);
            Drawing.DrawText(p.hp.ToString()+" hp", pos.X + 20, pos.Y + 20);
            Drawing.DrawText("wave "+ (wm.waveNumber+1)+"/"+wm.waves.Count, pos.X + 240, pos.Y + 20);
        }
    }
}

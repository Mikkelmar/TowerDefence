using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;
using TestGame.Managers;
using TestGame.Pages;

namespace TestGame.Huds
{
    public class PopupDisplay : Hud, Clickable, InfoDisplay
    {
        public HudManager hm = new HudManager();
        //private MouseManager mm = new MouseManager();
        public PopupDisplay()
        {
            
            Width = 48 * 16;
            Height = 32 * 16;
            X = 100;
            Y = 100;
            depth = 0.00000000001f;
        }
        public override void Init(Game1 g)
        {
            base.Init(g);
            X = Drawing.WINDOW_WIDTH / 2 - Width / 2;
            Y = Drawing.WINDOW_HEIGHT / 2 - Height / 2;
            //g.pageGame.mouseManager.
            if (g.pageManager.GetPage() is PageGame)
            {
                (g.pageManager.GetPage() as PageGame).mouseManager.Add(this);
                (g.pageManager.GetPage() as PageGame).gamePaused = true;
                g.soundManager.pauseSounds();
            }else if(g.pageManager.GetPage() is LevelMap)
            {
                (g.pageManager.GetPage() as LevelMap).mouseManager.Add(this);
            }
            
            g.gameSpeed = 0;
        }
        public override void Destroy(Game1 g)
        {
            hm.Clear(g);
            base.Destroy(g);
            if (g.pageManager.GetPage() is PageGame)
            {
                (g.pageManager.GetPage() as PageGame).mouseManager.Remove(this);
                (g.pageManager.GetPage() as PageGame).gamePaused = false;
                g.soundManager.unpauseSounds();
            }
            else if (g.pageManager.GetPage() is LevelMap)
            {
                (g.pageManager.GetPage() as LevelMap).mouseManager.Remove(this);
            }
            g.gameSpeed = 1f;
        }
        public void close(Game1 g)
        {
            if (g.pageManager.GetPage() is PageGame)
            {
                g.pageGame.hudManager.activeObject = null;
                g.pageGame.hudManager.Remove(this, g);
            }
            else if (g.pageManager.GetPage() is LevelMap)
            {
                g.levelMap.hudManager.activeObject = null;
                g.levelMap.hudManager.Remove(this, g);
            }
            
            
        }
        public override void Draw(Game1 g)
        {
            Vector2 pos = GetPos(g);
            new Sprite(Textures.infobox).Draw(pos.X, pos.Y, Width, Height, layerDepth: depth);
            //new Rectangle(0, 96, 48, 32)
            hm.Draw(g);
        }
        public void Clicked(float x, float y, Game1 g)
        {
            if (g.pageManager.GetPage() is PageGame)
            {
                g.pageGame.mouseManager.stopClick = true;
            }
            else if (g.pageManager.GetPage() is LevelMap)
            {
                g.levelMap.mouseManager.stopClick = true;
            }
            List<Hud> huds = new List<Hud>(hm.huds);
            foreach (Hud h in huds)
            {
                if(h is Clickable)
                {
                    (h as Clickable).Clicked(x, y, g);
                }
            }
        }

        public void select(Game1 g)
        {
            
        }
    }
}

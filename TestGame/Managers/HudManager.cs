using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TestGame.Graphics;
using TestGame.Huds;

namespace TestGame.Managers
{
    public class HudManager
    {
        public List<Hud> huds = new List<Hud>();

        public InfoDisplay activeObject = null;
        private static Sound clickSound = new Sound(Sounds.click, 0.1f, SoundManager.types.Normal);

        public void setActiveObject(InfoDisplay obj, Game1 g)
        {
            g.pageGame.mouseManager.stopClick = true;
            if(obj != activeObject)
            {
                clickSound.play(g);
                closeActiveObject(g);
                activeObject = obj;
                obj.select(g);
            }
        }
        public void closeActiveObject(Game1 g)
        {
            if (activeObject != null)
            {
                activeObject.close(g);
            }
            activeObject = null;
        }
        public void Draw(Game1 g)
        {
            foreach (Hud obj in huds)
            {
                if (obj.rendered && obj.visiable)
                {
                    obj.Draw(g);
                }

            }
        }
        public void Add(Hud obj, Game1 g) { huds.Add(obj); obj.Init(g); }
        public void Add(Hud obj) { huds.Add(obj); }
        public void Remove(Hud obj, Game1 g) { huds.Remove(obj); obj.Destroy(g); }
        public void Clear(Game1 g)
        {
            foreach (Hud o in huds)
            {
                o.Destroy(g);
            }
            huds.Clear();
        }
    }
}

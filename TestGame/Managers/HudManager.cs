using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Huds;
using TestGame.Huds.ActiveHuds;

namespace TestGame.Managers
{
    public class HudManager
    {
        public List<Hud> huds = new List<Hud>();
        private ActiveUI activeUI = null;
        public void Draw(Game1 g)
        {
            foreach (Hud obj in huds)
            {
                if (obj.rendered && obj.visiable)
                {
                    obj.Draw(g);
                }

            }
            if (activeUI != null)
            {
                activeUI.Draw(g);
            }
        }
        public void Open(ActiveUI activeUI, Game1 g)
        {
            this.activeUI = activeUI;
            //g.pageGame.player.canMove = false;
        }
        public void Close(Game1 g)
        {
            activeUI = null;
            //g.pageGame.player.canMove = true;
        }
        public void Add(Hud obj) { huds.Add(obj); }
        public void Remove(Hud obj, Game1 g) { huds.Remove(obj); }
        public void Clear() { huds.Clear(); }
    }
}

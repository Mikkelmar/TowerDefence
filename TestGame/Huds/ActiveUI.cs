using System;
using System.Collections.Generic;
using System.Text;

namespace TestGame.Huds
{
    public abstract class ActiveUI : Hud
    {
        private List<Hud> huds = new List<Hud>();
        public override void Draw(Game1 g)
        {
            foreach(Hud hud in huds)
            {
                if(hud.rendered && hud.visiable)
                {
                    hud.Draw(g);
                }
            }
        }
        public void Add(Hud hud) { huds.Add(hud); }
        public void Remove(Hud hud) { huds.Remove(hud); }
        public void Clear() { huds.Clear(); }
    }
}

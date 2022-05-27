using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Huds;

namespace TestGame.Managers
{
    public class HudManager
    {
        public List<Hud> huds = new List<Hud>();

        public void Draw(Game1 g)
        {
            //gameObjects.Sort((o1, o2) => o2.Y.CompareTo(o1.Y));
            foreach (Hud obj in huds)
            {
                if (obj.rendered && obj.visiable)
                {
                    obj.Draw(g);
                }

            }
        }
        public void Add(Hud obj) { huds.Add(obj); }
        public void Remove(Hud obj, Game1 g) { huds.Remove(obj); }
        public void Clear() { huds.Clear(); }
    }
}

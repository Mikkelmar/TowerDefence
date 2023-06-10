using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace TestGame.Managers
{
    public class PageManager
    {
        public List<Page> pages = new List<Page>();
        private int count { get { return pages.Count; } }
        public int selected = 0;
        public void Update(GameTime gt, Game1 g)
        {
            //foreach( Page p in pages)
            if (count > selected)
            {
                pages[selected].Update(gt, g);
            }
            
        }
        public void Draw(Game1 g)
        {
            if (count > selected)
            {
                pages[selected].Draw(g);
            }
        }
        public Page GetPage() {
            return pages[selected]; 
        }

        public virtual void Set(int id, Game1 g) { selected = id; pages[selected].Load(g); }
        public virtual void Set(Page page, Game1 g) { Set(page.id, g); }
        public void Add(Page page, Game1 g) { pages.Add(page); page.Init(g); }
        public void Remove(Page page) { pages.Remove(page); }
        public void Clear() { pages.Clear(); }

        internal void DrawUI(Game1 game1)
        {
            if (count > selected)
            {
                pages[selected].DrawUI(game1);
            }
        }
    }
}

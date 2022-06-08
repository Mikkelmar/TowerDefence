using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Containers.Items;
using TestGame.Huds;
using TestGame.Huds.ActiveHuds;
using TestGame.Objects.Entities;

namespace TestGame.Managers
{
    public class HudManager
    {
        public List<Hud> huds = new List<Hud>();
        public ActiveUI activeUI = null;
        public Item Holding = null;
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
                if(Holding != null)
                {
                    Vector2 pos = MouseManager.GetMousePos();
                    pos += g.gameCamera.Position;
                    Holding.Draw(pos, 64, 0);
                }
            }
        }
        public void Open(ActiveUI activeUI, Game1 g)
        {
            if (activeUI != null) //Se an hvordan man skal kunne åpne flere
            {
                Close(g);
            }
                this.activeUI = activeUI;
            //g.pageGame.player.canMove = false;
        }
        public void Close(Game1 g)
        {
            if(activeUI != null)
            {
                activeUI.Destroy(g);
                if(Holding != null)
                {
                    g.pageGame.getObjectManager().Add(new ItemEntity((int)g.pageGame.player.GetPosCenter().X, (int)g.pageGame.player.GetPosCenter().Y, Holding), g);
                    Holding = null;
                }
            }
            activeUI = null;
            //g.pageGame.player.canMove = true;
        }
        public void Add(Hud obj) { huds.Add(obj); }
        public void Remove(Hud obj, Game1 g) { huds.Remove(obj); obj.Destroy(g); }
        public void Clear() { huds.Clear(); }
    }
}

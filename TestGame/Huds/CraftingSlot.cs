using Microsoft.Xna.Framework;
using System;
using System.Diagnostics;
using TestGame.Containers;
using TestGame.Containers.Items;
using TestGame.Managers;

namespace TestGame.Huds
{
    public class CraftingSlot : Hud, Clickable
    {
        private Recepie recepie;
        public CraftingSlot(Recepie recepie, float x, float y) : base()
        {
            this.recepie = recepie;
            this.X = x;
            this.Y = y;
            this.Width = 200;
            this.Height = 50;
            this.depth = 0.0000000005f;
        }

        public void Clicked(float x, float y, Game1 g)
        {
            if(GetRectangle(g).Contains(new Vector2(x, y).ToPoint()))
            {
                ItemContainer inv = g.pageGame.player.inventory;
                if (inv.Contain(recepie.required))
                {
                    recepie.Create(inv);
                }
            }
        }

        public override void Draw(Game1 g)
        {
            Vector2 slotPos = new Vector2((this.X + g.gameCamera.Position.X + 12), (this.Y + g.gameCamera.Position.Y + 4));
            foreach (Item i in recepie.required.GetItems())
            {
                i.Draw(slotPos, 64, depth * 0.1f);
                slotPos.X += 64;
            }
            Drawing.DrawText("-->",(int)(slotPos.X+16),(int)(slotPos.Y+20),(depth * 0.1f));
            slotPos.X += 64;
            recepie.creates.Draw(slotPos, 64, depth * 0.1f);
        }
        public override void Destroy(Game1 g)
        {
            g.pageGame.mouseManager.Remove(this);
        }
    }
}

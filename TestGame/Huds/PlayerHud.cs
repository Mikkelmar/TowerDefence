using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Containers.Items;
using TestGame.Graphics;
using TestGame.Objects;

namespace TestGame.Huds
{
    class PlayerHud : Hud
    {
        private Player player;
        private Sprite sprite, activeSlot;
        public PlayerHud(Player player)
        {
            this.player = player;
            sprite = new Sprite(Textures.inevbar);
            activeSlot = new Sprite(Textures.selectedSlot);

            Width = 136 * 4;
            Height = 20 * 4;
            X = ((Width / 2) + 64);
            Y = 640;
        }
        public override void Draw(Game1 g)
        {


            Vector2 pos = GetPos(g);
            sprite.Draw(
                GetPos(g), Width, Height,
                depth
               );
            pos.X += (player.ActiveSlot * 64)+ 4;
            activeSlot.Draw(pos, Height, (float)(depth * 0.99));

            Vector2 itemPos = new Vector2(this.X + g.pageGame.cam.position.X + 12, this.Y + g.pageGame.cam.position.Y + 4);
            for (int i = 0; i < 8; i++) //8 for antall slots i hotbaren(bør ikke hardkodes)
            {
                Item item = player.inventory.GetItemAtSlot(i);
                if (item != null)
                {
                    if(player.ActiveSlot == i){itemPos.Y -= 20;} //harkodet for å teste lmao
                    item.Draw(itemPos, 64, (depth * 0.5f));
                    if (player.ActiveSlot == i) { itemPos.Y += 20; } //-1-

                }
                itemPos.X += 64;

            }
        }
    }
}

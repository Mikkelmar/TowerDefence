using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Containers.Items;
using TestGame.Graphics;
using TestGame.Managers;
using TestGame.Objects;

namespace TestGame.Huds.ActiveHuds
{
    public class InventoryUI : ActiveUI, KeyboardLisner
    {
        private Player player;
        private Sprite sprite;
        private float Width = 136 * 4, Height = 20 * 4;
        public InventoryUI(Player player)
        {
            this.player = player;
            this.sprite = new Sprite(Textures.inevbar);
            this.X = (Width / 2) + 64;
            this.Y = 640;
        }
        public override void Draw(Game1 g)
        {
            sprite.Draw(
                new Rectangle(
                    (int)(this.X + g.pageGame.cam.position.X),
                    (int)(this.Y + g.pageGame.cam.position.Y),
                    (int)Width,
                    (int)Height),
                depth
               );

            Vector2 itemPos = new Vector2(this.X + g.pageGame.cam.position.X + 12, this.Y + g.pageGame.cam.position.Y + 4);
            foreach (Item i in player.inventory.GetItems())
            {
                i.Draw(itemPos, 64, (depth * 0.5f));
                itemPos.X += 64;
            }
        }
        public void KeyPressed(KeyboardState kb, Game1 g)
        {
            if (kb.IsKeyDown(Keys.E))
            {
                g.pageGame.hudManager.Close(g);
                g.pageGame.keyBoardManager.Remove(this);
            }
        }
    }
}

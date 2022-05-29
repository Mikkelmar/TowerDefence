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
    public class InventoryUI : ActiveUI
    {
        private Sprite sprite;

        public InventoryUI(Game1 g)
        {
            this.sprite = new Sprite(Textures.inevntoryUI);
            this.X = 90;
            this.Y = 140;
            Width = 166 * 4;
            Height = 104 * 4;
            Add(new ItemDisplayer(g.pageGame.player.inventory, 8, 5, 210, 180, g));
            
        }
        public override void Draw(Game1 g)
        {
            sprite.Draw(GetRectangle(g));
            base.Draw(g);
        }
    }
}

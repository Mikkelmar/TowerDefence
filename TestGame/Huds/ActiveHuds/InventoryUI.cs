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
            this.X = 290;
            this.Y = 140;
            Width = 166 * 4;
            Height = 104 * 4;
            Add(new ItemDisplayer(g.pageGame.player.inventory, 8, 5, X+120, 180, g));
            Add(new ArmourDisplayer(g.pageGame.player.Wearing, new Vector2(X+9*4, Y+15*4), g));
            
        }
        public override void Draw(Game1 g)
        {
            sprite.Draw(GetPos(g), Width, Height, depth);
            base.Draw(g);
        }
    }
}

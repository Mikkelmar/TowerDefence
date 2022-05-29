using Microsoft.Xna.Framework;
using System;
using TestGame.Graphics;
using TestGame.Huds.ActiveHuds;
using TestGame.Managers;

namespace TestGame.Objects.Entities.Buildings
{
    public class CraftingTable : Building
    {
        public CraftingTable(int x, int y) : base(x, y, 16*6, 16 * 6, 4, new Sprite(Textures.spriteSheet_1, new Rectangle(24 * 16, 16 * 13, 32, 32)))
        {
            this.solid = true;
        }
        
        public override void Update(GameTime gt, Game1 g)
        {
            //
        }

        protected override void Open(Game1 g)
        {
            if (g.pageGame.player.DistanceTo(this.GetPosCenter()) <= 120)
            {
                g.pageGame.hudManager.Open(new Crafting(g), g);
            }
        }
    }
}

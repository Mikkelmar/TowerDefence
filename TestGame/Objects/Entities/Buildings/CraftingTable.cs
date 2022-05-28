using Microsoft.Xna.Framework;
using System;
using TestGame.Graphics;
using TestGame.Huds.ActiveHuds;
using TestGame.Managers;

namespace TestGame.Objects.Entities.Buildings
{
    public class CraftingTable : Entity, Clickable
    {
        public CraftingTable(int x, int y) : base(x, y, 16*6, 16 * 6, 4, new Sprite(Textures.spriteSheet_1, new Rectangle(24 * 16, 16 * 13, 32, 32)))
        {
            this.solid = true;
        }
        
        public override void Init(Game1 g)
        {
            base.Init(g);
            g.pageGame.mouseManager.Add(this, true);

        }
        public override void Destroy(Game1 g)
        {
            g.pageGame.mouseManager.Remove(this);
        }
        public void Clicked(float x, float y, Game1 g)
        {
            if (this.Intersect(new Vector2(x, y)))
            {
                if (g.pageGame.player.DistanceTo(this.GetPosCenter()) <= 120)
                {
                    g.pageGame.hudManager.Open(new Crafting(g), g);
                }
                
            }
        }

        public override void Update(GameTime gt, Game1 g)
        {
            //
        }
    }
}

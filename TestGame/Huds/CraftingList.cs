using Microsoft.Xna.Framework;
using TestGame.Graphics;

namespace TestGame.Huds
{
    public class CraftingList : Hud
    {

        private Sprite sprite;

        public CraftingList()
        {
            this.X = 200;
            this.Y = 100;
            this.Width = 239*4;
            this.Height = 104*4;
            this.sprite = new Sprite(Textures.craftingUI);
        }
        public override void Draw(Game1 g)
        {
            sprite.Draw(GetPos(g), Width, Height, depth);
        }
    }
}

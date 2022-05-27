using Microsoft.Xna.Framework;
using MonoGame.Extended.BitmapFonts;
using System.Diagnostics;
using TestGame.Containers.Items;
using TestGame.Graphics;
using TestGame.Objects;

namespace TestGame.Huds
{
    public class InventoryHud : Hud
    {
        //private Vector2 position { get { return new Vector2(player.X + X, player.Y + Y); } set { X = value.X; Y = value.Y; } }
        //private Vector2 position { get { return new Vector2(X+player.X, Y+player.Y); } set { X = value.X; Y = value.Y; } }
        private Player player;
        private Sprite sprite;
        private float Width= 136*4, Height=20*4;

        public InventoryHud(Player player)
        {
            this.player = player;
            this.sprite = new Sprite(Textures.inevbar);
            this.X = (Width / 2)+64;
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
            int index = 0;
            foreach(Item i in player.inventory.GetItems())
            {
                i.Sprite.Draw(
                   new Rectangle(
                    (int)(this.X + g.pageGame.cam.position.X +(64*index)+12),
                    (int)(this.Y + g.pageGame.cam.position.Y+4),
                    (int)64,
                    (int)64),
                   (depth*0.1f)
               );
                index++;
                if(i.Ammount != 1) //displayer kun antall hvis det ikke er kun 1
                {

                    Drawing.DrawText(
                    i.Ammount.ToString(),
                        (int)(this.X + g.pageGame.cam.position.X + (64 * index) - 10),
                        (int)(this.Y + g.pageGame.cam.position.Y + 40),
                        (depth * 0.1f)
                    );
                }
                

            }
        }
    }
}

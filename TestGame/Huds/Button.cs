using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TestGame.Graphics;
using TestGame.Managers;
using TestGame.Objects.Towers;

namespace TestGame.Huds
{
    public abstract class Button : HoverHud, Clickable
    {
        private static Sound clickSound = new Sound(Sounds.click2, 0.1f, SoundManager.types.Normal);
        public Button(int x, int y)
        {
            X = x;
            Y = y;
            Width = 48;
            Height = 48;
        }
        
        public override void Init(Game1 g)
        {
            base.Init(g);
            g.pageManager.GetPage().mouseManager.Add(this, true);  
        }
        public override void Destroy(Game1 g)
        {
            base.Destroy(g);
            g.pageManager.GetPage().mouseManager.Remove(this);
        }
        public void Clicked(float x, float y, Game1 g)
        {

            Vector2 cords = GetPos(g);
            if (new Rectangle((int)cords.X, (int)cords.Y, Width, Height).Contains(new Vector2(x,y)))
            {
                activate(g);
                clickSound.play(g);
            }

        }
        public abstract void activate(Game1 g);

        public override void Draw(Game1 g)
        {
            int hoverd = 0;
            if (BeingHoverd)
            {
                hoverd = 32;
            }
            new Sprite(Textures.gui, new Rectangle(hoverd, 80, 16, 16)).Draw(GetPos(g), Width, Height, depth);
            
        }
    }
}

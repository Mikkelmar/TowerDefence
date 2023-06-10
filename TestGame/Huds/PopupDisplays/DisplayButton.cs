using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;
using TestGame.Managers;

namespace TestGame.Huds.PopupDisplays
{
    public abstract class DisplayButton : HoverHud, Clickable
    {
        protected PopupDisplay pd;
        private static Sound hoverSound = new Sound(Sounds.hover, 0.2f, SoundManager.types.Menu);
        public string displayText;
        public DisplayButton(PopupDisplay pd, float x, float y, string displayText = "")
        {
            this.pd = pd;
            X = pd.X + x;
            Y = pd.Y + y;

            Width = 30 * 4;
            Height = 14 * 4;

            depth = pd.depth * 0.001f;
            this.displayText = displayText;
        }

        protected override void TriggerHoverd(float x, float y, Game1 g)
        {
            hoverSound.play(g);
        }

        public abstract void activate(Game1 g);
        public void Clicked(float x, float y, Game1 g)
        {
            if (new Rectangle((int)X, (int)Y, Width, Height).Contains(new Vector2(x, y)))
            {
                activate(g);
            }
        }

        public override void Draw(Game1 g)
        {
            int i = 0;
            if (BeingHoverd)
            {
                i = 32;
            }
            new Sprite(Textures.gui, new Rectangle(113, 81 + i, 30, 14)).Draw(X, Y, Width, Height, depth);
            drawText(g);
        }
        protected void drawText(Game1 g)
        {
            float fitScale = Math.Min(TextHandler.GetFitScale(displayText, Width - 20), 1f);
            Drawing.DrawText(
                displayText,
                X + (Width / 2) - (TextHandler.textLength(displayText) * fitScale / 2),
                Y + 10,
                layerDepth: depth * 0.2f,
                scale: fitScale
               );
        }
    }
}

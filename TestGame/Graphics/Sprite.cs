using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestGame.Graphics
{
    public class Sprite
    {
        public Texture2D Texture { get; private set; }

        private Rectangle? Rectangle = null;
        private Rectangle rectangle;
        private object p;

        public Sprite(Texture2D texture, int x, int y, int width, int height)
        {
            Texture = texture;
            Rectangle = new Rectangle(x, y, width, height);
        }
        public Sprite(Texture2D texture)
        {
            Texture = texture;   
        }
        public Sprite(Texture2D texture, Rectangle rect)
        {
            Rectangle = rect;
            Texture = texture;
        }

        public Sprite(Texture2D texture, Rectangle rectangle, object p) : this(texture)
        {
            this.rectangle = rectangle;
            this.p = p;
        }

        public void Draw(SpriteBatch spritebatch, Vector2 pos, float layerDepth = 0, Rectangle? bounds = null, int scale = 1)
        {
            //Todo setup this prettier
            if (bounds != null)
            {
                spritebatch.Draw(
                    Texture,
                    (Rectangle)bounds,
                    Rectangle,
                    Color.White,
                    0.0f,
                    Vector2.Zero,
                    SpriteEffects.None,
                    layerDepth
               );
            }
            else
            {
                spritebatch.Draw(
                    Texture,
                    pos,
                    Rectangle,
                    Color.White,
                    0.0f,
                    Vector2.Zero,
                    scale,
                    SpriteEffects.None,
                    layerDepth
                  );
            }
        }
    }
}

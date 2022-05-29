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
        public void Draw(Vector2 pos, float layerDepth = 0.00001f, int scale = 1)
        {
            Draw(Drawing._spriteBatch, pos, layerDepth, null, scale);
        }
        public void Draw(Rectangle bounds, float layerDepth = 0.00001f, int scale = 1)
        {
            Draw(Drawing._spriteBatch, bounds, layerDepth, scale);
        }
        public void Draw(SpriteBatch spritebatch, Rectangle bounds, float layerDepth = 0.00001f, int scale = 1)
        {
            spritebatch.Draw(
                    Texture,
                    bounds,
                    Rectangle,
                    Color.White,
                    0.0f,
                    Vector2.Zero,
                    SpriteEffects.None,
                    layerDepth
               );
        }
            public void Draw(SpriteBatch spritebatch, Vector2 pos, float layerDepth = 0.00001f, Rectangle? bounds = null, int scale = 1)
        {
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

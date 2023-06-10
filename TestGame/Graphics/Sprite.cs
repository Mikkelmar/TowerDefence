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

        public Rectangle? rectangle = null; //want to change this to private

        public Sprite(Texture2D texture, int x, int y, int width, int height)
        {
            Texture = texture;
            rectangle = new Rectangle(x, y, width, height);
        }
        public Sprite(Texture2D texture)
        {
            Texture = texture;   
        }

        public Sprite(Texture2D texture, Rectangle rectangle) : this(texture)
        {
            this.rectangle = rectangle;
        }
        //Welcome to overload hell
        public void Draw(Vector2 pos, float width, float height, float layerDepth = 0.00001f, float rotation = 0.0f, Vector2? origin = null, float alpha = 1f, SpriteEffects spriteEffects = SpriteEffects.None)
        {
            Draw(Drawing._spriteBatch, pos.X, pos.Y, width, height, layerDepth, null, rotation, origin, alpha: alpha, spriteEffects: spriteEffects);
        }
        public void Draw(Vector2 pos, float width, float height, float layerDepth = 0.00001f)
        {
            Draw(Drawing._spriteBatch, pos.X, pos.Y, width, height, layerDepth, null);
        }
        public void Draw(Vector2 pos, float size, float layerDepth = 0.00001f)
        {
            Draw(Drawing._spriteBatch, pos.X, pos.Y, size, size, layerDepth, null);
        }
        public void Draw(float x, float y, float size, float layerDepth = 0.00001f)
        {
            Draw(Drawing._spriteBatch, x, y, size, size, layerDepth, null);
        }

        public void Draw(float x, float y, float width, float height, float layerDepth = 0.00001f)
        {
            Draw(Drawing._spriteBatch, x, y, width, height, layerDepth, null);
        }
        public void Draw(Vector2 pos, float layerDepth = 0.00001f, int width = 32, int height=32, float alpha = 1f)
        {
            Draw(Drawing._spriteBatch, pos.X, pos.Y, width, height, layerDepth: layerDepth, alpha: alpha);
        }
        public void Draw(Vector2 pos, float layerDepth = 0.00001f, int scale = 3)
        {
            Draw(Drawing._spriteBatch, pos, layerDepth, null, scale);
        }
        public void Draw(Rectangle pos, float layerDepth = 0.00001f, Rectangle? bounds = null)
        {
            Draw(Drawing._spriteBatch, pos, layerDepth, bounds);
        }
        public void Draw(Rectangle pos, float layerDepth = 0.00001f, int scale = 3)
        {
            Draw(Drawing._spriteBatch, pos, layerDepth, null, scale);
        }

        public void Draw(SpriteBatch spritebatch, Rectangle rect, float layerDepth = 0.00001f, Rectangle? bounds = null, float rotation = 0.0f)
        {
            Rectangle? useBounds = rectangle;
            if (bounds != null)
            {
                useBounds = (Rectangle)bounds;
            }
            spritebatch.Draw(
                    Texture,
                    rect,
                    useBounds,
                    Color.White,
                    rotation,
                    Vector2.Zero,
                    SpriteEffects.None,
                    layerDepth
               );
        }
        
        public void Draw(SpriteBatch spritebatch, float x, float y, float width, float height, float layerDepth = 0.00001f, Rectangle? bounds = null, float rotation = 0.0f, Vector2? origin = null, float alpha = 1f, SpriteEffects spriteEffects = SpriteEffects.None)
        {
            Rectangle? useBounds = rectangle;
            Vector2? originVecotr = origin;
            if (originVecotr == null)
            {
                originVecotr = Vector2.Zero;
            }
            if (bounds != null)
            {
                useBounds = (Rectangle)bounds;
            }
            if (useBounds != null)
            {
                spritebatch.Draw(
                    Texture,
                    new Vector2(x, y),
                    useBounds,
                    Color.White * alpha,
                    rotation,
                    (Vector2)originVecotr,
                    new Vector2(width / ((Rectangle)useBounds).Width, height / ((Rectangle)useBounds).Height),
                    spriteEffects,
                    layerDepth
               ); ;
            }
            else
            {
                spritebatch.Draw(
                    Texture,
                    new Vector2(x, y),
                    useBounds,
                    Color.White*alpha,
                    rotation,
                    (Vector2)originVecotr,
                    new Vector2(width / Texture.Width, height / Texture.Height),
                    spriteEffects,
                    layerDepth
               ); ;
            }
            
        }
        /*
        public void Draw(Rectangle pos, Rectangle bounds, float layerDepth = 0.00001f)
        {
            Drawing._spriteBatch.Draw(
                    Texture,
                    pos,
                    bounds,
                    Color.White,
                    0.0f,
                    Vector2.Zero,
                    SpriteEffects.None,
                    layerDepth
               );
        }*/
        public void Draw(SpriteBatch spritebatch, Vector2 pos, float layerDepth = 0.00001f, Rectangle? bounds = null, int scale = 3)
        {
            Rectangle? useBounds = rectangle;
            if (bounds != null)
            {
                useBounds = (Rectangle)bounds;
            }
            spritebatch.Draw(
                Texture,
                pos,
                useBounds,
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

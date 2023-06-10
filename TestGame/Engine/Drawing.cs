using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;
using TestGame.Graphics;

namespace TestGame
{
    public static class Drawing
    {
        public static int WINDOW_WIDTH = 1280, WINDOW_HEIGHT = 720;


        public static string TITLE = "Tower Defence";
        public static bool vsync = false;

        //Graphics
        public static GraphicsDeviceManager graphics;
        public static SpriteBatch _spriteBatch;
        private static Texture2D rect;

        // frametime
        public static float fps, delta;

        public static void Initialize(Game1 g)
        {
            g.IsFixedTimeStep = false;
            graphics = new GraphicsDeviceManager(g);
            graphics.PreferredBackBufferWidth = WINDOW_WIDTH;
            graphics.PreferredBackBufferHeight = WINDOW_HEIGHT;
            graphics.SynchronizeWithVerticalRetrace = vsync;
            graphics.HardwareModeSwitch = false;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();
            _spriteBatch = new SpriteBatch(g.GraphicsDevice);
        }
        public static void Update(GameTime gt, Game1 g) {
            delta = (float)gt.ElapsedGameTime.TotalSeconds;
            fps = (float)(1/delta);
            
        }
        public static void DrawText(string text, float x, float y, Game1 g, float layerDepth = 0.0001f, Color? color = null, float scale = 1f)
        {
            DrawText(text, x - g.pageGame.cam.position.X, y - g.pageGame.cam.position.Y, layerDepth, color, scale);
        }
        public static void DrawText(string text, float x, float y, float layerDepth=0.0001f, Color? color = null, float scale = 1f, bool border=false)
          {
            if (color == null)
            {
                color = Color.White;
            }
            _spriteBatch.DrawString(Textures.font, text, new Vector2(x, y), (Color)color, 0.0f, new Vector2(0, 0), scale, SpriteEffects.None, layerDepth);
            if (border)
            {
                _spriteBatch.DrawString(Textures.font, text, new Vector2(x, y) + new Vector2(1 * scale, 1 * scale), (Color)Color.Black, 0.0f, new Vector2(0, 0), scale, SpriteEffects.None, layerDepth+ layerDepth);
                _spriteBatch.DrawString(Textures.font, text, new Vector2(x, y) + new Vector2(-1 * scale, 1 * scale), (Color)Color.Black, 0.0f, new Vector2(0, 0), scale, SpriteEffects.None, layerDepth + layerDepth);
                _spriteBatch.DrawString(Textures.font, text, new Vector2(x, y) + new Vector2(1 * scale, -1 * scale), (Color)Color.Black, 0.0f, new Vector2(0, 0), scale, SpriteEffects.None, layerDepth + layerDepth);
                _spriteBatch.DrawString(Textures.font, text, new Vector2(x, y) + new Vector2(-1 * scale, -1 * scale), (Color)Color.Black, 0.0f, new Vector2(0, 0), scale, SpriteEffects.None, layerDepth + layerDepth);
            }
        }
        public static void FillRect(Rectangle bounds, Color col, float depth, Game1 g) 
        { 
            if (rect == null) { rect = new Texture2D(g.GraphicsDevice, 1, 1);  }
            rect.SetData(new[] { Color.White });
            _spriteBatch.Draw(rect, bounds, null, col, 0, new Vector2(0, 0), SpriteEffects.None, depth);
        }
        public static void DrawLine(Texture2D texture, Vector2 begin, Vector2 end)
        {
            _spriteBatch.Draw(texture, begin, null, Color.White,
                         (float)Math.Atan2(end.Y - begin.Y, end.X - begin.X),
                         new Vector2(0f, (float)texture.Height / 2),
                         new Vector2(Vector2.Distance(begin, end)/ texture.Width, 1f),
                         SpriteEffects.None, 0f); 
        }



    }
}

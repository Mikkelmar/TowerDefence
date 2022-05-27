using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;

namespace TestGame
{
    public static class Drawing
    {
        public static int WINDOW_WIDTH = 1280, WINDOW_HEIGHT = 720;
        public static string TITLE = "Island RPG";
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
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();

            _spriteBatch = new SpriteBatch(g.GraphicsDevice);
        }
        public static void Update(GameTime gt, Game1 g) {
            delta = (float)gt.ElapsedGameTime.TotalSeconds;
            fps = (float)(1/delta);
            
        }
        public static void DrawText(string text, int x, int y, float layerDepth=0.0001f)
        {
            _spriteBatch.DrawString(Textures.font, text, new Vector2(x, y), Color.White, 0.0f, new Vector2(0, 0), 1f, SpriteEffects.None, layerDepth);
        }
        public static void FillRect(Rectangle bounds, Color col, float depth, Game1 g) 
        { 
            if (rect == null) { rect = new Texture2D(g.GraphicsDevice, 1, 1);  }
            rect.SetData(new[] { Color.White });
            _spriteBatch.Draw(rect, bounds, null, col, 0, new Vector2(0, 0), SpriteEffects.None, depth);
        }
    }
}

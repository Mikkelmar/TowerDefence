using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestGame.Graphics
{
    public static class Textures
    {
        public static Texture2D monster, player, spriteSheet_1, inevbar, craftingUI, inevntoryUI;
        public static SpriteFont font;
        public static void Load(Game1 g)
        {
            monster = g.Content.Load<Texture2D>("monster");
            player = g.Content.Load<Texture2D>("player");
            inevbar = g.Content.Load<Texture2D>("invenbar");
            craftingUI = g.Content.Load<Texture2D>("crafting");
            inevntoryUI = g.Content.Load<Texture2D>("inventory");

            spriteSheet_1 = g.Content.Load<Texture2D>("!CL_DEMO");

            font = g.Content.Load<SpriteFont>("fonts/boldGame");
        }
    }
}

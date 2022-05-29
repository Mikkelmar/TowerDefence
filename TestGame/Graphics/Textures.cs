using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestGame.Graphics
{
    public static class Textures
    {
        public static Texture2D monster, player, spriteSheet_1, inevbar, craftingUI, inevntoryUI, spriteSheet_2,
            slot, itemContainer;
        public static SpriteFont font;
        public static void Load(Game1 g)
        {
            monster = g.Content.Load<Texture2D>("monster");
            player = g.Content.Load<Texture2D>("player");
            inevbar = g.Content.Load<Texture2D>("invenbar");
            craftingUI = g.Content.Load<Texture2D>("crafting");
            inevntoryUI = g.Content.Load<Texture2D>("inventory");
            slot = g.Content.Load<Texture2D>("slot");
            itemContainer = g.Content.Load<Texture2D>("itemContainer");

            spriteSheet_1 = g.Content.Load<Texture2D>("!CL_DEMO");
            spriteSheet_2 = g.Content.Load<Texture2D>("sheet");

            font = g.Content.Load<SpriteFont>("fonts/boldGame");
        }
    }
}

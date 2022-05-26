using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestGame.Graphics
{
    public static class Textures
    {
        public static Texture2D monster, player, spriteSheet_1;
        public static void Load(Game1 g)
        {
            monster = g.Content.Load<Texture2D>("monster");
            player = g.Content.Load<Texture2D>("player");

            spriteSheet_1 = g.Content.Load<Texture2D>("!CL_DEMO");
        }
    }
}

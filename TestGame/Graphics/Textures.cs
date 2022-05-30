﻿using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestGame.Graphics
{
    public static class Textures
    {
        public static Texture2D monster, player, spriteSheet_1, inevbar, craftingUI, inevntoryUI, spriteSheet_2,
            slot, selectedSlot, itemContainer, melting, doneArrow, spriteSheet_3, fireIcon;
        public static SpriteFont font;
        public static void Load(Game1 g)
        {
            monster = g.Content.Load<Texture2D>("monster");
            player = g.Content.Load<Texture2D>("player");
            inevbar = g.Content.Load<Texture2D>("invenbar");
            craftingUI = g.Content.Load<Texture2D>("crafting");
            inevntoryUI = g.Content.Load<Texture2D>("inventory");
            slot = g.Content.Load<Texture2D>("slot");
            selectedSlot = g.Content.Load<Texture2D>("selected");
            itemContainer = g.Content.Load<Texture2D>("itemContainer");
            melting = g.Content.Load<Texture2D>("melting");
            doneArrow = g.Content.Load<Texture2D>("doneArrow");
            fireIcon = g.Content.Load<Texture2D>("fireIcon");

            spriteSheet_1 = g.Content.Load<Texture2D>("!CL_DEMO");
            spriteSheet_2 = g.Content.Load<Texture2D>("sheet");
            spriteSheet_3 = g.Content.Load<Texture2D>("icons");

            font = g.Content.Load<SpriteFont>("fonts/boldGame");
        }
    }
}

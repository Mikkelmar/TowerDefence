using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;
using TestGame.Pages;

namespace TestGame.Objects.Monsters
{
    public class MiniLegs : Monster
    {
        public MiniLegs(Path path, int startDistance = 0) : base(path, startDistance, true, 24, 24)
        {
            Speed = 80;
            hp = 4;
            reward = 1;
            sprite = new Sprite(Textures.monsterSheet, new Rectangle(32 * 0, 32 *3, 32, 32));
            name = "Mini Legs";
        }
    }
}

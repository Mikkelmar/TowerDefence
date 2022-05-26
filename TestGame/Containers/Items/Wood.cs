using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;

namespace TestGame.Containers.Items
{
    public class Wood : Item
    {
        public Wood() 
            : base(
                new Sprite(Textures.spriteSheet_1, new Rectangle(33 * 16, 16*5, 16, 16)), 
                "Wood")
        {
            
        }
    }
    public class Stone : Item
    {
        public Stone()
            : base(
                new Sprite(Textures.spriteSheet_1, new Rectangle(36 * 16, 16 * 6, 16, 16)),
                "Stone")
        {

        }
    }
    public class Apple : Item
    {
        public Apple()
            : base(
                new Sprite(Textures.spriteSheet_1, new Rectangle(19 * 16, 16 * 1, 16 * 1, 16 * 1)),
                "Apple")
        {

        }
    }
}

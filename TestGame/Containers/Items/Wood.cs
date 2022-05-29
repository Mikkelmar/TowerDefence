using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;

namespace TestGame.Containers.Items
{
    public class Wood : Item
    {
        public Wood(int ammount=1) 
            : base(
                new Sprite(Textures.spriteSheet_1, new Rectangle(33 * 16, 16*5, 16, 16)), 
                "Wood",
                ammount)
        {
            
        }
    }
    public class Stone : Item
    {
        public Stone(int ammount = 1)
            : base(
                new Sprite(Textures.spriteSheet_1, new Rectangle(36 * 16, 16 * 6, 16, 16)),
                "Stone",
                ammount)
        {

        }
    }
    public class Apple : Item
    {
        public Apple(int ammount = 1)
            : base(
                new Sprite(Textures.spriteSheet_1, getSpriteRect(19, 1)),
                "Apple",
                ammount)
        {

        }
    }
    public class Bow : Item
    {
        public Bow(int ammount = 1)
            : base(
                new Sprite(Textures.spriteSheet_2, getSpriteRect(0, 2)),
                "Bow",
                ammount)
        {

        }
    }
    public class IronHelmet : Item
    {
        public IronHelmet(int ammount = 1)
            : base(
                new Sprite(Textures.spriteSheet_2, getSpriteRect(4, 5)),
                "Iron Helmet",
                ammount)
        {

        }
    }
    public class Iron : Item
    {
        public Iron(int ammount = 1)
            : base(
                new Sprite(Textures.spriteSheet_2, getSpriteRect(12, 6)),
                "Iron",
                ammount)
        {

        }
    }
}

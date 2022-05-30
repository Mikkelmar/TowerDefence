﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;

namespace TestGame.Containers.Items
{
    public class Wood : Fuel
    {
        public Wood(int ammount=1) 
            : base(
                new Sprite(Textures.spriteSheet_1, new Rectangle(33 * 16, 16*5, 16, 16)), 
                "Wood",
                new TimeSpan(0, 0, 3),
                ammount)
        {}

    }
    public class Stone : MeltAble
    {
        public Stone(int ammount = 1)
            : base(
                new Sprite(Textures.spriteSheet_1, new Rectangle(36 * 16, 16 * 6, 16, 16)),
                "Stone",
                new Iron())
        {}

    }
    public class Apple : Item
    {
        public Apple(int ammount = 1)
            : base(
                new Sprite(Textures.spriteSheet_1, getSpriteRect(19, 1)),
                "Apple",
                ammount)
        {
            itemType = ItemType.Food;
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

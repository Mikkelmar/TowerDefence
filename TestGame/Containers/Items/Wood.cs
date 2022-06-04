using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Containers.Items.ItemTypes;
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
                new Iron(),
                ammount)
        {}

    }
    public class CopperOreItem : MeltAble
    {
        public CopperOreItem(int ammount = 1)
            : base(
                new Sprite(Textures.spriteSheet_2, getSpriteRect(2, 9)),
                "Copper ore",
                new CopperIngot(),
                ammount)
        { }
    }
    public class TinOreItem : MeltAble
    {
        public TinOreItem(int ammount = 1)
            : base(
                new Sprite(Textures.spriteSheet_2, getSpriteRect(3, 9)),
                "Tin ore",
                new TinIngot(),
                ammount)
        { }
    }
    public class Apple : Food
    {
        public Apple(int ammount = 1)
            : base(
                new Sprite(Textures.spriteSheet_1, getSpriteRect(19, 1)),
                "Apple",
                2,
                ammount)
        {
        }
    }
    public class Bow : BowItem
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
    public class CopperIngot : Item
    {
        public CopperIngot(int ammount = 1)
            : base(
                new Sprite(Textures.spriteSheet_2, getSpriteRect(4, 9)),
                "Copper Ingot",
                ammount)
        {
        }
    }
    public class TinIngot : Item
    {
        public TinIngot(int ammount = 1)
            : base(
                new Sprite(Textures.spriteSheet_2, getSpriteRect(0, 9)),
                "Tin Ingot",
                ammount)
        {
        }
    }
    public class BronzeIngot : Item
    {
        public BronzeIngot(int ammount = 1)
            : base(
                new Sprite(Textures.spriteSheet_2, getSpriteRect(1, 9)),
                "Bronze Bar",
                ammount)
        {
        }
    }
    public class IronArrow : Arrow
    {
        public IronArrow(int ammount = 1)
            : base(
                new Sprite(Textures.spriteSheet_2, getSpriteRect(0, 1)),
                "Iron Arrow",
                1,
                ammount)
        { }
    }
}

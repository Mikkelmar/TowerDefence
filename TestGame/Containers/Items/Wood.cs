using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TestGame.Containers.Items.ItemTypes;
using TestGame.Graphics;
using TestGame.Objects.Entities.Creatures;

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
    public class FineBow : BowItem
    {
        public FineBow(int ammount = 1)
            : base(
                new Sprite(Textures.spriteSheet_2, getSpriteRect(13, 2)),
                "Fine Bow",
                ammount,
                KnockBack: 200)
        {
        }
    }
    public class IronHelmet : Armour
    {
        public IronHelmet(int ammount = 1)
            : base(
                new Sprite(Textures.spriteSheet_2, getSpriteRect(4, 5)),
                "Iron Helmet",
                2,
                ammount)
        {
            itemType = ItemType.Helmet;
        }
    }
    public class BronzeChestPlate : Armour
    {
        public BronzeChestPlate(int ammount = 1)
            : base(
                new Sprite(Textures.spriteSheet_2, getSpriteRect(3, 7)),
                "Bronze Chestplate",
                5,
                ammount)
        {
            itemType = ItemType.Chest;
        }
    }
    public class LeatherBoots : Armour
    {
        private float speedBoost = 0.25f; // 25% Percent
        public LeatherBoots(int ammount = 1)
            : base(
                new Sprite(Textures.spriteSheet_2, getSpriteRect(0, 6)),
                "Leather Boots",
                1,
                ammount)
        {
            itemType = ItemType.Feet;
        }
        public override void Wearing(Creature creature, Game1 g)
        {
            //base.Wearing(creature, g);
            creature.Speed += creature.Speed * speedBoost;
        }
        public override List<string> GetDescription()
        {
            List<string> desc = base.GetDescription();
            desc.Add("+"+(speedBoost * 100) + "% speed boost");
            return desc;
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

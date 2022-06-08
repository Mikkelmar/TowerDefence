using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Containers.Items;
using TestGame.Containers.Items.ItemTypes.ItemList;
using TestGame.Graphics;

namespace TestGame.Objects.Entities.Structures
{
    public class TinOre : ResourceBlock
    {
        public TinOre(int x, int y) : base(x,y, 32, 32)
        {
            drop = new TinOreItem();
            sprite = new Sprite(Textures.tinOre);
        }
        public override Predicate<Item> CanDestroy()
        {
            return i => i is IronPickaxe;
        }

    }
}

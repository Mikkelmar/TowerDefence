using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Containers.Items;
using TestGame.Containers.Items.ItemTypes.ItemList;
using TestGame.Graphics;

namespace TestGame.Objects.Entities.Structures
{
    public class CopperOre : ResourceBlock
    {
        public CopperOre(int x, int y) : base(x,y, 64, 64)
        {
            drop = new CopperOreItem();
            sprite = new Sprite(Textures.copperOre);
        }
        public override Predicate<Item> CanDestroy()
        {
            return i => i is IronPickaxe;
        }

    }
}

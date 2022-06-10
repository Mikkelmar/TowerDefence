using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Containers.Items;
using TestGame.Containers.Items.ItemTypes.ItemList;
using TestGame.Graphics;

namespace TestGame.Objects.Entities.Structures
{
    public class CopperOre : Ore
    {
        public CopperOre(int x, int y) : base(x,y)
        {
            drop = new CopperOreItem();
            sprite = new Sprite(Textures.copperOre);
        }

    }
}

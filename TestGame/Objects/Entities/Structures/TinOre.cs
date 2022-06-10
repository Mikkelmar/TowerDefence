using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Containers.Items;
using TestGame.Containers.Items.ItemTypes.ItemList;
using TestGame.Graphics;

namespace TestGame.Objects.Entities.Structures
{
    public class TinOre : Ore
    {
        public TinOre(int x, int y) : base(x,y)
        {
            drop = new TinOreItem();
            sprite = new Sprite(Textures.tinOre);
        }
        public override void TakeDamage(int damage, Game1 g)
        {
            base.TakeDamage(damage, g);
        }
        

    }
}

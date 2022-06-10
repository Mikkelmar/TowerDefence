using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;
using TestGame.Objects.Entities.Buildings;
using TestGame.Objects.Entities.Structures;

namespace TestGame.Containers.Items.ItemTypes.ItemList
{
    public class TreeSappling : Buildable
    {
        public TreeSappling(int ammount = 1)
           : base(new Sprite(Textures.spriteSheet_1, getSpriteRect(19,5)), 
                 "Oak Sappling",
                 new Sappling(0, 0),
                 ammount)
        {
            consumes.Add(this);
        }
    }
}

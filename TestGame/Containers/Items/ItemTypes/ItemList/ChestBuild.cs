using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;
using TestGame.Objects.Entities.Buildings;

namespace TestGame.Containers.Items.ItemTypes.ItemList
{
    public class ChestBuild : Buildable
    {
        public ChestBuild(int ammount = 1)
           : base(new Sprite(Textures.spriteSheet_1, new Rectangle(16 * 29, 16 * 14, 32, 32)), 
                 "Chest item builder",
                 new Chest(0, 0),
                 ammount)
        {
            consumes.Add(this);
        }
    }
}

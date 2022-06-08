using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;

namespace TestGame.Containers.Items.ItemTypes.ItemList
{
    public class IronSword : Weapon
    {
        public IronSword(int ammount = 1)
            : base(
                new Sprite(Textures.spriteSheet_2, getSpriteRect(0, 0)),
                "Iron sword",
                ammount)
        {
        }
    }
}

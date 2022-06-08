using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;

namespace TestGame.Containers.Items.ItemTypes.ItemList
{
    class TwoHandSword : Weapon
    {
        public TwoHandSword(int ammount = 1)
            : base(
                new Sprite(Textures.spriteSheet_2, getSpriteRect(6, 0)),
                "Two hand sword",
                ammount)
        {
            Damage = 7;
            WeaponSpeed = new TimeSpan(0, 0, 0, 0, 400);
        }
    }
}

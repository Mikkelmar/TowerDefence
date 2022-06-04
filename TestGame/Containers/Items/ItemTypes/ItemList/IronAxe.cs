using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;

namespace TestGame.Containers.Items.ItemTypes.ItemList
{
    class IronAxe : Weapon
    {
        public IronAxe(int ammount = 1)
            : base(
                new Sprite(Textures.spriteSheet_2, getSpriteRect(4, 1)),
                "Iron axe",
                ammount)
        {
            WeaponSpeed = new TimeSpan(0, 0, 0, 0, 600);
            Damage = 5;
            KnockBack = 1000;
            Init();
        }
    }
}

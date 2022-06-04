using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;

namespace TestGame.Containers.Items.ItemTypes.ItemList
{
    class IronPickaxe : Weapon
    {
        public IronPickaxe(int ammount = 1)
            : base(
                new Sprite(Textures.spriteSheet_2, getSpriteRect(14, 0)),
                "Iron pickaxe",
                ammount)
        {
            WeaponSpeed = new TimeSpan(0, 0, 0, 0, 600);
            Damage = 2;
            KnockBack = 300;
            Init();
        }
    }
}

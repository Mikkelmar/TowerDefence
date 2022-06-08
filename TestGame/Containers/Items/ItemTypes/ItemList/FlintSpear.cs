using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;

namespace TestGame.Containers.Items.ItemTypes.ItemList
{
    public class FlintSpear : Spear
    {
        public FlintSpear(int ammount = 1)
          : base(new Sprite(Textures.spriteSheet_2, getSpriteRect(2, 1)), 
                "Flint spear", 
                2, 
                ammount: ammount)
                  
        {
            WeaponSpeed = new TimeSpan(0,0,0,0,200);
            KnockBack = 200;
            Speed = 400;
        }
    }
}

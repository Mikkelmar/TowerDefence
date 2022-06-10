using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Containers.Items;
using TestGame.Containers.Items.ItemTypes.ItemList;
using TestGame.Graphics;

namespace TestGame.Objects.Entities.Structures
{
    public abstract class Ore : ResourceBlock
    {
        public Ore(int x, int y) : base(x, y, 32, 32)
        {}
        public override Predicate<Item> CanDestroy()
        {
            return i => i is IronPickaxe;
        }
        public override void TakeDamage(int damage, Game1 g)
        {
            base.TakeDamage(damage, g);
            Random rnd = new Random();
            int r = rnd.Next(5- damage);
            if(r == 1)
            {
                g.pageGame.getObjectManager().Add(new ItemEntity((int)GetPosCenter().X, (int)(Y + Height), new Stone()), g);
            }

            
        }
        private int getCrackLevel()
        {
            Double level = ((Double)hp / basehp);
            if(level < 0.30)
            {
                return 3;
            }
            else if (level < 0.55)
            {
                return 2;
            }
            else if (level < 0.8)
            {
                return 1;
            }
            return 0;
        }

        public override void Draw(Game1 g)
        {
            base.Draw(g);
            new Sprite(Textures.miningCrack, new Rectangle(0,32* getCrackLevel(), 32,32)).Draw(position, Width, Height, layerDepth: depth*0.9f);
        }
    }
}

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Containers.Items;
using TestGame.Graphics;

namespace TestGame.Objects.Entities.Structures
{
    public class Sappling : GrowObject
    {
        public Sappling(int x, int y) : base(x, y, 
            new Sprite(Textures.spriteSheet_1, new Rectangle(20 * 16, 0, 16, 16)),
            new TimeSpan(0,0,3))
        {}

        public override void Grow(Game1 g)
        {
            switch (currentStage)
            {
                case 1:
                    solid = true;
                    sprite = new Sprite(Textures.spriteSheet_1, new Rectangle(19 * 16, 2*16, 16, 32));
                    setNewRect(getNextGrowIncreese(currentStage));
                    drop = new Wood(1);
                    HP = 4;
                    break;
                case 2:
                    sprite = new Sprite(Textures.spriteSheet_1, new Rectangle(20 * 16, 1 * 16, 16, 48));
                    setNewRect(getNextGrowIncreese(currentStage));
                    break;
                case 3:
                    sprite = new Sprite(Textures.spriteSheet_1, new Rectangle(21 * 16, 1 * 16, 32, 48));
                    setNewRect(getNextGrowIncreese(currentStage));
                    HP = 6;
                    drop = new Wood(2);
                    break;
                case 4:
                    sprite = new Sprite(Textures.spriteSheet_1, new Rectangle(24 * 16, 1 * 16, 32, 48));
                    HP = 6;
                    drop = new Wood(5);
                    break;
            }
        }

        protected override Rectangle getNextGrowIncreese(int stage)
        {
            return currentStage switch
            {
                1 => getNextGrowPos(0, 16),
                2 => getNextGrowPos(0, 16),
                3 => getNextGrowPos(32, 0),
                4 => getNextGrowPos(0, 0),
                _ => getNextGrowPos(0, 0),
            };
        }
        public override void Draw(Game1 g)
        {
            //Drawing.FillRect(GetHitbox(), Color.Red, 0.000000001f, g); //Debug hitboxes
            base.Draw(g);
        }
    }
}

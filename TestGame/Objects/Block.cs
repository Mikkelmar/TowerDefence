using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Managers;

namespace TestGame.Objects
{
    public class Block : GameObject
    {
        public Block(int x, int y) : base(x, y, 48, 48, ObjectsID.block) 
        {
            this.solid = true;
        }
        public override void Destroy(Game1 g)
        {
        }

        public override void Draw(Game1 g)
        {
            Drawing.FillRect(bounds, Color.Red, 0, g);
        }

        public override void Init(Game1 g)
        {
        }

        public override void Update(GameTime gt, Game1 g)
        {
        }
    }
}

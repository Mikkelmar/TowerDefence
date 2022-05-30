using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;

namespace TestGame.Objects.Entities.Structures
{
    public class Tree : Structure
    {
        public Tree(int x, int y) : base(x, y, 16*3*3, 16*4*3, 401)
        {
            this.sprite = new Sprite(Textures.spriteSheet_1, new Rectangle(24 * 16, 0, 16 * 3, 16 * 4));
            this.hitbox = new Rectangle(16*3, 16*3*3, 16*3, 16*3);
        }
        public override void Destroy(Game1 g)
        {}

        

        public override void Init(Game1 g)
        {}

        public override void Update(GameTime gt, Game1 g)
        {
        }
    }
}

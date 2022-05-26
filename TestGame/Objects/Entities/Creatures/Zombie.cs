using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;

namespace TestGame.Objects.Entities.Creatures
{
    public class Zombie : Hostile
    {
        public Zombie(int x, int y, int w, int h) : base(x, y, w, h, 3, Textures.monster)
        {
            this.Speed = 50;
            this.Health = 20;
            this.Name = "Zombie";
        }
        public override void Destroy(Game1 g)
        {
        }

        public override void Die(Game1 g)
        {
            g.pageManager.GetPage().objectManager.Remove(this, g);
        }

        public override void Init(Game1 g)
        {
        }
    }
}

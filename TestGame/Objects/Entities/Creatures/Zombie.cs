using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TestGame.Containers.Items;
using TestGame.Graphics;
using TestGame.Managers;

namespace TestGame.Objects.Entities.Creatures
{
    public class Zombie : Hostile, Clickable
    {
        public Zombie(int x, int y, int w =64, int h = 64) : base(x, y, w, h, 3, Textures.monster)
        {
            this.Speed = 50;
            this.Health = 20;
            this.Name = "Zombie";
            this.loot = new Apple();
        }

        public void Clicked(float x, float y, Game1 g)
        {
            //Debug.WriteLine("we cliked" + x + g.pageGame.cam.position.X +"  "+ y + g.pageGame.cam.position.Y);
            if(this.Intersect(new Microsoft.Xna.Framework.Vector2(x, y)))
            {
                Die(g);
            }
        }

        public override void Destroy(Game1 g)
        {
            g.pageGame.mouseManager.Remove(this);
            base.Destroy(g);
        }


        public override void Init(Game1 g)
        {
            g.pageGame.mouseManager.Add(this, true);
            base.Init(g);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TestGame.Containers.Items;
using TestGame.Graphics;
using TestGame.Managers;

namespace TestGame.Objects.Entities.Creatures
{
    public class Zombie : Hostile
    {
        public Zombie(int x, int y, int w =64, int h = 64) : base(x, y, w, h, 3, Textures.monster)
        {
            this.Speed = 50;
            this.Health = 20;
            this.Name = "Zombie";
            this.loot = new Apple();
        }
    }
}

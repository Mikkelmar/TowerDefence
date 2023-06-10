using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;
using TestGame.Pages;

namespace TestGame.Objects.Monsters
{
    public class BigSlime : Slime
    {
        public BigSlime(Path path, int startDistance = 0) : base(path, startDistance)
        {
            hp = 64;
            reward = 4;
            Width = 40;
            Height = 40;

            description = "Same but bigger...";
        }
    }
}

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;
using TestGame.Pages;

namespace TestGame.Objects.Monsters
{
    public class MegaSlime : Slime
    {
        public MegaSlime(Path path, int startDistance = 0) : base(path, startDistance)
        {
            hp = 128;
            reward = 5;
            Width = 48;
            Height = 48;

        }
    }
}

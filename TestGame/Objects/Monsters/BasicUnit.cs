using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;
using TestGame.Pages;

namespace TestGame.Objects.Monsters
{
    public class BasicUnit : Monster
    {
        public BasicUnit(Path path, int startDistance = 0) : base(path, startDistance)
        {
            Speed = 45;
            hp = 7;
            reward = 1;
            sprite = new Sprite(Textures.monster);
            name = "Globber";
            description = "Smoll green fella";
        }
    }
}

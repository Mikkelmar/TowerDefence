using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;
using TestGame.Pages;

namespace TestGame.Objects.Monsters
{
    public class UndeadBlobber : Monster
    {
        public UndeadBlobber(Path path, int startDistance = 0) : base(path, startDistance)
        {
            attackDamage = 3;
            attackSpeed = new TimeSpan(0, 0, 0, 0, 1100);
            Speed = 45;
            hp = 15;
            reward = 1;
            sprite = new Sprite(Textures.monster_yellow);
            name = "Undead Globber";
            description = "Average speed and health";
        }
    }
}

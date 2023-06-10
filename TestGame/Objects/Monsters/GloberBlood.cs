using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;
using TestGame.Pages;

namespace TestGame.Objects.Monsters
{
    public class GlobberBlood : Monster
    {
        public GlobberBlood(Path path, int startDistance = 0) : base(path, startDistance, width: 48, height: 48)
        {
            attackDamage = 22;
            attackSpeed = new TimeSpan(0, 0, 0, 1, 500);
            Speed = 32;
            hp = 100;
            reward = 8;
            damage = 3;
            sprite = new Sprite(Textures.monster_blood);
            name = "Crazed Globber";
            description = "TIME TO PANIC!! A 100 HEALTH POINTS!";
        }
    }
}

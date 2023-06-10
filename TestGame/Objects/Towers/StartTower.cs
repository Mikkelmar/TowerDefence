using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;
using TestGame.Objects.Monsters;
using TestGame.Objects.Projectile;

namespace TestGame.Objects.Towers
{
    public class StartTower : Tower
    {
        public StartTower(int x, int y) : base(x, y) {
            name = "Outpost";
            this.damage = 1;
            this.reloadTimer = new TimeSpan(0, 0, 0, 0, 500);
            this.range = 150;
            cost = 60;
            sprite = new Sprite(Textures.startTower_1);
            optionsID = new List<int>() { };
            canSell = false;

        }
        protected override void fire(Game1 g, Monster target)
        {
            g.pageGame.getObjectManager().Add(new Arrow((int)GetPosCenter().X, (int)GetPosCenter().Y, target, this));
            //target.takeDamage(this.damage, g);
        }
    }
}

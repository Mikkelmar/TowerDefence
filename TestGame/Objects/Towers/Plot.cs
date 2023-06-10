using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;
using TestGame.Objects.Monsters;
using TestGame.Pages;

namespace TestGame.Objects.Towers
{
    public class Plot : Tower
    {
        public static List<int> plotOptions = new List<int>() { 0, 6, 11, 15, 21};
    public Plot(int x, int y) : base(x-32,y-32)
        {
            sprite = new Sprite(Textures.emptySlot);
            optionsID = plotOptions;
            canSell = false;
            this.range = 0;
            name = "buildPlot";
            this.damage = 0;
            this.reloadTimer = new TimeSpan(0, 0, 0, 0, 500);
            cost = 0;
        }
        public override void Update(GameTime gt, Game1 g)
        {
        }

        protected override void fire(Game1 g, Monster target)
        {
        }
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace TestGame.Objects.Entities.Creatures
{
    public abstract class Hostile : Creature
    {
        public Hostile(int x, int y, int w, int h, int id, Texture2D texture) : base(x, y, w, h, id, texture)
        {

        }
        public override void Update(GameTime gt, Game1 g)
        {
            float _speed = this.Speed * Drawing.delta;
            Player player = g.pageGame.GetPlayer();
            if (player.DistanceTo(this.position) <= 200)
            {
                this.MoveTowards(player, g, _speed);
            }
            
        }
    }
}

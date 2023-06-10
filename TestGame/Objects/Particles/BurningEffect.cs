using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TestGame.Graphics;
using TestGame.Managers;
using TestGame.Objects.Monsters;

namespace TestGame.Objects.Particles
{
    public class BurningEffect : Particle
    {
        private Monster follow;
        private TimeSpan timeBurning = new TimeSpan(0);
        public BurningEffect(Vector2 pos, Monster follow) : base(pos, new Sprite(Textures.burning, new Rectangle(0, 0, 32, 32)), (int)follow.Width, (int)follow.Width)
        {
            this.follow = follow;
        }
        public override void Update(GameTime gt, Game1 g)
        {
            
            X = follow.GetPosCenter().X;
            Y = follow.GetPosCenter().Y;
            timeBurning += gt.ElapsedGameTime;
            sprite = new Sprite(Textures.burning, new Rectangle(32*(((int)timeBurning.TotalMilliseconds/100)%8), 0, 32, 32));
            if (follow.hp <= 0 || !follow.BeingEffectedBy("Burning"))
            {
                g.pageGame.getObjectManager().Remove(this, g);
            }
        }
    }
}

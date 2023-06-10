using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestGame.Objects.Particles
{
    public class DamageParticle : Particle
    {
        private int ammount;
        private readonly float moveSpeed = 20f;
        public DamageParticle(Vector2 pos, int ammount) : base(pos, null)
        {
            this.ammount = ammount;
        }
        public override void Update(GameTime gt, Game1 g)
        {
            base.Update(gt, g);
            Y -= Drawing.delta * moveSpeed;
        }
        private float getScale()
        {
            if (ammount == 0)
            {
                return 0.4f;
            }
            if (ammount < 3)
            {
                return 0.5f;
            }
            if (ammount < 5)
            {
                return 0.6f;
            }
            if (ammount < 8)
            {
                return 0.7f;
            }
            if (ammount < 15)
            {
                return 0.8f;
            }
            if (ammount < 20)
            {
                return 1f;
            }
            if (ammount >= 20)
            {
                return 1.2f;
            }
            return 0.4f;
        }
        private Color getColor()
        {
            if (ammount == 0)
            {
                return Color.Gray;
            }
            if (ammount  < 5)
            {
                return Color.White;
            }
            if (ammount < 7)
            {
                return Color.Yellow;
            }
            if (ammount < 10)
            {
                return Color.Orange;
            }
            if (ammount < 15)
            {
                return Color.Red;
            }
            if (ammount < 20)
            {
                return Color.DarkRed;
            }
            if (ammount >= 20)
            {
                return Color.Purple;
            }
            return Color.Red;
        }
        public override void Draw(Game1 g)
        {
            Drawing.DrawText(ammount.ToString(), X, Y, depth, color: getColor(), scale: getScale());
        }
    }
}

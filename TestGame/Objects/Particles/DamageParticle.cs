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
                return 1f;
            }
            if (ammount < 3)
            {
                return 1.1f;
            }
            if (ammount < 5)
            {
                return 1.3f;
            }
            if (ammount < 8)
            {
                return 1.4f;
            }
            return 1f;
        }
        private Color getColor()
        {
            if (ammount == 0)
            {
                return Color.Gray;
            }
            if (ammount  < 3)
            {
                return Color.White;
            }
            if (ammount < 5)
            {
                return Color.Yellow;
            }
            if (ammount < 8)
            {
                return Color.Red;
            }
            return Color.Red;
        }
        public override void Draw(Game1 g)
        {
            Drawing.DrawText(ammount.ToString(), X, Y, depth, color: getColor(), scale: getScale());
        }
    }
}

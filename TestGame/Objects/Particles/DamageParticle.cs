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
                return 0.2f;
            }
            if (ammount < 3)
            {
                return 0.3f;
            }
            if (ammount < 5)
            {
                return 0.4f;
            }
            if (ammount < 8)
            {
                return 0.5f;
            }
            return 0.2f;
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

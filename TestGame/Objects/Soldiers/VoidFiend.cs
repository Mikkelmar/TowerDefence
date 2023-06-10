using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using TestGame.Graphics;
using TestGame.Objects.Particles;

namespace TestGame.Objects.Soldiers
{
    public class VoidFiend : Soldier
    {
        private TimeSpan spawnSMoke = new TimeSpan(), vibeTime = new TimeSpan();
        public VoidFiend(int x, int y, Sprite spriteTexture = null, int width = 22, int height = 22) : base( x, y, spriteTexture, width, height)
        {

        }
      
        public void setSprite(Sprite spriteTexture = null)
        {
            sprite = spriteTexture;
        }
        public override void Update(GameTime gt, Game1 g)
        {
            
            vibeTime += gt.ElapsedGameTime;
            if (vibeTime.TotalSeconds <= 2)
            {
                yOffset -= Drawing.delta * 20f / 5;
            }
            else if (vibeTime.TotalSeconds <= 4)
            {
                yOffset += Drawing.delta * 20f / 5;
            }
            else
            {
                yOffset = 0;
                vibeTime = new TimeSpan();
            }
            spawnSMoke += gt.ElapsedGameTime;
            
            if (spawnSMoke.TotalMilliseconds > 1000)
            {
                spawnSMoke = new TimeSpan();
            }
            base.Update(gt, g);
        }
        private Sprite getAnimationStage()
        {
            double percentLeft = 1 - (spawnSMoke.TotalMilliseconds / 1000);
            return new Sprite(Textures.smoke, new Rectangle(32 * (int)(percentLeft * 8), 0, 32, 32));
        }
        public override void Draw(Game1 g)
        {
            getAnimationStage().Draw(position, size: Width, layerDepth: depth+ depth);
            SpriteEffects facing = SpriteEffects.None;
            if (FacingRight == 1)
            {
                facing = SpriteEffects.FlipHorizontally;
            }
            sprite.Draw(new Vector2(X, Y+ yOffset), Width, Height, layerDepth: depth, spriteEffects: facing);
            if (drawHealth && baseHp != 0 && baseHp != hp)
            {
                Drawing.FillRect(new Rectangle((int)(X), (int)(Y - 12), (int)Width - 4, 8), Color.Red, this.depth, g);
                Drawing.FillRect(new Rectangle((int)(X), (int)(Y - 12), (int)((Width - 4) * (hp / (double)baseHp)), 8), Color.Green, this.depth - this.depth * 0.1f, g);
            }
        }
    }
}

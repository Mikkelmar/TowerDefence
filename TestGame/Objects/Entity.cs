using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TestGame.Graphics;
using TestGame.Managers;
using TestGame.Objects.Particles;

namespace TestGame.Objects
{
    public abstract class Entity : GameObject
    {
        protected Sprite sprite;
        protected Shadow shadow;
        protected bool haveShadow = false;
        public Entity(float x, float y, int w, int h, Texture2D texture) : base(x, y, w, h) {
            this.sprite = new Sprite(texture);
        }
        public Entity(float x, float y, int w, int h, Sprite sprite) : base(x, y, w, h)
        {
            this.sprite = sprite;
        }
        public Entity(float x, float y, int w, int h) : base(x, y, w, h)
        {
        }
        public override void Draw(Game1 g)
        {
            //Drawing.FillRect(GetHitbox(), Color.Red, 0.000000001f, g); //Debug hitboxes
            sprite.Draw(X, Y, Width, Height, depth);
        }
       
        public override void Init(Game1 g)
        {
            if (haveShadow)
            {
                shadow = new Shadow(position, this, Height/5);
                g.pageGame.getObjectManager().Add(shadow, g);
            }
            
        }

        public override void Destroy(Game1 g)
        {
            if(shadow != null)
            {
                g.pageGame.getObjectManager().Remove(shadow, g);
            }
        }
    }
}

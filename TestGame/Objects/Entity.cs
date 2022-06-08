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
        private Shadow shadow;
        protected bool haveShadow = false;
        public Entity(int x, int y, int w, int h, int id, Texture2D texture) : base(x, y, w, h, id) {
            this.sprite = new Sprite(texture);
        }
        public Entity(int x, int y, int w, int h, int id, Sprite sprite) : base(x, y, w, h, id)
        {
            this.sprite = sprite;
        }
        public Entity(int x, int y, int id) : base(x, y, 32, 32, id)
        {
        }
        public override void Draw(Game1 g)
        {
            //Drawing.FillRect(GetHitbox(), Color.Red, 0.000000001f, g); //Debug hitboxes
            sprite.Draw(position, Width, Height, depth);
        }
        public virtual void Move(Vector2 newPos, Game1 g)
        {
            Vector2 nextPos = new Vector2(this.X, this.Y);
            if (g.pageGame.getObjectManager().CanMove(this, 
                new Rectangle(
                    (int)newPos.X + hitbox.X, 
                    (int)this.Y + hitbox.Y, 
                    (int)hitbox.Width, 
                    (int)hitbox.Height)
                ) == null &&
                !g.pageGame.sceneManager.ColideWithTerrein(new Rectangle(
                    (int)newPos.X + hitbox.X,
                    (int)this.Y + hitbox.Y,
                    (int)hitbox.Width,
                    (int)hitbox.Height))) 
            {
                nextPos.X = newPos.X;
            }
            if ((g.pageGame.getObjectManager().CanMove(this,
                new Rectangle(
                    (int)this.X + hitbox.X,
                    (int)newPos.Y + hitbox.Y,
                    (int)hitbox.Width,
                    (int)hitbox.Height)) == null) &&
                !g.pageGame.sceneManager.ColideWithTerrein(new Rectangle(
                    (int)this.X + hitbox.X,
                    (int)newPos.Y + hitbox.Y,
                    (int)hitbox.Width,
                    (int)hitbox.Height)))
            {
                nextPos.Y = newPos.Y;
            }
            SetPosition(nextPos.X, nextPos.Y);
        }

        public override void Init(Game1 g)
        {
            if (haveShadow)
            {
                shadow = new Shadow(position, this);
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

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TestGame.Graphics;
using TestGame.Managers;

namespace TestGame.Objects
{
    public abstract class Entity : GameObject
    {
        protected Sprite sprite;
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
            //Drawing.FillRect(GetHitbox(), Color.Red, 0.000000001f, g);
            sprite.Draw(position, Width, Height, depth);
        }
        public virtual void Move(Vector2 newPos, Game1 g)
        {
            Vector2 nextPos = new Vector2(this.X, this.Y);
            if (g.pageManager.GetPage().objectManager.CanMove(this, 
                new Rectangle(
                    (int)newPos.X + hitbox.X, 
                    (int)this.Y + hitbox.Y, 
                    (int)hitbox.Width, 
                    (int)hitbox.Height)
                ) == null) 
            {
                nextPos.X = newPos.X;
            }
            if (g.pageManager.GetPage().objectManager.CanMove(this,
                new Rectangle(
                    (int)this.X + hitbox.X,
                    (int)newPos.Y + hitbox.Y,
                    (int)hitbox.Width,
                    (int)hitbox.Height)) == null)
            {
                nextPos.Y = newPos.Y;
            }
            SetPosition(nextPos.X, nextPos.Y);
        }

        public override void Init(Game1 g)
        {
            //Default do nothing
        }

        public override void Destroy(Game1 g)
        {
            //Default do nothing
        }
    }
}

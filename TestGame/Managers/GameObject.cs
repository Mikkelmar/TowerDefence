using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestGame.Managers
{
    public abstract class GameObject
    {
        //dimensions
        public float X;
        public float Y;// { get { return Y; } set { Y = Y; } }
        public float xSpeed, ySpeed;
        public float Width, Height;

        //Default depth value for all objects. All game objects should be around this value
        private float _depth = 0.005f;
        //Returns value accounted for y value to the object.
        //this method may not be optimal if the Y cordinate reaches a high enough value to surpass other layers
        public float depth { get { return (1 / (Y+Height)) * _depth; }set { _depth = value; } }

        public Vector2 position { get { return new Vector2(X, Y); } set { X = value.X; Y = value.Y; } }
        public Vector2 speed { get { return new Vector2(xSpeed, ySpeed); } set { xSpeed = value.X; ySpeed = value.Y; } }
        public Vector2 size { get { return new Vector2(Width, Height); } set { Width = value.X; Height = value.Y; } }
        public Rectangle bounds, hitbox;

        //props
        public int id;
        public bool rendered, visiable;
        public bool collision, solid;

        // sprite
        public Vector2 spritePos;


        protected GameObject(float x, float y, int w, int h, int id)
        {
            // dimesnions
            this.X = x;
            this.Y = y;
            this.Width = w;
            this.Height = h;
            bounds = new Rectangle((int)x, (int)y, w, h);
            hitbox = new Rectangle(0, 0, w, h);

            // props
            this.id = id;
            rendered = true;
            visiable = true;
            collision = false;
            solid = false;
            spritePos = new Vector2(0, 0);
        }
        

        // asbtracts
        public abstract void Destroy(Game1 g);
        public abstract void Update(GameTime gt, Game1 g);
        public abstract void Draw(Game1 g);
        public abstract void Init(Game1 g);

        // sets
        public void SetPosition(float x, float y) { this.X = x; this.Y = y; }
        public void SetSpeed(float xs, float ys) { this.xSpeed = xs; this.ySpeed = ys; }
        public void SetSize(float w, float h) { this.Width = w; this.Height = h; }
        public void SetBounds(float x, float y, int w, int h) { this.bounds = new Rectangle((int) x,(int) y, w, h); }
        
        // gets
        public int GetID() { return id; }
        public float DistanceTo(Vector2 pos) { return Vector2.Distance(GetPosCenter(), pos); }
        public Vector2 GetPosCenter() { return new Vector2(X + (Width / 2), Y + (Height / 2)); }
        public virtual Rectangle GetHitbox() { return new Rectangle((int)X + hitbox.X, (int)Y + hitbox.Y, hitbox.Width, hitbox.Height); }
        public bool Intersect(GameObject obj)
        {
            return obj.GetHitbox().Intersects(GetHitbox());
        }
        public bool Intersect(Rectangle rect)
        {
            return rect.Intersects(GetHitbox());
        }

        public bool Intersect(Vector2 point)
        {
            return GetHitbox().Contains(point.ToPoint());
        }
        
    }
}

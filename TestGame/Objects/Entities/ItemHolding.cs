using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TestGame.Containers.Items.ItemTypes;
using TestGame.Graphics;
using TestGame.Managers;
using TestGame.Objects.Entities.Creatures;
using TestGame.Objects.StatusEffects;

namespace TestGame.Objects.Entities
{
    public class ItemHolding : Entity
    {
        protected Weapon item;
        protected Entity user;
        private List<Entity> objectsHit = new List<Entity>();
        protected float offSetX, offSetY;
        protected float startRotation, rotation;
        protected TimeSpan currentTime = new TimeSpan();
        public ItemHolding(int x, int y, int w, int h, Weapon item, float startRotation) : base(x, y, w, h, 0, item.Sprite) {
            collision = false;
            this.item = item;
            //rotation = (float)Math.Atan2(Direction.Y, Direction.X);
            this.startRotation = startRotation;//(float)(Math.PI / 4);
            rotation = startRotation;
            depth = 0.00000001f;
        }
        public ItemHolding(Entity user, int w, int h, Weapon item, float startRotation) : this((int)user.X, (int)user.Y, w, h, item, startRotation) {
            this.user = user;
        }
        public override void Update(GameTime gt, Game1 g)
        {
            if(user != null)
            {
                X = user.GetPosCenter().X;
                Y = user.GetPosCenter().Y;
            }

            X += offSetX;
            Y += offSetY;
        }
        protected virtual void rotateItem(Game1 g)
        {
            rotation = startRotation-(float)((currentTime/ (item.WeaponSpeed))* (Math.PI*2/ 3));
        }
        protected virtual void checkForHits(Game1 g)
        {
            List<GameObject> entities = g.pageGame.getObjectManager().GetAllObjectsWith(
               (o) => (o is Entity) && 
                (o is Destructable) && 
                ((Destructable)o).CanDestroy()(item) && 
                !o.Equals(this) && 
                o != user && 
                !objectsHit.Contains((Entity)o) && 
                Intersect(o) 
               );

            foreach (GameObject targetsHit in entities)
            {
                if (targetsHit is Creature) { 
       
                    ((Creature)targetsHit).TakeDamage(item.Damage, g);
                    Vector2 direction = new Vector2(user.X - targetsHit.X, user.Y - targetsHit.Y);
                    ((Creature)targetsHit).AddStatusEffect(new Knockback(direction, item.KnockBack, new TimeSpan(0,0,0,0,120)));

                         
                }
                else
                {
                    ((Destructable)targetsHit).TakeDamage(item.Damage, g);
                }
                objectsHit.Add((Entity)targetsHit);
            }
        }
        public override Rectangle GetHitbox()
        {
            Vector2 hitPos = new Vector2((float)Math.Cos(rotation+(Math.PI/8)), (float)Math.Sin(rotation + (Math.PI / 8)));
            return new Rectangle((int)(X - hitPos.X*16- Width/2), (int)(Y - hitPos.Y*16-Height/2), (int)Width, (int)Height); ;
        }
        protected virtual void checkIfDoneAttacking(GameTime gt, Game1 g)
        {
            currentTime += gt.ElapsedGameTime;
            if(currentTime > item.WeaponSpeed)
            {
                item.DoneUsing();
                g.pageGame.getObjectManager().Remove(this, g);
            }
        }
        public override void Draw(Game1 g)
        {
            Drawing.FillRect(GetHitbox(), Color.Red, 0.000000001f, g);
            item.Sprite.Draw(position, Width, Height, depth, rotation, new Vector2(16,16));
        }

    }
}

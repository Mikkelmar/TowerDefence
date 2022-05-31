using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Containers.Items.ItemTypes;
using TestGame.Graphics;
using TestGame.Managers;
using TestGame.Objects.Entities.Creatures;

namespace TestGame.Objects.Entities
{
    public class ItemSwing : Entity
    {
        private Weapon item;
        private Entity user;
        private List<Creature> objectsHit = new List<Creature>();
        private float offSetX, offSetY;
        private float rotation;
        private TimeSpan attackTime = new TimeSpan(0,0,0,0,200), //the attack default lasts 500 millisecunds
            currentTime = new TimeSpan();
        public ItemSwing (int x, int y, int w, int h, Weapon item) : base(x, y, w, h, 0, item.Sprite) {
            offSetX = 0;
            offSetY = 0;
            collision = false;
            this.item = item;
            //rotation = (float)Math.Atan2(Direction.Y, Direction.X);
            rotation = (float)((Math.PI / 4) + Math.PI);
        }
        public ItemSwing(Entity user, int w, int h, Weapon item) : this((int)user.X, (int)user.Y, w, h, item) {
            this.user = user;
        }
        public override void Update(GameTime gt, Game1 g)
        {
            if(user != null)
            {
                X = user.X;
                Y = user.Y;
            }

            float _speed = (float)(item.Speed * Drawing.delta);
            //offSetX += _speed;

            X += offSetX;
            Y += offSetY;
            //var transformed = Vector2.Transform(dir, Matrix.CreateRotationX());
            checkIfDoneAttacking(gt, g);
            checkForHits(g);
            rotateItem(gt);
        }
        private void rotateItem(GameTime gt)
        {
            rotation = (float)((float)((Math.PI / 4) + Math.PI)+ (currentTime/ attackTime)* (Math.PI / 2));
        }
        private void checkForHits(Game1 g)
        {
            List<GameObject> entities = g.pageGame.objectManager.GetAllObjectsWith(
                (o) => (o is Creature) && !o.Equals(this) && o != user && !objectsHit.Contains((Creature)o) && this.Intersect(o) 
                );
            foreach(GameObject targetsHit in entities)
            {
                ((Creature)targetsHit).TakeDamage(item.Damage, g);
                objectsHit.Add((Creature)targetsHit);
            }
        }
        private void checkIfDoneAttacking(GameTime gt, Game1 g)
        {
            currentTime += gt.ElapsedGameTime;
            if(currentTime > attackTime)
            {
                item.DoneUsing();
                g.pageGame.objectManager.Remove(this, g);
            }
        }
        public override void Draw(Game1 g)
        {
            //Drawing.FillRect(GetHitbox(), Color.Red, 0.000000001f, g);
            sprite.Draw(position, Width, Height, depth, rotation, new Vector2(16,16));
        }

    }
}

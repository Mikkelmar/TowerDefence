using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TestGame.Containers.Items;
using TestGame.Managers;

namespace TestGame.Objects.Entities
{
    public class ItemEntity : Entity
    {
        public Item item;
        private float Speed = 10;
        private TimeSpan graceTime = new TimeSpan(0, 0, 0,0,800); // 0.8 sekund for man kan plukke opp
        public ItemEntity(int x, int y, Item item) : base(x, y, 10, 10, 0, item.Sprite)
        {
            this.item = item;
            haveShadow = true;
            this.collision = false;
        }
        public override void Update(GameTime gt, Game1 g)
        {
            if(graceTime.Ticks > 0)
            {
                graceTime -= gt.ElapsedGameTime;
            }
            else { 
                Player player = g.pageGame.GetPlayer();

                if (player.inventory.CanAdd(this.item)){
                    float dist = player.DistanceTo(this.GetPosCenter());


                    if (dist <= 60)
                    {
                        float _speed = (float)((this.Speed * Drawing.delta) / Math.Pow(dist / 50, 2));
                        this.MoveTowards(player, g, _speed);
                        if (dist <= 10)
                        {
                            player.inventory.Add(this.item);
                            g.pageGame.getObjectManager().Remove(this, g);
                        }
                    }
                }
            }
        }

        protected void MoveTowards(GameObject obj, Game1 g, float moveSpeed)
        {
            Vector2 dir = g.pageGame.getObjectManager().FromToDir(this, obj);
            this.Move(new Vector2(X + (-moveSpeed * dir.X / dir.Length()), Y + (-moveSpeed * dir.Y / dir.Length())), g);
        }
        
    }
}

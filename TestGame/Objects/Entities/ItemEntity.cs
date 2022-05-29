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
        public ItemEntity(int x, int y, Item item) : base(x, y, 32, 32, 0, item.Sprite)
        {
            this.item = item;
        }
        public override void Update(GameTime gt, Game1 g)
        {
            Player player = g.pageGame.GetPlayer();

            if (player.inventory.CanAdd(this.item)){
                float dist = player.DistanceTo(this.GetPosCenter());


                if (dist <= 150)
                {
                    float _speed = (float)((this.Speed * Drawing.delta) * 10 / Math.Pow(dist / 100, 2));
                    this.MoveTowards(player, g, _speed);
                    if (dist <= 50)
                    {
                        player.inventory.Add(this.item);
                        g.pageGame.objectManager.Remove(this, g);
                    }
                }
            }
            

        }
        protected void MoveTowards(GameObject obj, Game1 g, float moveSpeed)
        {
            Vector2 dir = g.pageGame.objectManager.FromToDir(this, obj);
            this.Move(new Vector2(X + (-moveSpeed * dir.X / dir.Length()), Y + (-moveSpeed * dir.Y / dir.Length())), g);
        }
        
    }
}

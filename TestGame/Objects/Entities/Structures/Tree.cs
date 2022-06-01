using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TestGame.Containers.Items;
using TestGame.Containers.Items.ItemTypes.ItemList;
using TestGame.Graphics;

namespace TestGame.Objects.Entities.Structures
{
    public class Tree : Structure
    {
        private int hp = 10;
        private int basehp = 10;
        private TimeSpan? shakeTime;
        private int baseX, baseY;
        public Tree(int x, int y) : base(x, y, 16*3*3, 16*4*3, 401)
        {
            baseX = x;
            baseY = y;
            this.sprite = new Sprite(Textures.spriteSheet_1, new Rectangle(24 * 16, 0, 16 * 3, 16 * 4));
            this.hitbox = new Rectangle(16*3, 16*3*3, 16*3, 16*3);
        }

        public override Predicate<Item> CanDestroy()
        {
            return (i) => i is IronAxe;
        }
        public override void TakeDamage(int damage, Game1 g)
        {
            hp -= damage;
            if(hp <= 0)
            {
                Die(g);
            }
            else
            {
                shakeTime = new TimeSpan(0, 0, 0, 0, 300);
            }
        }
        private void Die(Game1 g)
        {
            g.pageGame.objectManager.Add(new ItemEntity((int)GetPosCenter().X, (int)(Y+Height), new Wood(5)), g);
            g.pageGame.objectManager.Remove(this, g);
        }

        public override void Destroy(Game1 g)
        {}

        private void shake(GameTime gt)
        {
            Random rand = new Random();
            X += (float)(rand.Next(5) - 2)/10;
            Y += (float)(rand.Next(5) - 2)/10;
            shakeTime -= gt.ElapsedGameTime;
            if(((TimeSpan)shakeTime).Ticks <= 0)
            {
                X = baseX;
                Y = baseY;
                shakeTime = null;
            }
        }

        public override void Init(Game1 g)
        {}

        public override void Update(GameTime gt, Game1 g)
        {
            if(shakeTime != null)
            {
                shake(gt);
            }
        }
    }
}

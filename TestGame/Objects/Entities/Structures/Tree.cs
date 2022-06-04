using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TestGame.Containers.Items;
using TestGame.Containers.Items.ItemTypes.ItemList;
using TestGame.Graphics;
using TestGame.Objects.Particles;

namespace TestGame.Objects.Entities.Structures
{
    public class Tree : ResourceBlock
    {
        private TimeSpan? shakeTime;
        private int baseX, baseY;
        public Tree(int x, int y) : base(x, y, 16*3*3, 16*4*3)
        {
            hp = 30;
            basehp = hp;
            baseX = x;
            baseY = y;
            this.sprite = new Sprite(Textures.spriteSheet_1, new Rectangle(24 * 16, 0, 16 * 3, 16 * 4));
            this.hitbox = new Rectangle(16*3, 16*3*3, 16*3, 16*3);
            drop = new Wood(5);
        }

        public override Predicate<Item> CanDestroy()
        {
            return (i) => i is IronAxe;
        }
        public override void TakeDamage(int damage, Game1 g)
        {
            hp -= damage;
            new DamageParticle(GetPosCenter(), damage).Spawn(g);
            if (hp <= 0)
            {
                Die(g);
            }
            else
            {
                shakeTime = new TimeSpan(0, 0, 0, 0, 300);
            }
        }

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

        public override void Update(GameTime gt, Game1 g)
        {
            if(shakeTime != null)
            {
                shake(gt);
            }
        }
    }
}

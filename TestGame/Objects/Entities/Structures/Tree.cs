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
        private float baseX, baseY;
        public Tree(int x, int y) : base(x, y, 16*3, 16*4)
        {
            hp = 30;
            basehp = hp;
            sprite = new Sprite(Textures.spriteSheet_1, new Rectangle(24 * 16, 0, 16 * 3, 16 * 4));
            hitbox = new Rectangle(16, 32, 16, 16);
            drop = new Wood(5);
        }
        public override void Init(Game1 g)
        {
            base.Init(g);
            baseX = X;
            baseY = Y;
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
            X += (float)(rand.Next(5) - 2)/40;
            Y += (float)(rand.Next(5) - 2)/40;
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

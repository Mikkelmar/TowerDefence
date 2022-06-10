using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Containers.Items;
using TestGame.Graphics;

namespace TestGame.Objects.Entities.Structures
{
    public abstract class GrowObject : Structure
    {
        protected int HP;
        private TimeSpan stageTime, currentTime;
        protected int finalStage, currentStage = 0;
        protected Item drop;
        public GrowObject(int x, int y, Sprite sprite, TimeSpan stageTime, int w=16, int h=16) : base(x, y, w, h, 4, sprite)
        {
            HP = 2;
            solid = false;
            this.stageTime = stageTime;
            currentTime = stageTime;
        }
        public override Predicate<Item> CanDestroy()
        {
            return p => true;
        }

        public override void TakeDamage(int damage, Game1 g)
        {
            HP -= damage;
            if (HP <= 0)
            {
                Break(g);
            }
        }
        protected void Break(Game1 g)
        {
            g.pageGame.getObjectManager().Remove(this, g);
            if(drop != null)
            {
                g.pageGame.getObjectManager().Add(new ItemEntity((int)GetPosCenter().X, (int)GetPosCenter().Y, drop), g);
            }
        }

        public override void Update(GameTime gt, Game1 g)
        {
            
            if(currentTime.Ticks <= 0)
            {
                if (CanGrow(g))
                {
                    currentTime = stageTime;
                    currentStage++;
                    Grow(g);
                }
            }
            else
            {
                currentTime -= gt.ElapsedGameTime;
            }
        }
        protected abstract Rectangle getNextGrowIncreese(int stage);
        private bool CanGrow(Game1 g)
        {
            if (g.pageGame.getObjectManager().CanMove(this, getNextGrowIncreese(currentStage+1)) == null)
            {
                return true;
            }
            return false;
        }
        protected Rectangle getNextGrowPos(int widthIncreese=0, int heightIncreese=0)
        {
            return new Rectangle((int)X- (widthIncreese/2), (int)Y- heightIncreese, (int)Width + (widthIncreese / 2), (int)Height+ heightIncreese);
        }
        protected void setNewRect(Rectangle rect)
        {
            X = rect.X;
            Y = rect.Y;
            Width = rect.Width;
            Height = rect.Height;

            hitbox.Width = (int)Width;
            hitbox.Height = (int)Height;
        }
        public abstract void Grow(Game1 g);
    }
}

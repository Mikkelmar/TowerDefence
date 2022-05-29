using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;
using TestGame.Managers;

namespace TestGame.Objects.Entities.Buildings
{
    public abstract class Building : Entity, RightClickable
    {
        public Building(int x, int y, int width, int height, int id, Sprite sprite) : base(x, y, width, height, id, sprite)
        {

        }
        public void RightClicked(float x, float y, Game1 g)
        {
            if (this.Intersect(new Vector2(x, y)))
            {
                Open(g);
            }
        }
        protected abstract void Open(Game1 g);
        public override void Init(Game1 g)
        {
            base.Init(g);
            g.pageGame.mouseManager.AddRight(this, true);

        }
        public override void Destroy(Game1 g)
        {
            g.pageGame.mouseManager.RemoveRight(this);
        }
    }
}

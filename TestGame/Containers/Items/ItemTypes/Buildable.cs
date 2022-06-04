using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;
using TestGame.Objects;

namespace TestGame.Containers.Items.ItemTypes
{
    public class Buildable : Item, Useable
    {
        private StackContainer consumes;

        public Buildable(Sprite sprite, string name, int ammount = 1)
           : base(sprite, name, ammount)
        {
            consumes = new StackContainer();
        }

        public void Activate(Entity user, float x, float y, Game1 g, bool leftClick)
        {
            throw new NotImplementedException();
        }

        public bool CanUse(Entity user, Game1 g)
        {
            return g.pageGame.player.inventory.Contain(consumes);
        }
        public bool IsUsing()
        {
            return false;
        }

        public void Update(Entity user, GameTime gt, Game1 g)
        {
        }

        public bool UseableOnClick(bool isLeftClick = true)
        {
            return true;
        }
            
    }
}

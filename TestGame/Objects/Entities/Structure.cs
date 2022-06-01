using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Containers.Items;
using TestGame.Graphics;
using TestGame.Managers;
using TestGame.Objects.Entities;

namespace TestGame.Objects.Entities
{
    public abstract class Structure : Entity, Destructable
    {
        public Structure(int x, int y, int w, int h, int id, Texture2D texture=null) : base(x, y, w, h, id, texture) {
            this.solid = true; 
        }

        public abstract Predicate<Item> CanDestroy();

        public abstract void TakeDamage(int damage, Game1 g);
    }
}

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;
using TestGame.Objects;
using TestGame.Objects.Entities;
using TestGame.Managers;

namespace TestGame.Containers.Items.ItemTypes
{
    public class Buildable : Item, Useable, Builder
    {
        protected StackContainer consumes;
        private Structure structure;
        private Player player;
        public Buildable(Sprite sprite, string name, Structure structure, int ammount = 1)
           : base(sprite, name, ammount)
        {
            this.structure = structure;
            consumes = new StackContainer();
        }

        public void Activate(Entity user, float x, float y, Game1 g, bool leftClick)
        {
            if(user is Player)
            {
                player = (Player)user;
            }
            if (CanUse(user, g))
            {
                g.pageGame.buildHandler.SetBuild(structure, this);
            }
        }

        public bool CanUse(Entity user, Game1 g)
        {
            return player.inventory.Contain(consumes) && !player.InAction(g);
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
            return !isLeftClick;
        }

        public bool CanBuild()
        {
            return player.inventory.Contain(consumes);
        }

        public void Built()
        {
            player.inventory.Take(consumes);
        }
    }
}

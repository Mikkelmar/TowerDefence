using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Objects;

namespace TestGame.Containers.Items.ItemTypes
{
    public interface Useable
    {
        public void Use(Entity user, float x, float y, GameTime gt, Game1 g, bool leftClick);
        public void Activate(Entity user, float x, float y, Game1 g, bool leftClick);
        public bool IsUsing();
        public bool UseableOnClick(bool isLeftClick = true);
        public bool CanUse(Entity user, Game1 g);
    }
}

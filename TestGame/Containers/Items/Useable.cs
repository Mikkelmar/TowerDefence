using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Objects;

namespace TestGame.Containers.Items.ItemTypes
{
    public interface Useable
    {
        //While IsUsing == true, -> update() should be called
        public void Update(Entity user, GameTime gt, Game1 g);
        public void Activate(Entity user, float x, float y, Game1 g, bool leftClick);
        public bool IsUsing();
        public bool UseableOnClick(bool isLeftClick = true);
        public bool CanUse(Entity user, Game1 g);
    }
}

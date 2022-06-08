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

        /// <summary>
        /// Returns if the item can be activated by the given click
        /// Returns true regardless if it can be activated by both.
        /// </summary>
        /// <param name="isLeftClick">If it's the left click being pressed.</param>
        public bool UseableOnClick(bool isLeftClick = true);

        /// <summary>
        /// Returns if the entity can use this item in the current game state.
        /// </summary>
        public bool CanUse(Entity user, Game1 g);
    }
}

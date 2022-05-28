using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestGame.Managers
{
    public interface KeyboardLisner
    {
        public void KeyPressed(KeyboardState kb, Game1 g);
    }
}

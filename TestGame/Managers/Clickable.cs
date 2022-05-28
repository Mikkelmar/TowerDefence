using System;
using System.Collections.Generic;
using System.Text;

namespace TestGame.Managers
{
    public interface Clickable
    {
        public void Clicked(float x, float y, Game1 g);
    }
}

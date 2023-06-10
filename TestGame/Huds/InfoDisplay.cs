using System;
using System.Collections.Generic;
using System.Text;

namespace TestGame.Huds
{
    public interface InfoDisplay
    {
        public void select(Game1 g);
        public void close(Game1 g);
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace TestGame.Managers
{
    public interface Builder
    {
        public bool CanBuild();
        public void Built();
    }
}

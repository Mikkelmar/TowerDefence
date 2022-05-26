using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestGame.Managers
{
    public abstract class Page
    {
        public ObjectManager objectManager { get; } = new ObjectManager();
   
        public int id;
        public Page(int id)
        {
            this.id = id;
        }
        
        public abstract void Init(Game1 g);
        public abstract void Update(GameTime gt, Game1 g);
        public abstract void Draw( Game1 g);
    }
}

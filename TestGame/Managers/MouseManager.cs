using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestGame.Managers
{
    public class MouseManager
    {
        /**
         * 
         * The bool is whether the mouse cords should be relative to the screen og game map
         * if true the mouse cords + camera position is alerted back at the lisner
         * */
        private Dictionary<Clickable, bool> mouseLeftClickLisners = new Dictionary<Clickable, bool>();
        private MouseState oldState = Mouse.GetState();
        public void Update(GameTime gt, Game1 g)
        {
            MouseState newState = Mouse.GetState();
            if (newState.LeftButton == ButtonState.Pressed && oldState.LeftButton == ButtonState.Released)
            {
                // do something here
         
                List<Clickable> lisners = new List<Clickable>(mouseLeftClickLisners.Keys);
                foreach (Clickable lisner in lisners)
                {
                    if (mouseLeftClickLisners[lisner])
                    {
                        lisner.Clicked(newState.X + g.pageGame.cam.position.X, newState.Y + g.pageGame.cam.position.Y, g);
                    }
                    else
                    {
                        lisner.Clicked(newState.X, newState.Y, g);
                    }
                    
                }
            }
            oldState = newState;
        }
     
        public void Add(Clickable obj, bool relative = false) { mouseLeftClickLisners.Add(obj, relative);}
        public void Remove(Clickable obj) { mouseLeftClickLisners.Remove(obj); }
        public void Clear() { mouseLeftClickLisners.Clear(); }
    }
}

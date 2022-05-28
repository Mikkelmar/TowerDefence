using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestGame.Managers
{
    public class KeyBoardManager
    {
        /**
         * 
         * The bool is whether the mouse cords should be relative to the screen og game map
         * if true the mouse cords + camera position is alerted back at the lisner
         * */
        private List<KeyboardLisner> keyboardLisners = new List<KeyboardLisner>();
        public void Update(GameTime gt, Game1 g)
        {

            KeyboardState kb = Keyboard.GetState();
            List<KeyboardLisner> lisners = new List<KeyboardLisner>(keyboardLisners);
            foreach (KeyboardLisner kl in lisners)
            {
                if(kl != null)
                {
                    kl.KeyPressed(kb, g);
                }
               
            }
        }

        public void Add(KeyboardLisner obj) { keyboardLisners.Add(obj); }
        public void Remove(KeyboardLisner obj) { keyboardLisners.Remove(obj); }
        public void Clear() { keyboardLisners.Clear(); }
    }
}

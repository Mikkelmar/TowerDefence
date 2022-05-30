using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Diagnostics;
using TestGame.Containers;
using TestGame.Graphics;
using TestGame.Huds.ActiveHuds;
using TestGame.Managers;
using TestGame.Objects.Entities.Structures;

namespace TestGame.Objects
{
    public class Player : Entity
    {
        public SlotContainer inventory;
        //input
        KeyboardState kb;
        public float walkSpeed = 370f;
        public bool canMove = true;
        private bool down = false;
        public int ActiveSlot = 0;
        public Player(int x, int y) : base(x, y, 28*3, 28*3, ObjectsID.player, Textures.player) 
        {
            collision = true;
            this.hitbox = new Rectangle((int)Width/4, (int)(Height/3.5), (int)Width / 2, (int)(Height - Height / 3.5));
        }
        public override void Destroy(Game1 g)
        {
        }


        public override void Init(Game1 g)
        {
            this.inventory = new SlotContainer(24);
            //inventory.Add(new Wood());
        }

        public override void Update(GameTime gt, Game1 g)
        {
            //input
            kb = Keyboard.GetState();
            MovmentInput(g);
            InteractInput(g);

            var mouseState = Mouse.GetState();
            if (canMove)
            {
                //move
                this.Move(new Vector2(X + xSpeed, Y + ySpeed), g);
            }

        }
        public override void Draw(Game1 g)
        {
            
            base.Draw(g);
            //inventory.Draw(g);
        }
        private void InteractInput(Game1 g)
        {
            if(kb.IsKeyDown(Keys.E)){
                if(down == false)
                {
                    down = true;
                    HudManager hm = g.pageGame.hudManager;
                    if (hm.activeUI == null)
                    {
                        hm.Open(new InventoryUI(g), g);
                    }
                    else
                    {
                        hm.Close(g);
                    }
                    //g.pageGame.hudManager
                }
            }
            else
            {
                down = false;
            }
            if (kb.IsKeyDown(Keys.R))
            {
                Debug.WriteLine(g.pageGame.mouseManager.mouseRightClickLisners.Count);
            }
            setActiveSlot(new List<Keys>{ Keys.D1, Keys.D2, Keys.D3, Keys.D4, Keys.D5, Keys.D6, Keys.D7, Keys.D8 });
        }
        private void setActiveSlot(List<Keys> keys)
        {
            for(int index= 0; index < keys.Count; index++)
            {
                if (kb.IsKeyDown(keys[index]))
                {
                    ActiveSlot = index;
                    return;
                }
            }

        }
        private void MovmentInput(Game1 g)
        {
            float _speed = walkSpeed * Drawing.delta;
            // pressed
            if(kb.IsKeyDown(Keys.W)) { ySpeed = -_speed; }
            if(kb.IsKeyDown(Keys.S)) { ySpeed = _speed; }
            if(kb.IsKeyDown(Keys.A)) { xSpeed = -_speed; }
            if(kb.IsKeyDown(Keys.D)) { xSpeed = _speed; }

            // released
            if (kb.IsKeyUp(Keys.W) && kb.IsKeyUp(Keys.S)) { ySpeed = 0; }
            if (kb.IsKeyUp(Keys.A) && kb.IsKeyUp(Keys.D)) { xSpeed = 0; }

            if(xSpeed != 0 && ySpeed != 0) { 
                ySpeed = (float)(ySpeed * 0.69);
                xSpeed = (float)(xSpeed * 0.69);
            }
        }
    }
}

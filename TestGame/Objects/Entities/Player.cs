using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using TestGame.Containers;
using TestGame.Graphics;
using TestGame.Objects.Entities.Structures;

namespace TestGame.Objects
{
    public class Player : Entity
    {
        public ItemContainer inventory;
        //input
        KeyboardState kb;
        public float walkSpeed = 370f;
        public bool canMove = true;
        public Player(int x, int y) : base(x, y, 28*3, 28*3, ObjectsID.player, Textures.player) 
        {
            this.inventory = new ItemContainer();
            collision = true;
            this.hitbox = new Rectangle((int)Width/4, (int)(Height/3.5), (int)Width / 2, (int)(Height - Height / 3.5));
        }
        public override void Destroy(Game1 g)
        {
        }


        public override void Init(Game1 g)
        {
            this.inventory = new ItemContainer();
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
                //g.pageGame.sceneManager.GetScene().GetTile((int)(X/3), (int)(Y/3));
  
                //g.pageGame.buildHandler.Build(new Tree(3 * (int)(X / 3), 3 * (int)(Y / 3)));
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

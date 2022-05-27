using Microsoft.Xna.Framework;
using MonoGame.Extended;
using MonoGame.Extended.ViewportAdapters;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestGame.Managers
{
    public class Camera
    {
        private OrthographicCamera cam;
        public Vector2 position;
        public Matrix transform { get; private set; }
        public float delay { get; set; } = 3.0f;
        public bool instantCamera = true;
        public Camera(Vector2 position)
        {
            this.position = position;
        }
        //update
        public void Update(Vector2 pos, Game1 g)
        {
            float zoomScale = 1f;
            float d = delay * Drawing.delta;

            //move
            if (instantCamera)
            {
                position.X = pos.X - ((Drawing.WINDOW_WIDTH / zoomScale) / 2);
                position.Y = pos.Y - ((Drawing.WINDOW_HEIGHT / zoomScale) / 2);

            }
            else
            {
                position.X += ((pos.X - position.X) - (Drawing.WINDOW_WIDTH / zoomScale) / 2) * d;
                position.Y += ((pos.Y - position.Y) - (Drawing.WINDOW_HEIGHT / zoomScale) / 2) * d;
            }
            

            transform = Matrix.CreateTranslation((int)-position.X, -position.Y, 0)
                //*Matrix.CreateScale(zoomScale)
                ;
     
        }

    }
}

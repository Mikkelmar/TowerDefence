using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TestGame.Graphics;
using TestGame.Huds;
using TestGame.Managers;
using TestGame.Objects.Particles;

namespace TestGame.Objects.PlayerLogic
{
    public abstract class PlayerPower : Hud, Clickable, InfoDisplay
    {
        protected TimeSpan currentTime;
        protected TimeSpan coolDown;
        private bool active = false, tryToActivate=false;
        protected Sprite icon;
        private float clickedX, clikedY;
        private static Sound deniedSound = new Sound(Sounds.denied, 0.1f, SoundManager.types.Menu);
        public PlayerPower(int x, int y)
        {
            Width = 100;
            Height = 100;
            X = x;
            Y = y;
        }
        public void Update(GameTime gt, Game1 g)
        {
            if(currentTime < coolDown)
            {
                currentTime += gt.ElapsedGameTime;
            }
            
            if (tryToActivate)
            {
                if (!active)
                {
                    active = true;
                    return;
                }
                if(g.pageGame.getHudManager().activeObject == this)
                {
                    triggerPower(clickedX, clikedY, g);
                    currentTime = new TimeSpan(0);
                    g.pageGame.getHudManager().closeActiveObject(g);
                }
                active = false;
            }
        }
        public void rechargePower(TimeSpan t, Game1 g)
        {
            currentTime += t;
            g.pageGame.getObjectManager().Add(new DamageParticle(new Vector2(X + 16, Y-20), (int)t.TotalSeconds), g);
        }
        public override void Draw(Game1 g)
        {
            float cx = g.gameCamera.Position.X;
            float cy = g.gameCamera.Position.Y;
            if (g.pageGame.getHudManager().activeObject == this)
            {
                Vector2 pos = g.pageGame.mouseManager.GetMousePos(g);
                new Sprite(Textures.target).Draw(pos.X + cx - 16, pos.Y + cy - 16, 32, 32, layerDepth: depth);

            }
            float alpha = 1f;
            if ((coolDown > currentTime))
            {
                alpha = 0.4f;
            }

            icon.Draw(new Vector2(X+cx,Y+cy), width: Width, height: Height, layerDepth: depth*0.2f, alpha: alpha);
            Drawing.FillRect(new Rectangle((int)(X + cx), (int)(Y + cy), Width, (int)(Height* (float)((coolDown-currentTime)/coolDown))), Color.Gray, depth*0.01f, g);
            
            new Sprite(Textures.gui, new Rectangle(96, 36, 26, 24)).Draw(new Vector2(X + cx - 8, Y + cy - 8), width: Width+16, height: Height+16, layerDepth: depth);

            //Drawing.FillRect(new Rectangle((int)X, (int)Y, Width, Height), Color.Black, depth, g);
        }
        protected abstract void triggerPower(float x, float y, Game1 g);
        public void Clicked(float x, float y, Game1 g)
        {
            if (coolDown > currentTime)
            {
                return;
            }
            
            if (g.pageGame.getHudManager().activeObject == this)
            {
                if (new Rectangle((int)X, (int)Y, Width, Height).Contains(x, y))
                {
                    g.pageGame.getHudManager().closeActiveObject(g);
                    return;
                }
                clickedX = x;
                clikedY = y;
                tryToActivate = true;
            }
            else if (new Rectangle((int)X, (int)Y, Width, Height).Contains(x, y)){
                g.pageGame.getHudManager().setActiveObject(this, g);
            }
        }
        public void activateFromKeyboard(Game1 g)
        {
            if (coolDown > currentTime)
            {
                deniedSound.play(g);
                return;
            }
            if (g.pageGame.getHudManager().activeObject == this)
            {
                g.pageGame.getHudManager().closeActiveObject(g);
            }
            else
            {
                g.pageGame.getHudManager().setActiveObject(this, g);
            }
        }

        public void select(Game1 g)
        {
            
        }

        public void close(Game1 g)
        {
            tryToActivate = false;
            active = false;
        }
    }
}

﻿using Microsoft.Xna.Framework;
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
        private Dictionary<LeftRelease, bool> mouseLeftReleaseLisners = new Dictionary<LeftRelease, bool>();
        private Dictionary<RightClickable, bool> mouseRightClickLisners = new Dictionary<RightClickable, bool>();
        private Dictionary<HoverLisner, bool> hoverLisners = new Dictionary<HoverLisner, bool>();

        private MouseState oldState = Mouse.GetState();
        public void Update(GameTime gt, Game1 g)
        {
            MouseState newState = Mouse.GetState();

            g.gameCamera.Zoom = 1f;
            Vector2 _worldPosition = g.gameCamera.ScreenToWorld(new Vector2(newState.X, newState.Y));
            g.gameCamera.Zoom = (g.pageGame.cam.Zoom);

            Vector2 _worldPositionZoomed = g.gameCamera.ScreenToWorld(new Vector2(newState.X, newState.Y));
            if (newState.LeftButton == ButtonState.Pressed && oldState.LeftButton == ButtonState.Released)
            {
                // do something here
         
                List<Clickable> lisners = new List<Clickable>(mouseLeftClickLisners.Keys);
                foreach (Clickable lisner in lisners)
                {
                    if (mouseLeftClickLisners[lisner])
                    {
                        lisner.Clicked(_worldPosition.X, _worldPosition.Y, g);
                    }
                    else
                    {
                        lisner.Clicked(_worldPositionZoomed.X, _worldPositionZoomed.Y, g);
                    }
                    
                }
            }
            else if (newState.LeftButton == ButtonState.Released && oldState.LeftButton == ButtonState.Pressed)
            {

                List<LeftRelease> lisners = new List<LeftRelease>(mouseLeftReleaseLisners.Keys);
                foreach (LeftRelease lisner in lisners)
                {
                    if (mouseLeftReleaseLisners[lisner])
                    {
                        lisner.LeftReleased(_worldPosition.X, _worldPosition.Y, g);
                    }
                    else
                    {
                        lisner.LeftReleased(_worldPositionZoomed.X, _worldPositionZoomed.Y, g);
                    }

                }
            }
            if (newState.RightButton == ButtonState.Pressed && oldState.RightButton == ButtonState.Released)
            {
                List<RightClickable> lisners = new List<RightClickable>(mouseRightClickLisners.Keys);
                foreach (RightClickable lisner in lisners)
                {
                    if(mouseRightClickLisners.ContainsKey(lisner)){ 
                        if (mouseRightClickLisners[lisner])
                        {
                            lisner.RightClicked(_worldPosition.X, _worldPosition.Y, g);
                        }
                        else
                        {
                            lisner.RightClicked(_worldPositionZoomed.X, _worldPositionZoomed.Y, g);
                        }
                    }

                }
            }
            oldState = newState;

            List<HoverLisner> hoverLisnerList = new List<HoverLisner>(hoverLisners.Keys);
            foreach (HoverLisner lisner in hoverLisnerList)
            {
                if (hoverLisners.ContainsKey(lisner))
                {
                    if (hoverLisners[lisner])
                    {
                        lisner.Hover(_worldPosition.X, _worldPosition.Y, g);
                    }
                    else
                    {
                        lisner.Hover(_worldPositionZoomed.X, _worldPositionZoomed.Y, g);
                    }
                }
            }
        }
        public static Vector2 GetMousePos()
        {
            MouseState state = Mouse.GetState();
            return new Vector2(state.X, state.Y);
        }
     
        public void Add(Clickable obj, bool relative = false) { mouseLeftClickLisners.Add(obj, relative);}
        public void Remove(Clickable obj) { mouseLeftClickLisners.Remove(obj); }
        public void Clear() { mouseLeftClickLisners.Clear(); }
        public void AddRight(RightClickable obj, bool relative = false) { mouseRightClickLisners.Add(obj, relative); }
        public void RemoveRight(RightClickable obj) { mouseRightClickLisners.Remove(obj); }
        public void ClearRight() { mouseRightClickLisners.Clear(); }
        public void AddHover(HoverLisner obj, bool relative = false) { hoverLisners.Add(obj, relative); }
        public void RemoveHover(HoverLisner obj) { hoverLisners.Remove(obj); }
        public void ClearHover() { hoverLisners.Clear(); }
        public void AddLeftRelease(LeftRelease obj, bool relative = false) { mouseLeftReleaseLisners.Add(obj, relative); }
        public void RemoveLeftRelease(LeftRelease obj) { mouseLeftReleaseLisners.Remove(obj); }
        public void ClearLeftRelease() { mouseLeftReleaseLisners.Clear(); }
    }
}

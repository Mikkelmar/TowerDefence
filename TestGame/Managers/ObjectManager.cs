﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestGame.Managers
{
    public class ObjectManager
    {
        public List<GameObject> gameObjects = new List<GameObject>();

        public void Update(GameTime gt, Game1 g)
        {
            for(var i = 0; i < gameObjects.Count;i++)
            {
                GameObject obj = gameObjects[i];
                if (obj.rendered)
                {
                    obj.SetBounds(obj.X, obj.Y, (int) obj.Width, (int) obj.Height);
                    obj.Update(gt, g);
                }
            }
        }
        public void Draw(Game1 g)
        {
            gameObjects.Sort((o1, o2) => o2.Y.CompareTo(o1.Y));
            foreach (GameObject obj in gameObjects)
            {
                if(obj.rendered && obj.visiable)
                {
                    obj.Draw(g);
                }
                
            }
        }
        public bool Intersect(Rectangle newPos)
        {
            foreach (GameObject obj in gameObjects)
            {
                if (obj.Intersect(newPos)){ return true; }
            }
            return false;
        }
        public bool CanMove(GameObject _object, Rectangle newPos)
        {
            foreach (GameObject obj in gameObjects)
            {
                if (obj != _object)
                {
                    if (obj.solid)
                    {
                        if (obj.Intersect(newPos))
                        {
                            return false;
                        }
                    }
                }

            }
            return true;
        }
        public Vector2 FromToDir(GameObject from, GameObject to)
        {
            return new Vector2(from.GetPosCenter().X - to.GetPosCenter().X, from.GetPosCenter().Y - to.GetPosCenter().Y);
        }
        public void Add(GameObject obj, Game1 g) { gameObjects.Add(obj); obj.Init(g); }
        public void Remove(GameObject obj, Game1 g) { obj.Destroy(g); gameObjects.Remove(obj);  }
        public void Remove(int index, Game1 g) { gameObjects[index].Destroy(g); gameObjects.Remove(gameObjects[index]);  }
        public void Clear() { gameObjects.Clear(); }
    }
}
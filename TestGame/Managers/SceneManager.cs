using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestGame.Managers
{
    public class SceneManager
    {
        public List<Scene> scenes = new List<Scene>();
        public int selected;
        public int count { get { return scenes.Count; } }

        public void Update(GameTime gt, Game1 g)
        {
            if (count > selected)
            {
                scenes[selected].Update(gt, g);
            }
        }
        public void Draw(Game1 g)
        {
            if (count > selected)
            {
                scenes[selected].Draw(g);
            }
        }
        public Scene GetScene() { return scenes[selected]; }
        public virtual void Set(int id) { selected = id; }
        public virtual void Set(Scene scene) { selected = 0; }
        public void Add(Scene scene, Game1 g) { scenes.Add(scene); scene.Init(g); }
        public void Remove(Scene scene) { scenes.Remove(scene); }
        public void Clear() { scenes.Clear(); }
    }
}

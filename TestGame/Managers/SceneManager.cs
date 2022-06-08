using Microsoft.Xna.Framework;
using MonoGame.Extended.Tiled;
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
        public Scene GetScene() {
            if (count > selected)
            {
                return scenes[selected];
            }
            return null;
        }
        public void gotoScene(Game1 g, int id)
        {
            if(id != selected)
            {
                GetScene().Close(g);
                Set(id);
                GetScene().Load(g);
            }
            
        }
        public virtual void Set(int id) { selected = id; }
        public virtual void Set(Scene scene) { selected = 0; }
        public void Add(Scene scene, Game1 g) { scenes.Add(scene); scene.Init(g); }
        public void Remove(Scene scene) { scenes.Remove(scene); }
        public void Clear() { scenes.Clear(); }
        
        public bool ColideWithTerrein(Rectangle posRect)
        {
            TiledMapObjectLayer CollisionLayer = GetScene()._tiledMap.GetLayer<TiledMapObjectLayer>("Collision");
            foreach (TiledMapObject obj in CollisionLayer.Objects)
            {
                if (new Rectangle((int)obj.Position.X, (int)obj.Position.Y, (int)obj.Size.Width, (int)obj.Size.Height).Intersects(posRect))
                {
                    return true;
                }
            }
            //return g.Map.Tilesets[0].Tiles[0].Properties["IsCollisionTile"].;
            return false;
        }
    }
}

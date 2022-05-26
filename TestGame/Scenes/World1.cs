using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TestGame.Managers;
using TestGame.Objects.Entities.Creatures;
using TestGame.Objects.Entities.Structures;
using TiledSharp;

namespace TestGame.Scenes
{
    public class World1 : Scene
    {
        public World1(Game1 g) : base(g)
        {

        }
        public void loadObject(Game1 g, TmxObject obj)
        {
            Type typ = Type.GetType(obj.Type);
            GameObject o = (GameObject)Activator.CreateInstance(typ, 3, 0);
            g.pageGame.objectManager.Add(o, g);
        }
        public override void Init(Game1 g)
        {
            Debug.WriteLine("INIT ONCE");
            tileset = g.Content.Load<Texture2D>("!CL_DEMO");
            var Objects = new List<GameObject>();
            foreach (var o in g.Map.ObjectGroups["Objects"].Objects)
            {
                Debug.WriteLine("OBJECT IS: _____> " + o.Name);
                if(o.Name == "Zombie")
                {
                    Zombie z = new Zombie((int)o.X, (int)o.Y, 16, 16);
                    z.Width *= Int32.Parse(o.Properties["size"]);
                    z.Height *= Int32.Parse(o.Properties["size"]);
                    g.pageGame.objectManager.Add(z, g);
                }
                if (o.Type == "TestGame.Objects.Entities.Structures.Tree")
                {
                    //Tree t = new Tree((int)o.X * 3, (int)o.Y * 3);
                    //g.pageGame.objectManager.Add(t, g);
                    loadObject(g, o);
                }
            }
            
            base.Init(g);
        }
        public override void Load(Game1 g)
        {
            //load scene
        }
    }
}

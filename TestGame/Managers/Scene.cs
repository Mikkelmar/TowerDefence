using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Renderers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TiledSharp;

namespace TestGame.Managers
{
    public abstract class Scene
    {
        public ObjectManager objectManager { get; } = new ObjectManager();

        public TiledMap _tiledMap;
        public TiledMapRenderer _tiledMapRenderer;
        protected Texture2D tileset;
        protected string fileName = "maps/Island";
        protected float LevelZoom = 3f;
        public Scene(Game1 g)
        {
        }
        public virtual void Init(Game1 g)
        {
            _tiledMap = g.Content.Load<TiledMap>(fileName);
            _tiledMapRenderer = new TiledMapRenderer(g.GraphicsDevice, _tiledMap);
        }
        public virtual void Update(GameTime gt, Game1 g)
        {
            _tiledMapRenderer.Update(gt);
            objectManager.Update(gt, g);
        }
        public void Draw(Game1 g)
        {
            _tiledMapRenderer.Draw(g.gameCamera.GetViewMatrix(), depth: 1f);
            objectManager.Draw(g);
        }
        public virtual void Load(Game1 g)
        {
            g.pageGame.cam.setZoom(g, LevelZoom);
        }
        public abstract void Close(Game1 g);
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using TiledSharp;

namespace TestGame.Managers
{
    public abstract class Scene
    {
        protected TmxMap _map;
        protected int tilesetWidth, tilesetHeight, tilesetWide;
        protected Texture2D tileset;

        public Scene(Game1 g)
        {
        }
        public virtual void Init(Game1 g)
        {
            //map = g.Content.Load<TiledMap>("example/map_1");
            //mapRender = new TiledMapRenderer(g.GraphicsDevice, map);
            _map = g.Map;

            tilesetWidth = _map.Tilesets[0].TileHeight;
            tilesetHeight = _map.Tilesets[0].TileHeight;
            tilesetWide = tileset.Width / tilesetWidth;
        }
        public virtual void Update(GameTime gt, Game1 g)
        {

        }
        public int GetTile(int xpos, int ypos)
        {
            return 0;
        }
        public void Draw(Game1 g)
        {
            int game_SIZE = 3;
            //draw map
            for (int i = 0; i < _map.Layers.Count; i++)
            {
                for (int h = 0; h < _map.Layers[i].Tiles.Count; h++)
                {
                    int gid = _map.Layers[i].Tiles[h].Gid;
                    if (gid != 0)
                    {
                        int tileFrame = gid - 1;
                        int column = tileFrame % tilesetWide;
                        int row = (int)Math.Floor(tileFrame / (double)tilesetWide);

                        float x = (h % _map.Width) * _map.TileWidth;
                        float y = (float)Math.Floor(h / (double)_map.Width) * _map.TileHeight;

                        Rectangle tilsetRectangle = new Rectangle(
                            tilesetWidth * column,
                            tilesetHeight * row,
                            tilesetWidth,
                            tilesetHeight);

                        Drawing._spriteBatch.Draw(tileset, 
                            new Rectangle((int)
                                (x* game_SIZE), 
                                (int)(y* game_SIZE), 
                                (int)(tilesetWidth* game_SIZE), 
                                (int)(tilesetHeight* game_SIZE)), 
                            tilsetRectangle, Color.White, 0.0f, Vector2.Zero, SpriteEffects.None, 0.0001f - (i * 0.00001f));
                    }
                }
            }
        }
        public abstract void Load(Game1 g);
    }
}

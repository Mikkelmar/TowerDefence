using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;
using TestGame.Objects.Entities;

namespace TestGame.Managers
{
    /**
     * BuildHandler har ansvar for å la spilleren plasere(bygge)
     * GameObjects inn i spillet
     */
    public class BuildHandler : HoverLisner, Clickable
    {
        private Vector2 mousePos = new Vector2();
        public Structure structure;
        private Builder builder;
        public BuildHandler(Game1 g)
        {
            g.pageGame.mouseManager.AddHover(this, false);
            g.pageGame.mouseManager.Add(this, false);
        }
        public void SetBuild(Structure structure, Builder builder)
        {
            this.structure = structure;
            this.builder = builder;
        }
        private Vector2 getWorldPos()
        {
            return new Vector2((int)(mousePos.X/16), (int)(mousePos.Y/16));
        }
        public void Build(Game1 g, Structure structure)
        {
            g.pageGame.getObjectManager().Add(structure, g);
            builder.Built();
            this.structure = null;
            builder = null; ;
        }
        public bool CanBuild(Game1 g, int x, int y, int width = 1, int height = 1)
        {
            if (!builder.CanBuild())
            {
                return false;
            }
            ObjectManager objm = g.pageGame.getObjectManager();
            Rectangle rect = new Rectangle(x, y, width, height);
            if (!objm.Intersect(rect) && !g.pageGame.sceneManager.ColideWithTerrein(rect))
            {
                return true;
            }
            return false;
        }
        public void Draw(Game1 g)
        {
            if(structure != null)
            {
                Color c = Color.Green * 0.5f;
                Vector2 pos = getWorldPos();
                pos.X *= 16;
                pos.Y *= 16;

                if (!CanBuild(g, (int)pos.X, (int)pos.Y, (int)structure.Width, (int)structure.Height))
                {
                    c = Color.Red * 0.5f;
                }
                //temp solution. TODO: add color to the sprite.draw()
                Drawing._spriteBatch.Draw(
                    texture: structure.GetSprite().Texture,
                    position: pos,
                    sourceRectangle: structure.GetSprite().rectangle,
                    color: c,
                    rotation: 0.0f,
                    origin: Vector2.Zero,
                    1,
                    SpriteEffects.None,
                    layerDepth: 0.001f
                );
            }
        }

        public void Hover(float x, float y, Game1 g)
        {
            mousePos.X = x;
            mousePos.Y = y;
        }

        public void Clicked(float x, float y, Game1 g)
        {
            if (structure != null) {

                Vector2 pos = getWorldPos();
                pos.X *= 16;
                pos.Y *= 16;
                if (CanBuild(g, (int)pos.X, (int)pos.Y, (int)structure.Width, (int)structure.Height))
                    {
                        structure.X = pos.X;
                        structure.Y = pos.Y;
                        Build(g, structure);
                    }
            }
        }
    }
}

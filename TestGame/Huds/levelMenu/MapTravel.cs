using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TestGame.Graphics;
using TestGame.Huds.PopupDisplays;
using TestGame.Managers;
using TestGame.Pages;

namespace TestGame.Huds.levelMenu
{
    public class MapTravel : Button
    {
        private int sceeneId;
        private Sprite texture;
        private int requireLevelClear = -1;
        PopupDisplay pd = new PopupDisplay();

        private static Sound hoverSound = new Sound(Sounds.hover, 1f, SoundManager.types.Menu);
        public MapTravel(int x, int y, int id, Sprite sprite, int requireLevelClear = -1) : base(x,y)
        {
            sceeneId = id;
            Width = 32;
            Height = 32;
            this.texture = sprite;
            this.requireLevelClear = requireLevelClear;
        }
        public override void activate(Game1 g)
        {
            if(requireLevelClear == -1 || g.pageGame.sceneManager.scenes[requireLevelClear].levelClearStars > 0)
            {
                if(g.levelMap.hudManager.activeObject != pd && g.levelMap.hudManager.activeObject == null)
                {
                    pd.depth = this.depth * 0.01f;
                    g.levelMap.hudManager.setActiveObject(pd, g);
                    g.levelMap.hudManager.Add(pd, g);
                    pd.hm.Add(new LevelSelectDisplay(pd, g.pageGame.sceneManager.scenes[sceeneId]), g);
                }
            }
        }
        protected override void TriggerHoverd(float x, float y, Game1 g)
        {
            hoverSound.play(g);
        }
        public override void Draw(Game1 g)
        {
            
            if (!(requireLevelClear == -1 || g.pageGame.sceneManager.scenes[requireLevelClear].levelClearStars > 0))
            {
                return;
            }
            Scene scene = g.pageGame.sceneManager.scenes[sceeneId];
            int starSize = 22;
            if (requireLevelClear == -1 || g.pageGame.sceneManager.scenes[requireLevelClear].levelClearStars > 0)
            {
                for(int i = 0; i < 3; i++)
                {
                    if (i < scene.levelClearStars)
                    {
                        
                        new Sprite(Textures.gold_star).Draw(X + i * starSize + Width / 2 - starSize*3/2, Y- starSize, starSize, starSize, depth*0.1f);
                    }
                    else
                    {
                        new Sprite(Textures.empty_star).Draw(X + i * starSize + Width / 2 - starSize * 3/2, Y- starSize, starSize, starSize, depth * 0.1f);
                    }
                    
                }
                //Drawing.DrawText(scene.levelClearStars.ToString(), X, Y, layerDepth: 0.000000001f, scale: 2f);
                
            }
            if (scene.specialStar >= 1)
            {
                texture = new Sprite(Textures.point_gold); 
            }
            else if(scene.levelClearStars < 1)
            {
                texture = new Sprite(Textures.point);
            }
            else
            {
                texture = new Sprite(Textures.point_blue);
            }
            if (scene.endlessStar >= 1)
            {
                new Sprite(Textures.greekGrass).Draw(X - 10, Y - 10, Width + 20, Height + 20, layerDepth: 0.000000003f);
            }


            Color nameColor = Color.LightGray;
            if (BeingHoverd)
            {
                nameColor = Color.White;
                texture.Draw(X-6, Y-6, Width+12, Height + 12, layerDepth: 0.000000002f);
            }
            else
            {
                texture.Draw(X, Y, Width, Height, layerDepth: 0.000000002f);
            }
            Drawing.DrawText(
                scene.name, 
                X+(Width/2)-(TextHandler.textLength(scene.name)* 0.9f/2), 
                Y+Height, layerDepth: 0.000000001f, scale: 0.9f,
                color: nameColor);

        }
    }
}

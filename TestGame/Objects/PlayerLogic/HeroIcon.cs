using Microsoft.Xna.Framework;
using System;
using TestGame.Graphics;
using TestGame.Huds;
using TestGame.Managers;
using TestGame.Objects.Particles;
using TestGame.Objects.Soldiers;

namespace TestGame.Objects.PlayerLogic
{
    public class HeroIcon : Hud, Clickable
    {
        //private static Sound deniedSound = new Sound(Sounds.denied, 0.1f, SoundManager.types.Menu);
        public Hero hero;
        public static int iconSize = 80;
        public HeroIcon(int x, int y, Hero hero)
        {
            Width = iconSize;
            Height = iconSize;
            X = x;
            Y = y;
            this.hero = hero;
        }
        public void Update(GameTime gt, Game1 g)
        {
        }
        public void rechargePower(TimeSpan t, Game1 g)
        {
            //currentTime += t;
            g.pageGame.getObjectManager().Add(new DamageParticle(new Vector2(X + 16, Y-20), (int)t.TotalSeconds), g);
        }
        public override void Draw(Game1 g)
        {
            float cx = g.gameCamera.Position.X;
            float cy = g.gameCamera.Position.Y;
            /*
            if (g.pageGame.getHudManager().activeObject == this)
            {
                Vector2 pos = g.pageGame.mouseManager.GetMousePos(g);
                new Sprite(Textures.target).Draw(pos.X + cx - 16, pos.Y + cy - 16, 32, 32, layerDepth: depth);
            }*/
            float alpha = 1f;
            if ((hero.hp <= 0))
            {
                alpha = 0.4f;
            }

            hero.getSprite().Draw(new Vector2(X+cx,Y+cy), width: Width, height: Height, layerDepth: depth*0.2f, alpha: alpha);
            if (hero.hp <= 0)
            {
                Drawing.FillRect(new Rectangle((int)(X + cx), (int)(Y + cy), Width, (int)(Height * (float)((hero.respawnTime - hero.currentRespawnTime) / hero.respawnTime))), Color.Gray, depth * 0.01f, g);

            }

            new Sprite(Textures.gui, new Rectangle(96, 36, 26, 24)).Draw(new Vector2(X + cx - 8, Y + cy - 8), width: Width+16, height: Height+16, layerDepth: depth);
            
            Drawing.DrawText(hero.getLevel().ToString(), X, Y, this.depth * 0.1f);
            //Drawing.FillRect(new Rectangle((int)X, (int)Y, Width, Height), Color.Black, depth, g);
            if (hero.baseHp != 0)
            {
                Drawing.FillRect(new Rectangle((int)(X), (int)(Y +iconSize-10), (int)Width, 8), Color.Red, this.depth*0.1f, g);
                Drawing.FillRect(new Rectangle((int)(X), (int)(Y + iconSize- 10), (int)((Width) * (hero.hp / (double)hero.baseHp)), 8), Color.Green, this.depth * 0.01f, g);
            }

            Drawing.FillRect(new Rectangle((int)(X), (int)(Y + iconSize - 2), (int)Width, 8), Color.Gray, this.depth * 0.1f, g);
            Drawing.FillRect(new Rectangle((int)(X), (int)(Y + iconSize - 2), (int)((Width) * (hero.getXp() / (double)hero.xpNeeded())), 8), Color.LightBlue, this.depth * 0.01f, g);

        }
        public void Clicked(float x, float y, Game1 g)
        {
            if (new Rectangle((int)X, (int)Y, Width, Height).Contains(x, y)){
                //g.pageGame.getHudManager().setActiveObject(hero, g);
                g.pageGame.getHudManager().setActiveObject(hero, g);
            }
        }
    }
}

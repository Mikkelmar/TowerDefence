using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;
using TestGame.Managers;
using TestGame.Objects.Towers;

namespace TestGame.Objects.MapObjects
{
    public class TowerSealer : Entity, Clickable
    {
        private Tower tower;
        private int hp, baseHp;
        private Sprite vines = new Sprite(Textures.vines);

        private static Sound vineScratchSound = new Sound(Sounds.scratch, 2f, SoundManager.types.Tower),
            fleeSound = new Sound(Sounds.fleeSound, 2f, SoundManager.types.Tower);
        
        public TowerSealer(Tower tower) : base(tower.X, tower.Y, (int)tower.Width, (int)tower.Height)
        {
            this.tower = tower;
            hp = 5;
            baseHp = hp;
            sprite = tower.getSprite();
        }
        public override void Init(Game1 g)
        {
            base.Init(g);
            g.pageGame.mouseManager.Add(this);
            if(g.pageGame.getHudManager().activeObject == tower)
            {
                g.pageGame.getHudManager().closeActiveObject(g);
            }
            if (g.pageGame.hudManager.activeObject == tower)
            {
                g.pageGame.hudManager.closeActiveObject(g);
            }
            g.pageGame.getObjectManager().Remove(tower, g);
        }
        public override void Destroy(Game1 g)
        {
            base.Destroy(g);
            g.pageGame.mouseManager.Remove(this);
        }
        public void Clicked(float x, float y, Game1 g)
        {
            if (new Rectangle((int)X, (int)Y, (int)Width, (int)Height).Contains(x,y))
            {
                
                if (--hp <= 0)
                {
                    fleeSound.play(g);
                    g.pageGame.getObjectManager().Add(tower, g);
                    g.pageGame.getObjectManager().Remove(this, g);
                }
                else
                {
                    vineScratchSound.play(g);
                }
                
            }
        }

        public override void Update(GameTime gt, Game1 g)
        {
            
        }
        public override void Draw(Game1 g)
        {
            base.Draw(g);
            vines.Draw(position, Width, Height, depth*0.5f);
            if (tower.drawGround)
            {
                new Sprite(Textures.plot).Draw(position, Width, Height, depth * 2);
            }
            Drawing.DrawText("CLICK!", X, Y, layerDepth: depth * 0.1f, color: Color.Red);
            if (baseHp != 0 && hp != baseHp)
            {
                Drawing.FillRect(new Rectangle((int)X+16, (int)Y - 12, 32, 12), Color.White, this.depth, g);
                Drawing.FillRect(new Rectangle((int)X + 16, (int)Y - 12, (int)(32 * ((baseHp-hp) / (double)baseHp)), 12), Color.Yellow, this.depth - this.depth * 0.1f, g);
            }
        }
    }
}

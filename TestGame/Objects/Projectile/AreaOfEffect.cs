using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;
using TestGame.Managers;
using TestGame.Objects.Monsters;
using TestGame.Objects.Particles;
using TestGame.Objects.StatusEffects;

namespace TestGame.Objects.Projectile
{
    public class AreaOfEffect : Projectile
    {
        private int range;
        public TimeSpan despawnTimer = TimeSpan.FromSeconds(10);
        private TimeSpan tickTimer = TimeSpan.FromMilliseconds(500);
        private StatusEffect effect;

        public AreaOfEffect(int x, int y, StatusEffect effect, Sprite sprite, int size=74) : base(x-37, y - 37)
        {
            this.sprite = sprite;
            this.effect = effect;
            Width = size;
            Height = size;
            range = size;
        }
        public override void Draw(Game1 g)
        {
            Vector2 drawPos = new Vector2(X, Y);
            //Drawing.FillRect(GetHitbox(), Color.Red, 0.000000001f, g); //Debug hitboxes
            sprite.Draw(drawPos, Width, Height, depth, rotation: rotation);
        }
        public override void Update(GameTime gt, Game1 g)
        {
            despawnTimer -= gt.ElapsedGameTime;
            if (despawnTimer.TotalMilliseconds < 0)
            {
                g.pageGame.getObjectManager().Remove(this, g);
                return;
            }

            tickTimer -= gt.ElapsedGameTime;
            if(tickTimer.TotalMilliseconds < 0)
            {
                tickTimer = TimeSpan.FromMilliseconds(500);
                ObjectManager om = g.pageGame.getObjectManager();
                foreach (Monster m in om.GetAllObjectsWith(p => p is Monster && (int)om.FromToDir(this, p).Length() < range))
                {
                    if (m.canBeAffactedBy(effect.Name) && !m.BeingEffectedBy(effect.Name))
                    {
                        m.GiveStatusEffect(effect.clone());
                        if(effect.Name == "Burning")
                        {
                            g.pageGame.getObjectManager().Add(new BurningEffect(m.GetPosCenter(), m), g);
                        }
                    }
                }
            }
            
        }
    }
}

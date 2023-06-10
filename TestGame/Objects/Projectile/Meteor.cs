using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;
using TestGame.Managers;
using TestGame.Objects.Monsters;
using TestGame.Objects.Particles;
using TestGame.Objects.StatusEffects;
using TestGame.Objects.Towers;

namespace TestGame.Objects.Projectile
{
    public class Meteor : Projectile
    {
        private int DamageRadius;
        private bool spawnFire;
        private TimeSpan spawnSMoke = new TimeSpan();
        public Meteor(int x, int y, bool spawnFire = false) : base(x, y, null, null, 26)
        {
            sprite = new Sprite(Textures.meteorRock);
            Speed = 350f;
            this.spawnFire = spawnFire;
            DamageRadius = 52;
            origionVector = new Vector2(30 / 2f, 30 / 2f);
        }
        public override void Update(GameTime gt, Game1 g)
        {
            base.Update(gt, g);
            rotation += Drawing.delta * 10f;

            spawnSMoke += gt.ElapsedGameTime;
            if (spawnSMoke.TotalMilliseconds > 100)
            {
                spawnSMoke = new TimeSpan();
                new SmokeParticle(new Vector2(X- 16, Y -16), 32, 600).Spawn(g);
            }
        }
        protected override void hitTarget(Game1 g)
        {
            if (spawnFire)
            {
                g.pageGame.getObjectManager().Add(
                new FirePit(
                    (int)X,
                    (int)Y,
                    new Burning(1, TimeSpan.FromSeconds(5), TimeSpan.FromMilliseconds(800)
                   ),
                    new Sprite(Textures.burnedHole),
                    48
                 )
                { despawnTimer = TimeSpan.FromSeconds(8)}, g);
            }
                

            new Sound(Sounds.bombImpact, 0.1f).play(g);
            ObjectManager om = g.pageGame.getObjectManager();
            foreach(Monster m in om.GetAllObjectsWith(p => p is Monster && (int)om.FromToDir(this, p).Length() < DamageRadius))
            {
                m.takeDamage(Math.Min(Damage, Math.Max((int)(Damage * ((DamageRadius * 3 / 2) - om.FromToDir(this, m).Length()) / DamageRadius), 1)), g);
               
            }
            for(int i = 0; i < 10; i++)
            {
                Random rnd = new Random();
                Vector2 pos;
                if (Target != null)
                {
                    pos = Target.GetPosCenter();
                }
                else
                {
                    pos = targetPos;
                }
                 
                om.Add(new Explotion(
                    new Vector2(
                        pos.X+ rnd.Next(DamageRadius/2+1)- DamageRadius/4, 
                        pos.Y + rnd.Next(DamageRadius/2+1) - DamageRadius / 4), 
                    24, 
                    rnd.Next(400)-150), g);
            }
            Vector2 pos2;
            if (Target != null)
            {
                pos2 = Target.GetPosCenter();
            }
            else
            {
                pos2 = targetPos;
            }
            
            
            g.pageGame.getObjectManager().Remove(this, g);
        }
        protected override void hitPos(Game1 g)
        {
            hitTarget(g);
        }

    }
}

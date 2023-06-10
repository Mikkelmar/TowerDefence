using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TestGame.Graphics;
using TestGame.Managers;
using TestGame.Objects.Monsters;
using TestGame.Objects.Particles;
using TestGame.Objects.Towers;

namespace TestGame.Objects.Projectile
{
    public class Missile : Projectile
    {
        private int DamageRadius;
        private TimeSpan shootUpCd = TimeSpan.FromMilliseconds(300), orbitTime = new TimeSpan();
        private BombTower_Missile missileTower;
        public Missile(int x, int y, BombTower_Missile caster = null) : base(x, y, null, caster, 16)
        {
            sprite = new Sprite(Textures.bomb);
            Speed = 300f;
            Damage = caster.damage;
            DamageRadius = 48;
            this.missileTower = caster;
        }
        public override void Destroy(Game1 g)
        {
            base.Destroy(g);
            missileTower.removeMissile(this);
        }
        public override void Update(GameTime gt, Game1 g)
        {
            //Debug.WriteLine(X+","+ Y);
            if(Target == null)
            {
                shootUpCd -= gt.ElapsedGameTime;
                if (shootUpCd.TotalMilliseconds > 0)
                {
                    
                    Y -= Speed*2/3 * Drawing.delta;
                }
                else
                {
                    findNewTarget(g);
                    
                    orbitTime += gt.ElapsedGameTime;
                    X += (float)(Math.Sin((orbitTime.TotalMilliseconds / 1000 + orbitTime.TotalSeconds)*4 ))* (Speed*2/3) * Drawing.delta;
                    Y += (float)(Math.Cos((orbitTime.TotalMilliseconds / 1000 + orbitTime.TotalSeconds)*4 )) * -(Speed*2/3) * Drawing.delta;
                    
                    
                }
            }
            else
            {
                if(Target.hp <= 0)
                {
                    Target = null;
                    return;
                }
                int maxAcc = 40;
                int accConst = 30;
                if(Target.GetPosCenter().Y < Y)
                {
                    if(ySpeed > -maxAcc)
                    {
                        ySpeed -= accConst * Drawing.delta;
                    }
                }
                else
                {
                    if (ySpeed < maxAcc)
                    {
                        ySpeed += accConst * Drawing.delta;
                    }
                }
                if(Target.GetPosCenter().X < X)
                {
                    if (xSpeed > -maxAcc)
                    {
                        xSpeed -= accConst * Drawing.delta;
                    }
                }
                else
                {
                    if (xSpeed < maxAcc)
                    {
                        xSpeed += accConst * Drawing.delta;
                    }
                }
                X += xSpeed * Drawing.delta*5;
                Y += ySpeed * Drawing.delta* 5;
                checkTargetCollision(g);
            }
            
        }
        protected override bool findNewTarget(Game1 g)
        {
            Monster BestMonster = null;
            foreach (Monster m in g.pageGame.getObjectManager().GetMonsters())
            {
                if (BestMonster == null)
                {
                    BestMonster = m;
                }
                else
                {
                    if (m.distance > BestMonster.distance)
                    {
                        BestMonster = m;
                    }
                }
            }
            if (BestMonster != null)
            {
                Target = BestMonster;
            }
            return true;
        }
        protected override void hitTarget(Game1 g)
        {
            ObjectManager om = g.pageGame.getObjectManager();
            foreach(Monster m in om.GetAllObjectsWith(p => p is Monster && (int)om.FromToDir(this, p).Length() < DamageRadius))
            {
                m.takeDamage(Math.Min(Damage, Math.Max((int)(Damage*((DamageRadius*3/2)-om.FromToDir(this, m).Length()) / DamageRadius),1)), g);
            }
            for(int i = 0; i < 10; i++)
            {
                Random rnd = new Random();
                Vector2 pos = Target.GetPosCenter();
                om.Add(new Explotion(new Vector2(pos.X+ rnd.Next(DamageRadius/2+1)- DamageRadius/4, pos.Y + rnd.Next(DamageRadius/2+1) - DamageRadius / 4), 32, rnd.Next(400)-150), g);
            }
            g.pageGame.getObjectManager().Remove(this, g);
        }
    }
}

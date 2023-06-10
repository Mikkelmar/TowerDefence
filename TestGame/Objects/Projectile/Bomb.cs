using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;
using TestGame.Managers;
using TestGame.Objects.Monsters;
using TestGame.Objects.Particles;
using TestGame.Objects.Towers;

namespace TestGame.Objects.Projectile
{
    public class Bomb : Projectile
    {
        public int DamageRadius;
        public Bomb(int x, int y, Monster target = null, Tower caster = null) : base(x, y, target, caster, 16)
        {
            sprite = new Sprite(Textures.bomb);
            Speed = 300f;
            if(caster != null)
            {
                Damage = caster.damage;
            }
            
            DamageRadius = 42;
        }
        protected override void hitTarget(Game1 g)
        {
            new Sound(Sounds.bombImpact, 0.1f).play(g);
            ObjectManager om = g.pageGame.getObjectManager();
            foreach(Monster m in om.GetAllObjectsWith(p => p is Monster && (int)om.FromToDir(this, p).Length() < DamageRadius))
            {
                if(Caster is BombTower && g.levelMap.playerData.starUpgrades["BOMB4"])
                {
                    m.takeDamage(Damage, g);
                }
                else
                {
                    m.takeDamage(Math.Min(Damage, Math.Max((int)(Damage * ((DamageRadius * 5 / 4) - om.FromToDir(this, m).Length()) / DamageRadius), 1)), g);
                }
               
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
                    32, 
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

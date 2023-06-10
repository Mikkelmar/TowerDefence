using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;
using TestGame.Managers;
using TestGame.Objects.Monsters;
using TestGame.Objects.Projectile;

namespace TestGame.Objects.Soldiers
{
    public class Viking : Soldier
    {
        public bool canThrowAxe = false;
        private int axeRange = 110, axeDamage = 2;

        private TimeSpan currentAxeTime, axeReloadTime = new TimeSpan(0, 0, 0, 0, 950);
        public Viking(int x, int y, Sprite spriteTexture = null, int width = 22, int height = 22) : base( x, y, spriteTexture, width, height)
        {
            string[] lines = System.IO.File.ReadAllLines("Saves/vikingNames.txt");
            name = lines[new Random().Next(0, lines.Length - 1)];
        }
        protected override void SearchingForTarget(GameTime gt, Game1 g)
        {
            base.SearchingForTarget(gt, g);
            if(Target == null && canThrowAxe)
            {
                if(currentAxeTime > axeReloadTime)
                {
                    if (throwAxe(g))
                    {
                        currentAxeTime = new TimeSpan();
                    }
                }
                else
                {
                    currentAxeTime += gt.ElapsedGameTime;
                }

            }
        }
        private bool throwAxe(Game1 g)
        {
            Vector2 targetPos = getTargetPos();
            List<GameObject> newTargets = g.pageGame.getObjectManager().GetAllObjectsWith(p =>
                p is Monster &&
                p.DistanceTo(targetPos) < axeRange
               );
            if (newTargets.Count != 0)
            {
                g.pageGame.getObjectManager().Add(new Axe((int)GetPosCenter().X, (int)GetPosCenter().Y, (Monster)newTargets[0], damage: axeDamage));
                return true;
            }
            return false;
        }
    }
}

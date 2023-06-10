using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;

namespace TestGame.Objects.Soldiers
{
    public class SkeletonSoldier : Soldier
    {
        private TimeSpan spawnDelay = new TimeSpan();
        public SkeletonSoldier(int x, int y, int width = 22, int height = 22) : base( x, y, new Sprite(Textures.skeleton), width, height)
        {
            string[] lines = System.IO.File.ReadAllLines("Saves/maleNames.txt");
            name = "Deceased " + lines[new Random().Next(0, lines.Length - 1)];
            despawn = false;
            selfRegain = false;
            baseHp = 8;
            hp = baseHp;
            attackDamage = 1;
            stationedPos = new Vector2(x, y);
        }
        public override void Update(GameTime gt, Game1 g)
        {
            if (spawnDelay <= TimeSpan.FromSeconds(5))
            {
                spawnDelay += gt.ElapsedGameTime;
                return;
            }
            base.Update(gt, g);
        }
        public override void Draw(Game1 g)
        {
            if (spawnDelay <= TimeSpan.FromSeconds(5))
            {
                float rotation = (float)Math.PI * 0.5f * (-FacingRight);
                int fallTime = 400;
                if (spawnDelay.CompareTo(TimeSpan.FromMilliseconds(5000 - fallTime)) >= 0)
                {
                    rotation = (float)(Math.PI * .5 * (TimeSpan.FromSeconds(5).TotalMilliseconds - spawnDelay.TotalMilliseconds) / fallTime) * (-FacingRight);
                }
                SpriteEffects directionFacing = SpriteEffects.FlipHorizontally;
                if (FacingRight != 1)
                {
                    directionFacing = SpriteEffects.None;
                }
                Vector2 drawPos = new Vector2(X, Y);
                sprite.Draw(drawPos, Width, Height, layerDepth: depth,
                    rotation: rotation,
                    alpha: (float)Math.Min(Math.Max(0f, (((float)spawnDelay.TotalMilliseconds) / 4000)), .9f),
                    origin: new Vector2(Width / 2, Height),
                    spriteEffects: directionFacing);
                return;
            }
            base.Draw(g);
        }

    }
}

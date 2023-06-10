using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;
using TestGame.Managers;
using TestGame.Objects.MapObjects;
using TestGame.Objects.Monsters;
using TestGame.Objects.Particles;
using TestGame.Objects.Towers;
using TestGame.Objects.Towers.NectoTowers;

namespace TestGame.Objects.Projectile
{
    public class SoulOrb : Projectile
    {
        NecroTower TargetTower;
        private TimeSpan fadeTime = new TimeSpan();
        public SoulOrb(int x, int y, NecroTower TargetTower) : base(x, y, null, null, 8)
        {
            sprite = new Sprite(Textures.greenShadow);
            Speed = 300f;
            this.TargetTower = TargetTower;
            targetPos = this.TargetTower.GetPosCenter();
        }
        public override void Update(GameTime gt, Game1 g)
        {
            base.Update(gt, g);
            fadeTime += gt.ElapsedGameTime;
            if (fadeTime.Milliseconds > 30)
            {
                new FadingParticle(new Vector2(X, Y), new Sprite(Textures.greenShadow), TimeSpan.FromMilliseconds(200), size: (int)Width).Spawn(g);
                fadeTime = new TimeSpan();
            }
        }
        protected override void hitTarget(Game1 g)
        {
            g.pageGame.getObjectManager().Remove(this, g);
        }
        protected override void hitPos(Game1 g)
        {
            hitTarget(g);
        }
    }
}

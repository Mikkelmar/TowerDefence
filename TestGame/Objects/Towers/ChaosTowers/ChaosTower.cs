using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;
using TestGame.Managers;
using TestGame.Objects.Monsters;
using TestGame.Objects.Particles;
using TestGame.Objects.Projectile;
using TestGame.Objects.Towers.TowerPowers;

namespace TestGame.Objects.Towers
{
    public class ChaosTower : Tower
    {
        protected ChaosBall orb;
        public static int TotalChaosTowers = 0;
        private static Sound shootSpund = new Sound(Sounds.charge_1, 0.5f, SoundManager.types.Tower);
        private TimeSpan spawnSMoke = TimeSpan.FromMilliseconds(600);
        public ChaosTower(int x, int y) : base(x, y) {
            name = "Chaos tower";
            this.damage = 2;
            this.reloadTimer = new TimeSpan(0, 0, 0, 0, 500);
            this.range = 140;
            cost = 80;
            sprite = new Sprite(Textures.chaosTower_1);
            optionsID = new List<int>() { 16 };
            orb = new ChaosBall(-1, -36, this);

        }
        public override void Init(Game1 g)
        {
            base.Init(g);
            updateTotalChaosTowers(g);
            g.pageGame.getObjectManager().Add(orb, g);
        }
        public override void Destroy(Game1 g)
        {
            base.Destroy(g);
            g.pageGame.getObjectManager().Remove(orb, g);
        }
        protected override void fire(Game1 g, Monster target)
        {
            orb.Target = target;
            shootSpund.play(g);
        }
        public override void Update(GameTime gt, Game1 g)
        {
            spawnSMoke += gt.ElapsedGameTime;
            if (spawnSMoke.TotalMilliseconds > 1000)
            {
                spawnSMoke = new TimeSpan();
                new SmokeParticle(new Vector2(X+16, Y), 32, 1000).Spawn(g);
            }
            if (orb.canFire)
            {
                if (findTarget(g))
                {
                    //
                }

            }
        }
        public override int getSellValue(Game1 g)
        {
            if (g.levelMap.playerData.starUpgrades["CHAOS1"])
            {
                return soldValue*9/10;
            }
            return soldValue / 2; ;
        }
        public override void Sell(Game1 g)
        {
            base.Sell(g);
            updateTotalChaosTowers(g);
        }
        private void updateTotalChaosTowers(Game1 g)
        {
            TotalChaosTowers = g.pageGame.getObjectManager().GetAllObjectsWith(t => t is ChaosTower).Count;
        }
        public override Tower LoadUpgrades(Game1 g)
        {
            if (g.levelMap.playerData.starUpgrades["CHAOS1"])
            {
                range += (int)(range *0.1f);
            }
            return base.LoadUpgrades(g);
        }
    }
}

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TestGame.Graphics;
using TestGame.Managers;
using TestGame.Objects.Monsters;
using TestGame.Objects.Projectile;
using TestGame.Objects.StatusEffects;

namespace TestGame.Objects.Towers
{
    public class SoulTower_1 : Tower
    {
        public List<TowersSlowBomb> slowBombs = new List<TowersSlowBomb>();
        protected StatusEffect effect;
        public SoulTower_1(int x, int y) : base(x, y)
        {
            name = "Soul tower";
            this.damage = 6;
            this.reloadTimer = new TimeSpan(0, 0, 0, 2, 500);
            this.range = 120;
            capacity = 3;
            cost = 70;
            sprite = new Sprite(Textures.spawnTower_1);
            optionsID = new List<int>() { 22 };
            canSelectTarget = true;
            targetPos = new Vector2(x, y - 64);
            effect = new Slow(0f, TimeSpan.FromSeconds(3));

        }
        public override void Buy(Game1 g, Tower tower)
        {
            if (tower is SoulTower_1)
            {
                (tower as SoulTower_1).slowBombs.AddRange(slowBombs);
                foreach (TowersSlowBomb tsl in slowBombs)
                {
                    tsl.spawnTower = (tower as SoulTower_1);
                    tsl.Damage = tower.damage;
                }
                slowBombs.Clear();
                tower.setTargetPos(g, this.targetPos);
            }

            base.Buy(g, tower);
        }
        public override void setTargetPos(Game1 g, Vector2 newPos)
        {
            if (Vector2.Distance(GetPosCenter(), newPos) > range)
            {
                //TODO sound type
                new Sound(Sounds.denied, 0.8f).play(g);
                return;
            }
            new Sound(Sounds.confirm, 0.8f).play(g);
            base.setTargetPos(g, newPos);
            foreach (TowersSlowBomb bomb in slowBombs)
            {
                bomb.inPos = false;
            }
        }
        public override void Init(Game1 g)
        {
            base.Init(g);
            spawnMinion(g);
        }
        private void spawnMinion(Game1 g)
        {
            TowersSlowBomb sb = new TowersSlowBomb((int)GetPosCenter().X, (int)GetPosCenter().Y, 130f, this,
                effect.clone());
            slowBombs.Add(sb);
            g.pageGame.getObjectManager().Add(sb, g);
        }
        public override void Update(GameTime gt, Game1 g)
        {
            if (capacity > slowBombs.Count)
            {
                currentTimer += gt.ElapsedGameTime;
                if (currentTimer >= reloadTimer)
                {
                    spawnMinion(g);
                    currentTimer = new TimeSpan();
                }
            }

        }
        public override void Sell(Game1 g)
        {
            base.Sell(g);
            foreach (TowersSlowBomb bomb in slowBombs.ToArray())
            {
                g.pageGame.getObjectManager().Remove(bomb, g);
            }
        }
        protected override void fire(Game1 g, Monster target)
        {
            //throw new NotImplementedException();
        }
        public override void Draw(Game1 g)
        {
            base.Draw(g);
            if (g.pageGame.getHudManager().activeObject == this)
            {
                new Sprite(Textures.target).Draw(targetPos.X - 16, targetPos.Y - 16, 32, 32, layerDepth: depth);
            }

        }
    }
}
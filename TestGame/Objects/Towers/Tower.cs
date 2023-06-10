using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TestGame.Graphics;
using TestGame.Managers;
using TestGame.Objects.Monsters;
using TestGame.Objects.Particles;
using TestGame.Objects.Soldiers;

namespace TestGame.Objects.Towers
{
    public abstract class Tower : Upgradable
    {

        public List<Soldier> soldiers = new List<Soldier>();
        protected int capacity=0;
        public string name = "", description = "";
        public int cost, damage, range, soldValue;
        public float fireRate { get{ return (float)reloadTimer.TotalMilliseconds/1000; } }
        public TimeSpan reloadTimer = new TimeSpan(0, 0, 0, 0, 500);
        protected TimeSpan currentTimer = new TimeSpan(0,0,0);
        protected TimeSpan spawnTimer = TimeSpan.FromSeconds(3);
        private TimeSpan currentSpawnTimer = new TimeSpan();
        public bool canSelectTarget = false, drawGround = true;
        public Vector2 targetPos { get; protected set; }

        public Tower(int x, int y) : base(x, y, 64, 64)
        {
            //depth = 0.001f;
            targetPos = new Vector2(x, y - 64);
        }
        public override void Update(GameTime gt, Game1 g)
        {
            if(capacity > 0)
            {
                updateMinionSpawn(gt, g);
            }
            currentTimer += gt.ElapsedGameTime;
            if(currentTimer >= reloadTimer)
            {
                if (findTarget(g)){
                    currentTimer = new TimeSpan(0, 0, 0);
                }
            }
        }
        protected void updateMinionSpawn(GameTime gt, Game1 g)
        {
            if (capacity > soldiers.Count)
            {
                currentSpawnTimer += gt.ElapsedGameTime;
                if (currentSpawnTimer >= spawnTimer)
                {
                    spawnMinion(g);
                    currentSpawnTimer = new TimeSpan();
                }
            }
        }
        protected abstract void fire(Game1 g, Monster target);
        public override void Buy(Game1 g, Tower tower)
        {

            foreach (Soldier soldier in new List<Soldier>(soldiers))
            {
                g.pageGame.getObjectManager().Remove(soldier, g);
                //soldier.spawnTower = (tower as SoldierTower);
                //soldier.Damage = tower.damage;
            }
            soldiers.Clear();
            tower.setTargetPos(g, this.targetPos);

            base.Buy(g, tower);
        }
        protected virtual bool findTarget(Game1 g)
        {
            Monster bestTarget = findMonster(g);
            if(bestTarget != null)
            {
                fire(g, bestTarget);
                return true;
            }
            return false;
        }
        protected virtual Monster findMonster(Game1 g)
        {
            Monster bestTarget = null;
            foreach (Monster m in g.pageGame.getObjectManager().GetMonsters())
            {
                if (canTarget(m, g))
                {
                    if (bestTarget == null ||m.path.totalDistance - m.distance < bestTarget.path.totalDistance-bestTarget.distance)
                    {
                        bestTarget = m;
                    }
                }
            }
            return bestTarget;
        }
        protected bool canTarget(Monster monster, Game1 g)
        {
            return (int)g.pageGame.getObjectManager().FromToDir(this, monster).Length() <= range;
        }
        public Sprite getSprite()
        {
            return sprite;
        }
        public override void Draw(Game1 g)
        {
            base.Draw(g);
            if (drawGround)
            {
                new Sprite(Textures.plot).Draw(position, Width, Height, depth * 2);
            }
            if (canSelectTarget && g.pageGame.getHudManager().activeObject == this)
            {
                new Sprite(Textures.target).Draw(targetPos.X - 16, targetPos.Y - 16, 32, 32, layerDepth: depth);
            }  
        }
        

        public virtual void setTargetPos(Game1 g, Vector2 newPos)
        {
            
            if(capacity > 0)
            {
                if (Vector2.Distance(GetPosCenter(), newPos) > range)
                {
                    //TODO sound type
                    new Sound(Sounds.denied, 0.8f).play(g);
                    return;
                }
                new Sound(Sounds.confirm, 0.8f).play(g);
                targetPos = newPos;
                foreach (Soldier soldier in soldiers)
                {
                    soldier.inPos = false;
                }
            }
            else
            {
                targetPos = newPos;
            }
            
        }
        protected void spawnMinion(Game1 g)
        {
            Soldier soldier = getMinion();
            int id = 0;
            soldiers.Sort((x, y) => x.soldierID.CompareTo(y.soldierID));
            foreach (Soldier s in soldiers)
            {
                if (s.soldierID == id)
                {
                    id += 1;
                }
            }
            soldier.soldierID = id;
            soldier.setOffset(this.capacity);
            soldier.spawnTower = this;
            soldiers.Add(soldier);
            g.pageGame.getObjectManager().Add(soldier, g);
        }
        protected virtual Soldier getMinion()
        {
            return new Soldier((int)GetPosCenter().X, (int)GetPosCenter().Y) { 
                damage = damage
            };
        }
        public virtual Tower LoadUpgrades(Game1 g)
        {
            return this;
        }
        public override void Sell(Game1 g)
        {
            base.Sell(g);
            g.pageGame.player.money += getSellValue(g);
            foreach (Soldier soldier in soldiers.ToArray())
            {
                g.pageGame.getObjectManager().Remove(soldier, g);
            }
        }
        public virtual int getSellValue(Game1 g)
        {
            return soldValue / 2;
        }
    }
}

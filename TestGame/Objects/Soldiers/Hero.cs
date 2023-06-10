using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TestGame.Graphics;
using TestGame.Huds;

namespace TestGame.Objects.Soldiers
{
    public abstract class Hero : Soldier
    {
        HeroUI ui;
        public TimeSpan respawnTime = TimeSpan.FromSeconds(20), currentRespawnTime;
        private bool isDead;
        public int lvl = 1, xp = 0;
        public bool isUnlocked = false;
        public int getLevel() { return lvl; }
        public int getXp() { return xp; }
        public Dictionary<string, bool> Powers = new Dictionary<string, bool>();
        private List<string> powerNames = new List<string>() { "ATTACK", "DEFENCE", "SPECIAL", "POWER" };
        public Hero(int x, int y, int width = 22, int height = 22) : base( x, y, null, width, height)
        {
            despawn = false;
            selfRegain = true;
            stationedPos = new Vector2(x, y);
            foreach(string power in powerNames)
            {
                for(int i = 0; i < 5; i++)
                {
                    Powers.Add(power+i, false);
                }
            }
        }
        public override void Init(Game1 g)
        {
            isDead = false;
            currentRespawnTime = new TimeSpan();
            attackTimer = new TimeSpan();
            Target = null;
            base.Init(g);
            resetHeroPowers();
            applyAllBuffs();
        }
        public void applyAllBuffs()
        {
            foreach(string powerName in Powers.Keys)
            {
                if (Powers[powerName])
                {
                    activatePower(powerName);
                }
            }
        }
        public abstract void activatePower(string powerName);
        public abstract void resetHeroPowers();
        public abstract List<object[]> getUpgrades(string powerName);
        public void gainXP(int ammount)
        {
            xp += ammount;
            if(xp >= xpNeeded())
            {
                int lefoverXP = xp - xpNeeded();
                xp = 0;
                lvl += 1;
                gainXP(lefoverXP);
            }
        }
        public int xpNeeded()
        {
            return (int)Math.Pow(2.2f * lvl + 4, 2) + 13;
        }

        public override void Update(GameTime gt, Game1 g)
        {
            if (isDead)
            {
                currentRespawnTime += gt.ElapsedGameTime;
                if (currentRespawnTime.CompareTo(respawnTime) >= 1)
                {
                    currentRespawnTime = new TimeSpan();
                    hp = baseHp;
                    g.pageGame.getObjectManager().Add(this);
                    isDead = false;
                }
                return;
            }
            base.Update(gt, g);
        }
        protected override void attackTarget(Game1 g)
        {
            float hpBefore = Target.hp;
            base.attackTarget(g);
            int damageDealy = (int)(hpBefore - Math.Max(Target.hp, 0));
            gainXP(damageDealy);
        }
        protected override void die(Game1 g)
        {
            base.die(g);
            isDead = true;
        }

        public override void select(Game1 g) {
            ui = new HeroUI(this, (int)X, (int)Y, g);
            g.pageGame.getHudManager().Add(ui);
            g.pageGame.mouseManager.Add(ui);
            g.pageGame.mouseManager.AddHover(ui);
        }

        public override void close(Game1 g) {
            g.pageGame.getHudManager().Remove(ui, g);
            g.pageGame.mouseManager.Remove(ui);
            g.pageGame.mouseManager.RemoveHover(ui);
        }
    }
}

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TestGame.Graphics;
using TestGame.Huds;
using TestGame.Managers;
using TestGame.Objects.Monsters;
using TestGame.Objects.Particles;
using TestGame.Objects.PlayerLogic;
using TestGame.Objects.Towers;

namespace TestGame.Objects.Soldiers
{
    public class Soldier : Creature
    {

        private int range = 64;
        public int damage = 1;
        private TimeSpan healTimer; 
        protected TimeSpan healRate = new TimeSpan(0, 0, 0, 0, 250);
        public Tower spawnTower;
        public Vector2 stationedPos;
        public int soldierID;
        public bool inPos = false;
        public Monster Target;

        public string name = "Soldier";
        private TimeSpan despawnTimer = new TimeSpan(0, 0, 0, 20, 0), timeSinceLastDamage, regainDelay = new TimeSpan(0, 0, 0, 1, 100);
        public bool despawn = false, selfRegain = true;
        public Soldier(int x, int y, Sprite spriteTexture = null, int width = 22, int height = 22) : base(width, height)
        {
            baseHp = 10;
            hp = baseHp;

            X = x;
            Y = y;
            LeaveCorpse = true;
            haveShadow = true;
            if (spriteTexture != null)
            {
                sprite = spriteTexture;
            }
            else
            {
                sprite = new Sprite(Textures.soldier);
            }
            string[] lines = System.IO.File.ReadAllLines("Saves/maleNames.txt");
            name = lines[new Random().Next(0, lines.Length - 1)];

        }
        public override void takeDamage(int damageGiven, Game1 g, Damagetype damagetype = Damagetype.Normal)
        {
            base.takeDamage(damageGiven, g, damagetype);
            timeSinceLastDamage = new TimeSpan();
        }

        public void setOffset(int spawnTowerCapacity)
        {
            if (spawnTowerCapacity == 1)
            {
                xOffset = 0;
                yOffset = 0;
            }
            else if (spawnTowerCapacity != 0)
            {
                xOffset = 18 * (float)Math.Cos(Math.PI * 2 * soldierID / spawnTowerCapacity);
                yOffset = 18 * (float)Math.Sin(Math.PI * 2 * soldierID / spawnTowerCapacity);
            }
        }
        protected Vector2 getTargetPos()
        {
            Vector2 targetPos;
            if (spawnTower == null) { targetPos = stationedPos; }
            else { targetPos = spawnTower.targetPos; }
            targetPos += new Vector2(xOffset, yOffset);
            return targetPos;
        }
        protected virtual void Move(Game1 g)
        {
            Move(g, Target.GetPosCenter().X, Target.GetPosCenter().Y);
        }
        protected virtual void SearchingForTarget(GameTime gt, Game1 g)
        {
            if (selfRegain && hp < baseHp)
            {
                if (timeSinceLastDamage >= regainDelay)
                {
                    if (healTimer >= healRate)
                    {
                        if (spawnTower != null && g.levelMap.playerData.starUpgrades["BARRACKS1"])
                        {
                            hp += baseHp / 18;
                        }
                        else
                        {
                            hp += baseHp / 35;
                        }

                        hp = Math.Min(hp, baseHp);
                        healTimer = new TimeSpan();
                    }
                    else
                    {
                        healTimer += gt.ElapsedGameTime;
                    }
                }
                else
                {
                    timeSinceLastDamage += gt.ElapsedGameTime;
                }
            }
            findNewTarget(g);
        }
        public override void Update(GameTime gt, Game1 g)
        {
            if (despawn)
            {
                despawnTimer -= gt.ElapsedGameTime;
                if (despawnTimer.TotalMilliseconds <= 0)
                {
                    deSpawn(g);
                    return;
                }
            }
            //If not is pos -> need to walk into pos
            if (!inPos)
            {
                if (Target != null)
                {
                    Target.waitingForCombat = false;
                    Target.fighting = null;
                    Target = null;
                }
                Vector2 targetPos = getTargetPos();

                Move(g, targetPos.X - Width / 2, targetPos.Y - Height / 2);
                checkTargetPosCollision(g);
                return;
            }
            // inPos: true, if no enemy -> try and find enemy
            if (Target == null)
            {
                SearchingForTarget(gt, g);
                return;
            }
            // in pos: true, Have a target, if not waiting for combat -> start combat
            if (!Target.waitingForCombat)
            {
                if (attackTimer >= attackSpeed)
                {
                    attackTarget(g);
                }
                else
                {
                    attackTimer += gt.ElapsedGameTime;
                    attackAnimation(g);
                }
                if (Target == null || Target.hp <= 0)
                {
                    inPos = false;
                    Target = null;
                    return;
                }
                return;
            }
            // in pos: true, Have a target, but not in combat pos -> move towards target    
            Move(g);
            checkTargetCollision(g);
        }
        protected virtual void attackTarget(Game1 g){
            Target.takeDamage(this.damage, g);
            attackTimer = new TimeSpan();
            haveAttacked = true;
        }
        
        protected override void die(Game1 g)
        {
            deathSound.play(g);
            g.pageGame.getObjectManager().Add(new Corps(this, this.sprite, directionFacing: FacingRight), g);
            deSpawn(g);
        }
        protected virtual void deSpawn(Game1 g)
        {
            if (hp > 0) { hp = 0; }
            if(Target!= null)
            {
                Target.waitingForCombat = false;
                Target.fighting = null;
            }
            Target = null;
            inPos = false;

            g.pageGame.getObjectManager().Remove(this, g);
            if (g.pageGame.getHudManager().activeObject == this)
            {
                g.pageGame.getHudManager().closeActiveObject(g);
            }
        }
       
  
        protected bool findNewTarget(Game1 g)
        {
            Vector2 targetPos = getTargetPos();
            List<GameObject> newTargets = g.pageGame.getObjectManager().GetAllObjectsWith(p =>
                p is Monster &&
                !((Monster)p).waitingForCombat &&
                ((Monster)p).fighting == null &&
                p.DistanceTo(targetPos) < range
               );
            if (newTargets.Count != 0)
            {
                Target = (Monster)newTargets[0];
                Target.waitingForCombat = true;
                Target.fighting = this;
                return true;
            }
            Target = null;
            return false;
        }
        protected virtual void checkTargetPosCollision(Game1 g)
        {
            Vector2 targetPos = getTargetPos();
            if (Vector2.Distance(GetPosCenter(), targetPos) <= 5)
            {
                hitPos(g);
            }
        }
        protected void checkTargetCollision(Game1 g)
        {
            if (Target.hp <= 0)
            {
                if (!findNewTarget(g))
                {
                    inPos = false;
                }
            }
            else if (g.pageGame.getObjectManager().FromToDir(this, Target).Length() <= Width / 2 + Target.Width / 2)
            {
                hitTarget(g);
            }
        }
        public override void Destroy(Game1 g)
        {
            base.Destroy(g);
            g.pageGame.mouseManager.Remove(this);
            if(spawnTower != null)
            {
                spawnTower.soldiers.Remove(this);
            }
            if (Target != null)
            {
                Target.waitingForCombat = false;
                Target.fighting = null;
            }
        }
        protected void hitPos(Game1 g)
        {
            inPos = true;
        }
        protected void hitTarget(Game1 g)
        {
            if(Target.X + Target.Width/2 > X + Width / 2)
            {
                //Target to the right, soldier to the left
                X = Target.X - Width;
                FacingRight = 1;
            }
            else
            {//Target to the left, soldier to the right
                X = Target.X + Target.Width;
                FacingRight = -1;
            }
            Y = Target.Y + Target.Height - Height;
            Target.FacingRight = FacingRight * -1;
            Target.waitingForCombat = false;
            haveAttacked = false;
        }
        
        public Sprite getSprite()
        {
            return sprite;
        }     
    }
}

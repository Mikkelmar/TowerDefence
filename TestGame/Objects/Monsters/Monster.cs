using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TestGame.Graphics;
using TestGame.Huds;
using TestGame.Managers;
using TestGame.Objects.Particles;
using TestGame.Objects.PlayerLogic;
using TestGame.Objects.Soldiers;
using TestGame.Objects.StatusEffects;
using TestGame.Pages;

namespace TestGame.Objects.Monsters
{
    public abstract class Monster : Creature
    {
        public int damage = 1;
        public float baseSpeed, distance = 0;
        public Path path;
        public string name, description = "";
        public bool waitingForCombat = false;
        public Soldier fighting = null;
        private List<StatusEffect> statusEffects = new List<StatusEffect>();
        
        
        
        private bool useOffset;
        public Monster(Path path, int startDistance = 0, bool useOffset=true, int width=32, int height=32) : base(width, height)
        {
            this.path = path;
            distance = startDistance;
            this.useOffset = useOffset;
        }

        public override void Init(Game1 g)
        {
            base.Init(g);
            baseHp = hp;
            baseSpeed = Speed;
            if (useOffset)
            {
                int maxSize = g.pageGame.sceneManager.GetScene().pathSize(path);
                Random random = new Random();

                xOffset = (float)(random.Next((int)Math.Max((maxSize-Width), 0)) - Math.Max(maxSize - Width, 0)*0.5);
                yOffset = (float)(random.Next((int)Math.Max((maxSize - Height), 0)) - Math.Max(maxSize - Height, 0) * 0.5);
            }
        }
        private void resetToDefaultState()
        {
            Speed = baseSpeed;
        }
        private void TriggerStatusEffects(GameTime gt, Game1 g)
        {
            resetToDefaultState();
            List<StatusEffect> effects = new List<StatusEffect>(statusEffects);
            foreach (StatusEffect effect in effects)
            {
                effect.Affect(this, gt.ElapsedGameTime, g);
            }
        }
        
        protected virtual void Fight(GameTime gt, Game1 g)
        {
            if (waitingForCombat)
            {
                haveAttacked = false;
                return;
            }
            if (fighting == null || fighting.hp <= 0)
            {
                fighting = null;
                waitingForCombat = false;
            }
            if (attackTimer >= attackSpeed)
            {
                fighting.takeDamage(attackDamage, g);
                attackTimer = new TimeSpan();
                haveAttacked = true;
            }
            else
            {
                attackTimer += gt.ElapsedGameTime;
                attackAnimation(g);
            }
        }
        public override void Update(GameTime gt, Game1 g)
        {
            TriggerStatusEffects(gt, g);
            if(fighting != null)
            {
                Fight(gt, g);
                return;
            }
            distance += Drawing.delta * Speed;
            Vector2 newPos = path.GetPos(distance);
            if(newPos.X + xOffset - (Width / 2) > X)
            {
                FacingRight = 1;
            }else if (newPos.X + xOffset - (Width / 2) < X)
            {
                FacingRight = -1;
            }
            SetPosition(newPos.X + xOffset - (Width / 2), newPos.Y + yOffset - Height);
            if (path.inGoal(distance))
            {
                g.pageGame.sceneManager.GetScene().inGoal(g, this);

            }

        }
        protected override void die(Game1 g)
        {
            if (LeaveCorpse)
            {
                g.pageGame.getObjectManager().Add(new Corps(this, this.sprite, directionFacing: FacingRight), g);
            }
            g.pageGame.monsterHandler.alertMonsterDied(g, this);
            g.pageGame.player.money += reward;
            statusEffects.Clear();
            g.pageGame.getObjectManager().Remove(this, g);
            deathSound.play(g);
            if (g.pageGame.getHudManager().activeObject == this)
            {
                g.pageGame.getHudManager().closeActiveObject(g);
            }
        }

        protected void SpawnDust(Game1 g)
        {
            for (int i = 0; i < 5; i++)
            {
                Vector2 spawnPos = this.GetPosCenter();
                spawnPos.X += Width / 3 * (float)Math.Cos(Math.PI * 2 * i / 5);
                spawnPos.Y += Height / 3 * (float)Math.Sin(Math.PI * 2 * i / 5);
                g.pageGame.getObjectManager().Add(new DustParticles(
                    spawnPos, 
                    new Random().Next(10) + 16+i*6, 
                    totMiliseconds: 300+ new Random().Next(10)*35), g);
            }
        }
        
        public void RemoveStatusEffect(StatusEffect effect)
        {
            statusEffects.Remove(effect);
        }
        public void GiveStatusEffect(StatusEffect effect)
        {
            if (BeingEffectedBy(effect.Name))
            {
                foreach (StatusEffect e in statusEffects) {
                    if(e.Name.Equals(effect.Name)){
                        if(e.Duration < effect.Duration){
                            e.Duration = effect.Duration;
                        }
                    }
                }
            }
            else
            {
                statusEffects.Add(effect);
            }   
        }
        public Sprite getSprite()
        {
            return sprite;
        }
        public virtual bool canBeAffactedBy(string effect)
        {
            return !BeingEffectedBy(effect);
        }
        public bool BeingEffectedBy(string effect)
        {
            
            foreach (StatusEffect e in statusEffects)
            {
                if (e.Name.Equals(effect))
                {
                    return true;
                }
            }
            return false;
        }
        private StatusEffect GetEffect(string effect)
        {
            foreach (StatusEffect e in statusEffects)
            {
                if (e.Name.Equals(effect))
                {
                    return e;
                }
            }
            return null;
        }
        
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;
using TestGame.Managers;
using TestGame.Objects.Monsters;
using TestGame.Objects.Projectile;

namespace TestGame.Objects.Towers.NectoTowers
{
    public class NecroTower : Tower
    {
        protected static Sound attackSound = new Sound(Sounds.shoot_1, 0.5f, SoundManager.types.Tower);
        protected static Sound beamSound = new Sound(Sounds.beam, 0.5f, SoundManager.types.Tower),
            beamChargeSound = new Sound(Sounds.beamCharge, 0.5f, SoundManager.types.Tower);
        private SoundEffectInstance beamsound = Sounds.beam.CreateInstance();
        protected int maxCharge = 10, beamDamage;
        public float charge = 0;
        protected bool beamMode = false, chargeing = false, waitingForTarget=true;
        protected float drainRate;
        private Monster currentTarget;
        private TimeSpan chargeTime = TimeSpan.FromMilliseconds(900);
        protected TimeSpan currentTime = new TimeSpan();
        protected TimeSpan tickDamageRate;
        
        public NecroTower(int x, int y) : base(x, y) {
            name = "Necro Tower";
            this.damage = 3;
            beamDamage = 4;
            drainRate = 0.5f;
            this.reloadTimer = new TimeSpan(0, 0, 0, 0, 850);
            this.range = 130;
            tickDamageRate = TimeSpan.FromMilliseconds(100);
            cost = 70;
            sprite = new Sprite(Textures.necroTower_1);
            optionsID = new List<int>() { 27 };
            description = "Slow fire spreed. Enemies who die whitin this towers range fuels its power into a deadly beam";

        }
        public virtual void OnMonsterDie(Monster monster, Game1 g, EventArgs eventArgs)
        {
            if (beamMode && !g.levelMap.playerData.starUpgrades["NECRO3"]) 
            {
                return;
            }
            if(monster.DistanceTo(position) <= range)
            {
                if (g.levelMap.playerData.starUpgrades["NECRO0"])
                {
                    gainCharge(g, monster.damage);
                }
                else
                {
                    gainCharge(g);
                }
            }
        }
        protected void gainCharge(Game1 g, int ammount = 1)
        {
            charge += ammount;
            charge = Math.Min(charge, maxCharge);
            if (charge >= maxCharge)
            {
                //currentTime = new TimeSpan();
                if (!beamMode)
                {
                    beamChargeSound.play(g);
                    chargeing = true;
                }
                beamMode = true;
            }
        }
        public override void Buy(Game1 g, Tower tower)
        {
            if(tower is NecroTower)
            {
                (tower as NecroTower).charge = charge;
            }
            base.Buy(g, tower);
        }
        protected virtual void chargeBeam()
        {
            if (currentTime >= chargeTime)
            {
                currentTime = new TimeSpan();
                chargeing = false;
            }
        }
        protected virtual void useBeam(Game1 g)
        {
            currentTime = new TimeSpan();
            Monster bestTarget;
            if (currentTarget != null && currentTarget.hp > 0 && Vector2.Distance(currentTarget.position, position) <= range)
            {
                bestTarget = currentTarget;
            }
            else
            {
                bestTarget = findMonster(g);
            }
            
            if (bestTarget != null)
            {
                currentTarget = bestTarget;
                beamTarget(g, currentTarget);
                if (waitingForTarget)
                {
                    beamsound.Volume = 0.1f;
                    g.soundManager.playLooped(beamsound);
                    waitingForTarget = false;
                }
            }
            else if (waitingForTarget)
            {
                return;
            }
            else
            {
                if (g.levelMap.playerData.starUpgrades["NECRO1"])
                {
                    beamMode = false;
                    g.soundManager.stopLooped(beamsound);
                    waitingForTarget = true;
                }
                currentTarget = null;

            }

            charge -= drainRate;
            if (charge <= 0)
            {
                charge = 0;
                beamMode = false;
                g.soundManager.stopLooped(beamsound);
                waitingForTarget = true;
            }
        }
        public override void Update(GameTime gt, Game1 g)
        {
            
            if (beamMode)
            {
                //BEAM
                currentTime += gt.ElapsedGameTime;
                if (chargeing)
                {
                    chargeBeam();
                }else if (currentTime >= tickDamageRate)
                {
                    useBeam(g);
                }
            }
            else
            {
                base.Update(gt, g);
            }
            
            
        }
        protected virtual void beamTarget(Game1 g, Monster target)
        {
            target.takeDamage(beamDamage, g, Monster.Damagetype.Magic);
        }
        protected override void fire(Game1 g, Monster target)
        {
            attackSound.play(g);
            target.takeDamage(damage, g, Monster.Damagetype.Magic);
            Vector2 pos = target.GetPosCenter();
            g.pageGame.getObjectManager().Add(new SoulOrb((int)pos.X, (int)pos.Y, this), g);
            //target.takeDamage(this.damage, g);
        }
        public override void Init(Game1 g)
        {
            base.Init(g);
            g.pageGame.monsterHandler.monsterDied += OnMonsterDie;
        }
        public override void Destroy(Game1 g)
        {
            base.Destroy(g);
            g.soundManager.stopLooped(beamsound);
            g.pageGame.monsterHandler.monsterDied -= OnMonsterDie;
            beamsound.Stop();
        }
        protected virtual Texture2D getBeamSprite()
        {
            return Textures.beam;
        }
        protected virtual Texture2D getChargeTexture()
        {
            return Textures.LightgreenShadow;
        }

        public override Tower LoadUpgrades(Game1 g)
        {
            if (g.levelMap.playerData.starUpgrades["NECRO2"])
            {
                range += (int)(range * 0.1f);
            }
            if (g.levelMap.playerData.starUpgrades["NECRO4"])
            {
                drainRate   *= .5f;
            }
            return base.LoadUpgrades(g);
        }
        public override void Draw(Game1 g)
        {
            base.Draw(g);
            if (beamMode && currentTarget != null && !chargeing && !waitingForTarget)
            {
                Vector2 beamStartPos = GetPosCenter();
                beamStartPos.Y -= 16;
                Drawing.DrawLine(getBeamSprite(), beamStartPos, currentTarget.GetPosCenter());
            }
            if(charge != 0)
            {
                Vector2 beamStartPos = GetPosCenter();
                beamStartPos.Y -= 20+ (int)((charge / (double)maxCharge) * 16);
                beamStartPos.X -= (int)((charge / (double)maxCharge) * 16);
                new Sprite(getChargeTexture()).Draw(beamStartPos, width: (int)((charge / (double)maxCharge)*32), height: (int)((charge / (double)maxCharge) * 32), layerDepth: this.depth * 0.1f);
            }
            if (maxCharge != 0 && charge != maxCharge)
            {
                Drawing.FillRect(new Rectangle((int)X+16, (int)Y - 16, 32, 12), Color.Gray, this.depth, g);
                Drawing.FillRect(new Rectangle((int)X + 16, (int)Y - 16, (int)(32 * (charge / (double)maxCharge)), 12), Color.ForestGreen, this.depth - this.depth * 0.2f, g);
            }
        }
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;
using TestGame.Managers;
using TestGame.Objects.Monsters;
using TestGame.Objects.Projectile;
using TestGame.Objects.Soldiers;
using TestGame.Objects.StatusEffects;
using TestGame.Objects.Towers.TowerPowers;

namespace TestGame.Objects.Towers.NectoTowers
{
    public class NecroTower_Beam : NecroTower
    {

        public NecroTower_Beam(int x, int y) : base(x, y) {
            name = "Tower of skulls";
            this.damage = 0;
            beamDamage = 4;
            this.reloadTimer = new TimeSpan(0, 0, 0, 0, 1);
            this.range = 155;
            drainRate = 1f;
            maxCharge = 10;
            cost = 300;
            sprite = new Sprite(Textures.necroTower_purple);
            optionsID = new List<int>() {  };
            powers = new List<TowerPower>() {
                new TowerPower {
                    name = "Drain soul",
                    desc="Slow down beaming targets",
                    color = Color.LightGreen,
                    cost=100,
                    icon = new Sprite(Textures.chaineDown),
                    nextTier = new TowerPower {
                    name = "Drain soul II",
                    desc="Greater slow",
                    color = Color.LightGreen,
                    cost=75,
                    icon = new Sprite(Textures.chaineDown),
                    }
                },new TowerPower {
                    name = "Raise dead",
                    desc="Raise the undead to fight for you",
                    color = Color.Wheat,
                    cost=125,
                    icon = new Sprite(Textures.skeleton),
                    nextTier = new TowerPower {
                    name = "Raise dead II",
                    desc="Raise more dead",
                    color = Color.Wheat,
                    cost=80,
                    icon = new Sprite(Textures.skeleton),
                    }
                }
            };

        }
        protected override void beamTarget(Game1 g, Monster target)
        {
            base.beamTarget(g, target);
            if (powers[0].stage > 0)
            {
                StatusEffect e = new Slow(.5f- (powers[0].stage-1)*.3f, tickDamageRate * 2);
                if (target.canBeAffactedBy(e.Name))
                {
                    if (!target.BeingEffectedBy(e.Name))
                    {
                        //g.pageGame.getObjectManager().Add(new BurningEffect(Target.GetPosCenter(), Target),g);
                    }
                    target.GiveStatusEffect(e);
                }

            }
        }
        protected override Texture2D getBeamSprite()
        {
            return Textures.beamPurple;
        }
        protected override Texture2D getChargeTexture()
        {
            return Textures.PurpleShadow;
        }
        public override void OnMonsterDie(Monster monster, Game1 g, EventArgs eventArgs)
        {
            
            if (monster.DistanceTo(position) <= range)
            {
                if (powers[1].stage > 0)
                {
                    if(new Random().Next(100) <= 20 + (powers[1].stage-1)*13)
                    {
                        SkeletonSoldier sSoldier = new SkeletonSoldier((int)(monster.X+ monster.Width/2), (int)(monster.Y + monster.Height / 2));
                        sSoldier.FacingRight = monster.FacingRight;
                        sSoldier.inPos = true;
                        g.pageGame.getObjectManager().Add(sSoldier, g);
                    }
                    
                }
                if (beamMode && !g.levelMap.playerData.starUpgrades["NECRO3"])
                {
                    return;
                }
                if (g.levelMap.playerData.starUpgrades["NECRO0"])
                {
                    gainCharge(g, monster.damage);
                }
                else
                {
                    gainCharge(g);
                }
            }
            
            //base.OnMonsterDie(monster, g, eventArgs);
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
                }
                else if (currentTime >= tickDamageRate)
                {
                    useBeam(g);
                }
            }
            else
            {
                currentTime += gt.ElapsedGameTime;
                if (currentTime.TotalMilliseconds >= 200)
                {
                    currentTime = new TimeSpan();
                    gainCharge(g, 1);
                }
            }
        }

    }
}

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;
using TestGame.Objects.Monsters;
using TestGame.Objects.Particles;
using TestGame.Objects.Projectile;
using TestGame.Objects.StatusEffects;
using TestGame.Objects.Towers.TowerPowers;

namespace TestGame.Objects.Towers
{
    public class ElectroTower : BombTower
    {
        public ElectroTower(int x, int y) : base(x, y)
        {
            name = "Electro tower";
            this.damage = 5;
            this.reloadTimer = new TimeSpan(0, 0, 0, 3, 0);
            this.range = 125;
            cost = 300;
            sprite = new Sprite(Textures.tower_electro);
            optionsID = new List<int>() {  };
            powers = new List<TowerPower>() {
                new TowerPower {
                    name = "9000 VOLT",
                    desc="Your attacks Ignores all forms of armour",
                    cost=150,
                    icon = new Sprite(Textures.destroyedArmour),
                    color = Color.Cyan
                },
                new TowerPower {
                    name = "Overcharge",
                    desc="5% to stun each target hit",
                    cost=300,
                    icon = new Sprite(Textures.stunIcon),
                    color = Color.Yellow,
                    nextTier =new TowerPower {
                        name = "Overcharge II",
                        desc="7% to stun each target hit, for longer duration",
                        cost=100,
                        icon = new Sprite(Textures.stunIcon),
                        nextTier =new TowerPower {
                            name = "Overcharge III",
                            desc="9% to stun each target hit, for even longer duration",
                            cost=100,
                            icon = new Sprite(Textures.stunIcon)
                        }
                    }
                }
            };

        }
        public override void Update(GameTime gt, Game1 g)
        {
            base.Update(gt, g);
        }
        protected override void fire(Game1 g, Monster target)
        {
            Monster.Damagetype damageType = Monster.Damagetype.Normal;
            if (powers[0].stage > 0)
            {
                damageType = Monster.Damagetype.None;
            }
            
            foreach (Monster m in g.pageGame.getObjectManager().GetMonsters()
                .FindAll(m => (int)g.pageGame.getObjectManager().FromToDir(this, m).Length() <= range))
            {
                m.takeDamage(damage, g, damageType);
                if(powers[1].stage > 0)
                {
                    if(new Random().Next(100) <= 3+(2* powers[1].stage)){
                        StatusEffect e = new Slow(0f, TimeSpan.FromMilliseconds(400+(100* powers[1].stage)));
                        if (m.canBeAffactedBy(e.Name))
                        {
                            if (!m.BeingEffectedBy(e.Name))
                            {
                                //g.pageGame.getObjectManager().Add(new BurningEffect(Target.GetPosCenter(), Target),g);
                            }
                            m.GiveStatusEffect(e);
                        }
                        
                    }
                    
                }
            }
            new ShockwaveParticle(GetPosCenter(), TimeSpan.FromMilliseconds(200), range*2).Spawn(g);
        }
    }
}

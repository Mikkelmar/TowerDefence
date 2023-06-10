using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;
using TestGame.Objects.Monsters;
using TestGame.Objects.Projectile;
using TestGame.Objects.StatusEffects;
using TestGame.Objects.Towers.TowerPowers;

namespace TestGame.Objects.Towers
{
    public class ChaosTower_Ultimate : ChaosTower
    {
        private int weakness = 0, orbSpeed = 0;
        public ChaosTower_Ultimate(int x, int y) : base(x, y) {
            name = "Controlled Chaos";
            this.damage = 12;
            this.range = 200;
            cost = 300;
            sprite = new Sprite(Textures.chaosTower_fantasy);
            optionsID = new List<int>() {  };
            orb = new ChaosBall(-1, -64, this, size: 14, speed: 350f);
            powers = new List<TowerPower>() {
                new TowerPower {
                    name = "Cursed orb",
                    desc="Your orb afflicts the target with Weakness, they take 50% more dmg",
                    cost=300,
                    color = Color.Purple,
                    icon = new Sprite(Textures.scroll),
                    nextTier =  new TowerPower {
                        name = "Cursed orb II",
                        desc="Your orb afflicts the target with Weakness, they take 75% more dmg",
                        cost=150,
                        icon = new Sprite(Textures.scroll),
                        nextTier = new TowerPower {
                            name = "Cursed orb III",
                            desc="Your orb afflicts the target with Weakness, they take 100% more dmg",
                            cost=150,
                            icon = new Sprite(Textures.scroll),
                        }
                    }
                },
                new TowerPower {
                    name = "Shadow stalk",
                    desc="Incress orb speed and damage",
                    cost=150,
                    color = Color.DarkRed,
                    icon = new Sprite(Textures.redStaff),
                    nextTier = new TowerPower {
                            name = "Shadow stalk II",
                            desc="Incress orb speed and damage",
                            cost=150,
                            icon = new Sprite(Textures.redStaff),
                        }
                }
            };
        }
        public override void Update(GameTime gt, Game1 g)
        {
            base.Update(gt, g);
            if (powers[0].stage > weakness)
            {
                weakness++;
                orb.afflict = new Weakness((1.25f+weakness*.25f), TimeSpan.FromSeconds(5));
            }
            if (powers[1].stage > orbSpeed)
            {
                orbSpeed++;
                orb.baseSpeed += 100;
                damage++;
                orb.Damage++;
            }
        }
    }

}

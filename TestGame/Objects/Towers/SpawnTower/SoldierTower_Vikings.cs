using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using TestGame.Graphics;
using TestGame.Objects.Monsters;
using TestGame.Objects.Soldiers;
using TestGame.Objects.Towers.TowerPowers;

namespace TestGame.Objects.Towers.SpawnTower
{
    public class SoldierTower_Vikings : SoldierTower
    {
  
        public SoldierTower_Vikings(int x, int y) : base(x, y) {
            name = "Viking fort";
            this.damage = 7;
            this.spawnTimer = new TimeSpan(0, 0, 0, 1, 200);
            this.range = 140;
            capacity = 4;
            cost = 300;
            sprite = new Sprite(Textures.vikingHouse);
            optionsID = new List<int>() {  };
            canSelectTarget = true;
            targetPos = new Vector2(x,y-64);
            powers = new List<TowerPower>() {
                new TowerPower {
                    name = "Strength in numbers",
                    desc="Max 5 vikings",
                    color = Color.LightGreen,
                    cost=75,
                    icon = new Sprite(Textures.viking),
                    nextTier = new TowerPower {
                        name = "Strength in numbers",
                        desc="Max 5 vikings",
                        color = Color.LightGreen,
                        cost=75,
                        icon = new Sprite(Textures.viking),
                    }
                },new TowerPower {
                    name = "Axe throw",
                    desc="Starts throwing axes",
                    color = Color.LightGreen,
                    cost=100,
                    icon = new Sprite(Textures.iconsSheet, new Rectangle(16 * 15, 16 * 1, 16, 16))
                }
            };

        }
        protected override void alertBuy(Game1 g, TowerPower tp)
        {
            if(powers.IndexOf(tp) == 0)
            {
                capacity++;
                foreach (Viking viking in soldiers)
                {
                    if(viking.Target == null)
                    {
                        viking.inPos = false;
                    }
                    viking.setOffset(this.capacity);
                }
                spawnMinion(g);
            }
            if (powers.IndexOf(tp) == 1)
            {
                foreach(Viking viking in soldiers)
                {
                    viking.canThrowAxe = true;
                }
            }
        }
        protected override Soldier getMinion()
        {
            Viking soldier = new Viking((int)GetPosCenter().X, (int)GetPosCenter().Y, spriteTexture: new Sprite(Textures.viking));
            if(powers[1].stage == 1)
            {
                soldier.canThrowAxe = true;
            }
            soldier.Width = 28;
            soldier.Height = 28;
            soldier.attackSpeed = TimeSpan.FromMilliseconds(550);
            soldier.baseHp += 16;
            soldier.hp = soldier.baseHp;
            soldier.damage = damage;
            soldier.armor = Creature.AmourLevels.None;
            return soldier;
        }
        



    }
}

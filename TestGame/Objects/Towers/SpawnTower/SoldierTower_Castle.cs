using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using TestGame.Graphics;
using TestGame.Objects.Monsters;
using TestGame.Objects.Soldiers;
using TestGame.Objects.Towers.TowerPowers;

namespace TestGame.Objects.Towers.SpawnTower
{
    public class SoldierTower_Castle : SoldierTower
    {
  
        public SoldierTower_Castle(int x, int y) : base(x, y) {
            name = "Knight Castle";
            this.damage = 6;
            this.spawnTimer = new TimeSpan(0, 0, 0, 2, 400);
            this.range = 140;
            capacity = 3;
            cost = 300;
            sprite = new Sprite(Textures.castle);
            optionsID = new List<int>() {  };
            canSelectTarget = true;
            targetPos = new Vector2(x,y-64);
            powers = new List<TowerPower>() {
                new TowerPower {
                    name = "Crusade",
                    desc="The knighs can travel far away",
                    color = Color.LightGreen,
                    cost=100,
                    icon = new Sprite(Textures.warrior)
                },new TowerPower {
                    name = "Heavy plates",
                    desc="Upgrades the night's armour",
                    color = Color.LightGreen,
                    cost=80,
                    icon = new Sprite(Textures.gold)
                }
            };

        }
        protected override void alertBuy(Game1 g, TowerPower tp)
        {
            if(powers.IndexOf(tp) == 0)
            {
                this.range += 200; 
            }
            else if (powers.IndexOf(tp) == 1)
            {
                foreach(Knight knight in soldiers)
                {
                    knight.armor = Creature.AmourLevels.High;
                    knight.setSprite(new Sprite(Textures.knight_armour));
                }
            }
        }
        protected override Soldier getMinion()
        {
            Knight soldier = new Knight((int)GetPosCenter().X, (int)GetPosCenter().Y, spriteTexture: new Sprite(Textures.knight));
            if(powers[1].stage == 1)
            {
                soldier.armor = Creature.AmourLevels.High;
                soldier.setSprite(new Sprite(Textures.knight_armour));
            }
            else
            {
                soldier.armor = Creature.AmourLevels.Medium;
            }
            soldier.Width = 26;
            soldier.Height = 26;
            soldier.attackSpeed = TimeSpan.FromMilliseconds(800);
            soldier.baseHp += 30;
            soldier.hp = soldier.baseHp;
            soldier.damage = damage;
            return soldier;
        }
        



    }
}

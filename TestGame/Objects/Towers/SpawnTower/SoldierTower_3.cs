using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TestGame.Graphics;
using TestGame.Managers;
using TestGame.Objects.Monsters;
using TestGame.Objects.Projectile;
using TestGame.Objects.Soldiers;
using TestGame.Objects.StatusEffects;

namespace TestGame.Objects.Towers.SpawnTower
{
    public class SoldierTower_3 : SoldierTower
    {
  
        public SoldierTower_3(int x, int y) : base(x, y) {
            name = "Soldier tower 3";
            this.damage = 5;
            this.spawnTimer = new TimeSpan(0, 0, 0, 2, 300);
            this.range = 140;
            capacity = 3;
            cost = 180;
            sprite = new Sprite(Textures.bracketTower_3);
            optionsID = new List<int>() { 34, 35 };
            canSelectTarget = true;
            targetPos = new Vector2(x,y-64);

        }
        protected override Soldier getMinion()
        {
            Soldier soldier = new Soldier((int)GetPosCenter().X, (int)GetPosCenter().Y, spriteTexture: new Sprite(Textures.soldier_3));
            soldier.baseHp += 20;
            soldier.hp = soldier.baseHp;
            soldier.damage = damage;
            soldier.armor = Creature.AmourLevels.Medium;
            return soldier;
        }
        



    }
}

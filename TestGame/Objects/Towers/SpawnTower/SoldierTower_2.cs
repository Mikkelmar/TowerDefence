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
    public class SoldierTower_2 : SoldierTower
    {
  
        public SoldierTower_2(int x, int y) : base(x, y) {
            name = "Soldier tower 2";
            this.damage = 3;
            this.spawnTimer = new TimeSpan(0, 0, 0, 2, 550);
            this.range = 130;
            capacity = 3;
            cost = 120;
            sprite = new Sprite(Textures.bracketTower_2);
            optionsID = new List<int>() { 33 };
            canSelectTarget = true;
            targetPos = new Vector2(x,y-64);

        }
        protected override Soldier getMinion()
        {
            Soldier soldier = new Soldier((int)GetPosCenter().X, (int)GetPosCenter().Y, spriteTexture: new Sprite(Textures.soldier_2))
            {
                armor = Creature.AmourLevels.Low,
                damage = damage
            };
            soldier.baseHp += 5;
            soldier.hp = soldier.baseHp;
            return soldier;
        }
        



    }
}

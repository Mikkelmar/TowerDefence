using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using TestGame.Graphics;
using TestGame.Managers;
using TestGame.Objects.Monsters;
using TestGame.Objects.Soldiers;

namespace TestGame.Objects.Towers.SpawnTower
{
    public class SoldierTower : Tower
    {
        
        public SoldierTower(int x, int y) : base(x, y) {
            name = "Soldier tower";
            this.damage = 1;
            this.spawnTimer = new TimeSpan(0, 0, 0, 2, 800);
            this.range = 120;
            capacity = 3;
            cost = 60;
            sprite = new Sprite(Textures.bracketTower);
            optionsID = new List<int>() { 32 };
            canSelectTarget = true;
        }
        
        public override void Init(Game1 g)
        {
            base.Init(g);
            for (int i= 0;i < capacity; i++)
            {
                spawnMinion(g);
            }     
        }
        
      
        public override void Update(GameTime gt, Game1 g)
        {
            updateMinionSpawn(gt, g);
        }
        protected override void fire(Game1 g, Monster target)
        {
            //throw new NotImplementedException();
        }
        public override Tower LoadUpgrades(Game1 g)
        {
            if (g.levelMap.playerData.starUpgrades["BARRACKS0"])
            {
                damage += 1;
            }
            if (g.levelMap.playerData.starUpgrades["BARRACKS3"])
            {
                spawnTimer -= TimeSpan.FromMilliseconds(200);
            }
            if (g.levelMap.playerData.starUpgrades["BARRACKS4"])
            {
                capacity++;
            }

            return base.LoadUpgrades(g);
        }

    }
}

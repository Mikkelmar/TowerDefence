using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;
using TestGame.Objects.Monsters;
using TestGame.Objects.PlayerLogic;
using TestGame.Objects.Projectile;
using TestGame.Objects.Towers.TowerPowers;

namespace TestGame.Objects.Towers
{
    public class BombTower_Missile : BombTower
    {
        private List<Missile> missiles = new List<Missile>();
        public BombTower_Missile(int x, int y) : base(x, y)
        {
            name = "Missile Luncher";
            this.damage = 16;
            this.reloadTimer = new TimeSpan(0, 0, 0, 0, 1500);
            this.range = 180;
            cost = 325;
            sprite = new Sprite(Textures.bombTower_missile);
            optionsID = new List<int>() { };
            powers = new List<TowerPower>() {
                new TowerPower {
                    name = "Missile",
                    desc="Fire a homing missile",
                    cost=250,
                    icon = new Sprite(Textures.bomb)
                },
                new TowerPower {
                    name = "Oil spill",
                    desc="Gain oil power",
                    cost=300,
                    icon = new Sprite(Textures.oil)
                }
            };
        }
        protected override void alertBuy(Game1 g, TowerPower tp)
        {
            if (powers.IndexOf(tp) == 1)
            {
                g.pageGame.player.AddPlayerPower(g, new PlayerPower_FireOil(200, 600));
            }
        }
        public override void Update(GameTime gt, Game1 g)
        {
            base.Update(gt, g);
            if(powers[0].stage > 0)
            {
                if(missiles.Count < 1)
                {
                    Missile createdMissile = new Missile((int)X, (int)Y, this);
                    g.pageGame.getObjectManager().Add(createdMissile);
                    missiles.Add(createdMissile);
                }
            }
        }
        public void removeMissile(Missile createdMissile) 
        {
            missiles.Remove(createdMissile);
        }

        protected override void fire(Game1 g, Monster target)
        {
            g.pageGame.getObjectManager().Add(new Bomb((int)GetPosCenter().X, (int)GetPosCenter().Y, target, this));
        }
    }
}

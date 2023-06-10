using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;

namespace TestGame.Objects.Towers.TowerPowers
{
    public class TowerPower
    {
        public int cost;
        public string name, desc;
        public Sprite icon;
        public TowerPower nextTier;
        public int stage = 0;
        private bool canUpgrade = true;
        public TimeSpan coolDown;
        public Color color = Color.White;
        public TowerPower(TowerPower nextTier = null)
        {
            this.nextTier = nextTier;
        }
        public bool CanUpgrade() { return canUpgrade; }
        public int TotalUpgrades()
        {
            if(nextTier == null)
            {
                if (!canUpgrade)
                {
                    return stage;
                }
                return stage+1;
                
            }
            return nextTier.TotalUpgrades()+stage+1;
        }
        public void buy()
        {
            stage++;
            if(nextTier != null)
            {
                name = nextTier.name;
                desc = nextTier.desc;
                cost = nextTier.cost;
                icon = nextTier.icon;
                coolDown = nextTier.coolDown;
                nextTier = nextTier.nextTier;
            }
            else
            {
                canUpgrade = false;
            }
        }
    }
}

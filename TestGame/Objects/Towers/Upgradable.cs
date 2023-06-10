using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TestGame.Graphics;
using TestGame.Huds;
using TestGame.Managers;
using TestGame.Objects.Towers.TowerPowers;
using TestGame.Pages;

namespace TestGame.Objects.Towers
{
    public abstract class Upgradable : Entity, Clickable, InfoDisplay
    {
        public List<Tower> options = new List<Tower>();
        public List<TowerPower> powers = new List<TowerPower>();
        protected List<int> optionsID = new List<int>();
        private TowerUI ui;
        public bool canSell = true;
        private static Sound buildingSound = new Sound(Sounds.building, 0.6f, SoundManager.types.Tower);
        private static Sound sellSound = new Sound(Sounds.sell, 0.6f, SoundManager.types.Tower);
        public Upgradable(int x, int y, int w, int h) : base(x, y, w, h)
        {

        }
        public void Clicked(float x, float y, Game1 g)
        {
            if(Intersect(new Vector2(x, y)))
            {
                g.pageGame.getHudManager().setActiveObject(this, g);
                if(this is Tower)
                {
                    g.pageGame.player.displayTange = (this as Tower).range;
                }
                
            }/*
            else
            { 
                if(g.pageGame.hudManager.activeObject != null && g.pageGame.hudManager.activeObject == this)
                {
                    //TODO finne en bedre løsning
                    if (Math.Sqrt(Math.Pow((X - x), 2) + Math.Pow((Y - y), 2)) >= 140)
                    {
                        g.pageGame.hudManager.closeActiveObject(g);
                    }
                    
                }
            }*/
            
        }
        public virtual void Buy(Game1 g, Tower tower)
        {
            if(this is Tower)
            {
                tower.soldValue = (this as Tower).soldValue+tower.cost;
            }
            else {
                tower.soldValue = tower.cost;
            }
            
            g.pageGame.getObjectManager().Add(tower, g);
            g.pageGame.getObjectManager().Remove(this, g);
            g.pageGame.player.money -= tower.cost;
            //g.pageGame.hudManager.closeActiveObject(g);
            g.pageGame.getHudManager().setActiveObject(tower, g);

            buildingSound.play(g);
        }
        public void Buy(Game1 g, TowerPower tp)
        {
            g.pageGame.player.money -= tp.cost;
            tp.buy();
            alertBuy(g, tp);
        }
        protected virtual void alertBuy(Game1 g, TowerPower tp)
        {

        }
        public virtual void Sell(Game1 g)
        {
            g.pageGame.getObjectManager().Add(new Plot((int)X+32, (int)Y+32), g);
            g.pageGame.getObjectManager().Remove(this, g);       
            g.pageGame.getHudManager().closeActiveObject(g);
            sellSound.play(g);
        }
        public override void Init(Game1 g)
        {
            options.Clear();
            foreach (int i in optionsID)
            {
                options.Add(ObjectCreator.createTower(i, (int)X, (int)Y, g));
            }
            base.Init(g);
            g.pageGame.mouseManager.Add(this);
        }
        public override void Destroy(Game1 g)
        {
            base.Destroy(g);
            g.pageGame.mouseManager.Remove(this);
        }
        public void close(Game1 g)
        {
            g.pageGame.getHudManager().Remove(ui, g);
            g.pageGame.mouseManager.Remove(ui);
            g.pageGame.mouseManager.RemoveHover(ui);
        }

        public void select(Game1 g) {
            ui = new TowerUI(this, (int)X, (int)Y, g);
            g.pageGame.getHudManager().Add(ui);
            g.pageGame.mouseManager.Add(ui);
            g.pageGame.mouseManager.AddHover(ui);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace TestGame.Huds
{
    public class TargetButton : Button
    {
        private TowerUI uiT;
        private HeroUI uiH;
        public TargetButton(int x, int y, TowerUI ui=null, HeroUI uiH = null) : base(x,y)
        {
            this.uiT = ui;
            this.uiH = uiH;
        }
        public override void activate(Game1 g)
        {
            if(uiT != null)
            {
                uiT.selectedOption(-1);
            }
            if (uiH != null)
            {
                uiH.selectedOption(-1);
            }
            g.pageGame.mouseManager.stopClick=true;
        }
    }
}

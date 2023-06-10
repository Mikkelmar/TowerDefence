using Microsoft.Xna.Framework;
using System.Collections.Generic;
using TestGame.Graphics;

namespace TestGame.Huds.PopupDisplays.starUpgrades
{
    public class StarUpgradeDisplay : Hud
    {
        private PopupDisplay pd;
        public int starsLeft=0;
        private List<UpgradeButton> upgrades = new List<UpgradeButton>();
        public StarUpgradeDisplay(PopupDisplay pd)
        {
            this.pd = pd;
            X = pd.X;
            Y = pd.Y;


        }
        public override void Destroy(Game1 g)
        {
            base.Destroy(g);
            g.saveManager.updateSave(g);
        }

        public override void Init(Game1 g)
        {
            base.Init(g);
            starsLeft = g.levelMap.playerData.getTotalStars(g);
            pd.hm.Add(new ContinueButton(pd, pd.Width-160,40)
            {
                depth = pd.depth * 0.5f
            }, g);
            pd.hm.Add(new ResetStarsButton(pd, this, pd.Width - 160, pd.Height-150)
            {
                depth = pd.depth * 0.5f
            }, g);

            int gap = 90, offset= 120, widthGap = 90, xMargin=100;
            int x = 0;
            //ARCHER
            int i = 0;
            pd.hm.Add(new UpgradeType(pd, 100, pd.Height - offset - (gap * i), new Sprite(Textures.archerTower_1),"Archer"), g);
            i++;
            upgrades.Add(new UpgradeButton(pd, this, xMargin + widthGap * x, pd.Height - offset - (gap * i),
                "ARCHER0", "Steady aim", "Increases archer towers damage by 1", 1, new Sprite(Textures.bowAndArrow)));
            i++;
            upgrades.Add(new UpgradeButton(pd, this, xMargin + widthGap*x, pd.Height - offset - (gap * i), 
                "ARCHER1", "Keen eye", "Increases archer towers range", 2, new Sprite(Textures.archerRange), "ARCHER0"));
            i++;
            upgrades.Add(new UpgradeButton(pd, this, xMargin + widthGap * x, pd.Height - offset - (gap * i), 
                "ARCHER2", "Royal Supplies", "Final stage archer towers cost 50g less", 2, new Sprite(Textures.gold), "ARCHER1"));
            i++;
            upgrades.Add(new UpgradeButton(pd, this, xMargin + widthGap * x, pd.Height - offset - (gap * i),
                "ARCHER3", "Crossbows", "Increases archer towers range by 10%", 2, new Sprite(Textures.crossBow), "ARCHER2"));
            i++;
            upgrades.Add(new UpgradeButton(pd, this, xMargin + widthGap * x, pd.Height - offset - (gap * i),
                "ARCHER4", "Heavy Arrows", "Each arrow have a chance of dealing double damage", 3, new Sprite(Textures.deadlyArrow), "ARCHER3"));
            i = 0;
            x++;
            //MAGE
            pd.hm.Add(new UpgradeType(pd, 100 + widthGap * x, pd.Height - offset - (gap * i), new Sprite(Textures.mageTower_1), "MAGE"), g);
            i++;
            upgrades.Add(new UpgradeButton(pd, this, xMargin + widthGap * x, pd.Height - offset - (gap * i),
                "MAGE0", "Cheap crystals", "Mage towers cost 10g less", 1, new Sprite(Textures.CheapCrystals)));
            i++;
            upgrades.Add(new UpgradeButton(pd, this, xMargin + widthGap * x, pd.Height - offset - (gap * i),
                "MAGE1", "Mana harvest", "Killing enemies have a chance to grant bonus gold", 2, new Sprite(Textures.manaOre), "MAGE0"));
            i++;
            upgrades.Add(new UpgradeButton(pd, this, xMargin + widthGap * x, pd.Height - offset - (gap * i),
                "MAGE2", "Magic mirror", "Increases mage towers range", 2, new Sprite(Textures.magicMirror), "MAGE1"));
            i++;
            upgrades.Add(new UpgradeButton(pd, this, xMargin + widthGap * x, pd.Height - offset - (gap * i),
                "MAGE3", "Light stone", "Reduce the cost of all special power upgrades by 25%", 3, new Sprite(Textures.stone), "MAGE2"));
            i++;
            upgrades.Add(new UpgradeButton(pd, this, xMargin + widthGap * x, pd.Height - offset - (gap * i),
                "MAGE4", "Mana drain", "Mage orbs slows enemies", 3, new Sprite(Textures.manaPotion), "MAGE3"));
            i = 0;
            x++;
            //BOMB
            pd.hm.Add(new UpgradeType(pd, 100 + widthGap * x, pd.Height - offset - (gap * i), new Sprite(Textures.bombTower_2), "BOMB"), g);
            i++;
            upgrades.Add(new UpgradeButton(pd, this, xMargin + widthGap * x, pd.Height - offset - (gap * i),
                "BOMB0", "Gunpowder", "Deals more damage", 1, new Sprite(Textures.gunpowder)));
            i++;
            upgrades.Add(new UpgradeButton(pd, this, xMargin + widthGap * x, pd.Height - offset - (gap * i),
                "BOMB1", "Bigger Bang", "Increases explotion range", 2, new Sprite(Textures.bombIcon), "BOMB0"));
            i++;
            upgrades.Add(new UpgradeButton(pd, this, xMargin + widthGap * x, pd.Height - offset - (gap * i),
                "BOMB2", "LOOK! LOOK!", "Increases bomb towers range", 2, new Sprite(Textures.scope), "BOMB1"));
            i++;
            upgrades.Add(new UpgradeButton(pd, this, xMargin + widthGap * x, pd.Height - offset - (gap * i),
                "BOMB3", "Fine engineering", "Reduce the cost of all special power upgrades by 25%", 3, new Sprite(Textures.wood), "BOMB2"));
            i++;
            upgrades.Add(new UpgradeButton(pd, this, xMargin + widthGap * x, pd.Height - offset - (gap * i),
                "BOMB4", "Bone shattering", "Suffer no splash damage reduction", 3, new Sprite(Textures.splashDamage), "BOMB3"));
            i = 0;
            x++;
            //Barracks
            pd.hm.Add(new UpgradeType(pd, 100 + widthGap * x, pd.Height - offset - (gap * i), new Sprite(Textures.bracketTower), "BARRACKS"), g);
            i++;
            upgrades.Add(new UpgradeButton(pd, this, xMargin + widthGap * x, pd.Height - offset - (gap * i),
                "BARRACKS0", "Better gear", "Soldiers deal 1 more damage", 1, new Sprite(Textures.icons, new Rectangle(32 * 0, 32 * 3, 32, 32))));
            i++;
            upgrades.Add(new UpgradeButton(pd, this, xMargin + widthGap * x, pd.Height - offset - (gap * i),
                "BARRACKS1", "Just a scratch", "Increases selfhealing speed", 1, new Sprite(Textures.icons, new Rectangle(32 * 6, 32 * 3, 32, 32)), "BARRACKS0"));
            i++;
            upgrades.Add(new UpgradeButton(pd, this, xMargin + widthGap * x, pd.Height - offset - (gap * i),
                "BARRACKS2", "Field constructions", "When you start the game, a random barracks will be built", 2, new Sprite(Textures.icons, new Rectangle(32 * 4, 32 * 4, 32, 32)), "BARRACKS1"));
            i++;
            upgrades.Add(new UpgradeButton(pd, this, xMargin + widthGap * x, pd.Height - offset - (gap * i),
                "BARRACKS3", "Soldiers any%", "Train soldiers faster", 3, new Sprite(Textures.icons, new Rectangle(32 * 9, 32 * 5, 32, 32)), "BARRACKS2"));
            i++;
            upgrades.Add(new UpgradeButton(pd, this, xMargin + widthGap * x, pd.Height - offset - (gap * i),
                "BARRACKS4", "Army", "Your barracks have +1 soldier", 5, new Sprite(Textures.icons, new Rectangle(32 * 7, 32 * 3, 32, 32)), "BARRACKS3"));
            i = 0;
            x++;
            //CHAOS
            pd.hm.Add(new UpgradeType(pd, 100 + widthGap * x, pd.Height - offset - (gap * i), new Sprite(Textures.chaosTower_2), "CHAOS"), g);
            i++;
            upgrades.Add(new UpgradeButton(pd, this, xMargin + widthGap * x, pd.Height - offset - (gap * i),
                "CHAOS0", "Recyclable chaos", "Chaos towers can be sold for 90% their cost", 1, new Sprite(Textures.ruby)));
            i++;
            upgrades.Add(new UpgradeButton(pd, this, xMargin + widthGap * x, pd.Height - offset - (gap * i),
                "CHAOS1", "Pondering my orb", "Increases chaos towers range", 2, new Sprite(Textures.darkOrb), "CHAOS0"));
            i++;
            upgrades.Add(new UpgradeButton(pd, this, xMargin + widthGap * x, pd.Height - offset - (gap * i),
                "CHAOS2", "Unstable power", "Can randomly deals 1-3 more damage", 2, new Sprite(Textures.dices), "CHAOS1"));
            i++;
            upgrades.Add(new UpgradeButton(pd, this, xMargin + widthGap * x, pd.Height - offset - (gap * i),
                "CHAOS3", "Momentum", "Deal more damage the longer the orb travels", 2, new Sprite(Textures.ruin), "CHAOS2"));
            i++;
            upgrades.Add(new UpgradeButton(pd, this, xMargin + widthGap * x, pd.Height - offset - (gap * i),
                "CHAOS4", "Beyond madness", "Gain a damage bonus for each chaos tower", 3, new Sprite(Textures.tomb), "CHAOS3"));
            i = 0;
            x++;
            if (g.levelMap.playerData.towersUnlocked.Contains(26))
            {
                pd.hm.Add(new UpgradeType(pd, 100 + widthGap * x, pd.Height - offset - (gap * i), new Sprite(Textures.necroTower_1), "NECRO"), g);
                i++;
                upgrades.Add(new UpgradeButton(pd, this, xMargin + widthGap * x, pd.Height - offset - (gap * i),
                    "NECRO0", "The bigger they are..", "Gain more charge from enemies with more damage", 1, new Sprite(Textures.hearth)));
                i++;
                upgrades.Add(new UpgradeButton(pd, this, xMargin + widthGap * x, pd.Height - offset - (gap * i),
                    "NECRO1", "Non blood wasted", "Beam mode ends without consuming all charges, when no targets are in sight", 2, new Sprite(Textures.bloodBowl), "NECRO0"));
                i++;
                upgrades.Add(new UpgradeButton(pd, this, xMargin + widthGap * x, pd.Height - offset - (gap * i),
                    "NECRO2", "Soulbound gems", "Increases necro towers range", 2, new Sprite(Textures.emralds), "NECRO1"));
                i++;
                upgrades.Add(new UpgradeButton(pd, this, xMargin + widthGap * x, pd.Height - offset - (gap * i),
                    "NECRO3", "Self Fueling", "Can still gain charge in beam mode", 3, new Sprite(Textures.greenPowder), "NECRO2"));
                i++;
                upgrades.Add(new UpgradeButton(pd, this, xMargin + widthGap * x, pd.Height - offset - (gap * i),
                    "NECRO4", "Unlimeted power", "Reduce beam drain rate by 50%", 3, new Sprite(Textures.goo), "NECRO3"));
                i = 0;
                x++;
            }
            //SLOWPOWER
            /*
            pd.hm.Add(new UpgradeType(pd, 100 + widthGap * x, pd.Height - offset - (gap * i), new Sprite(Textures.sticky_bombs_icon), "SLOWS"), g);
            i++;
            upgrades.Add(new UpgradeButton(pd, this, xMargin + widthGap * x, pd.Height - offset - (gap * i),
                "SLOW0", "Stingy", "Deal 3 extra damage", 1, new Sprite(Textures.jelly)));
            i++;
            upgrades.Add(new UpgradeButton(pd, this, xMargin + widthGap * x, pd.Height - offset - (gap * i),
                "SLOW1", "Chained down", "Increases slow effect", 1, new Sprite(Textures.chaineDown), "SLOW0"));
            i++;
            upgrades.Add(new UpgradeButton(pd, this, xMargin + widthGap * x, pd.Height - offset - (gap * i),
                "SLOW2", "Spell ring", "Spawn 1 more slow orb", 2, new Sprite(Textures.ring), "SLOW1"));
            i++;
            upgrades.Add(new UpgradeButton(pd, this, xMargin + widthGap * x, pd.Height - offset - (gap * i),
                "SLOW3", "Spell scroll", "Reduce cooldown by 5s", 3, new Sprite(Textures.scroll), "SLOW2"));
            i++;
            upgrades.Add(new UpgradeButton(pd, this, xMargin + widthGap * x, pd.Height - offset - (gap * i),
                "SLOW4", "Mind control", "Will make the target walk backwards", 3, new Sprite(Textures.mindControl), "SLOW3"));
            i = 0;
            x++;*/
            //SOLDIER POWER
            pd.hm.Add(new UpgradeType(pd, 100 + widthGap * x, pd.Height - offset - (gap * i), new Sprite(Textures.soldierPower), "Recruits"), g);
            i++;
            upgrades.Add(new UpgradeButton(pd, this, xMargin + widthGap * x, pd.Height - offset - (gap * i),
                "SOLDIER0", "Training", "Stronger soldiers", 1, new Sprite(Textures.icons, new Rectangle(32 * 4, 32 * 1, 32, 32))));
            i++;
            upgrades.Add(new UpgradeButton(pd, this, xMargin + widthGap * x, pd.Height - offset - (gap * i),
                "SOLDIER1", "Armoury", "Better weapons and armour", 2, new Sprite(Textures.icons, new Rectangle(32 * 3, 32 * 7, 32, 32)), "SOLDIER0"));
            i++;
            upgrades.Add(new UpgradeButton(pd, this, xMargin + widthGap * x, pd.Height - offset - (gap * i),
                "SOLDIER2", "Drill sragent", "Reduce cooldown by 5s", 2, new Sprite(Textures.icons, new Rectangle(32 * 3, 32 * 15, 32, 32)), "SOLDIER1"));
            i++;
            upgrades.Add(new UpgradeButton(pd, this, xMargin + widthGap * x, pd.Height - offset - (gap * i),
                "SOLDIER3", "Reinforcments", "+1 Soldier", 3, new Sprite(Textures.icons, new Rectangle(32 * 1, 32 * 5, 32, 32)), "SOLDIER2"));
            i++;
            upgrades.Add(new UpgradeButton(pd, this, xMargin + widthGap * x, pd.Height - offset - (gap * i),
                "SOLDIER4", "Combined powers", "Will spawn a knight and an axe throwing viking", 2, new Sprite(Textures.icons, new Rectangle(32 * 11, 32 * 5, 32, 32)), "SOLDIER3"));
            i = 0;
            x++;
            //Meteor
            pd.hm.Add(new UpgradeType(pd, 100 + widthGap * x, pd.Height - offset - (gap * i), new Sprite(Textures.meteor), "METEOR"), g);
            i++;
            upgrades.Add(new UpgradeButton(pd, this, xMargin + widthGap * x, pd.Height - offset - (gap * i),
                "METEOR0", "Double trouble", "Adds 2 extria meteors", 2, new Sprite(Textures.moreMeteors)));
            i++;
            upgrades.Add(new UpgradeButton(pd, this, xMargin + widthGap * x, pd.Height - offset - (gap * i),
                "METEOR1", "Rock solid!", "Each meteor deals more damage", 2, new Sprite(Textures.fireHead), "METEOR0"));
            i++;
            upgrades.Add(new UpgradeButton(pd, this, xMargin + widthGap * x, pd.Height - offset - (gap * i),
                "METEOR2", "Heavy weather", "Reduce cooldown by 10s", 3, new Sprite(Textures.redStaff), "METEOR1"));
            i++;
            upgrades.Add(new UpgradeButton(pd, this, xMargin + widthGap * x, pd.Height - offset - (gap * i),
                "METEOR3", "Blazeing", "Meteors scorche the ground, setting fire to enemies walking over it", 3, new Sprite(Textures.fireCircle), "METEOR2"));
            i++;
            upgrades.Add(new UpgradeButton(pd, this, xMargin + widthGap * x, pd.Height - offset - (gap * i),
                "METEOR4", "The end is here", "Also spawns 5 other meteors randomly around the battle field", 3, new Sprite(Textures.theEnd), "METEOR3"));
            i = 0;
            x++;
            

            foreach (UpgradeButton upgrade in upgrades)
            {
                starsLeft -= upgrade.getStarsUsed(g);
                pd.hm.Add(upgrade, g);
            }


        }

        public override void Draw(Game1 g)
        {
            Drawing.DrawText("Upgrades", X+200, Y+20, scale: 3f, layerDepth: pd.depth*0.1f);
            new Sprite(Textures.gold_star).Draw(X+pd.Width-160, pd.Height-70, 64, 64, pd.depth * 0.1f);
            Drawing.DrawText(starsLeft.ToString(), X + pd.Width -80, pd.Height+10 - 70, layerDepth: pd.depth * 0.1f, scale: 2f);
        }
    }
}

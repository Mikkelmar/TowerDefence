using Microsoft.Xna.Framework;
using System.Collections.Generic;
using TestGame.Graphics;
using TestGame.Huds.PopupDisplays.starUpgrades;
using TestGame.Objects.Soldiers;

namespace TestGame.Huds.PopupDisplays.heroUpgrades
{
    public class HeroUpgradeDisplay : Hud
    {
        private PopupDisplay pd;
        private Hero hero;
        public int SkillPoints = 0;
        private List<HeroUpgradeButton> upgrades = new List<HeroUpgradeButton>();
        public HeroUpgradeDisplay(PopupDisplay pd, Hero hero)
        {
            this.hero = hero;
            this.pd = pd;
            X = pd.X;
            Y = pd.Y;
            caluculateSkillPoints();
        }
        private void caluculateSkillPoints()
        {
            SkillPoints = (hero.getLevel() - 1) * 2;
        }
        public override void Destroy(Game1 g)
        {
            base.Destroy(g);
            g.saveManager.updateSave(g);
        }

        public override void Init(Game1 g)
        {
            base.Init(g);
            pd.hm.Add(new ContinueButton(pd, pd.Width-160,40)
            {
                depth = pd.depth * 0.5f
            }, g);
            pd.hm.Add(new ResetSkillPointsButton(pd, this, hero, pd.Width - 160, pd.Height - 150)
            {
                depth = pd.depth * 0.5f
            }, g);
            int gap = 90;
            int offset = 120, widthGap = 110, xMargin = 400;
            int x = 0;
            //POWERONE
            int i = 0;

            
            string powerKey = "ATTACK";
            List<object[]> powerList = hero.getUpgrades(powerKey);
            pd.hm.Add(new UpgradeType(pd, xMargin, pd.Height - offset - (gap * i), new Sprite(Textures.icons, new Rectangle(32 * 1, 32 * 5, 32, 32)), "Offence"), g);
            i++;
            foreach (object[] data in powerList)
            {
                string reqKey = powerKey + (i - 2);
                if (i == 1)
                {reqKey = null;}
                upgrades.Add(new HeroUpgradeButton(pd, this, hero, xMargin + widthGap * x, pd.Height - offset - (gap * i),
                powerKey + (i - 1), (string)data[0], (string)data[0], (int)data[1], (Sprite)data[2], reqKey));
                i++;
            }
            i = 0;
            x++; 
            powerKey = "DEFENCE";
            powerList = hero.getUpgrades(powerKey);
            pd.hm.Add(new UpgradeType(pd, xMargin + widthGap * x, pd.Height - offset - (gap * i), new Sprite(Textures.icons, new Rectangle(32 * 1, 32 * 6, 32, 32)), "Defence"), g);
            i++;
            foreach (object[] data in powerList)
            {
                string reqKey = powerKey + (i - 2);
                if (i == 1)
                { reqKey = null; }
                upgrades.Add(new HeroUpgradeButton(pd, this, hero, xMargin + widthGap * x, pd.Height - offset - (gap * i),
                powerKey + (i - 1), (string)data[0], (string)data[0], (int)data[1], (Sprite)data[2], reqKey));
                i++;
            }
            i = 0;
            x++;
            powerKey = "SPECIAL";
            powerList = hero.getUpgrades(powerKey);
            pd.hm.Add(new UpgradeType(pd, xMargin + widthGap * x, pd.Height - offset - (gap * i), new Sprite(Textures.icons, new Rectangle(32 * 3, 32 * 1, 32, 32)), "Abilities"), g);
            i++;
            foreach (object[] data in powerList)
            {
                string reqKey = powerKey + (i - 2);
                if (i == 1)
                { reqKey = null; }
                upgrades.Add(new HeroUpgradeButton(pd, this, hero, xMargin + widthGap * x, pd.Height - offset - (gap * i),
                powerKey + (i - 1), (string)data[0], (string)data[0], (int)data[1], (Sprite)data[2], reqKey));
                i++;
            }
            i = 0;
            x++;
            powerKey = "POWER";
            powerList = hero.getUpgrades(powerKey);
            pd.hm.Add(new UpgradeType(pd, xMargin + widthGap * x, pd.Height - offset - (gap * i), new Sprite(Textures.manaPotion), "Power"), g);
            i++;
            foreach (object[] data in powerList)
            {
                string reqKey = powerKey + (i - 2);
                if (i == 1)
                { reqKey = null; }
                upgrades.Add(new HeroUpgradeButton(pd, this, hero, xMargin + widthGap * x, pd.Height - offset - (gap * i),
                powerKey + (i - 1), (string)data[0], (string)data[0], (int)data[1], (Sprite)data[2], reqKey));
                i++;
            }
            i = 0;
            x++;


            foreach (HeroUpgradeButton upgrade in upgrades)
            {
                SkillPoints -= upgrade.getSkillPointsUsed(g);
                pd.hm.Add(upgrade, g);
            }


        }

        public override void Draw(Game1 g)
        {
            //DRAW HERO INFO
            Drawing.DrawText(hero.name, X+40, Y+40, scale: 2f, layerDepth: pd.depth* 0.1f, color: Color.Gold);
            Drawing.DrawText("Level " + hero.getLevel().ToString(), X + 40, Y + 90, scale: 1.4f, layerDepth: pd.depth * 0.1f, color: Color.BlueViolet);

            Drawing.FillRect(new Rectangle((int)(X+40), (int)(Y + 130), 100, 22), Color.Gray, pd.depth * 0.1f, g);
            Drawing.FillRect(new Rectangle((int)(X + 40), (int)(Y + 130), (int)(100 * (hero.getXp() / (double)hero.xpNeeded())), 22), Color.LightSkyBlue, pd.depth * 0.01f, g);
            Drawing.DrawText(hero.getXp().ToString()+"/"+hero.xpNeeded(), X + 45, Y + 134, scale: 0.6f, layerDepth: pd.depth * 0.001f, color: Color.Black);
            hero.getSprite().Draw(new Vector2(X + 180, Y + 100), width: 148, height: 148, layerDepth: pd.depth*0.1f);

            int i = 0, gap = 32;

            new Sprite(Textures.icons, new Rectangle(32 * 4, 32 * 19, 32, 32)).Draw(new Vector2(X + 40, Y + 164 + gap * i), width: 32, height: 32, layerDepth: pd.depth * 0.1f);
            Drawing.DrawText(hero.baseHp.ToString()+" HP", X + 80, Y + 168 + gap * i, layerDepth: pd.depth * 0.1f);
            i++;
            new Sprite(Textures.icons, new Rectangle(32 * 1, 32 * 5, 32, 32)).Draw(new Vector2(X + 40, Y + 164+ gap*i), width: 32, height: 32, layerDepth: pd.depth * 0.1f);
            Drawing.DrawText(hero.damage.ToString()+" DMG", X + 80, Y + 168 + gap * i, layerDepth: pd.depth * 0.1f);
            i++; 
            new Sprite(Textures.speed1).Draw(new Vector2(X + 40, Y + 164 + gap * i), width: 32, height: 32, layerDepth: pd.depth * 0.1f);
            Drawing.DrawText((hero.attackSpeed.TotalMilliseconds/1000).ToString()+"/s", X + 80, Y + 168 + gap * i, layerDepth: pd.depth * 0.1f);
            i++;
            new Sprite(Textures.icons, new Rectangle(32 * 7, 32 * 7, 32, 32)).Draw(new Vector2(X + 40, Y + 164 + gap * i), width: 32, height: 32, layerDepth: pd.depth * 0.1f);
            Drawing.DrawText(hero.armor.ToString(), X + 80, Y + 168 + gap * i, layerDepth: pd.depth * 0.1f);
            i++;
            new Sprite(Textures.icons, new Rectangle(32 * 8, 32 * 7, 32, 32)).Draw(new Vector2(X + 40, Y + 164 + gap * i), width: 32, height: 32, layerDepth: pd.depth * 0.1f);
            Drawing.DrawText(hero.magicArmor.ToString(), X + 80, Y + 168 + gap * i, layerDepth: pd.depth * 0.1f);
            i++;

            new Sprite(Textures.icons, new Rectangle(32 * 6, 32 * 20, 32, 32)).Draw(X+pd.Width-160, pd.Height-70, 64, 64, pd.depth * 0.1f);
            Drawing.DrawText(SkillPoints.ToString(), X + pd.Width -80, pd.Height+10 - 70, layerDepth: pd.depth * 0.1f, scale: 2f);

            //DRAW UPGRADE OPTIONS
            
        }
    }
}

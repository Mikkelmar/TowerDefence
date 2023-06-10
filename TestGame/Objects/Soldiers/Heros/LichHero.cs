using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TestGame.Graphics;

namespace TestGame.Objects.Soldiers.Heros
{
    public class LichHero : Hero
    {
        public LichHero(int x, int y) : base(x, y, 32, 32)
        {
            sprite = new Sprite(Textures.skeleton);
        }

        public override void activatePower(string powerName)
        {
            switch (powerName)
            {
                case "ATTACK0":
                    damage += 1;
                    break;
                case "ATTACK1":
                    damage += 1;
                    break;
                case "ATTACK2":
                    attackSpeed = TimeSpan.FromMilliseconds(1400);
                    break;
                case "ATTACK3":
                    damage += 2;
                    break;
                case "ATTACK4":
                    attackSpeed = TimeSpan.FromMilliseconds(1100);
                    break;
                case "DEFENCE0":
                    hp += 5;
                    baseHp += 5;
                    break;
                case "DEFENCE1":
                    healRate = new TimeSpan(0, 0, 0, 0, 190);
                    break;
                case "DEFENCE2":
                    armor = AmourLevels.Low;
                    break;
                case "DEFENCE3":
                    hp += 10;
                    baseHp += 10;
                    break;
                case "DEFENCE4":
                    armor = AmourLevels.Medium;
                    break;
            }
        }

        public override List<object[]> getUpgrades(string powerName)
        {
            if (powerName == "ATTACK")
            {
                return new List<object[]>(){ 
                    new object[] { "+1 Damage", 1, new Sprite(Textures.bowAndArrow) },
                    new object[] { "+1 Damage", 1, new Sprite(Textures.bowAndArrow) },
                    new object[] { "Attack speed", 2, new Sprite(Textures.bowAndArrow) },
                    new object[] { "+2 Damage", 2, new Sprite(Textures.bowAndArrow) },
                    new object[] { "Attack speed", 3, new Sprite(Textures.bowAndArrow) }};
            }
            if (powerName == "DEFENCE")
            {
                return new List<object[]>(){
                    new object[] { "+5 Health", 1, new Sprite(Textures.bowAndArrow) },
                    new object[] { "Increase healing speed", 1, new Sprite(Textures.bowAndArrow) },
                    new object[] { "Low armour", 2, new Sprite(Textures.bowAndArrow) },
                    new object[] { "+10 Health", 2, new Sprite(Textures.bowAndArrow) },
                    new object[] { "Medium Armour", 3, new Sprite(Textures.bowAndArrow) }};
            }
            return new List<object[]>();
        }


        public override void resetHeroPowers()
        {
            hp = 40;
            baseHp = hp;
            damage = 2;
            armor = AmourLevels.None;
            magicArmor = AmourLevels.None;
            attackSpeed = TimeSpan.FromMilliseconds(1500);
            name = "Skeleton man";
        }
    }
}

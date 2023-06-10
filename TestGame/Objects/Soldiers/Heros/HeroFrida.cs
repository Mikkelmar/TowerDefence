using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TestGame.Graphics;
using TestGame.Managers;
using TestGame.Objects.Particles;
using TestGame.Objects.StatusEffects;

namespace TestGame.Objects.Soldiers.Heros
{
    public class HeroFrida : Hero
    {
        private static Sound buySound = new Sound(Sounds.sell, 0.1f, SoundManager.types.Menu);
        public HeroFrida(int x, int y) : base(x, y, 32, 32)
        {
            sprite = new Sprite(Textures.warrior);
            isUnlocked = true;
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
            else if (powerName == "DEFENCE")
            {
                return new List<object[]>(){
                    new object[] { "+5 Health", 1, new Sprite(Textures.bowAndArrow) },
                    new object[] { "Increase healing speed", 1, new Sprite(Textures.bowAndArrow) },
                    new object[] { "Low armour", 2, new Sprite(Textures.bowAndArrow) },
                    new object[] { "+10 Health", 2, new Sprite(Textures.bowAndArrow) },
                    new object[] { "Medium Armour", 3, new Sprite(Textures.bowAndArrow) }};
            }
            else if(powerName == "SPECIAL")
            {
                return new List<object[]>(){
                    new object[] { "Multistrike, can somtimes attack multiple targets in the area", 4, new Sprite(Textures.icons, new Rectangle(32 * 12, 32 * 3, 32, 32)) },
                    new object[] { "Have a chance to steal gold from targets slayed", 4, new Sprite(Textures.icons, new Rectangle(32 * 13, 32 * 12, 32, 32)) },
                    new object[] { "Fire sword, set enemies ablaze", 4, new Sprite(Textures.icons, new Rectangle(32 * 5, 32 * 1, 32, 32)) },
                    new object[] { "Parry, sometimes parry attacks and crit the enemy", 5, new Sprite(Textures.icons, new Rectangle(32 * 9, 32 * 5, 32, 32)) },
                    new object[] { "Sacred hellfire blase. Stronger burn effect", 3, new Sprite(Textures.icons, new Rectangle(32 * 6, 32 * 1, 32, 32)) }};
            }
            else if (powerName == "POWER")
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
            name = "Frida the Fast";
        }
        protected override void attackTarget(Game1 g)
        {
            if (Powers["SPECIAL2"])
            {
                StatusEffect e = new Burning(1, TimeSpan.FromSeconds(3), TimeSpan.FromMilliseconds(500));
                if (Powers["SPECIAL4"])
                {
                    e = new Burning(1, TimeSpan.FromSeconds(3), TimeSpan.FromMilliseconds(200));
                }
                if (Target.canBeAffactedBy(e.Name))
                {
                    if (!Target.BeingEffectedBy(e.Name))
                    {
                        g.pageGame.getObjectManager().Add(new BurningEffect(Target.GetPosCenter(), Target), g);
                    }
                    Target.GiveStatusEffect(e);
                }
            }
            base.attackTarget(g);
            if(Powers["SPECIAL1"] && Target.hp <= 0)
            {
                Random rnd = new Random();
                if (rnd.Next(100) <= 10)
                {
                    g.pageGame.player.money += 1;
                    buySound.play(g);
                }
            }
        }
        public override void takeDamage(int damageGiven, Game1 g, Damagetype damagetype = Damagetype.Normal)
        {
            if (Powers["SPECIAL3"] && new Random().Next(100) <= 50)
            {
                attackTarget(g);
                return;
            }
            base.takeDamage(damageGiven, g, damagetype);
        }
    }
}

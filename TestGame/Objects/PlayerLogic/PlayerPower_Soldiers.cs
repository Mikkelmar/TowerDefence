using Microsoft.Xna.Framework;
using System;
using TestGame.Graphics;
using TestGame.Managers;
using TestGame.Objects.Monsters;
using TestGame.Objects.Soldiers;

namespace TestGame.Objects.PlayerLogic
{
    public class PlayerPower_Soldiers : PlayerPower
    {
        private static Sound spawnSound = new Sound(Sounds.use, 1f, SoundManager.types.Normal);
        public PlayerPower_Soldiers(int x, int y) : base(x,y)
        {
            icon = new Sprite(Textures.soldierPower);
            coolDown = TimeSpan.FromSeconds(20);
            currentTime = coolDown;
        }

        protected override void triggerPower(float x, float y, Game1 g)
        {
            spawnSound.play(g);
            //ammount
            int spawnAmmount = 2;
            if (g.levelMap.playerData.starUpgrades["SOLDIER3"])
            {
                spawnAmmount++;
            }

            //spawn
            for (int i = 0; i < spawnAmmount; i++)
            {
                Soldier s = new Soldier((int)x, (int)y)
                {
                    stationedPos = new Vector2(x, y),
                    soldierID = i,
                    despawn = true
                };
                if (g.levelMap.playerData.starUpgrades["SOLDIER3"] && i == 0)
                {
                    s = new Viking((int)x, (int)y, spriteTexture: new Sprite(Textures.viking)) {
                        stationedPos = new Vector2(x, y),
                        soldierID = i,
                        despawn = true
                    };
                    
                    ((Viking)s).canThrowAxe = true;
                    s.Width = 28;
                    s.Height = 28;
                    s.attackSpeed = TimeSpan.FromMilliseconds(550);
                    s.baseHp += 4;
                    s.hp = s.baseHp;
                    s.damage = 7;
                    s.armor = Creature.AmourLevels.None;
                }
                else if(g.levelMap.playerData.starUpgrades["SOLDIER3"] && i == 1)
                {
                    s = new Knight((int)x, (int)y, spriteTexture: new Sprite(Textures.knight))
                    {
                        stationedPos = new Vector2(x, y),
                        soldierID = i,
                        despawn = true
                    };
                    s.attackSpeed = TimeSpan.FromMilliseconds(800);
                    s.armor = Creature.AmourLevels.High;
                    s.Width = 26;
                    s.Height = 26;
                    s.baseHp += 30;
                    s.hp = s.baseHp;
                    s.damage = 5;
                }
                else if (g.levelMap.playerData.starUpgrades["SOLDIER1"])
                {
                    s.armor = Creature.AmourLevels.Medium;
                    s.damage = 5;
                    s.baseHp += 20;
                    s.hp = s.baseHp;
                }
                else if (g.levelMap.playerData.starUpgrades["SOLDIER0"])
                {
                    s.armor = Creature.AmourLevels.Low;
                    s.damage = 3;
                    s.baseHp += 5;
                    s.hp = s.baseHp;
                }
                s.selfRegain = false;
                s.setOffset(spawnAmmount);
                g.pageGame.getObjectManager().Add(s, g);
            };
            
            if (g.levelMap.playerData.starUpgrades["SOLDIER2"])
            {
                coolDown = TimeSpan.FromSeconds(15);
            }

        }
    }
}

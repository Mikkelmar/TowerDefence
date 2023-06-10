using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Huds;
using TestGame.Huds.MonsterUI;
using TestGame.Huds.PopupDisplays;
using TestGame.Objects.Monsters;

namespace TestGame.Managers
{
    public class DiscoverMonsterHandler
    {

        public List<string> discoveredEnemies = new List<string>();
        public List<NewMonsterHud> monsterList = new List<NewMonsterHud>();
        private int distance = 70;
        public void clearLevel(Game1 g)
        {
            g.levelMap.playerData.discoveredEnemies.AddRange(discoveredEnemies);
        }
        //TODO: Max plass til 6 discovered monsters i et game, bør ikke være et problem, men
        //Kan være lurt å lage en workaround
        public void addNewMonster(Game1 g, Monster monster)
        {
            if(monster is Boss)
            {
                discoveredEnemies.Add(monster.name);
                return;
            }
            if(!(discoveredEnemies.Contains(monster.name) || g.levelMap.playerData.discoveredEnemies.Contains(monster.name)))
            {
                NewMonsterHud newMonsterHud = new NewMonsterHud(monster, 40, 120+ monsterList.Count* distance, 64);
                monsterList.Add(newMonsterHud);
                g.pageGame.getHudManager().Add(newMonsterHud, g);
                
                discoveredEnemies.Add(monster.name);
                
            } 
        }
        public void clikecOn(NewMonsterHud monsterHud)
        {
            if (monsterList.Contains(monsterHud))
            {
                for (int i = monsterList.IndexOf(monsterHud); i < monsterList.Count; i++)
                {
                    monsterList[i].Y -= distance;
                }
                monsterList.Remove(monsterHud);
            }
            


        }
    }
}

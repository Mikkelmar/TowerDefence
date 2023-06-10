using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace TestGame.Objects.Monsters
{
    public class MonsterHandler
    {

        public delegate void MonsterDiedEventHandler(Monster source, Game1 g, EventArgs args);
        public event MonsterDiedEventHandler monsterDied;
        public void alertMonsterDied(Game1 g, Monster monster)
        {
            try
            {
                if(monsterDied != null)
                {
                    monsterDied(monster, g, null);
                }
                
            }
            catch 
            {
                Debug.WriteLine("ERROR: "+monster);
            }
            
        }
        public static string getSpeedLevel(float speed)
        {
            if(speed < 20)
            {
                return "Exremly slow";
            }
            if (speed < 30)
            {
                return "Very slow";
            }
            if (speed < 38)
            {
                return "Slow";
            }
            if (speed < 45)
            {
                return "Gradual";
            }
            if (speed == 45)
            {
                return "Normal";
            }
            if (speed < 70)
            {
                return "Fast";
            }
            if (speed <= 80)
            {
                return "Speedy";
            }
            if (speed <= 90)
            {
                return "Very Speedy";
            }

            return "Normal";
        }
    }
}

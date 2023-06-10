using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;
using TestGame.Managers;
using TestGame.Objects.Soldiers;
using TestGame.Pages;

namespace TestGame.Objects.Monsters
{
    public abstract class Boss : Monster
    {
        protected List<TimeSpan> coolDowns;
        private List<TimeSpan> coolDownsTimer = new List<TimeSpan>();
        protected Song bossMusic;
        private bool spawning = true, started = false;
        private TimeSpan spawnTimer = new TimeSpan(), graceTime = TimeSpan.FromSeconds(2), spawnEndTime = TimeSpan.FromSeconds(5);
        public Boss(Path path, int width = 64, int height = 64, int startDistance = 0) : base(path, startDistance, width: width, height: height)
        {
            LeaveCorpse = false;
            damage = 20;
            drawHealth = false;
        }
        public override void Init(Game1 g)
        {
            base.Init(g);
            foreach(TimeSpan cd in coolDowns)
            {
                coolDownsTimer.Add(new TimeSpan());
            }
            
            
        }
        public override void Update(GameTime gt, Game1 g)
        {
            
            if (0 <  graceTime.TotalMilliseconds)
            {
                MediaPlayer.Stop();
                graceTime -= gt.ElapsedGameTime;
                return;
            }
            if (!started)
            {
                MediaPlayer.Play(bossMusic);
                started = true;
            }
            if (spawning)
            {
                spawnTimer += gt.ElapsedGameTime;
                if(spawnTimer >= spawnEndTime)
                {
                    spawning = false;
                    
                }
            }
            base.Update(gt, g);
            for (int i = 0;i< coolDownsTimer.Count;i++)
            {
                coolDownsTimer[i] += gt.ElapsedGameTime;
                if(coolDownsTimer[i] >= coolDowns[i])
                {
                    activatePower(g, i);
                    coolDownsTimer[i] = new TimeSpan();
                }

            }
        }
        protected override void Fight(GameTime gt, Game1 g)
        {
            if (waitingForCombat)
            {
                haveAttacked = false;
                return;
            }
            if (fighting == null || fighting.hp <= 0)
            {
                fighting = null;
                waitingForCombat = false;
            }
            if (attackTimer >= attackSpeed)
            {
                if(fighting.spawnTower != null)
                {
                    List<Soldier> sameUnit = new List<Soldier>(fighting.spawnTower.soldiers);
                    foreach (Soldier s in sameUnit)
                    {
                        s.takeDamage(this.attackDamage, g, Damagetype.None);
                    }
                }
                else
                {
                    List<GameObject> sameUnit = new List<GameObject>(g.pageGame.getObjectManager().GetAllObjectsWith(p => p is Soldier && p.DistanceTo(fighting.GetPosCenter()) <= 64));
                    foreach (Soldier s in sameUnit)
                    {
                        s.takeDamage(this.attackDamage, g, Damagetype.None);
                    }
                    //fighting.takeDamage(this.attackDamage, g, Damagetype.None);
                }
                
                attackTimer = new TimeSpan();
                haveAttacked = true;
            }
            else
            {
                attackTimer += gt.ElapsedGameTime;
                attackAnimation(g);
            }
        }
        public override void Draw(Game1 g)
        {
            if (0 < graceTime.TotalMilliseconds)
            {
                return;
            }
            base.Draw(g);
            if (baseHp != 0)
            {
                int barWidth = 400;
                float textSize=1.4f;
                float drawDepth = 0.000000001f;
                int boarderSize = 2;
                Drawing.DrawText(name,  Drawing.WINDOW_WIDTH / 2- TextHandler.textLength(name)* textSize / 2, 44, layerDepth: drawDepth, color: Color.MediumVioletRed, scale: textSize);
                Drawing.FillRect(new Rectangle(Drawing.WINDOW_WIDTH / 2 - barWidth / 2-boarderSize, 80- +boarderSize, barWidth+boarderSize*2, 20+boarderSize*2), Color.Black, drawDepth, g);
                Drawing.FillRect(new Rectangle(Drawing.WINDOW_WIDTH / 2- barWidth/2, 80, barWidth, 20), Color.Red, drawDepth*0.2f, g);
                if (spawning)
                {
                    Drawing.FillRect(new Rectangle(Drawing.WINDOW_WIDTH / 2, 80, (int)(barWidth * (double)(spawnTimer.TotalMilliseconds)*0.5/ spawnEndTime.TotalMilliseconds), 20), Color.Green, drawDepth * 0.1f, g);
                    float xOffSet = (float)((barWidth)* (double)(spawnTimer.TotalMilliseconds) * 0.5 / spawnEndTime.TotalMilliseconds);
                    Drawing.FillRect(new Rectangle((int)(Drawing.WINDOW_WIDTH / 2- xOffSet), 80, (int)(barWidth * (double)(spawnTimer.TotalMilliseconds) * 0.5 / spawnEndTime.TotalMilliseconds)+5, 20), Color.Green, drawDepth * 0.1f, g);
                }
                else
                {
                    Drawing.FillRect(new Rectangle(Drawing.WINDOW_WIDTH / 2 - barWidth / 2, 80, (int)(barWidth * (hp / (double)baseHp)), 20), Color.Green, drawDepth * 0.1f, g);
                }
                
            }

        }
        protected abstract void activatePower(Game1 g, int i);
        public override bool canBeAffactedBy(string effect)
        {
            return false;
        }
    }
}

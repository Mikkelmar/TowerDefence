using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using TestGame.Graphics;
using TestGame.Huds;
using TestGame.Objects.Monsters;
using TestGame.Objects.Towers;
using TestGame.Pages;

namespace TestGame.Managers
{
    public abstract class Scene
    {
        public ObjectManager objectManager { get; } = new ObjectManager();
        public HudManager hudManager { get; } = new HudManager();
        public WaveManager waveManager { get; private set; } = new WaveManager();

        protected float LevelZoom = 1f;
        public List<Path> Paths = new List<Path>();
        protected string levelData, levelPaths;
        public float waveStartMoneyValue = 10;
        public string name;
        public Song levelSong;
        protected float mapWidth;
        public int sceeneID, mode=0;
        public Sprite background = new Sprite(Textures.map1), overlay;
        public DiscoverMonsterHandler discoverMonsterHandler = new DiscoverMonsterHandler();

        public int levelClearStars = 0, specialStar = 0, endlessStar = 0;
        public Scene(Game1 g)
        {
            
        }
        public virtual void inGoal(Game1 g, Monster monster)
        {
            g.pageGame.player.takeDamage(monster.damage, g);
            g.pageGame.getObjectManager().Remove(monster, g);
        }
        public virtual int pathSize(Path path) //maybe if need in future
        {
            return 74;
        }
        protected List<int> getNormalTowersSelection(Game1 g)
        {
            List<int> towers = new List<int>() { 0, 6, 11, 31, 15 };
            towers.AddRange(g.levelMap.playerData.towersUnlocked);
            return towers;
        }
        public void clearLevel(Game1 g)
        {
            discoverMonsterHandler.clearLevel(g);
            if(mode == 0)
            {
                if (g.pageGame.player.hp > 17)
                {
                    updateStars(3);
                }
                else if (g.pageGame.player.hp > 9)
                {
                    updateStars(2);
                }
                else
                {
                    updateStars(1);
                }
                g.saveManager.updateSave(g);
            }else if(mode == 1)
            {
                specialStar = 1;
            }
            else if (mode == 2)
            {
                endlessStar = 1;
            }

        }
        public abstract List<int> getTowersIDs(Game1 g, int mode);
        private void updateStars(int i)
        {
            if(levelClearStars < i)
            {
                levelClearStars = i;
            }
        }
        public virtual void Init(Game1 g)
        {
            LevelZoom = Drawing.WINDOW_WIDTH / mapWidth;
        }
        public virtual void Update(GameTime gt, Game1 g)
        {
            waveManager.Update(gt, g);
            objectManager.Update(gt, g);
        }
        public virtual void Draw(Game1 g)
        {
            objectManager.Draw(g);
            hudManager.Draw(g);
            if(overlay!= null)
            {
                overlay.Draw(0, 0, mapWidth, Drawing.WINDOW_HEIGHT * mapWidth / Drawing.WINDOW_WIDTH, layerDepth: 0.000004f);
            }
            background.Draw(0, 0, mapWidth, Drawing.WINDOW_HEIGHT * mapWidth/Drawing.WINDOW_WIDTH, layerDepth: 0.9f);
        }
        protected virtual void setHeroPos(Game1 g)
        {
            g.pageGame.player.getHero().X = 200;
            g.pageGame.player.getHero().Y = 200;
        }
        public virtual void Load(Game1 g)
        {
            Plot.plotOptions = getTowersIDs(g, mode);
            g.pageGame.cam.setZoom(g, LevelZoom);
            g.pageGame.cam.Update(new Vector2(mapWidth/ 2, (Drawing.WINDOW_HEIGHT * mapWidth/ Drawing.WINDOW_WIDTH) / 2), g);

            loadLevel(waveManager);
            g.pageGame.gamePaused = false;

            g.pageGame.hudManager.Add(new PlayerUI());
            //Reset player
            g.pageGame.player = new Objects.Player();
            g.pageGame.getObjectManager().Add(g.pageGame.player, g);
            setHeroPos(g);
            g.pageGame.hudManager.Add(new TowerInfo(), g);
            g.pageGame.hudManager.Add(new MonsterInfo());
            g.pageGame.hudManager.Add(new SoldierInfo());
            g.pageGame.hudManager.Add(new WaveButton(40, 60), g);
            //g.pageGame.hudManager.Add(new GameRestartButton(40, 100), g);

            //g.pageGame.hudManager.Add(new GameSpeedButton(90, 60, 0), g);
            //g.pageGame.hudManager.Add(new GameSpeedButton(90, 90, 0.5f), g);
            g.pageGame.hudManager.Add(new GameSpeedButton(120, 60, 1), g);
            g.pageGame.hudManager.Add(new GameSpeedButton(168, 60, 2), g);
            //g.pageGame.hudManager.Add(new GameSpeedButton(180, 60, 3), g);
            
            //Reset discovered enemies
            discoverMonsterHandler = new DiscoverMonsterHandler();
        }
        public virtual void Close(Game1 g)
        {
            waveManager = new WaveManager();
            g.resetGameTime();
            objectManager.Clear(g);
            g.pageGame.hudManager.Clear(g);
            g.pageGame.getHudManager().Clear(g);
            g.pageGame.getHudManager().closeActiveObject(g);

            g.pageGame.cam.setZoom(g, 1f);
            g.pageGame.cam.Update(new Vector2(Drawing.WINDOW_WIDTH/2, Drawing.WINDOW_HEIGHT/2), g);


        }
        private void loadLevel(WaveManager wm)
        {
            wm.boss = null;
            if (mode == 2)
            {
                loadEndlessLevel(wm);
                return;
            }
            //Load paths
            string[] lines = System.IO.File.ReadAllLines(levelPaths);
            foreach (string line in lines)
            {
                string[] points = line.Split("!");
                List<int[]> newPath = new List<int[]>();
                foreach (string point in points)
                {
                    string[] cords = point.Split(",");
                    newPath.Add(new int[2] { Int32.Parse(cords[0]), Int32.Parse(cords[1]) });
                }
                this.Paths.Add(new Path(newPath));
            }
            //load waves

            lines = System.IO.File.ReadAllLines(levelData);
            Wave currentWave = null;
            int readingWaveLine = 0;
            foreach (string line in lines)
            {
                if (line == "!")
                {
                    if(currentWave != null)
                    {
                        wm.waves.Add(currentWave);
                    }
                    currentWave = new Wave(this);
                    readingWaveLine = 0;
                }
                else
                {
                    if(readingWaveLine == 1)
                    { 
                        currentWave.startCoolDown = new TimeSpan(0, 0, 0, 0, Int32.Parse(line));
                    }
                    else
                    {
                        string[] _subLine = line.Split("/");
                        currentWave.AddMonsterSpawns(Int32.Parse(_subLine[0]), _subLine[1]);
                    }
                }
                readingWaveLine++;
            }

           
        }
        private void loadEndlessLevel(WaveManager wm)
        {
            //Load paths
            string[] lines = System.IO.File.ReadAllLines(levelPaths);
            foreach (string line in lines)
            {
                string[] points = line.Split("!");
                List<int[]> newPath = new List<int[]>();
                foreach (string point in points)
                {
                    string[] cords = point.Split(",");
                    newPath.Add(new int[2] { Int32.Parse(cords[0]), Int32.Parse(cords[1]) });
                }
                this.Paths.Add(new Path(newPath));
            }
            //load waves

            lines = System.IO.File.ReadAllLines(levelData);
            Wave currentWave = new Wave(this);
            int readingWaveLine = 0;
            int currentTime = 0;
            currentWave.startCoolDown = new TimeSpan(0, 0, 0, 0, 200);
            foreach (string line in lines)
            {
                if (line == "!")
                {
                    readingWaveLine = 0;
                    if(currentWave.monsterSpawnTimer.Count != 0)
                    {
                       // Debug.WriteLine(currentWave.monsterSpawnTimer.Keys);
                        currentTime = new List<int>(currentWave.monsterSpawnTimer.Keys).Max() + 2000;
                    }
                }
                else
                {
                    if (readingWaveLine == 1)
                    {
                        //currentWave.startCoolDown = new TimeSpan(0, 0, 0, 0, Int32.Parse(line));
                    }
                    else
                    {
                        string[] _subLine = line.Split("/");
                        currentWave.AddMonsterSpawns(Int32.Parse(_subLine[0])+ currentTime, _subLine[1]);
                    }
                }
                readingWaveLine++;
            }
            wm.waves.Add(currentWave);
        }
    }
}

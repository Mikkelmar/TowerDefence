using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using TestGame.Objects;
using TestGame.Objects.Soldiers;
using TestGame.Objects.Soldiers.Heros;

namespace TestGame.Managers
{
    public class SaveManager
    {
        public void loadSave(Game1 g)
        {
            string[] lines = System.IO.File.ReadAllLines("Saves/save1.txt");

            //Each level completed
            try{ 
                foreach (string line in lines)
                {
                    string[] _data = line.Split("/");
                    switch (_data[0])
                    {
                        case "LEVEL":
                            foreach (string data in _data[1].Split("!"))
                            {
                                string[] levelData = data.Split(":");
                                g.pageGame.sceneManager.scenes[Int32.Parse(levelData[0])].levelClearStars = Int32.Parse(levelData[1]);
                                g.pageGame.sceneManager.scenes[Int32.Parse(levelData[0])].specialStar = Int32.Parse(levelData[2]);
                                g.pageGame.sceneManager.scenes[Int32.Parse(levelData[0])].endlessStar = Int32.Parse(levelData[3]);
                            }
                            break;
                        case "MONSTER":
                            foreach (string data in _data[1].Split(","))
                            {
                                g.levelMap.playerData.discoveredEnemies.Add(data);
                            }
                            break;
                        case "TOWER":
                            foreach (string data in _data[1].Split(","))
                            {
                                g.levelMap.playerData.towersUnlocked.Add(Int32.Parse(data));
                            }
                            break;
                        case "POWER":
                            foreach (string data in _data[1].Split(","))
                            {
                                g.levelMap.playerData.starUpgrades[data] = true;
                            }
                            break;
                        case "HERO":
                            foreach (string data in _data[1].Split("!"))
                            {
                                string[] heroData = data.Split(":");
                                int heroID = Int32.Parse(heroData[0]);
                                int level = Int32.Parse(heroData[1]);
                                int xp = Int32.Parse(heroData[2]);
                                Hero loadHero = g.pageGame.player.heros[heroID];
                                loadHero.lvl = level;
                                loadHero.xp = xp;
                                foreach (string powerName in heroData[3].Split(","))
                                {
                                    loadHero.Powers[powerName] = true;
                                    loadHero.activatePower(powerName);
                                }

                            }
                            break;
                        case "ACTIVE_HERO":
                            Player.activeHero = Int32.Parse(_data[1]);
                            break;
                        case "UNLOCKED_HERO":
                            foreach (string unlockedHeroId in _data[1].Split("!"))
                            {
                                g.pageGame.player.heros[Int32.Parse(unlockedHeroId)].isUnlocked = true;
                            }
                            break;
                    }
                }
            }
            catch (IndexOutOfRangeException e)
            {
                Debug.WriteLine(e);
            }

            //Load settings
            lines = System.IO.File.ReadAllLines("Saves/settings.txt");
            try
            {
                foreach (string line in lines)
                {
                    string[] data = line.Split(":");
                    switch (data[0])
                    {
                        case "MUSIC":
                            //Debug.WriteLine(data[1]);
                            g.soundManager.setMusicVolume(Math.Max(Math.Min(float.Parse(data[1]), 1f),0f));//, CultureInfo.InvariantCulture));
                            break;
                        case "GAMESOUND":
                            SoundManager.GameVolume = float.Parse(data[1], CultureInfo.InvariantCulture);
                            break;
                        case "FULLSCREEN":
                            if (bool.Parse(data[1]))
                            {
                                Drawing.graphics.PreferredBackBufferWidth = g.GraphicsDevice.Adapter.CurrentDisplayMode.Width;
                                Drawing.graphics.PreferredBackBufferHeight = g.GraphicsDevice.Adapter.CurrentDisplayMode.Height;
                                Drawing.graphics.ApplyChanges();
                                Drawing.graphics.IsFullScreen = true;
                                Drawing.graphics.ApplyChanges();
                            }
                            else
                            {
                                Drawing.graphics.IsFullScreen = false;
                                Drawing.graphics.ApplyChanges();
                            }
                            break;

                    }
                    
                }
            }
            catch (IndexOutOfRangeException e)
            {
                throw e;
            }
        }
        public void updateSave(Game1 g)
        {
            //Progress
            List<string> lines = new List<string>();

            List<string> levelData = new List<string>();
            int i = 0;
            foreach (Scene s in g.pageGame.sceneManager.scenes)
            {
                levelData.Add(i + ":" + s.levelClearStars+":"+s.specialStar+":"+s.endlessStar);
                i++;
            }
            System.IO.File.WriteAllText("Saves/save1.txt", "LEVEL/"+ String.Join("!", levelData.ToArray()) + Environment.NewLine);
            System.IO.File.AppendAllText("Saves/save1.txt", "MONSTER/"+String.Join(",", g.levelMap.playerData.discoveredEnemies.ToArray()) + Environment.NewLine);
            System.IO.File.AppendAllText("Saves/save1.txt", "TOWER/" + String.Join(",", g.levelMap.playerData.towersUnlocked.ToArray()) + Environment.NewLine);

            //Hero data
            List<string> allHeroData = new List<string>();
            int hero_index = 0;
            foreach (Hero hero in g.pageGame.player.heros)
            {
                List<string> heroData = new List<string>();
                heroData.Add(hero_index + ":" + hero.getLevel() + ":" + hero.getXp());
                lines = new List<string>();
                foreach (string s in hero.Powers.Keys)
                {
                    if (hero.Powers[s])
                    {
                        lines.Add(s);
                    }
                }
                heroData.Add(String.Join(",", lines.ToArray()));
                allHeroData.Add(String.Join(":", heroData.ToArray()));
                hero_index++;
            }
            

            System.IO.File.AppendAllText("Saves/save1.txt", "HERO/" + String.Join("!", allHeroData.ToArray()) + Environment.NewLine);
            System.IO.File.AppendAllText("Saves/save1.txt", "ACTIVE_HERO/" + Player.activeHero + Environment.NewLine);
            List<int> allHeroUnlockedData = new List<int>();
            hero_index = 0;
            foreach (Hero hero in g.pageGame.player.heros)
            {
                if (hero.isUnlocked)
                {
                    allHeroUnlockedData.Add(hero_index);
                }
                hero_index++;
            }
            System.IO.File.AppendAllText("Saves/save1.txt", "UNLOCKED_HERO/" + String.Join("!", allHeroUnlockedData.ToArray()) + Environment.NewLine);
            lines = new List<string>();
            foreach (string s in g.levelMap.playerData.starUpgrades.Keys)
            {
                if (g.levelMap.playerData.starUpgrades[s]) {
                    lines.Add(s);
                }
            }
            System.IO.File.AppendAllText("Saves/save1.txt", "POWER/"+String.Join(",", lines.ToArray()) + Environment.NewLine);

            //Settings
            System.IO.File.WriteAllText("Saves/settings.txt", "MUSIC:"+ SoundManager.MusicVolume.ToString() + Environment.NewLine);
            System.IO.File.AppendAllText("Saves/settings.txt", "GAMESOUND:" + SoundManager.GameVolume.ToString() + Environment.NewLine);
            System.IO.File.AppendAllText("Saves/settings.txt", "FULLSCREEN:" + Drawing.graphics.IsFullScreen.ToString() + Environment.NewLine);


        }
    }
}

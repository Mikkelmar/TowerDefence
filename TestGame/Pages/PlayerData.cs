using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;
using TestGame.Huds;
using TestGame.Huds.PopupDisplays;
using TestGame.Huds.PopupDisplays.OptionScreen;
using TestGame.Huds.PopupDisplays.starUpgrades;
using TestGame.Managers;

namespace TestGame.Pages
{
    public class PlayerData
    {

        public List<string> discoveredEnemies = new List<string>();
        public List<int> towersUnlocked = new List<int>();
        private PopupDisplay pd;
        public Dictionary<string, bool> starUpgrades = new Dictionary<string, bool>()
        {
            { "ARCHER0", false },
            { "ARCHER1", false },
            { "ARCHER2", false },
            { "ARCHER3", false },
            { "ARCHER4", false },

            { "MAGE0", false },
            { "MAGE1", false },
            { "MAGE2", false },
            { "MAGE3", false },
            { "MAGE4", false },

            { "BOMB0", false },
            { "BOMB1", false },
            { "BOMB2", false },
            { "BOMB3", false },
            { "BOMB4", false },

            { "CHAOS0", false },
            { "CHAOS1", false },
            { "CHAOS2", false },
            { "CHAOS3", false },
            { "CHAOS4", false },

            { "METEOR0", false },
            { "METEOR1", false },
            { "METEOR2", false },
            { "METEOR3", false },
            { "METEOR4", false },

            { "SLOW0", false },
            { "SLOW1", false },
            { "SLOW2", false },
            { "SLOW3", false },
            { "SLOW4", false },

            { "NECRO0", false },
            { "NECRO1", false },
            { "NECRO2", false },
            { "NECRO3", false },
            { "NECRO4", false },

            { "SOLDIER0", false },
            { "SOLDIER1", false },
            { "SOLDIER2", false },
            { "SOLDIER3", false },
            { "SOLDIER4", false },

            { "BARRACKS0", false },
            { "BARRACKS1", false },
            { "BARRACKS2", false },
            { "BARRACKS3", false },
            { "BARRACKS4", false },
        };
        public int getTotalStars(Game1 g)
        {
            int totStars = 0;
            foreach(Scene c in g.pageGame.sceneManager.scenes)
            {
                totStars += c.specialStar + c.endlessStar + c.levelClearStars;
            }
            if (Game1.devMode)
            {
                totStars += 100;
            }
            return totStars;
        }
        public void Update(GameTime gt, Game1 g)
        {
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Escape))
            {
                //g.levelMap.Load(g);
                g.levelMap.hudManager.closeActiveObject(g);
                if (!g.levelMap.hudManager.huds.Contains(pd))
                {
                    pd = new PopupDisplay();
                    pd.hm.Add(new OptionsDisplay(pd)
                    {
                        depth = pd.depth * 0.5f
                    }, g);
                    //new Sound(Sounds.pause, 0.1f).play(g);
                    //MediaPlayer.Pause();
                    g.levelMap.hudManager.Add(pd, g);
                }
                
            }
            if (state.IsKeyDown(Keys.R))
            {
                //g.levelMap.Load(g);
                g.levelMap.hudManager.closeActiveObject(g);
                if (!g.levelMap.hudManager.huds.Contains(pd))
                {
                    pd = new PopupDisplay() {
                        Width = 48 * 21,
                        Height = 32 * 21
                    };
                    g.levelMap.hudManager.Add(pd, g);

                    pd.hm.Add(new StarUpgradeDisplay(pd)
                    {
                        depth = pd.depth * 0.5f
                    }, g);
                    //new Sound(Sounds.pause, 0.1f).play(g);
                    //MediaPlayer.Pause();
                    
                }
            }
        }
    }
}

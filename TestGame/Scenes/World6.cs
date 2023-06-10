using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TestGame.Graphics;
using TestGame.Managers;
using TestGame.Objects.Towers;

namespace TestGame.Scenes
{
    public class World6 : Scene
    {
        

        public World6(Game1 g) : base(g)
        {
            levelData = "Levels/Level6/waves.txt";
            levelPaths = "Levels/Level6/paths.txt";
            waveStartMoneyValue = 30;
            mapWidth = Drawing.WINDOW_WIDTH;
            background = new Sprite(Textures.map6);
            name = "Town";
            levelSong = Sounds.finalBattle;
            sceeneID = 5;
        }
        public override List<int> getTowersIDs(Game1 g, int mode)
        {
            if (mode == 0)
            {
                return getNormalTowersSelection(g);
            }
            else if (mode == 1)
            {
                return new List<int>() { 15, 31 };
            }
            return getNormalTowersSelection(g);
        }
        public override void Load(Game1 g)
        {
            //load scene
            base.Load(g);
            if (mode == 0)
            {
                g.pageGame.player.hp = 20;
                g.pageGame.player.money = 800;//700
                if (!g.pageGame.player.heros[1].isUnlocked)
                {
                    g.pageGame.player.heros[1].isUnlocked = true;
                }
            }
            else if (mode == 1)
            {
                g.pageGame.player.hp = 1;
                g.pageGame.player.money = 900;
            }

            else if (mode == 2)
            {
                g.pageGame.player.hp = 1;
                g.pageGame.player.money = 1100;
            }

            g.pageGame.getObjectManager().Add(new Plot(863, 484), g);
            g.pageGame.getObjectManager().Add(new Plot(421, 484), g);

            g.pageGame.getObjectManager().Add(new Plot(727, 493), g);
            g.pageGame.getObjectManager().Add(new Plot(635, 492), g);

            g.pageGame.getObjectManager().Add(new Plot(538, 492), g);
            g.pageGame.getObjectManager().Add(new Plot(429, 293), g);

            g.pageGame.getObjectManager().Add(new Plot(820, 299), g);
            g.pageGame.getObjectManager().Add(new Plot(252, 476), g);

            g.pageGame.getObjectManager().Add(new Plot(619, 305), g);
            g.pageGame.getObjectManager().Add(new Plot(323, 312), g);

            //g.pageGame.getObjectManager().Add(new Plot(323, 329), g);
            g.pageGame.getObjectManager().Add(new Plot(206, 312), g);

            g.pageGame.getObjectManager().Add(new Plot(1015, 500), g);
            //g.pageGame.getObjectManager().Add(new Plot(827, 344), g);
            
                

            //g.pageGame.getObjectManager().Add(new StartTower(524, 503), g);
        }

    }
}

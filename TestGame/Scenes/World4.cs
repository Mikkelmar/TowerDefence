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
    public class World4 : Scene
    {
        

        public World4(Game1 g) : base(g)
        {
            levelData = "Levels/Level4/waves.txt";
            levelPaths = "Levels/Level4/paths.txt";
            waveStartMoneyValue = 30;
            mapWidth = Drawing.WINDOW_WIDTH;
            background = new Sprite(Textures.map5);
            name = "River cross";
            levelSong = Sounds.morning;
            sceeneID = 3;
        }
        public override List<int> getTowersIDs(Game1 g, int mode)
        {
            if (mode == 0)
            {
                return getNormalTowersSelection(g);
            }
            else if (mode == 1)
            {
                return new List<int>() { 6, 11 };
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
                g.pageGame.player.money = 500;
            }
            else if (mode == 1)
            {
                g.pageGame.player.hp = 1;
                g.pageGame.player.money = 700;
            }

            else if (mode == 2)
            {
                g.pageGame.player.hp = 1;
                g.pageGame.player.money = 1000;
            }



            g.pageGame.getObjectManager().Add(new Plot(478, 345), g);
            g.pageGame.getObjectManager().Add(new Plot(410, 346), g);

            g.pageGame.getObjectManager().Add(new Plot(410, 170), g);
            g.pageGame.getObjectManager().Add(new Plot(500, 170), g);

            g.pageGame.getObjectManager().Add(new Plot(590, 170), g);
            g.pageGame.getObjectManager().Add(new Plot(680, 170), g);

            g.pageGame.getObjectManager().Add(new Plot(249, 170), g);
            g.pageGame.getObjectManager().Add(new Plot(699, 339), g);

            g.pageGame.getObjectManager().Add(new Plot(463, 490), g);
            g.pageGame.getObjectManager().Add(new Plot(820, 524), g);

            g.pageGame.getObjectManager().Add(new Plot(977, 366), g);
            g.pageGame.getObjectManager().Add(new Plot(980, 275), g);

            g.pageGame.getObjectManager().Add(new Plot(541, 343), g);
            g.pageGame.getObjectManager().Add(new Plot(827, 344), g);
            
                

            //g.pageGame.getObjectManager().Add(new StartTower(524, 503), g);
        }

    }
}

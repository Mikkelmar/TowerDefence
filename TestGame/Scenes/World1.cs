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
    public class World1 : Scene
    {
        

        public World1(Game1 g) : base(g)
        {
            levelData = "Levels/Level1/waves.txt";
            levelPaths = "Levels/Level1/paths.txt";
            waveStartMoneyValue = 12;
            mapWidth = Drawing.WINDOW_WIDTH;
            background = new Sprite(Textures.map1);
            name = "Plain fields";
            levelSong = Sounds.adventure;
            sceeneID = 0;
        }

        public override List<int> getTowersIDs(Game1 g, int mode)
        {
            if (mode == 0)
            {
                return getNormalTowersSelection(g);
            }
            else if (mode == 1)
            {
                return new List<int>() { 0, 11 };
            }
            return getNormalTowersSelection(g);
        }

        public override void Load(Game1 g)
        {
            //load scene
            base.Load(g);
            if(mode == 0)
            {
                g.pageGame.player.hp = 20;
                g.pageGame.player.money = 250;
            }
            else if(mode == 1)
            {
                g.pageGame.player.hp = 1;
                g.pageGame.player.money = 400;
            }
            else if (mode == 2)
            {
                g.pageGame.player.hp = 1;
                g.pageGame.player.money = 400;
            }
            if (Game1.devMode)
            {
                g.pageGame.player.money = 400000;
            }


            g.pageGame.getObjectManager().Add(new Plot(445, 226), g);
            //g.pageGame.getObjectManager().Add(new StartTower(245, 226 - 32), g);

            g.pageGame.getObjectManager().Add(new Plot(893, 226), g);
            g.pageGame.getObjectManager().Add(new Plot(740, 573), g);
            g.pageGame.getObjectManager().Add(new Plot(680, 216), g);
            //g.pageGame.getObjectManager().Add(new Plot(285, 226), g);
            //g.pageGame.getObjectManager().Add(new Plot(395, 356), g);
            g.pageGame.getObjectManager().Add(new Plot(909, 432), g);
            //g.pageGame.getObjectManager().Add(new StartTower(524, 503), g);
        }

    }
}

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
    public class World0 : Scene
    {
        

        public World0(Game1 g) : base(g)
        {
            levelData = "Levels/Level0/waves.txt";
            levelPaths = "Levels/Level0/paths.txt";
            waveStartMoneyValue = 10;
            mapWidth = Drawing.WINDOW_WIDTH;
            background = new Sprite(Textures.map0);
            name = "Forest entrance";
            levelSong = Sounds.adventure;
            sceeneID = 4;
        }
        public override List<int> getTowersIDs(Game1 g, int mode)
        {
            if (mode == 0)
            {
                return getNormalTowersSelection(g);
            }
            else if (mode == 1)
            {
                return new List<int>() { 6, 31 };
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
                g.pageGame.player.money = 500;
            }

            //g.pageGame.getObjectManager().Add(new Plot(385, 552), g);
            g.pageGame.getObjectManager().Add(new Plot(418, 125), g);
            g.pageGame.getObjectManager().Add(new Plot(475, 252), g);

            g.pageGame.getObjectManager().Add(new Plot(314, 317), g);
            g.pageGame.getObjectManager().Add(new Plot(345, 450), g);

            g.pageGame.getObjectManager().Add(new Plot(510, 500), g);
            g.pageGame.getObjectManager().Add(new Plot(665, 390), g);

            g.pageGame.getObjectManager().Add(new Plot(770, 252), g);
            g.pageGame.getObjectManager().Add(new Plot(196, 480), g);

            //g.pageGame.getObjectManager().Add(new StartTower(524, 503), g);
        }

    }
}

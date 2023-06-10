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
    public class World3 : Scene
    {
        

        public World3(Game1 g) : base(g)
        {
            levelData = "Levels/Level3/waves.txt";
            levelPaths = "Levels/Level3/paths.txt";
            waveStartMoneyValue = 18;
            mapWidth = Drawing.WINDOW_WIDTH;
            background = new Sprite(Textures.map4);
            name = "Dark Forest";
            levelSong = Sounds.finalBattle;
            sceeneID = 2;
        }
        public override List<int> getTowersIDs(Game1 g, int mode)
        {
            if (mode == 0)
            {
                return getNormalTowersSelection(g);
            }
            else if (mode == 1)
            {
                return new List<int>() { 6, 15 };
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
                g.pageGame.player.money = 600;
            }
            else if (mode == 1)
            {
                g.pageGame.player.hp = 1;
                g.pageGame.player.money = 750;
            }
            else if (mode == 2)
            {
                g.pageGame.player.hp = 1;
                g.pageGame.player.money = 850;
            }

            g.pageGame.getObjectManager().Add(new Plot(445, 258), g);
            g.pageGame.getObjectManager().Add(new Plot(442, 342), g);
            g.pageGame.getObjectManager().Add(new Plot(261, 490), g);
            g.pageGame.getObjectManager().Add(new Plot(116, 412), g);
            g.pageGame.getObjectManager().Add(new Plot(578, 504), g);
            g.pageGame.getObjectManager().Add(new Plot(771, 469), g);
            g.pageGame.getObjectManager().Add(new Plot(701, 600), g);
            g.pageGame.getObjectManager().Add(new Plot(821, 284), g);
            g.pageGame.getObjectManager().Add(new Plot(596, 370), g);
            g.pageGame.getObjectManager().Add(new Plot(410, 462), g);
            g.pageGame.getObjectManager().Add(new Plot(589, 244), g);
            g.pageGame.getObjectManager().Add(new Plot(255, 382), g);

            //g.pageGame.getObjectManager().Add(new StartTower(524, 503), g);
        }

    }
}

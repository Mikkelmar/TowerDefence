using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;
using TestGame.Managers;
using TestGame.Objects.Towers;

namespace TestGame.Scenes
{
    public class World2 : Scene
    {

        public World2(Game1 g) : base(g)
        {
            levelData = "Levels/Level2/waves.txt";
            levelPaths = "Levels/Level2/paths.txt";
            waveStartMoneyValue = 15;
            background = new Sprite(Textures.map3);
            mapWidth = (float)(Drawing.WINDOW_WIDTH*1.25);
            name = "Town of Durin";
            sceeneID = 1;
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
            g.pageGame.player.money = 200;
            g.pageGame.player.hp = 20;


            

            g.pageGame.getObjectManager().Add(new Plot(623, 230), g);
            g.pageGame.getObjectManager().Add(new Plot(807, 363), g);
            g.pageGame.getObjectManager().Add(new Plot(1073, 502), g);
            
            g.pageGame.getObjectManager().Add(new Plot(1322, 503), g);
            g.pageGame.getObjectManager().Add(new Plot(307, 506), g);
            g.pageGame.getObjectManager().Add(new Plot(270, 701), g);

            g.pageGame.getObjectManager().Add(new Plot(382, 636), g);
            g.pageGame.getObjectManager().Add(new Plot(593, 522), g);

        }
    }
}

using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TestGame.Graphics;
using TestGame.Managers;
using TestGame.Objects.Monsters;
using TestGame.Objects.Towers;
using TestGame.Pages;

namespace TestGame.Scenes
{
    public class CaveWorld2 : Scene
    {
        

        public CaveWorld2(Game1 g) : base(g)
        {
            levelData = "Levels/CaveLevel2/waves.txt";
            levelPaths = "Levels/CaveLevel2/paths.txt";
            waveStartMoneyValue = 32;
            mapWidth = Drawing.WINDOW_WIDTH;
            background = new Sprite(Textures.cave2);
            overlay = new Sprite(Textures.cave2_overlay); 
            name = "Abyss bridge";
            levelSong = Sounds.finalBattle;
            sceeneID = 7;
        }
        public override List<int> getTowersIDs(Game1 g, int mode)
        {
            if (mode == 0)
            {
                return getNormalTowersSelection(g);
            }
            else if (mode == 1)
            {
                return new List<int>() { 26, 31 };
            }
            return getNormalTowersSelection(g);
        }
        public override int pathSize(Path path) //maybe if need in future
        {
            if(Paths.IndexOf(path) == 2 || Paths.IndexOf(path) == 3)
            {
                return base.pathSize(path);
            }
            return 58;
        }
        public override void inGoal(Game1 g, Monster monster)
        {
            if(Paths.IndexOf(monster.path) == 2)
            {
                monster.path = Paths[3];
                monster.distance = -10;
            }
            else
            {
                g.pageGame.player.takeDamage(monster.damage, g);
                g.pageGame.getObjectManager().Remove(monster, g);
            }     
        }
        public override void Load(Game1 g)
        {
            //load scene
            base.Load(g);
            if (mode == 0)
            {
                g.pageGame.player.hp = 20;
                g.pageGame.player.money = 750;
            }
            else if (mode == 1)
            {
                g.pageGame.player.hp = 1;
                g.pageGame.player.money = 1200;
            }

            else if (mode == 2)
            {
                g.pageGame.player.hp = 1;
                g.pageGame.player.money = 1300;
            }

            g.pageGame.getObjectManager().Add(new Plot(236, 465), g);

            g.pageGame.getObjectManager().Add(new Plot(415, 449), g);
            g.pageGame.getObjectManager().Add(new Plot(238, 381), g);

            g.pageGame.getObjectManager().Add(new Plot(732, 445), g);
            g.pageGame.getObjectManager().Add(new Plot(900, 463), g);

            g.pageGame.getObjectManager().Add(new Plot(1043, 463), g);
            g.pageGame.getObjectManager().Add(new Plot(810, 230), g);
            g.pageGame.getObjectManager().Add(new Plot(810, 310), g);
            g.pageGame.getObjectManager().Add(new Plot(916, 221), g);



            //g.pageGame.getObjectManager().Add(new StartTower(524, 503), g);
        }

    }
}

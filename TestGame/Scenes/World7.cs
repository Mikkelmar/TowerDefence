using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TestGame.Graphics;
using TestGame.Huds;
using TestGame.Huds.PopupDisplays;
using TestGame.Managers;
using TestGame.Objects.Monsters;
using TestGame.Objects.Towers;
using TestGame.Pages;

namespace TestGame.Scenes
{
    public class World7 : Scene
    {
        

        public World7(Game1 g) : base(g)
        {
            levelData = "Levels/CaveLevel1/waves.txt";
            levelPaths = "Levels/CaveLevel1/paths.txt";
            waveStartMoneyValue = 30;
            mapWidth = Drawing.WINDOW_WIDTH;
            background = new Sprite(Textures.cave);
            overlay = new Sprite(Textures.cave1_overlay); 
            name = "Abyss";
            levelSong = Sounds.finalBattle;
            sceeneID = 6;
        }
        public override List<int> getTowersIDs(Game1 g, int mode)
        {
            if (mode == 0)
            {
                return getNormalTowersSelection(g);
            }
            else if (mode == 1)
            {
                return new List<int>() { 11, 26 };
            }
            return getNormalTowersSelection(g);
        }
        public override void inGoal(Game1 g, Monster monster)
        {
            if(Paths.IndexOf(monster.path) == 2)
            {
                monster.path = Paths[3];
                monster.distance = -10; ;
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
            
            if (mode == 0)
            {
                if (!g.levelMap.playerData.towersUnlocked.Contains(26))
                {
                    g.levelMap.playerData.towersUnlocked.Add(26);
                    PopupDisplay pd = new PopupDisplay();
                    pd.hm.Add(new TowerDisplay(pd, ObjectCreator.createTower(26, 0,0,g)), g);

                    g.pageGame.hudManager.Add(pd, g);
;
                }
                
                g.pageGame.player.hp = 20;
                g.pageGame.player.money = 800;
            }
            else if (mode == 1)
            {
                g.pageGame.player.hp = 1;
                g.pageGame.player.money = 1100;
            }

            else if (mode == 2)
            {
                g.pageGame.player.hp = 1;
                g.pageGame.player.money = 1300;
            }
            base.Load(g);
            g.pageGame.getObjectManager().Add(new Plot(904, 201), g);

            g.pageGame.getObjectManager().Add(new Plot(697, 422), g);
            g.pageGame.getObjectManager().Add(new Plot(815, 517), g);

            g.pageGame.getObjectManager().Add(new Plot(994, 468), g);
            g.pageGame.getObjectManager().Add(new Plot(850, 365), g);

            g.pageGame.getObjectManager().Add(new Plot(511, 228), g);
            g.pageGame.getObjectManager().Add(new Plot(596, 228), g);

            g.pageGame.getObjectManager().Add(new Plot(702, 239), g);
            g.pageGame.getObjectManager().Add(new Plot(628, 577), g);

            g.pageGame.getObjectManager().Add(new Plot(553, 424), g);
            g.pageGame.getObjectManager().Add(new Plot(435, 425), g);



            //g.pageGame.getObjectManager().Add(new StartTower(524, 503), g);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Objects.Monsters;
using TestGame.Objects.Towers;
using TestGame.Objects.Towers.NectoTowers;
using TestGame.Objects.Towers.SpawnTower;

namespace TestGame.Pages
{
    public static class ObjectCreator
    {
        public static Monster createMonster(string name, Path path)
        {
            switch (name)
            {
                case "BasicUnit":
                    return new BasicUnit(path);
                case "HelmetMonster":
                    return new HelmetMonster(path);
                case "SpeedMonster":
                    return new SpeedMonster(path);
                case "BulderMonster":
                    return new BulderMonster(path);
                case "SpawnMonster":
                    return new SpawnMonster(path);
                case "MiniLegs":
                    return new MiniLegs(path);
                case "GibliGuy":
                    return new GibliGuy(path);
                case "TeleportMonster":
                    return new TeleportMonster(path);
                case "GlobberTank":
                    return new GlobberTank(path);
                case "BloodGlobber":
                    return new GlobberBlood(path);
                case "UndeadBlobber":
                    return new UndeadBlobber(path);
                case "OTron":
                    return new OTron(path);
                case "GobblerDestroyer":
                    return new GobblerDestroyer(path);
                case "Boss1":
                    return new Boss1(path);
                case "Rat":
                    return new Rat(path);
                case "RatHood":
                    return new RatHood(path);
                case "Crawler":
                    return new Crawler(path);
                case "CaveBear":
                    return new CaveBear(path);
                case "Slime":
                    return new Slime(path);
                case "BigSlime":
                    return new BigSlime(path);
                case "MegaSlime":
                    return new MegaSlime(path);
                case "GoblinArmour":
                    return new GoblinArmour(path);
                case "CaveGoblin":
                    return new CaveGoblin(path);

                default:
                    break;
                    
            }
            return null;
        }
        public static Tower createTower(int id, int x, int y, Game1 g)
        {
            switch (id)
            {
                case 0:
                    return new ArcherTower(x,y).LoadUpgrades(g);
                case 1:
                    return new ArcherTower_2(x, y).LoadUpgrades(g);
                case 3:
                    return new ArcherTower_3(x, y).LoadUpgrades(g);
                case 4:
                    return new ArcherTower_Fire(x, y).LoadUpgrades(g);
                case 5:
                    return new ArcherTower_Sniper(x, y).LoadUpgrades(g);
                case 6:
                    return new MageTower(x, y).LoadUpgrades(g);
                case 7:
                    return new MageTower_2(x, y).LoadUpgrades(g);
                case 8:
                    return new MageTower_3(x, y).LoadUpgrades(g);
                case 9:
                    return new MageTower_Arcane(x, y).LoadUpgrades(g);
                case 10:
                    return new MageTower_Floating(x, y).LoadUpgrades(g);
                case 11:
                    return new BombTower(x, y).LoadUpgrades(g);
                case 12:
                    return new BombTower_2(x, y).LoadUpgrades(g);
                case 13:
                    return new BombTower_3(x, y).LoadUpgrades(g);
                case 14:
                    return new BombTower_Missile(x, y).LoadUpgrades(g);
                case 15:
                       return new ChaosTower(x, y).LoadUpgrades(g);
                case 16:
                    return new ChaosTower_2(x, y).LoadUpgrades(g);
                case 17:
                    return new ChaosTower_3(x, y).LoadUpgrades(g);
                case 18:
                    return new ChaosTower_Ultimate(x, y).LoadUpgrades(g);
                case 19:
                    return new ChaosTower_Crazy(x, y).LoadUpgrades(g);
                case 20:
                    return new ElectroTower(x, y).LoadUpgrades(g);
                case 21:
                    return new SoulTower_1(x, y).LoadUpgrades(g);
                case 22:
                    return new SoulTower_2(x, y).LoadUpgrades(g);
                case 23:
                    return new SoulTower_3(x, y).LoadUpgrades(g);
                case 26:
                    return new NecroTower(x, y).LoadUpgrades(g);
                case 27:
                    return new NecroTower_2(x, y).LoadUpgrades(g);
                case 28:
                    return new NecroTower_3(x, y).LoadUpgrades(g);
                case 29:
                    return new NecroTower_Death(x, y).LoadUpgrades(g);
                case 30:
                    return new NecroTower_Beam(x, y).LoadUpgrades(g);
                case 31:
                    return new SoldierTower(x, y).LoadUpgrades(g);
                case 32:
                    return new SoldierTower_2(x, y).LoadUpgrades(g);
                case 33:
                    return new SoldierTower_3(x, y).LoadUpgrades(g);
                case 34:
                    return new SoldierTower_Vikings(x, y).LoadUpgrades(g);
                case 35:
                    return new SoldierTower_Castle(x, y).LoadUpgrades(g); 





                default:
                    break;

            }
            return null;
        }
    }
}

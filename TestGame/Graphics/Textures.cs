using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestGame.Graphics
{
    public static class Textures
    {
        public static Texture2D monster, map1, archerTower_1, mageTower_1, mageTower_2, archerTower_2, arrow, range, emptySlot, option, shadow, helmetMonster,
            speedMonster, mageball, monsterSheet, bombTower_1, bombTower_2, bomb, explotionSheet, ballFade, archerTower_fire,
            fireArrow, burning, greenCheck, option_gold, greyCheck, map3, mageTower_arcane, teleport, blueExplotion, gui,
            startTower_1, towerInfo, bombTower_missile, rikkeArcher, rikkeMage, plot, chaosBall, chaosTower_1, chaosTower_2,
            chaosTower_ultimate, meteor, target, levelmap, level_camp, level_town, infobox, map4, level_forest,
            empty_star, gold_star, monster_yellow, monster_big, monster_blood, sticky_bombs_icon, sticky_bombs, hole,
            mageTower_floating, oil, archerTower_sniper, weakness, archerTower_0, chaosTower_fantasy, bombTower_3, mageTower_3,
            speed1, speed2, map5, smoke, tower_electro, shockWave, icons, map0, mapSheet, point, chaosTower_crazy, miniChaosBall,
            destroyedArmour, stunIcon, arrowRain, deadlyArrow, archerRange, bowAndArrow, CheapCrystals, heavyArrow, manaOre,
            manaPotion, crossBow, magicMirror, dices, wood, splashDamage, gunpowder, scope, hoverbox, bigHoverbox,
            ruby, tomb, ruin, theEnd, redStaff, fireCircle, fireHead, burnedHole, ring, jelly, mindControl, scroll, chaineDown,
            stone, darkOrb, bombIcon, moreMeteors, map6, monster_armour, meteorRock, monster_tank_animation, vines,
            monster_tank_animation2, greenShadow, cave, monsterSheet2, cave1_overlay, cave2, cave2_overlay, warrior,
            blueFire, spawnTower_1, spawnTower2_1, spawnTower_2, spawnTower_3, gold, beam, necroTower_1, LightgreenShadow,
            goo, bloodBowl, emralds, hearth, greenPowder, necroTower_2, necroTower_3, necroTower_death, necroTower_purple, beamPurple,
            PurpleShadow, bracketTower, bracketTower_2, bracketTower_3, soldier, soldier_2, soldier_3, viking, vikingHouse, iconsSheet,
            castle, knight, knight_armour, dust, voidFiend, point_blue, point_gold, greekGrass, soldierPower, skeleton,
            towerInfo_selected;
        public static SpriteFont font;
        public static void Load(Game1 g)
        {
            monster = g.Content.Load<Texture2D>("monster");
            warrior = g.Content.Load<Texture2D>("warrior/warrior");
            shadow = g.Content.Load<Texture2D>("shadow");
            icons = g.Content.Load<Texture2D>("icons");
            iconsSheet = g.Content.Load<Texture2D>("Sheet");
            map0 = g.Content.Load<Texture2D>("map/map0");
            map1 = g.Content.Load<Texture2D>("map/towerMap2");
            map3 = g.Content.Load<Texture2D>("map/towerMap3");
            map4 = g.Content.Load<Texture2D>("map/map4");
            map5 = g.Content.Load<Texture2D>("map/map5");
            map6 = g.Content.Load<Texture2D>("map/map6");
            cave = g.Content.Load<Texture2D>("map/cave");
            cave1_overlay = g.Content.Load<Texture2D>("map/cave1_overlay");
            cave2 = g.Content.Load<Texture2D>("map/cave2");
            cave2_overlay = g.Content.Load<Texture2D>("map/cave2_overlay");
            arrow = g.Content.Load<Texture2D>("misc/arrow");
            mageball = g.Content.Load<Texture2D>("misc/mageball");
            bomb = g.Content.Load<Texture2D>("misc/bomb");
            teleport = g.Content.Load<Texture2D>("misc/teleport");
            gui = g.Content.Load<Texture2D>("ui/GUI");
            towerInfo = g.Content.Load<Texture2D>("ui/towerInfo");
            infobox = g.Content.Load<Texture2D>("ui/infobox");
            hoverbox = g.Content.Load<Texture2D>("ui/hoverbox");
            bigHoverbox = g.Content.Load<Texture2D>("ui/bigHoverbox");
            towerInfo_selected = g.Content.Load<Texture2D>("ui/towerInfo_selected");

            soldierPower = g.Content.Load<Texture2D>("misc/soldierPower");
            blueFire = g.Content.Load<Texture2D>("misc/blueFire");
            greenCheck = g.Content.Load<Texture2D>("misc/greenCheck");
            greyCheck = g.Content.Load<Texture2D>("misc/greyCheck");
            range = g.Content.Load<Texture2D>("range");
            emptySlot = g.Content.Load<Texture2D>("towers/plot_buy");
            plot = g.Content.Load<Texture2D>("towers/plot");
            option = g.Content.Load<Texture2D>("option");
            option_gold = g.Content.Load<Texture2D>("gold_option");
            empty_star = g.Content.Load<Texture2D>("misc/empty_star");
            gold_star = g.Content.Load<Texture2D>("misc/gold_star");
            sticky_bombs = g.Content.Load<Texture2D>("misc/sticky_bomb");
            sticky_bombs_icon = g.Content.Load<Texture2D>("misc/sticky_bomb_icon");
            smoke = g.Content.Load<Texture2D>("misc/smoke");
            dust = g.Content.Load<Texture2D>("misc/dust");
            miniChaosBall = g.Content.Load<Texture2D>("misc/miniChaosBall");
            destroyedArmour = g.Content.Load<Texture2D>("misc/destroyedArmour");
            stunIcon = g.Content.Load<Texture2D>("misc/stunIcon");
            burnedHole = g.Content.Load<Texture2D>("misc/burnedHole");
            meteorRock = g.Content.Load<Texture2D>("misc/meteorRock");
            vines = g.Content.Load<Texture2D>("misc/vines");
            greenShadow = g.Content.Load<Texture2D>("misc/greenShadow");
            LightgreenShadow = g.Content.Load<Texture2D>("misc/LightgreenShadow");
            PurpleShadow = g.Content.Load<Texture2D>("misc/PurpleShadow");

            mageTower_1 = g.Content.Load<Texture2D>("towers/mageTower_1");
            mageTower_2 = g.Content.Load<Texture2D>("towers/mageTower_2");
            archerTower_1 = g.Content.Load<Texture2D>("towers/archerTower_1");
            archerTower_2 = g.Content.Load<Texture2D>("towers/archerTower_2");
            archerTower_fire = g.Content.Load<Texture2D>("towers/archerTower_fire");
            archerTower_sniper = g.Content.Load<Texture2D>("towers/archerTower_sniper");
            bombTower_1 = g.Content.Load<Texture2D>("towers/bombTower_1");
            bombTower_2 = g.Content.Load<Texture2D>("towers/bombTower_2");
            mageTower_arcane = g.Content.Load<Texture2D>("towers/mageTower_arcane");
            mageTower_floating = g.Content.Load<Texture2D>("towers/mageTower_floating");
            startTower_1 = g.Content.Load<Texture2D>("towers/startTower_1");
            bombTower_missile = g.Content.Load<Texture2D>("towers/bombTower_missile");
            chaosTower_1 = g.Content.Load<Texture2D>("towers/chaosTower_1");
            chaosTower_2 = g.Content.Load<Texture2D>("towers/chaosTower_2");
            chaosTower_ultimate = g.Content.Load<Texture2D>("towers/chaosTower_ultimate");
            archerTower_0 = g.Content.Load<Texture2D>("towers/archerTower_0");
            chaosTower_fantasy = g.Content.Load<Texture2D>("towers/chaosTower_ultimate2");
            bombTower_3 = g.Content.Load<Texture2D>("towers/bombTower_3");
            mageTower_3 = g.Content.Load<Texture2D>("towers/mageTower_3");
            hole = g.Content.Load<Texture2D>("towers/hole");
            tower_electro = g.Content.Load<Texture2D>("towers/electroTower");
            chaosTower_crazy = g.Content.Load<Texture2D>("towers/chaosTower_crazy");
            spawnTower_1 = g.Content.Load<Texture2D>("towers/spawnTower1");
            spawnTower2_1 = g.Content.Load<Texture2D>("towers/spawnTower2");
            spawnTower_2 = g.Content.Load<Texture2D>("towers/spawnTower_2");
            spawnTower_3 = g.Content.Load<Texture2D>("towers/spawnTower_3");
            necroTower_1 = g.Content.Load<Texture2D>("towers/necroTower_1");
            necroTower_2 = g.Content.Load<Texture2D>("towers/necroTower_2");
            necroTower_3 = g.Content.Load<Texture2D>("towers/necroTowers");
            necroTower_death = g.Content.Load<Texture2D>("towers/necroTower_death");
            necroTower_purple = g.Content.Load<Texture2D>("towers/necroTower_beam");
            bracketTower = g.Content.Load<Texture2D>("towers/bracketTower");
            bracketTower_2 = g.Content.Load<Texture2D>("towers/bracketTower_2");
            bracketTower_3 = g.Content.Load<Texture2D>("towers/bracketTower_3");
            vikingHouse = g.Content.Load<Texture2D>("towers/vikingHouse");
            castle = g.Content.Load<Texture2D>("towers/castle");

            rikkeArcher = g.Content.Load<Texture2D>("rikke/archerTower");
            rikkeMage = g.Content.Load<Texture2D>("rikke/mageTower");

            font = g.Content.Load<SpriteFont>("fonts/boldGame");
            helmetMonster = g.Content.Load<Texture2D>("monsters/helmetMonster");
            speedMonster = g.Content.Load<Texture2D>("monsters/speedMonster");
            monsterSheet = g.Content.Load<Texture2D>("monsters/monsterSheet");
            monsterSheet2 = g.Content.Load<Texture2D>("monsters/monsterSheet2");
            skeleton = g.Content.Load<Texture2D>("monsters/skeleton");
            explotionSheet = g.Content.Load<Texture2D>("misc/explotion");
            ballFade = g.Content.Load<Texture2D>("misc/ballFade");
            fireArrow = g.Content.Load<Texture2D>("misc/fireArrow");
            burning = g.Content.Load<Texture2D>("misc/fire");
            weakness = g.Content.Load<Texture2D>("misc/weakness");
            blueExplotion = g.Content.Load<Texture2D>("misc/blueExplotion");
            chaosBall = g.Content.Load<Texture2D>("misc/chaosBall");
            meteor = g.Content.Load<Texture2D>("misc/meteor");
            target = g.Content.Load<Texture2D>("misc/target");
            oil = g.Content.Load<Texture2D>("misc/oil");
            speed1 = g.Content.Load<Texture2D>("misc/speed1");
            speed2 = g.Content.Load<Texture2D>("misc/speed2");
            shockWave = g.Content.Load<Texture2D>("misc/shockWave");
            monster_yellow = g.Content.Load<Texture2D>("monsters/monster_2");
            monster_big = g.Content.Load<Texture2D>("monsters/monster_tank");
            monster_blood = g.Content.Load<Texture2D>("monsters/monster_blood");
            monster_armour = g.Content.Load<Texture2D>("monsters/armourTank");
            monster_tank_animation = g.Content.Load<Texture2D>("monsters/monster_tank_animation");
            monster_tank_animation2 = g.Content.Load<Texture2D>("monsters/monster_tank_animation2");
            beam = g.Content.Load<Texture2D>("misc/beam");
            beamPurple = g.Content.Load<Texture2D>("misc/beamPurple");
            soldier = g.Content.Load<Texture2D>("monsters/soldier");
            soldier_2 = g.Content.Load<Texture2D>("monsters/soldier_2");
            soldier_3 = g.Content.Load<Texture2D>("monsters/soldier_3");
            viking = g.Content.Load<Texture2D>("monsters/viking");
            knight = g.Content.Load<Texture2D>("monsters/knight");
            knight_armour = g.Content.Load<Texture2D>("monsters/knight_armour");
            voidFiend = g.Content.Load<Texture2D>("monsters/voidFiennd");

            arrowRain = g.Content.Load<Texture2D>("misc/arrowRain");
            deadlyArrow = g.Content.Load<Texture2D>("misc/deadlyArrow");
            archerRange = g.Content.Load<Texture2D>("misc/upgradeIcons/archerRange");
            bowAndArrow = g.Content.Load<Texture2D>("misc/upgradeIcons/bowAndArrow");
            CheapCrystals = g.Content.Load<Texture2D>("misc/upgradeIcons/CheapCrystals");
            heavyArrow = g.Content.Load<Texture2D>("misc/upgradeIcons/heavyArrow");
            manaOre = g.Content.Load<Texture2D>("misc/upgradeIcons/manaOre");
            manaPotion = g.Content.Load<Texture2D>("misc/upgradeIcons/manaPotion");
            crossBow = g.Content.Load<Texture2D>("misc/upgradeIcons/crossBow");
            magicMirror = g.Content.Load<Texture2D>("misc/upgradeIcons/magicMirror");
            dices = g.Content.Load<Texture2D>("misc/upgradeIcons/dices");
            wood = g.Content.Load<Texture2D>("misc/upgradeIcons/wood");
            splashDamage = g.Content.Load<Texture2D>("misc/upgradeIcons/splashDamage");
            gunpowder = g.Content.Load<Texture2D>("misc/upgradeIcons/gunpowder");
            scope = g.Content.Load<Texture2D>("misc/upgradeIcons/scope");
            ruby = g.Content.Load<Texture2D>("misc/upgradeIcons/ruby");
            tomb = g.Content.Load<Texture2D>("misc/upgradeIcons/tomb");
            ruin = g.Content.Load<Texture2D>("misc/upgradeIcons/ruin");
            theEnd = g.Content.Load<Texture2D>("misc/upgradeIcons/theEnd");
            redStaff = g.Content.Load<Texture2D>("misc/upgradeIcons/redStaff");
            fireCircle = g.Content.Load<Texture2D>("misc/upgradeIcons/fireCircle");
            fireHead = g.Content.Load<Texture2D>("misc/upgradeIcons/fireGround");
            ring = g.Content.Load<Texture2D>("misc/upgradeIcons/ring");
            jelly = g.Content.Load<Texture2D>("misc/upgradeIcons/jelly");
            mindControl = g.Content.Load<Texture2D>("misc/upgradeIcons/mindControl");
            scroll = g.Content.Load<Texture2D>("misc/upgradeIcons/scroll");
            chaineDown = g.Content.Load<Texture2D>("misc/upgradeIcons/chainedDown");
            darkOrb = g.Content.Load<Texture2D>("misc/upgradeIcons/darkOrb");
            bombIcon = g.Content.Load<Texture2D>("misc/upgradeIcons/bomb");
            stone = g.Content.Load<Texture2D>("misc/upgradeIcons/stone");
            moreMeteors = g.Content.Load<Texture2D>("misc/upgradeIcons/moreMeteors");
            gold = g.Content.Load<Texture2D>("misc/upgradeIcons/gold");
            goo = g.Content.Load<Texture2D>("misc/upgradeIcons/goo");
            bloodBowl = g.Content.Load<Texture2D>("misc/upgradeIcons/bloodBowl");
            emralds = g.Content.Load<Texture2D>("misc/upgradeIcons/emralds");
            hearth = g.Content.Load<Texture2D>("misc/upgradeIcons/heart");
            greenPowder = g.Content.Load<Texture2D>("misc/upgradeIcons/greenPowder");

            levelmap = g.Content.Load<Texture2D>("levelmap/levelmap");
            level_camp = g.Content.Load<Texture2D>("levelmap/camp");
            level_town = g.Content.Load<Texture2D>("levelmap/town");
            level_forest = g.Content.Load<Texture2D>("levelmap/forest");
            mapSheet = g.Content.Load<Texture2D>("levelmap/overworld_tileset_grass");
            point = g.Content.Load<Texture2D>("misc/point");
            point_blue = g.Content.Load<Texture2D>("misc/point_blue");
            point_gold = g.Content.Load<Texture2D>("misc/point_gold");
            greekGrass = g.Content.Load<Texture2D>("misc/greekGrass");

        }
    }
}

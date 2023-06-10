using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestGame.Graphics
{
    public static class Sounds
    {
        public static SoundEffect building, shoot_1, hover, confirm, decline, denied, pause, unpause,
            mageAttack, bombImpact, charge_1, charge_2, death, teleport, miniImpact, smallHit, sell,
            fireSpawn, use, loseHp, playerLoseHp, click, click2, Monster_Groan1, Monster_Roar2, scratch,
            fleeSound, beamCharge, beam;

        public static Song adventure, finalBattle, defeat, levelClear, morning, bossFight1;
        public static void Load(Game1 g)
        {
            building = g.Content.Load<SoundEffect>("sounds/hammer");
            shoot_1 = g.Content.Load<SoundEffect>("sounds/sfx/shoot_1");
            hover = g.Content.Load<SoundEffect>("sounds/menu/001_Hover_01");
            confirm = g.Content.Load<SoundEffect>("sounds/menu/013_Confirm_03");
            decline = g.Content.Load<SoundEffect>("sounds/menu/029_Decline_09");
            denied = g.Content.Load<SoundEffect>("sounds/menu/033_Denied_03");
            pause = g.Content.Load<SoundEffect>("sounds/menu/092_Pause_04");
            unpause = g.Content.Load<SoundEffect>("sounds/menu/098_Unpause_04");
            mageAttack = g.Content.Load<SoundEffect>("sounds/mageAttack");
            bombImpact = g.Content.Load<SoundEffect>("sounds/bombImpact");
            charge_1 = g.Content.Load<SoundEffect>("sounds/charge_1");
            charge_2= g.Content.Load<SoundEffect>("sounds/charge_2");
            death = g.Content.Load<SoundEffect>("sounds/death");
            teleport = g.Content.Load<SoundEffect>("sounds/teleport");
            miniImpact = g.Content.Load<SoundEffect>("sounds/miniImpact");
            smallHit = g.Content.Load<SoundEffect>("sounds/smallHit");
            sell = g.Content.Load<SoundEffect>("sounds/sell");
            fireSpawn = g.Content.Load<SoundEffect>("sounds/fireSpawn");
            use = g.Content.Load<SoundEffect>("sounds/use");
            loseHp = g.Content.Load<SoundEffect>("sounds/loseHp");
            playerLoseHp = g.Content.Load<SoundEffect>("sounds/playerLoseHp");
            click = g.Content.Load<SoundEffect>("sounds/click");
            click2 = g.Content.Load<SoundEffect>("sounds/click2");
            Monster_Groan1 = g.Content.Load<SoundEffect>("sounds/monster/Monster_Groan1");
            Monster_Roar2 = g.Content.Load<SoundEffect>("sounds/monster/Monster_Roar2");
            scratch = g.Content.Load<SoundEffect>("sounds/scratch");
            fleeSound = g.Content.Load<SoundEffect>("sounds/fleeSound");
            beam = g.Content.Load<SoundEffect>("sounds/beam");
            beamCharge = g.Content.Load<SoundEffect>("sounds/beamCharge");



            adventure = g.Content.Load<Song>("sounds/music/adventure");
            finalBattle = g.Content.Load<Song>("sounds/music/finalBattle");
            levelClear = g.Content.Load<Song>("sounds/music/levelClear");
            defeat = g.Content.Load<Song>("sounds/music/defeat");
            morning = g.Content.Load<Song>("sounds/music/morning");
            bossFight1 = g.Content.Load<Song>("sounds/music/bossFight1");
        }
    }
}

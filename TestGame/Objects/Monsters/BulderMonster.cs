using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;
using TestGame.Objects.Particles;
using TestGame.Pages;

namespace TestGame.Objects.Monsters
{
    public class BulderMonster : Monster
    {
        public BulderMonster(Path path, int startDistance = 0) : base(path, startDistance, width: 48, height:48)
        {

            attackDamage = 9;
            attackSpeed = new TimeSpan(0, 0, 0, 1, 500);
            Speed = 30;
            hp = 35;
            reward = 4;
            damage = 3;
            armor = Creature.AmourLevels.Low;
            sprite = new Sprite(Textures.monsterSheet, new Rectangle(32*1,32*0,32,32));
            name = "Bolder";
            description = "Large health pool, but slow";
            LeaveCorpse = false;
        }

        protected override void die(Game1 g)
        {
            base.die(g);
            SpawnDust(g);
        }
    }
}

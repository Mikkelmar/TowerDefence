using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;
using TestGame.Objects.Particles;
using TestGame.Pages;

namespace TestGame.Objects.Monsters
{
    public class SpawnMonster : Monster
    {
        public SpawnMonster(Path path, int startDistance = 0) : base(path, startDistance, width: 48, height:48)
        {
            attackDamage = 8;
            attackSpeed = new TimeSpan(0, 0, 0, 1, 0);
            Speed = 30;
            hp = 35;
            reward = 3;
            sprite = new Sprite(Textures.monsterSheet, new Rectangle(32*2,32*0,32,32));
            name = "Mother Stone";
            description = "Spawns a swarm of small enemies upon death";
            LeaveCorpse = false;
        }
        protected override void die(Game1 g)
        {
            base.die(g);
            for(int i = 0; i < 5; i++)
            {
                g.pageGame.getObjectManager().Add(new MiniLegs(path, (int)distance), g);
            }
            SpawnDust(g);

        }
    }
}

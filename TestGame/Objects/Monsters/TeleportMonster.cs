using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;
using TestGame.Objects.Particles;
using TestGame.Pages;

namespace TestGame.Objects.Monsters
{
    public class TeleportMonster : Monster
    {
        private bool teleported = false;
        public TeleportMonster(Path path, int startDistance = 0) : base(path, startDistance)
        {
            attackDamage = 4;
            Speed = 45;
            hp = 20;
            reward = 2;
            armor = 0;
            sprite = new Sprite(Textures.monsterSheet, new Rectangle(32 * 2, 32 * 3, 32, 32));
            name = "Shadow walker";
            description = "Teleports a short distance the first time they take damage";

        }
        public override void takeDamage(int damage, Game1 g, Damagetype damagetype = Damagetype.Normal)
        {
            base.takeDamage(damage, g, damagetype);
            if(!teleported && hp < baseHp)
            {
                if(fighting != null)
                {
                    fighting.Target = null;
                    fighting = null;
                    waitingForCombat = false;

                }
                teleported = true;
                Vector2 pos = path.GetPos(distance);
                g.pageGame.getObjectManager().Add(
                    new FadingParticle(new Vector2(pos.X - 32, pos.Y - 32),
                    new Sprite(Textures.teleport),
                    TimeSpan.FromMilliseconds(1600),
                    32), g);

                distance += 150; //teleport distance

                pos = path.GetPos(distance);
                g.pageGame.getObjectManager().Add(
                    new FadingParticle(new Vector2(pos.X - 32, pos.Y - 32),
                    new Sprite(Textures.teleport),
                    TimeSpan.FromMilliseconds(1600),
                    32), g);
            }
        }
    }
}

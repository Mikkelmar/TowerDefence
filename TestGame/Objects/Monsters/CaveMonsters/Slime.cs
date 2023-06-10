using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;
using TestGame.Pages;

namespace TestGame.Objects.Monsters
{
    public class Slime : Monster
    {
        public Slime(Path path, int startDistance = 0) : base(path, startDistance)
        {

            attackDamage = 1+((int)Width-16)/8;
            Speed = 45;
            hp = 32;
            reward = 3;
            sprite = new Sprite(Textures.monsterSheet2, new Rectangle(32 * 3, 32 * 1, 32, 32));
            name = "Slime";
            description = "Splits in two upon death. Oh god can this even die?!";
            LeaveCorpse = false;

        }
        protected override void die(Game1 g)
        {
            base.die(g);
            if(Width > 16)
            {
                g.pageGame.getObjectManager().Add(new Slime(path, (int)distance - 4) { 
                    Width = Width-8,
                    Height = Height - 8,
                    reward = reward - 1,
                    hp = (int)(baseHp*0.5f)
                }, g);
                g.pageGame.getObjectManager().Add(new Slime(path, (int)distance - 6)
                {
                    Width = Width - 8,
                    Height = Height - 8,
                    reward = reward - 1,
                    hp = (int)(baseHp * 0.5f)
                }, g);
            }
            
        }
    }
}

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;
using TestGame.Pages;

namespace TestGame.Objects.Monsters
{
    public class CaveBear : Monster
    {
        public CaveBear(Path path, int startDistance = 0) : base(path, startDistance)
        {
            attackDamage = 14;
            Speed = 36;
            hp = 90;
            reward = 3;
            sprite = new Sprite(Textures.monsterSheet2, new Rectangle(32 * 0, 32 * 1, 32, 32));
            name = "Cave bear";
            description = "The classic cave bear";
        }
    }
}

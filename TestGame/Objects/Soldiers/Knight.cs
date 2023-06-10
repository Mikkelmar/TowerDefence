using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;

namespace TestGame.Objects.Soldiers
{
    public class Knight : Soldier
    {
        
        public Knight(int x, int y, Sprite spriteTexture = null, int width = 22, int height = 22) : base( x, y, spriteTexture, width, height)
        {
            magicArmor = Creature.AmourLevels.Medium;
            string[] lines = System.IO.File.ReadAllLines("Saves/maleNames.txt");
            name = "sir. "+lines[new Random().Next(0, lines.Length - 1)];
        }
      
        public void setSprite(Sprite spriteTexture = null)
        {
            sprite = spriteTexture;
        }
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;

namespace TestGame.Containers.Items
{
    public class Item
    {
        public Sprite Sprite;
        public enum ItemType { Weapon, Food, Bulding, Misc, Armour };
        public string Name { get; }
        public ItemType itemType;
        public int Ammount { get; set; }

        public Item(Sprite texture, String name, int ammount = 1)
        {
            this.Sprite = texture;
            this.Name = name;
            this.Ammount = ammount;
            this.itemType = ItemType.Misc;
        }
        public void addAmmount(int ammount)
        {
            this.Ammount += ammount;
        }
        public void Draw(int x, int y, int size, float depth = 0.01f, bool showAmmount = true)
        {
            Sprite.Draw(new Rectangle(x, y, size, size), depth);
            if (Ammount != 1 && showAmmount) //displayer kun antall hvis det ikke er kun 1
            {
                Drawing.DrawText(Ammount.ToString(), x + 40, y + 40, depth * 0.5f);
            }
        }
        public void Draw(Vector2 pos, int size, float depth = 0.01f, bool showAmmount = true)
        {
            Draw(pos.X, pos.Y, size, depth, showAmmount);
        }
        public void Draw(float x, float y, int size, float depth = 0.01f, bool showAmmount = true)
        {
            Draw((int)x, (int)y, size, depth, showAmmount);
        }
        protected static Rectangle getSpriteRect(int x, int y, int with = 1, int height = 1)
        {
            return new Rectangle(x * 16, 16 * y, 16 * with, 16 * height);
        }
        public virtual Item Clone()
        {
            return (Item)Activator.CreateInstance(this.GetType(), this.Ammount);
        }

        //TODO: Bør bruke noe annet en navn, helst lage et ID system eller noe
        public bool Equals(Item item)
        {
            if(item == null || this == null)
            {
                return false;
            }
            return item.Name.Equals(this.Name);
        }
    }
}

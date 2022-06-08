using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;

namespace TestGame.Containers.Items
{
    public abstract class Item
    {
        public Sprite Sprite;
        public enum ItemType { Weapon, Food, Fuel, Meltable, Misc, Armour,
            Arrow, Helmet, Chest, Legs, Feet
        }
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
        public void Draw(float x, float y, int size, float depth = 0.01f, bool showAmmount = true)
        {
            Sprite.Draw(new Vector2(x, y), size, layerDepth: depth);
            if (Ammount != 1 && showAmmount) //displayer kun antall hvis det ikke er kun 1
            {
                Drawing.DrawText(Ammount.ToString(), x + 40, y + 40, depth * 0.999f);
            }
        }
        public void Draw(Vector2 pos, int size = 64, float depth = 0.01f, bool showAmmount = true)
        {
            Draw(pos.X, pos.Y, size, depth, showAmmount);
        }
  
        protected static Rectangle getSpriteRect(int x, int y, int with = 1, int height = 1)
        {
            return new Rectangle(x * 16, 16 * y, 16 * with, 16 * height);
        }
        public virtual Item Clone()
        {
            //TODO: er noe muffins med item logic, mistenker feilen ligger her
            //Item clonedItem = (Item)Activator.CreateInstance(this.GetType(), Ammount);
            //clonedItem.Ammount = Ammount;
            return (Item)Activator.CreateInstance(this.GetType(), Ammount);
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
        public override string ToString()
        {
            return Name + ": [Ammount: "+Ammount+", Type: "+itemType+"]";
        }
        public virtual List<string> GetDescription()
        {
            List<string> newList = new List<string>();
            return newList;
        }
    }
}

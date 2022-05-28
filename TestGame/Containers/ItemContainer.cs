using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Containers.Items;

namespace TestGame.Containers
{
    public class ItemContainer
    {
        private List<Item> items = new List<Item>();
        protected int Capacity = -1; //default for infinit capacity
        public ItemContainer(){}
        public ItemContainer(List<Item> items)
        {
            Add(items);
        }
        public override string ToString()
        {
            String content = "Contains: ["+ System.Environment.NewLine;
            foreach(Item i in GetItems())
            {
                content += i.Name + ": " + i.Ammount + System.Environment.NewLine;
            }
            return content + "]";
        }
        public void Add(Item item, int ammount) {
            item.addAmmount(ammount);
            Add(item);
        }
        public virtual void Add(Item item) {
            if (Contain(item)){
                getItem(item).addAmmount(item.Ammount);
            }
            else
            {
                items.Add(item);
            }
        }

        public void Add(ItemContainer ic)
        {
            Add(ic.GetItems());
        }
        public void Add(List<Item> items)
        {
            foreach (Item i in items)
            {
                Add(i);
            }
        }
        public Item getItem(Item item) { return getItem(item.Name); }
        public Item getItem(String name)
        {
            foreach(Item i in items)
            {
                if (i.Name.Equals(name))
                {
                    return i;
                }
            }
            return null;
        }
        public List<Item> GetItems()
        {
            return new List<Item>(items);
        }
        public void Take(ItemContainer ic)
        {
            foreach(Item i in ic.GetItems())
            {
                Take(i, i.Ammount);
            }
        }
        public void Take(Item item, int ammount)
        {
            if(!Contain(item, ammount))
            {
                throw new Exception("Don't have enough to take!");
            }
            Item i = getItem(item);
            i.addAmmount(-ammount);
            if (i.Ammount <= 0)
            {
                Remove(i);
            }
        }
        public bool Contain(ItemContainer ic)
        {
            foreach(Item i in ic.GetItems())
            {
                if(!Contain(i, i.Ammount)){
                    return false;
                }
            }
            return true;
        }
        public bool Contain(Item item) { return getItem(item) != null; }
        public bool Contain(Item item, int ammount) {
            return Contain(item) && getItem(item).Ammount >= ammount;
        }
        public void Remove(Item item) { items.Remove(item); }
        public void Clear() { items.Clear(); }
    }
}

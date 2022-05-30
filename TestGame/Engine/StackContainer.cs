using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Containers.Items;

namespace TestGame.Containers
{
    public class StackContainer : ItemContainer
    {
        private List<Item> items = new List<Item>();
        protected int Capacity = -1; //default for infinit capacity
        public StackContainer(){}
        public StackContainer(List<Item> items)
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
        public override void Add(Item item, int ammount) {
            item.addAmmount(ammount);
            Add(item);
        }
        public override void Add(Item item) {
            if (Contain(item)){
                getItem(item).addAmmount(item.Ammount);
            }
            else
            {
                items.Add(item);
            }
        }

        public override void Add(ItemContainer ic)
        {
            Add(ic.GetItems());
        }
        public override void Add(List<Item> items)
        {
            foreach (Item i in items)
            {
                Add(i);
            }
        }
        public override Item getItem(Item item) {
            foreach(Item i in items)
            {
                if (i.Equals(item))
                {
                    return i;
                }
            }
            return null;
        }
        public override List<Item> GetItems()
        {
            return new List<Item>(items);
        }
        public override void Remove(Item item) { items.Remove(item); }
        public override void Clear() { items.Clear(); }

        public override void RemoveAmmount(Item item, int ammount)
        {
            getItem(item).addAmmount(-ammount);
        }

        public override bool CanAdd(Item item)
        {
            if (Contain(item))
            {
                return true;
            }
            else if(items.Count <= Capacity)
            {
                return true;
            }
            return false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Containers.Items;

namespace TestGame.Containers
{
    public abstract class ItemContainer
    {
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
        public abstract bool CanAdd(Item item);
        public abstract void Add(Item item, int ammount);
        public abstract void Add(Item item);
        public abstract void Add(ItemContainer ic);
        public abstract void Add(List<Item> items);
        public abstract void RemoveAmmount(Item item, int ammount);
        public abstract Item getItem(Item item);
        public abstract List<Item> GetItems();
        public void Take(Item item, int ammount)
        {
            if(Contain(item, ammount))
            {
                RemoveAmmount(item, ammount);
            }
            else
            {
                throw new Exception("Don't have enough to take!");
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
        public virtual void Take(ItemContainer ic)
        {
            foreach (Item i in ic.GetItems())
            {
                Take(i, i.Ammount);
            }
        }
        public virtual bool Contain(Predicate<Item> filter) {
            foreach (Item i in GetItems())
            {
                if (filter(i))
                {
                    return true;
                }
            }
            return false;
        }
        public virtual bool Contain(Item item) { return getItem(item) != null; }
        public bool Contain(Item item, int ammount) {
            return Contain(item) && getItem(item).Ammount >= ammount;
        }
        public abstract void Remove(Item item);
        public abstract void Clear();
    }
}

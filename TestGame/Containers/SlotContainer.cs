using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TestGame.Containers.Items;

namespace TestGame.Containers
{
    /**
     *  TODO Finish this
     *  skal holde styr på hvilken "slot" gjenstandene beffiner seg på
     */
    public class SlotContainer : ItemContainer
    {
        private Dictionary<int, Item> items = new Dictionary<int, Item>();
        private int Capacity;
        public int Xrows, Yrows;
        public SlotContainer(int capacity)
        {
            this.Capacity = capacity;
            Xrows = capacity;
            Yrows = 1;
        }
        public SlotContainer(int capacity, int Xrows, int Yrows)
        {
            this.Capacity = capacity;
            this.Xrows = Xrows;
            this.Yrows = Yrows;
        }

        public override void Add(Item item)
        {
            for (int i = 0; i < Capacity; i++)
            {
                if (item.Equals(GetItemAtSlot(i)))
                {
                    GetItemAtSlot(i).addAmmount(item.Ammount);
                    return;
                }
            }
            for (int i = 0; i < Capacity; i++)
            {
                if (GetItemAtSlot(i) == null)
                {
                    items.Add(i, item);
                    return;
                }
            }
        }

        public override void Add(Item item, int ammount)
        {
            item.Ammount = ammount;
            Add(item);
        }

        public override void Add(ItemContainer ic)
        {
            Add(ic.GetItems());
        }

        public override void Add(List<Item> items)
        {
            foreach (Item item in items)
            {
                Add(item);
            }
        }

        /// <summary>
        /// Trys to adds the given item in the given inex slot.
        /// </summary>
        /// <returns>
        /// Returns true if the opperation was succsesfull.
        /// returns false if another item was takeing it's place.
        /// </returns>
        /// <param name="item">The item to be added</param>
        /// <param name="slot">What index the item to be added to</param>
        public bool AddToSlot(Item item, int slot)
        {
            if (item == null)
            {
                return true;
            }
            Item itemAtSlot = GetItemAtSlot(slot);
            if (item.Equals(itemAtSlot))
            {
                itemAtSlot.addAmmount(item.Ammount);
                return true;
            }
            else if (itemAtSlot == null)
            {
                items.Add(slot, item);
                return true;
            }
            return false;

        }

        public override void Clear()
        {
            items.Clear();
        }

        public override Item getItem(Item item)
        {
            Item theItem = (Item)Activator.CreateInstance(item.GetType(), 0);
            for (int i = 0; i < Capacity; i++)
            {
                if ((item).Equals(GetItemAtSlot(i)))
                {
                    theItem.addAmmount(items[i].Ammount);
                }
            }
            if (theItem.Ammount == 0)
            {
                return null;
            }
            return theItem;
        }

        public Item GetItemAtSlot(int slot)
        {
            if (items.ContainsKey(slot))
            {
                return items[slot];
            }
            return null;
        }
        public Item RemoveItemAtSlot(int slot)
        {
            if (items.ContainsKey(slot))
            {
                Item i = items[slot];
                items.Remove(slot);
                return i;
            }
            return null;
        }
        public void RemoveAmmountAtSlot(int slot, int ammount = 1)
        {
            if (items.ContainsKey(slot))
            {
                Item i = items[slot];
                i.addAmmount(-ammount);
                if(i.Ammount <= 0)
                {
                    RemoveItemAtSlot(slot);
                }
            }
        }
        public Item RemoveAmmountPredicate(Predicate<Item> filter, int ammount = 1)
        {
            for (int index = 0; index < Capacity; index++) {
                Item i = GetItemAtSlot(index);
                if (i != null && filter(i))
                {
                    Item returnItem = i.Clone();
                    returnItem.Ammount = ammount;
                    RemoveAmmount(i, ammount);
                    return returnItem;
                }
            }
            return null;
        }

        public override List<Item> GetItems()
        {
            List<Item> items = new List<Item>();
            for (int i = 0; i < Capacity; i++)
            {
                Item item = GetItemAtSlot(i);
                if (item != null)
                {
                    items.Add((Item)Activator.CreateInstance(item.GetType(), item.Ammount));
                }
            }
            return items;
        }

        public override void Remove(Item item)
        {
            for (int i = 0; i < Capacity; i++)
            {
                if (item.Equals(GetItemAtSlot(i)))
                {
                    items.Remove(i);
                }
            }
        }

        public override void RemoveAmmount(Item item, int ammount)
        {
            int ammountLeft = ammount;
            for (int i = 0; i < Capacity; i++)
            {
                Item itemAtSlot = GetItemAtSlot(i);
                if ((item).Equals(itemAtSlot))
                {
                    if (itemAtSlot.Ammount > ammountLeft)
                    {
                        itemAtSlot.addAmmount(-ammountLeft);
                    }
                    else
                    {
                        ammountLeft -= itemAtSlot.Ammount;
                        itemAtSlot.Ammount = 0;
                        items.Remove(i);
                    }
                    if (ammountLeft == 0)
                    {
                        return;
                    }

                }
            }
        }

        public override bool CanAdd(Item item)
        {
            for (int i = 0; i < Capacity; i++)
            {
                if (GetItemAtSlot(i) == null || GetItemAtSlot(i).Equals(item))
                {
                    return true;
                }
            }
            return false;
        }
    }
}

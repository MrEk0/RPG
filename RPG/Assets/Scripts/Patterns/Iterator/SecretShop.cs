using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Patterns.Iterator
{
    class SecretShop : IItemEnumerable
    {
        List<Item> items = new List<Item>();

        //public SecretShop()
        //{
        //    items.Add(new Item("Axe"));
        //    items.Add(new Item("Rapier"));
        //    items.Add(new Item("Sword"));
        //    items.Add(new Item("Bow"));
        //}

        public void AddItem(Item item)
        {
            items.Add(item);
        }

        public void RemoveItem(Item item)
        {
            items.Remove(item);
        }

        //public Item this[int index] => items[index];

        public int Count => items.Count();

        public Item GetItem(int index)
        {
            return items[index];
        }

        public IItemEnumerator GetItemEnumerator()
        {
            return new ShopIterator(this);
        }
    }
}

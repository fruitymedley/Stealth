using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stealth
{
    public class State
    {
        public Player Player { get; set; }
        public Inventory Inventory { get; set; }
        public Dictionary<uint, Item> Items { get; set; }

        public State()
        {
            Player = new Player();
            Inventory = new Inventory();
            Items = new Dictionary<uint, Item>
            {
                { 0x00000101, new Item(0, 1, null) }
            };
        }

        private uint key => (uint)((Player.Room << 16) + (Player.Y << 8) + Player.X);

        public Item GetItem()
        {
            return Items.ContainsKey(key) ? Items[key] : null;
        }

        public bool RemoveItem()
        {
            return Items.Remove(key);
        }

        public void SetItem(Item item)
        {
            Items[key] = item;
        }

        public IEnumerable<KeyValuePair<uint, Item>> GetItemsInRoom()
        {
            return Items.Where(i => (i.Key >> 16) == Player.Room);
        }
    }
}

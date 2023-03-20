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
                // Attic
                { 0x00000201, new Item(5, 1, null) },
                { 0x00000202, new Item(6, 1, null) },
                { 0x00000203, new Item(7, 1, null) },
                { 0x00000204, new Item(1, 1, null) },
                { 0x00000206, new Item(1, 1, null) },
                { 0x00000208, new Item(1, 1, null) },
                { 0x0000020A, new Item(1, 1, null) },
                { 0x0000020C, new Item(1, 1, null) },
                { 0x0000020E, new Item(1, 1, null) },
                { 0x00000210, new Item(1, 1, null) },
                { 0x00000212, new Item(1, 1, null) },
                { 0x00000502, new Item(3, 1, null) },
                { 0x00000504, new Item(3, 1, null) },
                { 0x00000506, new Item(3, 1, null) },
                { 0x00000508, new Item(3, 1, null) },
                { 0x0000050A, new Item(3, 1, null) },
                { 0x0000050C, new Item(3, 1, null) },
                { 0x0000050E, new Item(3, 1, null) },
                { 0x00000510, new Item(3, 1, null) },
                { 0x00000512, new Item(3, 1, null) },
                { 0x00000302, new Item(2, 1, null) },
                { 0x00000312, new Item(2, 1, null) },
                { 0x00000104, new Item(8, 1, null) },
                { 0x00000105, new Item(9, 1, null) },
                { 0x00000106, new Item(10, 1, null) },
                { 0x00000006, new Item(8, 1, null) },
                { 0x00000007, new Item(9, 1, null) },
                { 0x00000008, new Item(10, 1, null) },
                { 0x00000108, new Item(8, 1, null) },
                { 0x00000109, new Item(9, 1, null) },
                { 0x0000010A, new Item(10, 1, null) },
                { 0x0000010B, new Item(8, 1, null) },
                { 0x0000010C, new Item(9, 1, null) },
                { 0x0000010D, new Item(10, 1, null) },
                { 0x00000601, new Item(11, 1, null) },
                { 0x00000602, new Item(12, 1, null) },
                { 0x00000603, new Item(13, 1, null) },
                { 0x00000605, new Item(11, 1, null) },
                { 0x00000606, new Item(12, 1, null) },
                { 0x00000607, new Item(13, 1, null) },
                { 0x00000608, new Item(11, 1, null) },
                { 0x00000609, new Item(13, 1, null) },

                // Closet
                { 0x000100FE, new Item(4, 1, null) },
                { 0x000100FF, new Item(4, 1, null) },
                { 0x00010000, new Item(4, 1, null) },
                { 0x00010001, new Item(14, 1, null) },
                { 0x00010002, new Item(15, 1, null) },
                { 0x00010003, new Item(16, 1, null) },
                { 0x00010004, new Item(4, 1, null) },
                { 0x00010005, new Item(4, 1, null) },
                { 0x00010006, new Item(4, 1, null) },
                { 0x00010101, new Item(17, 1, null) },
                { 0x00010102, new Item(19, 1, null) },
                { 0x00010103, new Item(18, 1, null) },
                { 0x00010201, new Item(17, 1, null) },
                { 0x00010203, new Item(18, 1, null) },

                // Bathroom
                { 0x000200FE, new Item(4, 1, null) },
                { 0x000200FF, new Item(4, 1, null) },
                { 0x00020000, new Item(4, 1, null) },
                { 0x00020003, new Item(21, 1, null) },
                { 0x00020004, new Item(22, 1, null) },
                { 0x00020005, new Item(4, 1, null) },
                { 0x00020006, new Item(4, 1, null) },
                { 0x00020007, new Item(4, 1, null) },
                { 0x00020202, new Item(23, 1, null) },
                { 0x00020201, new Item(24, 1, null) },
                { 0x00020301, new Item(25, 1, null) },

                // Hallway
                { 0x000300FD, new Item(4, 1, null) },
                { 0x000300FE, new Item(4, 1, null) },
                { 0x000300FF, new Item(4, 1, null) },
                { 0x00030000, new Item(4, 1, null) },
                { 0x00030003, new Item(4, 1, null) },
                { 0x00030004, new Item(4, 1, null) },
                { 0x00030005, new Item(4, 1, null) },
                { 0x00030006, new Item(4, 1, null) },

                // Bedroom
                { 0x00040000, new Item(4, 1, null) },
                { 0x00040003, new Item(26, 1, null) },
                { 0x00040005, new Item(26, 1, null) },
                { 0x00040203, new Item(27, 1, null) },
                { 0x00040204, new Item(29, 1, null) },
                { 0x00040205, new Item(28, 1, null) },
                { 0x00040303, new Item(30, 1, null) },
                { 0x00040304, new Item(31, 1, null) },
                { 0x00040305, new Item(32, 1, null) },
                { 0x00040503, new Item(33, 1, null) },
                { 0x00040504, new Item(34, 1, null) },
                { 0x00040505, new Item(35, 1, null) },
                { 0x00040008, new Item(4, 1, null) },
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
            return Items.Where(kvp => (kvp.Key >> 16) == Player.Room).OrderBy(kvp => kvp.Key);
        }
    }
}

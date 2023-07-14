using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stealth
{
    public class Item
    {
        private int id;
        public int ID { get => id; }

        private sbyte size;
        public sbyte Size { get => size; }

        private List<Item> children;
        public List<Item> Children { get => children; }

        public Item(int id, sbyte size, List<Item> children)
        {
            this.id = id;
            this.size = size;
            this.children = children;
        }

        public Sprite Sprite { get => Assets.Items[ID]; }
    }
}

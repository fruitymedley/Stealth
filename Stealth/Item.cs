using System;
using System.Collections.Generic;
using System.Text;

namespace Stealth
{
    public class Item
    {
        private int id;
        public int ID { get => id; }

        private sbyte size;
        public sbyte Size { get => size; }

        public Item(int id, sbyte size)
        {
            this.id = id;
            this.size = size;
        }
    }
}

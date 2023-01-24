using System;
using System.Collections.Generic;
using System.Text;

namespace Stealth
{
    public class State
    {
        public Player Player { get; set; }
        public Inventory Inventory { get; set; }
        public Dictionary<long, Item> Items { get; set; }

        public State()
        {
            Player = new Player();
            Inventory = new Inventory();
            Items = new Dictionary<long, Item>();
        }
    }
}

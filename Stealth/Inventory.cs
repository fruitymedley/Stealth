using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stealth
{
    public class Inventory
    {
        private sbyte selection;
        public sbyte Selection { get => selection; set => selection = value; }

        public const int CAPACITY = 8;
        private List<Item> items;
        public List<Item> Items { get => items; set => items = value; }
        public int Size { get => Items.Sum((i) => i.Size); }

        public Inventory()
        {
            items = new List<Item>();
        }
    }

    public partial class Stealth
    {
        public enum PickUpResult { empty, success, full }
        public PickUpResult PickUp()
        {
            // Get item
            Item item = State.GetItem();

            // No item in spot
            if (item == null)
                return PickUpResult.empty;

            // Inventory is full
            if (State.Inventory.Size + item.Size > Inventory.CAPACITY)
                return PickUpResult.full;

            // Put item into inventory
            State.Inventory.Items.Add(item);
            State.RemoveItem();
            return PickUpResult.success;
        }

        public enum PutDownResult { empty, success, full }
        public PutDownResult PutDown()
        {
            // Item in spot
            if (State.GetItem() != null)
                return PutDownResult.full;

            // Nothing in hand
            if (State.Inventory.Selection < 0)
                return PutDownResult.empty;
                
            // Put item on floor
            Item item = State.Inventory.Items[State.Inventory.Selection];
            State.SetItem(item);
            State.Inventory.Items.Remove(item);
            State.Inventory.Selection = -1;
            return PutDownResult.success;
        }
    }
}

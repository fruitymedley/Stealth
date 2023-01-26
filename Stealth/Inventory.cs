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
            // Hash location
            long key = (State.Player.Room << 32) + (State.Player.Y << 16) + State.Player.X;

            // No item in spot
            if (!State.Items.ContainsKey(key))
                return PickUpResult.empty;

            // Inventory is full
            Item item = State.Items[key];
            if (State.Inventory.Size + item.Size > Inventory.CAPACITY)
                return PickUpResult.full;

            // Put item into inventory
            State.Inventory.Items.Add(item);
            State.Items.Remove(key);
            return PickUpResult.success;
        }

        public enum PutDownResult { empty, success, full }
        public PutDownResult PutDown()
        {
            // Hash location
            long key = (State.Player.Room << 32) + (State.Player.Y << 16) + State.Player.X;

            // No item in spot
            if (State.Items.ContainsKey(key))
                return PutDownResult.full;

            // Nothing in hand
            if (State.Inventory.Selection < 0)
                return PutDownResult.empty;
                
            // Put item on floor
            Item item = State.Inventory.Items[State.Inventory.Selection];
            State.Items[key] = item;
            State.Inventory.Items.Remove(item);
            State.Inventory.Selection = -1;
            return PutDownResult.success;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using RSG.Global.Inventory;

namespace Content.Features.StorageModule.Scripts
{
    public class StandardStorage : IStorage
    {
        private GlobalInventoryModel _globalInventory;


        public event Action<Item> OnItemAdded;
        public event Action<Item> OnItemRemoved;

        public StandardStorage(GlobalInventoryModel globalInventory) =>
            _globalInventory = globalInventory;

        public List<Item> GetAllItems() =>
            _globalInventory.Items.ToList();
        
        public float GetMaxWeight()=>_globalInventory.MaxWeight;
        public float GetCurrentWeight() =>_globalInventory.CurrentWeight;

        public int GetItemCount(ItemType type)
        {
            return _globalInventory.Items.Count(item => item.ItemType == type);
        }

        public bool CheckWeightAvailability(Item item)
        {
            return _globalInventory.CurrentWeight+item.Weight<=_globalInventory.MaxWeight;
        }

        public void AddItem(Item item)
        {
            _globalInventory.Add(item);
            OnItemAdded?.Invoke(item);
        }

        public void AddItems(List<Item> items)
        {
            foreach (Item item in items)
                AddItem(item);
        }

        public void RemoveItem(Item item)
        {
            _globalInventory.Remove(item);
            OnItemRemoved?.Invoke(item);
        }

        public void RemoveItems(List<Item> items)
        {
            foreach (Item item in items)
                RemoveItem(item);
        }

        public void RemoveAllItems()
        {
            var items =GetAllItems();
            foreach (Item item in items)
                RemoveItem(item);
        }
    }
}
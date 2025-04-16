using System;
using System.Collections.Generic;

namespace Content.Features.StorageModule.Scripts {
    public interface IStorage {
        public event Action<Item> OnItemAdded;
        public event Action<Item> OnItemRemoved;
        public List<Item> GetAllItems();
        public float GetMaxWeight();
        public float GetCurrentWeight();
        public int GetItemCount(ItemType itemType);
        public bool CheckWeightAvailability(Item item);
        public void AddItem(Item item);
        public void AddItems(List<Item> items);

        public void RemoveItem(Item item);
        public void RemoveItems(List<Item> items);

        public void RemoveAllItems();
        
    }
}
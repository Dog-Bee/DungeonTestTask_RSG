using Content.Features.StorageModule.Scripts;
using UnityEngine;

namespace Content.Features.LootModule.Scripts
{
    public class LootService : ILootService
    {
        private IItemFactory _itemFactory;

        public LootService(IItemFactory itemFactory) =>
            _itemFactory = itemFactory;


        public bool CollectLoot(Loot loot, IStorage storage)
        {
            bool itemCollected = false;

            foreach (ItemType itemType in loot.GetItemsInLoot())
            {
                var item  = _itemFactory.GetItem(itemType);
                Debug.Log($"Collecting loot item: {item} , weight: {item.Weight}, storage  Weight{storage.GetCurrentWeight()}/{storage.GetMaxWeight()},count{storage.GetAllItems().Count}, result {storage.CheckWeightAvailability(item)}");
               var items = storage.GetAllItems();
               foreach (var i in items)
               {
                   Debug.Log(i.Name);
               }
                if (!storage.CheckWeightAvailability(item))
                {
                    continue;
                }
                
                storage.AddItem(_itemFactory.GetItem(itemType));
                itemCollected = true;
            }
            
            return itemCollected;
        }
    }
}
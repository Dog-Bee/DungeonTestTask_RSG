using System.Collections.Generic;
using System.Linq;
using Content.Features.StorageModule.Scripts;
using UnityEngine;

namespace RSG.Global.Inventory
{
    [CreateAssetMenu(fileName = nameof(GlobalInventoryModel),
        menuName = "RSG/Inventory/" + nameof(GlobalInventoryModel))]
    public class GlobalInventoryModel : ScriptableObject
    {
        private float maxWeight = 20;

        private List<Item> items = new();
        private float _currentWeight;
        public IReadOnlyList<Item> Items => items;
        public float CurrentWeight => _currentWeight;
        public float MaxWeight => maxWeight;
        public float CurrentItemWeight => _currentWeight;

        public void Add(Item item)
        {
            if (item == null || items.Contains(item)) return;
            
            _currentWeight += item.Weight;
            items.Add(item);
        }

        public void Remove(Item item)
        {
            if (item == null || !items.Contains(item)) return;
            
            _currentWeight -= item.Weight;
            items.Remove(item);
        }
    }
}
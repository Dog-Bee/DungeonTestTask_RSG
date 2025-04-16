using UnityEngine;
using UnityEngine.UI;

namespace Content.Features.StorageModule.Scripts
{
    public class Item
    {
        public string Name { get; private set; }
        public Sprite Icon { get; private set; }
        public int Price { get; private set; }
        public float Weight { get; private set; }
        public ItemType ItemType { get; private set; }

        public Item(string name, Sprite icon, int price, float weight, ItemType itemType)
        {
            Name = name;
            Icon = icon;
            Price = price;
            Weight = weight;
            ItemType = itemType;
        }

        public Item(ItemConfiguration itemConfiguration)
        {
            Name = itemConfiguration.Name;
            Icon = itemConfiguration.Icon;
            Price = itemConfiguration.Price;
            Weight = itemConfiguration.Weight;
            ItemType = itemConfiguration.ItemType;
        }
    }
}
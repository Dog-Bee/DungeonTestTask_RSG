using System.Collections.Generic;
using System.Linq;
using Content.Features.StorageModule.Scripts;
using UnityEngine;
using Zenject;

namespace Content.Features.ShopModule.Scripts
{
    public class Trader : MonoBehaviour
    {
        [Inject] private PlayerMoneyModel _moneyModel;
        
        public int SellAllItemsFromStorage(IStorage storage)
        {
            int sumOfMoney = 0;
            foreach (int price in storage.GetAllItems().Select(item => item.Price))
                sumOfMoney += price;

            storage.RemoveAllItems();
            
            _moneyModel.AddMoney(sumOfMoney);
            Debug.LogError("Recieved " + sumOfMoney);
            return sumOfMoney;
        }

        public int SellItemFromStorage(Item item, IStorage storage)
        {
            storage.RemoveItem(item);

            return item.Price;
        }

        public int SellItemsFromStorage(List<Item> items, IStorage storage)
        {

            int sumOfMoney = 0;
            foreach (int price in items.Select(item => item.Price))
                sumOfMoney += price;
            
            storage.RemoveItems(items);

            _moneyModel.AddMoney(sumOfMoney);
            Debug.LogError("Recieved " + sumOfMoney);
            return sumOfMoney;
        }
    }
}
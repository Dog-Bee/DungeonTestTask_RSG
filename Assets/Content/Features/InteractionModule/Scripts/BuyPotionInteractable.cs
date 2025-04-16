using Content.Features.AIModule.Scripts.Entity;
using Content.Features.InteractionModule;
using Content.Features.StorageModule.Scripts;
using UnityEngine;
using Zenject;

public class BuyPotionInteractable : MonoBehaviour,IInteractable
{
    [SerializeField] private int cost;

    private IStorage _storage;
    private PlayerMoneyModel _moneyModel;
    private IItemFactory _itemFactory;

    [Inject] public void Construct(IStorage storage, PlayerMoneyModel moneyModel, IItemFactory itemFactory)
    {
        _storage = storage;
        _moneyModel = moneyModel;
        _itemFactory = itemFactory;
    }
    public void Interact(IEntity entity)
    {
        if (!_moneyModel.SpendMoney(cost))
        {
            Debug.Log("Not enough money");
            return;
        }
        
        var potion = _itemFactory.GetItem(ItemType.Potion);
        _storage.AddItem(potion);
    }
}

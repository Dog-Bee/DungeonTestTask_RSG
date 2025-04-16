using System.Linq;
using Content.Features.StorageModule.Scripts;
using UnityEngine;

public class HealPotionService
{
    private readonly IStorage _storage;
    private readonly PlayerHealthModel _playerHealthModel;

    public HealPotionService(IStorage storage, PlayerHealthModel playerHealthModel)
    {
        _storage = storage;
        _playerHealthModel = playerHealthModel;
    }

    public void TryUsePotion()
    {
        var pot = _storage.GetAllItems().FirstOrDefault(item => item.ItemType == ItemType.Potion);

        if (pot == null) return;
        
        _playerHealthModel.Heal(100);
        _storage.RemoveItem(pot);

    }
}

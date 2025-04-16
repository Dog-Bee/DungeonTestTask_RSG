using Content.Features.StorageModule.Scripts;
using UnityEngine;

public class HealPotionPresenter
{
    private readonly IStorage _storage;
    private readonly HealPotionView _view;
    private readonly HealPotionService _service;

    public HealPotionPresenter(IStorage storage, HealPotionView view, HealPotionService service)
    {
        _storage = storage;
        _view = view;
        _service = service;
        
        _view.Button.onClick.AddListener(_service.TryUsePotion);
        _storage.OnItemAdded += _ => Refresh();
        _storage.OnItemRemoved += _ => Refresh();
        
        Refresh();
    }

    private void Refresh()
    {
        _view.SetCount(_storage.GetItemCount(ItemType.Potion));
    }
}

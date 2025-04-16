using System.Linq;
using Content.Features.StorageModule.Scripts;
using UnityEngine;

public class InventoryPresenter
{
    private readonly InventoryUIView _view;
    private readonly IStorage _storage;

    public InventoryPresenter(InventoryUIView view, IStorage storage)
    {
        _view = view;
        _storage = storage;

        _storage.OnItemAdded += _ => Refresh();
        _storage.OnItemRemoved += _ => Refresh();

        Refresh();
    }

    public void Refresh()
    {
        Debug.Log("REFRESH");
        var items = _storage.GetAllItems();
        
        float totalWeight = items.Sum(item => item.Weight);
        
        _view.SetItemsCount(items.Count);
        _view.SetWeight(totalWeight,_storage.GetMaxWeight());
    }
}

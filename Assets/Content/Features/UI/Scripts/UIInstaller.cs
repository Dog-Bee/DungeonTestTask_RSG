using Content.Features.AIModule.Scripts.Entity;
using Content.Features.PrefabSpawner;
using Content.Features.StorageModule.Scripts;
using Global.Scripts.Generated;
using UnityEngine;
using Zenject;

public class UIInstaller : Installer<UIInstaller>
{
    public override void InstallBindings()
    {
        var factory = Container.Resolve<IPrefabsFactory>();
        GameObject uiRoot = factory.Create(Address.Prefabs.UIGeneral);

        var inventoryView = uiRoot.GetComponentInChildren<InventoryUIView>();
        var moneyView = uiRoot.GetComponentInChildren<PlayerMoneyView>();
        var playerHealthView = uiRoot.GetComponentInChildren<PlayerHealthBarView>();
        var healPotionView = uiRoot.GetComponentInChildren<HealPotionView>();

        Container.Bind<InventoryUIView>().FromInstance(inventoryView).AsSingle();
        Container.Bind<PlayerMoneyView>().FromInstance(moneyView).AsSingle();
        Container.Bind<PlayerHealthBarView>().FromInstance(playerHealthView).AsSingle();
        Container.Bind<HealPotionView>().FromInstance(healPotionView).AsSingle();


        Container.Bind<InventoryPresenter>().FromMethod(context =>
        {
            var view = context.Container.Resolve<InventoryUIView>();
            var storage = Container.Resolve<IStorageFactory>().GetStorage(EntityType.Player);
            return new InventoryPresenter(view, storage);
        }).AsSingle().NonLazy();

        Container.Bind<PlayerMoneyPresenter>().FromMethod(context =>
        {
            var view = context.Container.Resolve<PlayerMoneyView>();
            var model = context.Container.Resolve<PlayerMoneyModel>();

            return new PlayerMoneyPresenter(view, model);
        }).AsSingle().NonLazy();

        Container.Bind<PlayerHealthPresenter>().FromMethod(context =>
        {
            var view = context.Container.Resolve<PlayerHealthBarView>();
            var model = context.Container.Resolve<PlayerHealthModel>();
            return new PlayerHealthPresenter(view, model);
        }).AsSingle().NonLazy();

        Container.Bind<HealPotionService>().FromMethod(context =>
        {
            var storage = context.Container.Resolve<IStorage>();
            var model = context.Container.Resolve<PlayerHealthModel>();
            return new HealPotionService(storage, model);
        } );
        
        Container.Bind<HealPotionPresenter>().FromMethod(context =>
        {
            var storage = context.Container.Resolve<IStorage>();
            var view = context.Container.Resolve<HealPotionView>();
            var service = context.Container.Resolve<HealPotionService>();
            
            return new HealPotionPresenter(storage, view, service);
        }).AsSingle().NonLazy();
        
        Container.InstantiateComponent<healInputListener>(uiRoot);
    }
}
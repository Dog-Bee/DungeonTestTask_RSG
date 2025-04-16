using Content.Features.AIModule.Scripts.Entity;
using Core.AssetLoaderModule.Core.Scripts;
using Global.Scripts.Generated;
using RSG.Global.Inventory;
using UnityEngine;
using Zenject;

namespace Content.Features.StorageModule.Scripts
{
    public class StorageModuleInstaller : Installer<StorageModuleInstaller>
    {
        public override void InstallBindings()
        {
            IAddressablesAssetLoaderService addressablesAssetLoaderService =
                Container.Resolve<IAddressablesAssetLoaderService>();
            
            Container.Bind<ItemsConfiguration>()
                .FromScriptableObject(
                    addressablesAssetLoaderService.LoadAsset<ItemsConfiguration>(Address.Configurations
                        .ItemsConfiguration_Default))
                .AsSingle();

            Container.Bind<GlobalInventoryModel>()
                .FromScriptableObject(
                    addressablesAssetLoaderService.LoadAsset<GlobalInventoryModel>(Address.Data
                        .GlobalInventoryModel_Default))
                .AsSingle();
            
            var playerMoneyModel = addressablesAssetLoaderService.LoadAsset<PlayerMoneyModel>(Address.Data.PlayerMoneyModel);
            playerMoneyModel.Reset();
            Container.Bind<PlayerMoneyModel>()
                .FromInstance(playerMoneyModel).AsSingle();
            
            Container.Bind<IItemFactory>()
                .To<ItemFactory>()
                .AsSingle();

            Container.Bind<IStorageFactory>()
                .FromMethod(context => new StorageFactory(context.Container.Resolve<GlobalInventoryModel>()))
                .AsSingle();
            
            Container.Bind<IStorage>()
                .FromMethod(context => context.Container.Resolve<IStorageFactory>().GetStorage(EntityType.Player))
                .AsSingle();
        }
    }
}
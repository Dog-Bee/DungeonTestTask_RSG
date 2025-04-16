using Content.Features.AIModule.Scripts.Entity;
using Core.AssetLoaderModule.Core.Scripts;
using Global.Scripts.Generated;
using Zenject;

namespace Content.Features.PlayerData.Scripts
{
    public class PlayerDataInstaller : Installer<PlayerDataInstaller>
    {
        public override void InstallBindings()
        {
            IAddressablesAssetLoaderService addressablesAssetLoaderService =
                Container.Resolve<IAddressablesAssetLoaderService>();
            var playerData = Container.Resolve<IEntityDataService>().GetEntityData(EntityType.Player);
            var healthModel =
                addressablesAssetLoaderService.LoadAsset<PlayerHealthModel>(Address.Data.PlayerHealthModel);
            healthModel.Reset((int)playerData.StartHealth);
            
           Container.Bind<PlayerHealthModel>().FromInstance(healthModel).AsSingle();
            Container.Bind<PlayerTransformModel>()
                .AsSingle();
        }
    }
}
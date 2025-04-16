using Content.Features.AIModule.Scripts.Entity;
using RSG.Global.Inventory;

namespace Content.Features.StorageModule.Scripts
{
    public class StorageFactory : IStorageFactory
    {
        private readonly GlobalInventoryModel _globalInventory;
        private IStorage _playerStorage;

        public StorageFactory(GlobalInventoryModel globalInventory) =>
            _globalInventory = globalInventory;

        public IStorage GetStorage(EntityType entityType)
        {
            if (entityType == EntityType.Player)
                return _playerStorage ??= new StandardStorage(_globalInventory);

            return new StandardStorage(_globalInventory);
        }
    }
}
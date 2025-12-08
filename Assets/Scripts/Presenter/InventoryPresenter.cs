using Configs;
using Factory;
using Storage.Character;
using Storage.Item;
using Storage.User;
using Utils;
using View;

namespace Presenter
{
    public class InventoryPresenter
    {
        private readonly ItemStorage _storage;
        private readonly InventoryItemFactory _factory;
        
        public InventoryPresenter(ItemStorage storage)
        {
            _storage = storage;
            _factory = new InventoryItemFactory();

            Init();
        }

        private void Init()
        {
            
        }    
    }
}

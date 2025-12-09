using Configs;
using Storage.Item;
using Storage.User;
using View;

namespace Presenter
{
    public class PurchasePresenter
    {
        private UserStorage _userStorage;
        private IPurchasableView _view;
        private ItemStorage _itemStorage;
        private readonly ItemConfig _config;

        public string Id => _config.Id;

        public PurchasePresenter(UserStorage userStorage, ItemStorage itemStorage, ItemConfig config, IPurchasableView view)
        {
            _view = view;
            _userStorage = userStorage;
            _itemStorage = itemStorage;
            _config = config;

            UpdateItem();
        }

        public void Subscribe()
        {
            _view.OnPurchaseClicked += PurchaseItem;
        }

        public void UpdateItem()
        {
            _view.UpdatePriceView(IsItemAvailable());
        }

        public void PurchaseItem()
        {
            if (!IsItemAvailable()) return;

            _userStorage.Decrement(_config.Price);
            _itemStorage.AddItemToInventory(Id);

            _view.UpdatePriceView(IsItemAvailable());
        }

        public bool IsItemAvailable()
        {
            if (_config == null) return false;

            return _userStorage.HasEnoughCurrency(_config.Price);
        }
    }
}

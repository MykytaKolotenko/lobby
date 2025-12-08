using System.Collections.Generic;
using Configs;
using Factory;
using Storage.Item;
using Storage.User;
using View;

namespace Presenter
{
    public class ShopPresenter
    {
        private readonly UserStorage _userStorage;
        private readonly ShopView _view;
        private readonly ShopItemFactory _viewFactory;
        private readonly ItemStorage _itemStorage;
        private readonly PrefabDatabase _prefabDatabase;
        private readonly List<PurchasePresenter> _itemsPresenters = new List<PurchasePresenter>();

        public ShopPresenter(ShopView view, UserStorage userStorage, ItemStorage itemStorage, PrefabDatabase prefabDatabase)
        {
            _prefabDatabase = prefabDatabase;
            _viewFactory = new ShopItemFactory(prefabDatabase.ShopItemPrefab);
            _view = view;
            _itemStorage = itemStorage;
            _userStorage = userStorage;

            CreateItems(_itemStorage.Items);
        }

        public void Subscribe()
        {
            _userStorage.ValueChanged += CurrencyChanged;
        }

        public void Unsubscribe()
        {
            _userStorage.ValueChanged -= CurrencyChanged;
        }

        private void CurrencyChanged()
        {
            foreach (PurchasePresenter purchasePresenter in _itemsPresenters)
            {
                purchasePresenter.UpdateItem();
            }
        }

        private void CreateItems(List<ItemConfig> items)
        {
            foreach (ItemConfig itemConfig in items)
            {
                CreateItem(itemConfig);
            }
        }

        private void CreateItem(ItemConfig itemConfig)
        {
            ShopItemView shopItemView = _viewFactory.Create(itemConfig, _view.parent);

            PurchasePresenter shopItemPresenter = new PurchasePresenter(_userStorage, _itemStorage, itemConfig, shopItemView);
            _itemsPresenters.Add(shopItemPresenter);

            shopItemPresenter.Subscribe();
        }
    }
}

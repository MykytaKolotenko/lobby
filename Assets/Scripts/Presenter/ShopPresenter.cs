using System.Collections.Generic;
using System.Linq;
using Configs;
using Factory;
using UnityEngine;
using View;

namespace Presenter
{
    public class ShopPresenter
    {
        private ShopView _view;
        private ShopItemFactory _viewFactory;
        private ItemDatabase _config;

        private readonly List<ShopItemPresenter> _shopItems = new List<ShopItemPresenter>();

        public ShopPresenter(ShopView view, ItemDatabase config)
        {
            _viewFactory = new ShopItemFactory();
            _view = view;
            _config = config;

            Init();
        }

        public void Dispose()
        {
            _shopItems.ToList().ForEach(DestroyItem);
        }

        private void Init()
        {
            CreateItems(_config.items);
        }

        private void CreateItems(ItemConfig[] items)
        {
            foreach (ItemConfig itemConfig in items)
            {
                CreateItem(itemConfig);
            }
        }

        private void CreateItem(ItemConfig itemConfig)
        {
            ShopItemView shopItemView = _viewFactory.Create(itemConfig, _view.parent);

            ShopItemPresenter shopItemPresenter = new ShopItemPresenter(shopItemView, itemConfig);
            _shopItems.Add(shopItemPresenter);

            SetItemAvailability(shopItemPresenter);

            shopItemPresenter.ItemClicked += OnItemClicked;
        }

        private void DestroyItem(ShopItemPresenter presenter)
        {
            presenter.Dispose();
            _shopItems.Remove(presenter);
            presenter.ItemClicked -= OnItemClicked;
        }

        private void OnItemClicked(string obj)
        {
            Debug.Log($"Item clicked: {obj}");
        }

        private void SetItemAvailability(ShopItemPresenter presenter)
        {
        }
    }
}

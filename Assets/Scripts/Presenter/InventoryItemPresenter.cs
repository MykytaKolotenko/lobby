using System;
using Configs;
using Storage.Item;
using UnityEngine;
using View;

namespace Presenter
{
    public class InventoryItemPresenter
    {
        private InventoryItemView _view;

        public ItemConfig _config;

        public string PresenterId => _view.GetInstanceID().ToString();
        public string ItemId => _config.Id;
        public EItemType ItemType => _config.Type;

        public event Action<InventoryItemPresenter> ItemClicked;

        public InventoryItemPresenter(InventoryItemView view, ItemConfig config)
        {
            _view = view;
            _config = config;

            _view.Init(config);
        }

        public void Dispose()
        {
            _view.Dispose();
        }

        public void Subscribe()
        {
            _view.ItemClicked += OnItemClicked;
        }

        public void Unsubscribe()
        {
            _view.ItemClicked -= OnItemClicked;
        }

        public void SetParent(RectTransform transform)
        {
            _view.SetParent(transform);
        }

        private void OnItemClicked()
        {
            ItemClicked?.Invoke(this);
        }
    }
}

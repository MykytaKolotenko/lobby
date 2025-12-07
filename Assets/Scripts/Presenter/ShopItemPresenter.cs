using System;
using Configs;
using View;

namespace Presenter
{
    public class ShopItemPresenter
    {
        private readonly ShopItemView _view;
        private readonly ItemConfig _config;

        public string Id => _config.Id;

        public ShopItemPresenter(ShopItemView view, ItemConfig config)
        {
            _view = view;
            _config = config;
        }

        public event Action<string> ItemClicked
        {
            add => _view.ItemClicked += value;
            remove => _view.ItemClicked -= value;
        }

        public void Dispose()
        {
            _view.Dispose();
        }
    }
}

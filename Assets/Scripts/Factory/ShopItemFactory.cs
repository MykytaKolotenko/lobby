using Configs;
using UnityEngine;
using View;

namespace Factory
{
    public class ShopItemFactory : ViewFactory<ShopItemView, ItemConfig>
    {
        public new ShopItemView Create(ItemConfig config, Transform parent)
        {
            ShopItemView shopItemView = base.Create(config, parent);

            shopItemView.Init(config);

            return shopItemView;
        }
    }
}

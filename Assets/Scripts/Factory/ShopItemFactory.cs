using Configs;
using UnityEngine;
using View;

namespace Factory
{
    public class ShopItemFactory : ViewFactory<ShopItemView, ItemConfig>
    {
        public ShopItemFactory(GameObject prefab) : base(prefab)
        {
        }

        public new ShopItemView Create(ItemConfig config, Transform parent)
        {
            ShopItemView shopItemView = base.Create(parent);

            shopItemView.Init(config);

            return shopItemView;
        }
    }
}

using Configs;
using UnityEngine;
using View;

namespace Factory
{
    public class InventoryItemFactory : ViewFactory<InventoryItemView>
    {
        public InventoryItemFactory(GameObject prefab) : base(prefab)
        {
        }

        public InventoryItemView Create(ItemConfig config, Transform parent)
        {
            InventoryItemView shopItemView = base.Create(parent);

            shopItemView.Init(config);

            return shopItemView;
        }
    }
}

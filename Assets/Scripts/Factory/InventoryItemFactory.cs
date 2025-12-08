using Configs;
using UnityEngine;
using View.Inventory;

namespace Factory
{
    public class InventoryItemFactory: ViewFactory<InventoryItemView, ItemConfig>
    {
        public new InventoryItemView Create(ItemConfig config, Transform parent)
        {
            InventoryItemView shopItemView = base.Create(config, parent);

            shopItemView.Init(config);

            return shopItemView;
        }
    }
}
using System.Collections.Generic;
using Presenter;
using Storage.Item;
using UnityEngine;

namespace View.Inventory
{
    public class InventoryView : MonoBehaviour
    {
        public RectTransform inventoryParent;
        public List<EquippedItemsPos> equippedItemsPos;

        public RectTransform GetPosByType(EItemType type)
        {
            return equippedItemsPos.Find(pos => pos.Type == type).Parent;
        }
    }
}

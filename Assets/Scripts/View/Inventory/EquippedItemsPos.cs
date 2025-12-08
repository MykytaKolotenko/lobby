using System;
using Storage.Item;
using UnityEngine;

namespace View
{
    [Serializable]
    public struct EquippedItemsPos
    {
        public EItemType Type;
        public RectTransform Parent;
    }
}

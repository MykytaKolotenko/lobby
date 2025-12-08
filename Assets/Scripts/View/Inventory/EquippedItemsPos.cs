using System;
using Storage.Item;
using UnityEngine;

namespace Presenter
{
    [Serializable]
    public struct EquippedItemsPos
    {
        public EItemType Type;
        public RectTransform Parent;
    }
}

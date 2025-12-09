using System.Collections.Generic;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "ItemDatabase", menuName = "Configs/ItemDatabase")]
    public class ItemDatabase : ScriptableObject
    {
        public List<ItemConfig> items;
    }
}

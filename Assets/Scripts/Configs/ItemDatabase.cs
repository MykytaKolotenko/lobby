using System.Linq;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "ItemDatabase", menuName = "Configs/ItemDatabase")]
    public class ItemDatabase : ScriptableObject
    {
        public ItemConfig[] items;

        public ItemConfig GetItemById(string id)
        {
            return items.FirstOrDefault(config => config.Id == id);
        }
    }
}

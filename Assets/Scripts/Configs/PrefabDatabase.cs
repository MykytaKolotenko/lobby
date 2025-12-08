using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "PrefabDatabase", menuName = "Configs/PrefabDatabase", order = 1)]
    public class PrefabDatabase : ScriptableObject
    {
        [field: SerializeField] public GameObject ShopItemPrefab { get; private set; }
        [field: SerializeField] public GameObject InventoryItemPrefab { get; private set; }
    }
}

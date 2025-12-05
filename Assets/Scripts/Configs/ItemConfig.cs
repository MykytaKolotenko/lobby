using System;
using Storage.Character.Data;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "ItemConfig", menuName = "Configs/ItemConfig", order = 0)]
    public class ItemConfig : ScriptableObject
    {
        public string Id { get; private set; }

        [field: SerializeField] public GameObject ItemPrefab { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public string Description { get; private set; }
        [field: SerializeField] public int Price { get; private set; }
        [field: SerializeField] public CharacterParams Params { get; private set; }

        private void OnValidate()
        {
            if (string.IsNullOrEmpty(Id))
            {
                Id = Guid.NewGuid().ToString();
            }
        }
    }
}

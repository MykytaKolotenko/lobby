using Core;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "ConfigDatabase", menuName = "Configs/ConfigDatabase")]
    public class MainConfig : ScriptableObject
    {
        [field: SerializeField] public int Currency { get; private set; }
        [field: SerializeField] public EMenuState InitState { get; private set; }
        [field: SerializeField] public Vector2Int TapDelay { get; private set; }

        public CharacterStatsConfig characterStatsConfig;
        public ParamsConverterConfig paramsConverterConfig;
        public ItemDatabase itemDatabase;
        public PrefabDatabase prefabDatabase;
    }
}

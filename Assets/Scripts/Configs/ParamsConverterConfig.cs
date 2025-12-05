using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "ParamsConverterConfig", menuName = "Configs/ParamsConverterConfig")]
    public class ParamsConverterConfig : ScriptableObject
    {
        [field: SerializeField] public float HealthMultiplier { get; private set; }
        [field: SerializeField] public float ArmorMultiplier { get; private set; }
        [field: SerializeField] public float DamageMultiplier { get; private set; }
    }
}

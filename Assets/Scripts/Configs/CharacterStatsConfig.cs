using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "CharacterStatsConfig", menuName = "Configs/CharacterStatsConfig")]
    public class CharacterStatsConfig : ScriptableObject
    {
        [field: SerializeField] public int Health { get; private set; }
        [field: SerializeField] public int Armor { get; private set; }
        [field: SerializeField] public int Damage { get; private set; }
    }
}

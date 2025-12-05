using System;
using Configs;
using UnityEngine;

namespace Storage.Character.Data
{
    [Serializable]
    public struct CharacterParams
    {
        [field: SerializeField] public int Health { get; private set; }
        [field: SerializeField] public int Armor { get; private set; }
        [field: SerializeField] public int Damage { get; private set; }

        public CharacterParams(int health, int armor, int damage)
        {
            Health = health;
            Armor = armor;
            Damage = damage;
        }

        public static CharacterParams ConvertFromConfig(CharacterStatsConfig config)
        {
            return new CharacterParams(config.Health, config.Armor, config.Damage);
        }
    }
}

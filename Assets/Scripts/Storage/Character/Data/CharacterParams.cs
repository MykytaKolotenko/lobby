using System;
using Configs;

namespace Storage.Character.Data
{
    [Serializable]
    public struct CharacterParams
    {
        public int Health;
        public int Armor;
        public int Damage;

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

        public readonly CharacterParams Clone()
        {
            return new CharacterParams(Health, Armor, Damage);
        }
    }
}

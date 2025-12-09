using System;
using System.Collections.Generic;
using Configs;
using Storage.Character.Data;

namespace Utils
{
    public static class CoreGameUtils
    {
        public static int EvaluateGoldFromParams(CharacterParams characterParams, ParamsConverterConfig config)
        {
            return
                EvaluateParam(characterParams.Armor, config.ArmorMultiplier)
                + EvaluateParam(characterParams.Damage, config.DamageMultiplier)
                + EvaluateParam(characterParams.Health, config.HealthMultiplier);
        }

        private static int EvaluateParam(int param, float multiplier)
        {
            return (int)Math.Round(param * multiplier);
        }

        public static CharacterParams EvaluateParams(List<ItemConfig> purchasedItems, CharacterParams baseParams)
        {
            CharacterParams newParams = baseParams.Clone();

            foreach (ItemConfig itemConfig in purchasedItems)
            {
                newParams.Armor += itemConfig.Params.Armor;
                newParams.Damage += itemConfig.Params.Damage;
                newParams.Health += itemConfig.Params.Health;
            }

            return newParams;
        }
    }
}

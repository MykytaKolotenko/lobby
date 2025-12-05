using System;
using Configs;
using Storage.Character.Data;

namespace Utils
{
    public static class CurrencyUtils
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
    }
}

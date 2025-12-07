using System;
using Configs;
using Storage.Character.Data;

namespace Storage.Character
{
    public class CharacterStorage : ICharacterParams
    {
        private CharactersParamContainer _characterParam;

        public event Action<CharacterParams> OnParamsChanged;

        public CharacterStorage(CharacterStatsConfig characterParamsConfig)
        {
            _characterParam = new CharactersParamContainer(CharacterParams.ConvertFromConfig(characterParamsConfig));
        }

        private void UpdateParams(ItemConfig[] purchasedItems)
        {
            CharacterParams newParams = _characterParam.BaseParams.Clone();

            foreach (ItemConfig itemConfig in purchasedItems)
            {
                newParams.Armor += itemConfig.Params.Armor;
                newParams.Damage += itemConfig.Params.Damage;
                newParams.Health += itemConfig.Params.Health;
            }

            _characterParam.CurrentParams = newParams;

            OnParamsChanged?.Invoke(CurrentCharacterParams);
        }

        public CharacterParams CurrentCharacterParams => _characterParam.CurrentParams;
    }
}

using System;
using Configs;
using Storage.Character.Data;

namespace Storage.Character
{
    public class CharacterStorage : ICharacterParams
    {
        private CharactersParamContainer _characterParam;
        public CharacterParams CurrentParams => _characterParam.CurrentParams;
        public CharacterParams BaseParams => _characterParam.BaseParams;

        public event Action<CharacterParams> OnParamsChanged;

        public CharacterStorage(CharacterStatsConfig characterParamsConfig)
        {
            _characterParam = new CharactersParamContainer(CharacterParams.ConvertFromConfig(characterParamsConfig));
        }

        public void UpdateParams(CharacterParams currentParams)
        {
            _characterParam.CurrentParams = currentParams;

            OnParamsChanged?.Invoke(CurrentParams);
        }
    }
}

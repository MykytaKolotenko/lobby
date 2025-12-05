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

        public void SetCurrentParams(CharacterParams newParams)
        {
            _characterParam.CurrentParams = newParams;
        }

        public CharacterParams CurrentCharacterParams => _characterParam.CurrentParams;
    }
}

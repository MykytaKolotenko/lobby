using System;
using Storage.Character.Data;

namespace Storage.Character
{
    public interface ICharacterParams
    {
        public CharacterParams CurrentCharacterParams { get; }

        public event Action<CharacterParams> OnParamsChanged;
    }
}

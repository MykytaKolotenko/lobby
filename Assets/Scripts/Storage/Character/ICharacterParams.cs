using System;
using Storage.Character.Data;

namespace Storage.Character
{
    public interface ICharacterParams
    {
        public CharacterParams CurrentParams { get; }
        public event Action<CharacterParams> OnParamsChanged;
    }
}

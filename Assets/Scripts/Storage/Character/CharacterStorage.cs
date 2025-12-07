using System;
using System.Collections.Generic;
using Configs;
using Storage.Character.Data;

namespace Storage.Character
{
    public class CharacterStorage : ICharacterParams
    {
        private CharactersParamContainer _characterParam;
        private readonly List<string> _purchasedItems = new List<string>();

        private ItemDatabase _itemDatabase;

        public event Action<CharacterParams> OnParamsChanged;

        public CharacterStorage(CharacterStatsConfig characterParamsConfig, ItemDatabase itemDatabase)
        {
            _characterParam = new CharactersParamContainer(CharacterParams.ConvertFromConfig(characterParamsConfig));
            _itemDatabase = itemDatabase;
        }

        public void AddItem(string itemId)
        {
            if (_purchasedItems.Contains(itemId)) return;
            _purchasedItems.Add(itemId);
        }

        private void UpdateParams()
        {
            CharacterParams newParams = _characterParam.BaseParams.Clone();

            foreach (string itemId in _purchasedItems)
            {
                ItemConfig item = _itemDatabase.GetItemById(itemId);

                newParams.Armor += item.Params.Armor;
                newParams.Damage += item.Params.Damage;
                newParams.Health += item.Params.Health;
            }

            _characterParam.CurrentParams = newParams;

            OnParamsChanged?.Invoke(CurrentCharacterParams);
        }

        public CharacterParams CurrentCharacterParams => _characterParam.CurrentParams;
    }
}

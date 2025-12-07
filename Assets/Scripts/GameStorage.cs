using Configs;
using Storage.Character;
using Storage.Item;
using Storage.User;

namespace DefaultNamespace
{
    public class GameStorage
    {
        private GameRoot _gameRoot;

        public CharacterStorage CharacterStorage { get; private set; }
        public UserStorage UserStorage { get; private set; }
        public ItemStorage ItemStorage { get; private set; }

        private MainConfig MainConfig => _gameRoot.mainConfig;

        public GameStorage(GameRoot gameRoot)
        {
            _gameRoot = gameRoot;

            CharacterStorage = new CharacterStorage(MainConfig.characterStatsConfig);
            UserStorage = new UserStorage(MainConfig.Currency);
            ItemStorage = new ItemStorage(MainConfig.itemDatabase);
        }
    }
}

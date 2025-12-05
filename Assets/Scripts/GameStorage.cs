using Storage.Character;
using Storage.User;

namespace DefaultNamespace
{
    public class GameStorage
    {
        private GameRoot _gameRoot;

        public CharacterStorage CharacterStorage { get; private set; }
        public UserStorage UserStorage { get; private set; }

        public GameStorage(GameRoot gameRoot)
        {
            _gameRoot = gameRoot;

            CharacterStorage = new CharacterStorage(_gameRoot.mainConfig.characterStatsConfig);
            UserStorage = new UserStorage(_gameRoot.mainConfig.Currency);
        }
    }
}

using Storage.Character;
using Storage.User;

namespace DefaultNamespace
{
    public class StorageBase
    {
        private GameController _gameController;

        public CharacterStorage CharacterStorage { get; private set; }
        public UserStorage UserStorage { get; private set; }

        public StorageBase(GameController gameController)
        {
            _gameController = gameController;

            CharacterStorage = new CharacterStorage(_gameController.mainConfig.characterStatsConfig);
            UserStorage = new UserStorage(_gameController.mainConfig.Currency);
        }
    }
}

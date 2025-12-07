using Configs;
using Storage.Character;
using Storage.User;
using Utils;
using View;

namespace Presenter
{
    public class AttackButtonPresenter
    {
        private ButtonView _view;
        private UserStorage _userStorage;
        private CharacterStorage _characterStorage;
        private ParamsConverterConfig _config;

        public AttackButtonPresenter(
            ButtonView view,
            UserStorage userStorage,
            CharacterStorage characterStorage,
            ParamsConverterConfig paramsConverterConfig
        )
        {
            _view = view;
            _userStorage = userStorage;
            _characterStorage = characterStorage;
            _config = paramsConverterConfig;
        }

        public void Subscribe()
        {
            _view.ButtonClicked += OnButtonClicked;
        }

        public void Unsubscribe()
        {
            _view.ButtonClicked -= OnButtonClicked;
        }

        private void OnButtonClicked()
        {
            int currencyDelta = CurrencyUtils.EvaluateGoldFromParams(_characterStorage.CurrentCharacterParams, _config);

            if (currencyDelta > 0)
            {
                _userStorage.Increment(currencyDelta);
            }
        }
    }
}
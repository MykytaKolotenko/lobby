using Configs;
using Storage.Character;
using Storage.User;
using Utils;
using View;

namespace Presenter
{
    public class AttackButtonPresenter
    {
        private AttackButtonView _view;
        private UserStorage _userStorage;
        private CharacterStorage _characterStorage;
        private ParamsConverterConfig _config;

        public AttackButtonPresenter(
            AttackButtonView view,
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
            _view.AttackClicked += OnAttackClicked;
        }

        public void Unsubscribe()
        {
            _view.AttackClicked -= OnAttackClicked;
        }

        private void OnAttackClicked()
        {
            int currencyDelta = CurrencyUtils.EvaluateGoldFromParams(_characterStorage.CurrentCharacterParams, _config);

            if (currencyDelta > 0)
            {
                _userStorage.Increment(currencyDelta);
            }
        }
    }
}

using System.Threading.Tasks;
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
        private CharacterView _characterView;
        private UserStorage _userStorage;
        private CharacterStorage _characterStorage;
        private MainConfig _mainConfig;

        public AttackButtonPresenter(
            ButtonView view,
            CharacterView characterView,
            UserStorage userStorage,
            CharacterStorage characterStorage,
            MainConfig mainConfig
        )
        {
            _characterView = characterView;
            _view = view;
            _userStorage = userStorage;
            _characterStorage = characterStorage;
            _mainConfig = mainConfig;
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
            int currencyDelta = CoreGameUtils.EvaluateGoldFromParams(_characterStorage.CurrentParams, _mainConfig.paramsConverterConfig);

            if (currencyDelta > 0)
            {
                _userStorage.Increment(currencyDelta);
            }

            _view.Interactable = false;
            _characterView.AttackAnimation();

            ActivateButtonAsync();
        }

        private async void ActivateButtonAsync()
        {
            await Task.Delay(MathUtils.RandomNumber(_mainConfig.TapDelay.x, _mainConfig.TapDelay.y));
            _view.Interactable = true;
        }
    }
}

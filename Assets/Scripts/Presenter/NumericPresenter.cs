using Storage.User;
using View;

namespace Presenter
{
    public class NumericPresenter
    {
        private INumericLabel _view;
        private IUserStorage _userStorage;

        public NumericPresenter(IUserStorage userStorage, INumericLabel view)
        {
            _userStorage = userStorage;
            _view = view;

            SetCurrency(_userStorage.Value);
        }

        public void Subscribe()
        {
            _userStorage.OnValueChanged += SetCurrency;
        }

        public void Unsubscribe()
        {
            _userStorage.OnValueChanged -= SetCurrency;
        }

        private void SetCurrency(int value)
        {
            _view.SetCurrency(_userStorage.Value);
        }
    }
}

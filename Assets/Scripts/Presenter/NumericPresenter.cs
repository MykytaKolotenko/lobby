using Storage.User;
using View;

namespace Presenter
{
    public class NumericPresenter
    {
        private INumericLabel _view;
        private IUserStorage _userStorage;

        public NumericPresenter(INumericLabel view, IUserStorage userStorage)
        {
            _userStorage = userStorage;
            _view = view;

            SetCurrency();
        }

        public void Subscribe()
        {
            _userStorage.ValueChanged += SetCurrency;
        }

        public void Unsubscribe()
        {
            _userStorage.ValueChanged -= SetCurrency;
        }

        private void SetCurrency()
        {
            _view.SetCurrency(_userStorage.Value);
        }
    }
}

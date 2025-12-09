using Storage.User;
using View;

namespace Presenter
{
    public class NumericPresenter
    {
        private INumericLabelView _view;
        private IUserStorage _userStorage;

        public NumericPresenter(INumericLabelView view, IUserStorage userStorage)
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

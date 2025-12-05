using Storage.User;
using UnityEngine;

namespace Currency
{
    public class CurrencyPresenter : MonoBehaviour
    {
        [SerializeField] private CurrencyView view;

        private IUserStorage _userStorage;

        public void Init(IUserStorage userStorage)
        {
            _userStorage = userStorage;

            SetCurrency(_userStorage.Currency);
        }

        private void Start()
        {
            _userStorage.OnCurrencyChanged += SetCurrency;
        }

        private void OnDestroy()
        {
            _userStorage.OnCurrencyChanged -= SetCurrency;
        }

        private void SetCurrency(int value)
        {
            view.SetCurrency(_userStorage.Currency);
        }
    }
}

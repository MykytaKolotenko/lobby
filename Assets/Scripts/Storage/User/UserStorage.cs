using System;

namespace Storage.User
{
    public class UserStorage : IUserStorage
    {
        private int _currency;

        public event Action<int> ValueChanged;

        public UserStorage(int currency)
        {
            _currency = currency;
        }

        public void Increment(int value)
        {
            _currency += value;
            OnValueChanged();
        }

        public void Decrement(int value)
        {
            _currency -= value;
            OnValueChanged();
        }

        public bool IsPurchaseAvailable(int value)
        {
            return _currency >= value;
        }

        public bool TryPurchase(int value)
        {
            if (!IsPurchaseAvailable(value)) return false;

            _currency -= value;
            OnValueChanged();

            return true;
        }

        public int Value => _currency;

        private void OnValueChanged()
        {
            ValueChanged?.Invoke(_currency);
        }
    }
}

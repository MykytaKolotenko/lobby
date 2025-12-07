using System;

namespace Storage.User
{
    public class UserStorage : IUserStorage
    {
        private int _currency;

        public event Action ValueChanged;

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

        public bool HasEnoughCurrency(int value)
        {
            return _currency >= value;
        }

        public int Value => _currency;

        private void OnValueChanged()
        {
            ValueChanged?.Invoke();
        }
    }
}

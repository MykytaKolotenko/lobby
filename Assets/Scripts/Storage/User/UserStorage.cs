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

        public int Value => _currency;

        private void OnValueChanged()
        {
            ValueChanged?.Invoke(_currency);
        }
    }
}
